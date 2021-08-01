using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using Planten2021.Data;
using Planten2021.Domain.Models;
using PlantenApplicatie.HelpClasses.Login.classes;
using PlantenApplicatie.HelpClasses.Login.enums;
using PlantenApplicatie.Services.Interfaces;
using PlantenApplicatie.View;
using PlantenApplicatie.View.Home;
using PlantenApplicatie.Viewmodel;


namespace PlantenApplicatie.Services
{
    public class LoginUserService : IloginUserService, INotifyPropertyChanged
    {  
        //gebruiker verklaren  om te gebruiken in de logica
        private Gebruiker _gebruiker { get; set; }

        //dao verklaren om data op te vragen en te setten in de databank
        private DAO _dao;

        //iocc container om de mainwindow te verkrijgen
        private SimpleIoc iocc = SimpleIoc.Default;


        public LoginUserService()
        {
            this._dao = DAO.Instance();
        }
        #region Login Region
        //globale gebruiker om te gebruiken in de service
        public Gebruiker gebruiker = new Gebruiker();
        //zorgen dat de INotifyPropertyChanged geimplementeerd wordt
        public event PropertyChangedEventHandler PropertyChanged;

        //visibility check

        public void ConfigureRoll(Gebruiker gebruiker)
        {
            var iocc = SimpleIoc.Default;
            var mainWindow = iocc.GetInstance<MainWindow>();

            switch (gebruiker.Rol)
            {
                case "student":

                    MessageBox.Show("dit is een student en mag de naamknop bv niet zien.");
                    
                    break;

                case "docent":
                    break;

                case "oud-student":
                    mainWindow.btnBloei.Visibility = Visibility.Hidden;
                    mainWindow.btnExporteeralle.Visibility = Visibility.Hidden;
                    mainWindow.btnExporteergeselecteerd.Visibility = Visibility.Hidden;
                    mainWindow.btnExporteergeselecteerd.Visibility = Visibility.Hidden;
                    mainWindow.btnHabitat.Visibility = Visibility.Hidden;
                    mainWindow.btnGroei.Visibility = Visibility.Hidden;
                    mainWindow.btnLijst.Visibility = Visibility.Hidden;
                    mainWindow.btnLopendVerzoek.Visibility = Visibility.Hidden;
                    mainWindow.btnSorteer.Visibility = Visibility.Hidden;
                    mainWindow.btnUiterlijk.Visibility = Visibility.Hidden;
                    mainWindow.btnVerzorging.Visibility = Visibility.Hidden;

                    break;

            }
        }
        
        //het eigenlijke loginsysteem
        public LoginResult CheckCredentials(string userNameInput, string passwordInput)
        {   //Nieuw loginResult om te gebruiken, status op NotLoggedIn zetten
            var loginResult = new LoginResult() {loginStatus = LoginStatus.NotLoggedIn};
           
            //check if email is valid email
            if (userNameInput != null)
            {   //gebruiker zoeken in de databank
                gebruiker = _dao.GetGebruikerWithEmail(userNameInput);
                loginResult.gebruiker = gebruiker;
            }
            else
            {//indien geen geldig emailadress, errorMessage opvullen
                loginResult.errorMessage = "Dit is geen geldig Vives emailadres.";
            }

            //omzetten van het ingegeven passwoord naar een gehashed passwoord
            var passwordBytes = Encoding.ASCII.GetBytes(passwordInput);
            var md5Hasher = new MD5CryptoServiceProvider();
            var passwordHashed = md5Hasher.ComputeHash(passwordBytes);

            if (gebruiker != null)
            {
                _gebruiker = gebruiker;
                loginResult.gebruiker = gebruiker;
                //passwoord controle
                if (gebruiker.HashPaswoord != null && passwordHashed.SequenceEqual(gebruiker.HashPaswoord))
                {   //indien true status naar LoggedIn zetten
                    loginResult.loginStatus = LoginStatus.LoggedIn;
                }
                else
                {   //indien false errorMessage opvullen
                    loginResult.errorMessage += "\r\n"+"Het ingegeven wachtwoord is niet juist, probeer opnieuw";
                }
            }
            else
            {   // als de gebruiker niet gevonden wordt, errorMessage invullen
                loginResult.errorMessage = $"Er is geen account gevonden voor {userNameInput} "+"\r\n"+" gelieve eerst te registreren";
            }
            return loginResult;
        }

