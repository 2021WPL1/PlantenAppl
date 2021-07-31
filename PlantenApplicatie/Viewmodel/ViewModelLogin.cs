using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using Planten2021.Data;
using Planten2021.Domain.Models;
using PlantenApplicatie.HelpClasses.Login.classes;
using PlantenApplicatie.HelpClasses.Login.enums;
using PlantenApplicatie.Services;
using PlantenApplicatie.Services.Interfaces;
using PlantenApplicatie.View;
using PlantenApplicatie.View.Home;
using PlantenApplicatie.ViewModel;
//written by kenny
namespace PlantenApplicatie.Viewmodel
{
    public class ViewModelLogin : ViewModelBase
    {   
        private IWindowManagerService _windowManagerService { get; }
        private IloginUserService _loginService { get; }
        public RelayCommand loginCommand { get; set; }
        public RelayCommand cancelCommand { get; set; }
        public RelayCommand registerCommand { get; set; }

        private string _userNameInput;
        private string _passwordInput;
        private string _errorMessage;
        private string _loggedInMessage;
        

       

        public ViewModelLogin(IloginUserService loginUserService, IWindowManagerService windowManagerService)
        {
            this._windowManagerService = windowManagerService;
            this._loginService = loginUserService;
            loginCommand = new RelayCommand(LoginButtonClick);
            cancelCommand = new RelayCommand(CancelButton);
            registerCommand = new RelayCommand(RegisterButtonView);
        }
        public void RegisterButtonView()
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            Application.Current.Windows[0]?.Close();
           

        }
        public void CancelButton()
        {
            Application.Current.Shutdown();
        }

        private void LoginButtonClick()
        {
            if (!string.IsNullOrWhiteSpace(userNameInput))
            {
                LoginResult loginResult = _loginService.CheckCredentials(userNameInput, passwordInput);

                if (loginResult.loginStatus == LoginStatus.LoggedIn)
                {
                  //  loggedInMessage = _loginService.LoggedInMessage(userNameInput);
                    MainWindow mainWindow = new MainWindow();
                    
                    mainWindow.Show();
                    Application.Current.Windows[0]?.Close();
                }
                else
                {
                    errorMessage = loginResult.errorMessage;
                }
            }
            else
            {
                errorMessage = "gebruikersnaam invullen";
            }

           

        }
        public string errorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;

                RaisePropertyChanged("errorMessage");
            }
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
    }
}
