using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
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
    {   //gebruiker verklaren  om te gebruiken in de logica
        private Gebruiker _gebruiker { get; set; }
        //dao verklaren om data op te vragen en te setten in de databank
        private DAO _dao;

        //checken of emailadres en rol aanwezig zijn in de tabel gebruiker aanwezig is
        private List<string> emailAdresOudStudenten = new List<string>();
        
        public LoginUserService()
        {
            this._dao = DAO.Instance();
        }
        #region Login Region
        //globale gebruiker om te gebruiken in de service
        public Gebruiker gebruiker = new Gebruiker();
        //zorgen dat de INotifyPropertyChanged geimplementeerd wordt
        public event PropertyChangedEventHandler PropertyChanged;
        
        //het eigenlijke loginsysteem
        public LoginResult CheckCredentials(string userNameInput, string passwordInput)
        {   //Nieuw loginResult om te gebruiken, status op NotLoggedIn zetten
            var loginResult = new LoginResult() {loginStatus = LoginStatus.NotLoggedIn};
           //check if email is valid email
            

            if (userNameInput != null && userNameInput.Contains("@student.vives.be"))
            {   //gebruiker zoeken in de databank

                gebruiker = _dao.GetGebruikerWithEmail(userNameInput);
                loginResult.gebruiker = gebruiker;
               
            }

            else if (userNameInput != null && userNameInput.Contains("@vives.be"))
            {
                 gebruiker = _dao.GetGebruikerWithEmail(userNameInput);
                loginResult.gebruiker = gebruiker;
                

            }

            else if (userNameInput != null && emailAdresOudStudenten.Contains(userNameInput))
            {
                gebruiker = _dao.GetGebruikerWithEmail(userNameInput);
                loginResult.gebruiker = gebruiker;
                
            }
            else
            {//indien geen geldig emailadress, errorMessage opvullen
                loginResult.errorMessage = "Dit is geen geldig emailadres.";
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

        public string CheckRol(string emailAdres)
        {
            var rolInput = "";

            if (emailAdres.Contains("@student.vives.be"))
            {
                rolInput = "Student";
            }

            else if (emailAdres.Contains("@vives.be"))
            {
                rolInput = "Docent";
            }

            else  
            {
                if ((CheckListOudstudenten(emailAdres)))
                {
                    rolInput = "Oud-Student";
                }

                else
                {
                    MessageBox.Show($"{emailAdres} is nog niet geregistreerd in de database als oudstudent");
                }

            }

            return rolInput;
        }

        public void RestrictionRol(Gebruiker gebruiker)
        {
            var iocc = SimpleIoc.Default;
            var mainWindow = iocc.GetInstance<MainWindow>();

            switch (gebruiker.Rol)
            {
                case "Student":

                    mainWindow.btnNaam.Visibility = Visibility.Visible;
                    mainWindow.btnBloei.Visibility = Visibility.Visible;
                    mainWindow.btnGroei.Visibility = Visibility.Visible;
                    mainWindow.btnHabitat.Visibility = Visibility.Visible;
                    mainWindow.btnUiterlijk.Visibility = Visibility.Visible;
                    mainWindow.btnVerzorging.Visibility = Visibility.Visible;
                    mainWindow.btnExporteeralle.Visibility = Visibility.Visible;
                    mainWindow.btnExporteergeselecteerd.Visibility = Visibility.Visible;
                    mainWindow.btnLijst.Visibility = Visibility.Visible;
                    mainWindow.btnLopendVerzoek.Visibility = Visibility.Visible;
                    mainWindow.btnSorteer.Visibility = Visibility.Visible;

                    break;

                case "Docent":

                    mainWindow.btnNaam.Visibility = Visibility.Visible;
                    mainWindow.btnBloei.Visibility = Visibility.Visible;
                    mainWindow.btnGroei.Visibility = Visibility.Visible;
                    mainWindow.btnHabitat.Visibility = Visibility.Visible;
                    mainWindow.btnUiterlijk.Visibility = Visibility.Visible;
                    mainWindow.btnVerzorging.Visibility = Visibility.Visible;
                    mainWindow.btnExporteeralle.Visibility = Visibility.Visible;
                    mainWindow.btnExporteergeselecteerd.Visibility = Visibility.Visible;
                    mainWindow.btnLijst.Visibility = Visibility.Visible;
                    mainWindow.btnLopendVerzoek.Visibility = Visibility.Visible;
                    mainWindow.btnSorteer.Visibility = Visibility.Visible;

                    break;

                case "Oud-student":

                    mainWindow.btnNaam.Visibility = Visibility.Visible;
                    mainWindow.btnBloei.Visibility = Visibility.Hidden;
                    mainWindow.btnGroei.Visibility = Visibility.Hidden;
                    mainWindow.btnHabitat.Visibility = Visibility.Hidden;
                    mainWindow.btnUiterlijk.Visibility = Visibility.Hidden;
                    mainWindow.btnVerzorging.Visibility = Visibility.Hidden;
                    mainWindow.btnExporteeralle.Visibility = Visibility.Hidden;
                    mainWindow.btnExporteergeselecteerd.Visibility = Visibility.Hidden;
                    mainWindow.btnLijst.Visibility = Visibility.Hidden;
                    mainWindow.btnLopendVerzoek.Visibility = Visibility.Hidden;
                    mainWindow.btnSorteer.Visibility = Visibility.Hidden;
                    break;
            }
        }

        //functie om naam weer te geven in loginWindow
        public string LoggedInMessage()
        {
            string message= String.Empty;
            if (_gebruiker != null)
            {
                message = $"ingelogd als: {_gebruiker.Voornaam} {_gebruiker.Achternaam} {gebruiker.Rol}";
                return message;
            }
            return message;

            
        }

        private List<string> emailAdresOudstudenten = new List<string>()
        {
            "Marc.vandeputte@gmail.com",
            "Joris.Brys@hotmail.com",
            "Martine.Thange@live.be"
        };

        public bool CheckListOudstudenten(string emailAdres)
        {
            bool xBool = false;
            foreach (string emailOudStudent in emailAdresOudStudenten)
            {
                if (emailOudStudent == emailAdres)
                {
                    xBool = true;
                }
                else
                {
                    xBool = false;
                }
            }

            return xBool;
        }

        
        #endregion

        #region Register Region

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
                passwordRepeatInput != null &&
                rolInput != null)
            {   //checken als het emailadres een geldig vives email is.
                if (emailAdresInput != null && emailAdresInput.Contains("vives.be") && emailAdresInput.Contains("@")
                    //checken als het email adres al bestaat of niet.
                    && _dao.CheckIfEmailAlreadyExists(emailAdresInput))
                {   //checken als het herhaalde wachtwoord klopt of niet.
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