        //functie om naam weer te geven in loginWindow
        public string LoggedInMessage()
        {
            string message= String.Empty;
            if (_gebruiker != null)
            {
                message = $"ingelogd als: {_gebruiker.Voornaam} {_gebruiker.Achternaam} met als rol {gebruiker.Rol}";
                return message;
            }
            return message;
        }

        #endregion

        #region Register Region

        public string CheckRol(string emailAdresInput)
        {
            var rolInput = "";
            if (emailAdresInput != null && emailAdresInput.Contains(".vives.be") &&
                emailAdresInput.Contains("@") & !emailAdresInput.Contains("student")
                //checken als het email adres al bestaat of niet.
                && _dao.CheckIfEmailAlreadyExists(emailAdresInput))

            {
                rolInput = "docent";
            }
            else if (emailAdresInput != null && emailAdresInput.Contains(".vives.be") &&
                emailAdresInput.Contains("@") &&emailAdresInput.Contains("student")
                //checken als het email adres al bestaat of niet.
                && _dao.CheckIfEmailAlreadyExists(emailAdresInput))

            {
                rolInput = "student";
            }
            else
            {
                if (checkIfInlist(emailAdresInput))
                {
                    rolInput = "oud-student";
                }
                else
                {
                    MessageBox.Show($"{emailAdresInput} is nog niet geregistreerd in de database als oudstudent");
                }
            }

            return rolInput;
        }

        private List<string> adressList = new List<string>
        {
            "kdemits@hotmail.com",
            "Christoph@hotmail.com"
        };
        public bool checkIfInlist(string email)
        {
            var boolean = false;
            foreach (var emailcheck in adressList)
            {
                if (email == emailcheck )
                {
                    boolean = true;
                    break;
                }
                else
                {
                    boolean = false;
                }

            }

            return boolean;
        }

        public string RegisterButton(string vivesNrInput, string lastNameInput, 
                                   string firstNameInput, string emailAdresInput,
                                   string passwordInput, string passwordRepeatInput, string rolInput)
        {
            //errorMessage die gereturned wordt om de gebruiker te waarschuwen wat er aan de hand is
            string Message = string.Empty;
            //checken of alle velden ingevuld zijn
            if (vivesNrInput != null &&
                firstNameInput != null &&
                lastNameInput != null &&
                emailAdresInput != null &&
                passwordInput != null &&
                passwordRepeatInput != null)

            {   //checken als het emailadres een geldig vives email is.
                if (emailAdresInput != null && _dao.CheckIfEmailAlreadyExists(emailAdresInput))
                {
                    rolInput = CheckRol(emailAdresInput);

                    //checken als het herhaalde wachtwoord klopt of niet.
                    if (passwordInput == passwordRepeatInput)
                    {   //gebruiker registreren.
                        _dao.RegisterUser(vivesNrInput, firstNameInput, lastNameInput, rolInput, emailAdresInput, passwordInput);
                        Message = $"{firstNameInput}, je bent succevol geregistreerd,"+"\r\n"+$" uw gebruikersnaam is {emailAdresInput}." + 
                                       "\r\n" + $" {firstNameInput}, je kan dit venster wegklikken en inloggen.";
                        LoginWindow loginWindow = new LoginWindow();
                        loginWindow.Show();
                    }//foutafhandeling
                    else
                    {
                        Message = "zorg dat de wachtwoorden overeen komen.";
                    }
                }
                else
                {
                    Message = $"{emailAdresInput} is geen geldig emailadres, "+"\r\n"+" of het eamiladres is al in gebruik.";
                }
            }
            else
            {
                Message = "zorg dat alle velden ingevuld zijn";
            }//Message terugsturen om te binden aan een label in de viewModel.
            return Message;
        }

        #endregion
    }
    
}