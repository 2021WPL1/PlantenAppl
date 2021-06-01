using System;
using System.Collections.Generic;
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
        private IloginUserService _loginService { get; }

        public RelayCommand loginCommand { get; set; }
        public RelayCommand cancelCommand { get; set; }
        public RelayCommand registerCommand { get; set; }

        private string _userNameInput;
        private string _passwordInput;

        public ViewModelLogin(IloginUserService loginUserService)
        {

            this._loginService = loginUserService;
            loginCommand = new RelayCommand(LoginButtonClick);
            cancelCommand = new RelayCommand(loginUserService.CancelButton);
            registerCommand = new RelayCommand(loginUserService.RegisterButton);

        }

        private void LoginButtonClick()
        {
            _loginService.LoginButton(userNameInput, passwordInput);
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
