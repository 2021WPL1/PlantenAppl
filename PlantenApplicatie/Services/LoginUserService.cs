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
        private DAO _dao;

        public LoginUserService()
        {
            this._dao = DAO.Instance();

        }

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
                MessageBox.Show($"{userNameInput}, je bent succevol ingelogd");
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
        public void RegisterButton()
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            Application.Current.Windows[0]?.Close();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

    }
}