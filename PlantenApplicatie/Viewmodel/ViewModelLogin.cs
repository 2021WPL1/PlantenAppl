using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using Planten2021.Data;
using Planten2021.Domain.Models;
using PlantenApplicatie.HelpClasses.Login.classes;
using PlantenApplicatie.HelpClasses.Login.enums;
using PlantenApplicatie.View;
using PlantenApplicatie.View.Home;
using PlantenApplicatie.ViewModel;

namespace PlantenApplicatie.Viewmodel
{
    class ViewModelLogin : ViewModelBase
    {
        private DAO _dao;


        public RelayCommand loginCommand { get; set; }
        public RelayCommand cancelCommand { get; set; }
        public RelayCommand registerCommand { get; set; }

        private string _userNameInput;
        private string _passwordInput;

        public ViewModelLogin()
        {
            this._dao = DAO.Instance();
            loginCommand = new RelayCommand(LoginButton);
            cancelCommand = new RelayCommand(CancelButton);
            registerCommand = new RelayCommand(RegisterButton);
        }

        public string userNameInput
        {
            get
            {
                return _userNameInput;
            }
            set
            {
                _userNameInput = value;
                OnPropertyChanged();
            }
        }

        public string passwordInput
        {
            get
            {
                return _passwordInput;
            }
            set
            {
                _passwordInput = value;
                OnPropertyChanged();
            }
        }

        public Gebruiker gebruiker = new Gebruiker();
        private User user = new User();
        public void LoginButton()
        {
            //check if email is valid email
            if (userNameInput!=null && userNameInput.Contains("@student.vives.be"))
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
            if (gebruiker.HashPaswoord !=null && passwordHashed.SequenceEqual(gebruiker.HashPaswoord))
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
            Application.Current.Windows[0].Close();
        }
    }
}
