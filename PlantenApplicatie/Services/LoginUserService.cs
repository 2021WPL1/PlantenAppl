using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using GalaSoft.MvvmLight.Command;
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
        
        private Gebruiker _gebruiker { get; set; }

        /*written by kenny from an example of Roy and some help of Killian*/
        private DAO _dao;
        public LoginUserService()
        {
            this._dao = DAO.Instance();
        }
        #region Login Region

        public Gebruiker gebruiker = new Gebruiker();
       // private LoginResult _loginResult = new LoginResult();

        public event PropertyChangedEventHandler PropertyChanged;



        public void BackButtonRegister()
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            Application.Current.Windows[0]?.Close();
        }

        public LoginResult CheckCredentials(string userNameInput, string passwordInput)
        {
            var loginResult = new LoginResult() {loginStatus = LoginStatus.NotLoggedIn};
           
            //check if email is valid email
            if (userNameInput != null && userNameInput.Contains("@student.vives.be"))
            {
                gebruiker = _dao.GetGebruikerWithEmail(userNameInput);
                loginResult.gebruiker = gebruiker;
                loginResult.loginStatus = LoginStatus.LoggedIn;
            }
            else
            {
                loginResult.loginStatus = LoginStatus.NotLoggedIn;
                loginResult.errorMessage = "Dit is geen geldig Vives emailadres.";
            }

            if (passwordInput is null)
            {
                passwordInput = "";
            }
            //change entered password to hashed password
            var passwordBytes = Encoding.ASCII.GetBytes(passwordInput);
            var md5Hasher = new MD5CryptoServiceProvider();
            var passwordHashed = md5Hasher.ComputeHash(passwordBytes);

            if (gebruiker != null)
            {
                _gebruiker = gebruiker;
                loginResult.gebruiker = gebruiker;
                //check if entered password is correct and change LoginStatus
                if (gebruiker.HashPaswoord != null && passwordHashed.SequenceEqual(gebruiker.HashPaswoord))
                {
                    loginResult.loginStatus = LoginStatus.LoggedIn;
                }
                else
                {
                    loginResult.loginStatus = LoginStatus.NotLoggedIn;
                    loginResult.errorMessage += "\r\n"+"Het ingegeven wachtwoord is niet juist, probeer opnieuw";
                }
            }
            else
            {
                loginResult.errorMessage = $"Er is geen account gevonden voor {userNameInput} "+"\r\n"+" gelieve eerst te registreren";
            }
            return loginResult;
        }

       
        public string LoggedInMessage()
        {
            string message= String.Empty;
          
                message = $"ingelogd als: {_gebruiker.Voornaam} {_gebruiker.Achternaam}";
                
            return message;
        }

        public void CancelButton()
        {
            Application.Current.Shutdown();
        }
        public void RegisterButtonView()
        {
            
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            Application.Current.Windows[0]?.Close();
        }


        #endregion

        #region Register Region

        public string RegisterButton(string vivesNrInput, string lastNameInput, 
                                   string firstNameInput, string emailAdresInput,
                                   string passwordInput, string passwordRepeatInput, string rolInput)
        {

            string errorMessage = string.Empty;
            if (vivesNrInput != null &&
                firstNameInput != null &&
                lastNameInput != null &&
                emailAdresInput != null &&
                passwordInput != null &&
                passwordRepeatInput != null &&
                rolInput != null)
            {
                if (emailAdresInput != null && emailAdresInput.Contains("@student.vives.be") && _dao.CheckIfEmailAlreadyExists(emailAdresInput))
                {
                    if (passwordInput == passwordRepeatInput)
                    {
                        _dao.RegisterUser(vivesNrInput, firstNameInput, lastNameInput, rolInput, emailAdresInput, passwordInput);
                        errorMessage = $"{firstNameInput}, je bent succevol geregistreerd,"+"\r\n"+$" uw gebruikersnaam is {emailAdresInput}." + "\r\n" + $" {firstNameInput}, je kan dit venster wegklikken en inloggen.";
                        LoginWindow loginWindow = new LoginWindow();
                        loginWindow.Show();
                    }
                    else
                    {
                        errorMessage = "zorg dat de wachtwoorden overeen komen.";
                    }
                }
                else
                {
                    errorMessage = $"{emailAdresInput} is geen geldig emailadres, "+"\r\n"+" of het eamiladres is al in gebruik.";
                }
            }
            else
            {
                errorMessage = "zorg dat alle velden ingevuld zijn";
            }

            return errorMessage;
        }
        
        

#endregion
    }
    
}