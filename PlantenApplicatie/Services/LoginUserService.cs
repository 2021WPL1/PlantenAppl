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


namespace PlantenApplicatie.Services
{
    public class LoginUserService : IloginUserService, INotifyPropertyChanged
    {
        /*written by kenny from an example of Roy and some help of Killian*/
        private DAO _dao;
        public LoginUserService()
        {
            this._dao = DAO.Instance();

        }
        #region Login Region

        public Gebruiker gebruiker = new Gebruiker();
        private User user = new User();

        public event PropertyChangedEventHandler PropertyChanged;

        public void LoginButton(string userNameInput, string passwordInput)
        {
            //check if email is valid email
            if (userNameInput != null && userNameInput.Contains("@student.vives.be"))
            {
                gebruiker = _dao.GetGebruikerWithEmail(userNameInput);
                user.gebruiker = gebruiker;
            }
            else
            {
                MessageBox.Show("This is not a valid Email-adress.");
            }

            if (passwordInput is null)
            {
                passwordInput = "";
            }
            //change entered password to hashed password
            var passwordBytes = Encoding.ASCII.GetBytes(passwordInput);
            var md5Hasher = new MD5CryptoServiceProvider();
            var passwordHashed = md5Hasher.ComputeHash(passwordBytes);

            //check if entered password is correct and change LoginStatus
            if (gebruiker.HashPaswoord != null && passwordHashed.SequenceEqual(gebruiker.HashPaswoord))
            {
                user.loginStatus = LoginStatus.LoggedIn;
            }
            else
            {
                user.loginStatus = LoginStatus.NotLoggedIn;
                MessageBox.Show("Het ingegeven wachtwoord is niet juist, probeer opnieuw");
            }

            if (user.loginStatus == LoginStatus.LoggedIn)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }

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

        public void RegisterButton(string vivesNrInput, string lastNameInput, 
                                   string firstNameInput, string emailAdresInput,
                                   string passwordInput, string passwordRepeatInput, string rolInput)
        {
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
                        MessageBox.Show($"{firstNameInput}, je bent succevol geregistreerd, uw gebruikersnaam is {emailAdresInput}.");
                        LoginWindow loginWindow = new LoginWindow();
                        loginWindow.Show();
                    }
                    else
                    {
                        MessageBox.Show("zorg dat de wachtwoorden overeen komen.");
                    }
                }
                else
                {
                    MessageBox.Show($"{emailAdresInput} is geen geldig emailadres, of het eamiladres is al in gebruik.");
                }
            }
            else
            {
                MessageBox.Show("zorg dat alle velden ingevuld zijn");
            }
        }
        #endregion


    }
}