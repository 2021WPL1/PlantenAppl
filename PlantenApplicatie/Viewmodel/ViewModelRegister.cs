﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using Planten2021.Data;
using PlantenApplicatie.Services;
using PlantenApplicatie.Services.Interfaces;
using PlantenApplicatie.View;
using PlantenApplicatie.View.Home;
using PlantenApplicatie.ViewModel;

namespace PlantenApplicatie.Viewmodel
{
    //written by kenny
    public class ViewModelRegister : ViewModelBase
    {
        private WindowManagerService windowManagerService;
        private IloginUserService _loginService { get; }
        private IWindowManagerService _windowManagerService { get; }
        public RelayCommand registerCommand { get; set; }
        public RelayCommand backCommand { get; set; }

        private ObservableCollection<Window> _windows;
        public ViewModelRegister(IloginUserService loginUserService, IWindowManagerService windowManagerService)
        {
            this._windowManagerService = windowManagerService;
            this._loginService = loginUserService;
            registerCommand = new RelayCommand(RegisterButtonClick);
            backCommand = new RelayCommand(BackButtonClick);
            _windows = new ObservableCollection<Window> { new LoginWindow(), new MainWindow(), new RegisterWindow() };
        }

        public void BackButtonClick()
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            Application.Current.Windows[0]?.Close();
        }
        public void RegisterButtonClick()
        {
            errorMessage = _loginService.RegisterButton(vivesNrInput, lastNameInput,
                 firstNameInput, emailAdresInput,
                 passwordInput, passwordRepeatInput, rolInput);
           /*Close*/

           _windows.Remove()


        }
        #region MVVM TextFieldsBinding
        private string _vivesNrInput;
        private string _firstNameInput;
        private string _lastNameInput;
        private string _emailAdresInput;
        private string _passwordInput;
        private string _passwordRepeatInput;
        private string _rolInput;
        private string _errorMessage;

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
        public string vivesNrInput
        {
            get
            {
                return _vivesNrInput;
            }
            set
            {
                _vivesNrInput = value;
                OnPropertyChanged();
            }
        }

        public string firstNameInput
        {
            get
            {
                return _firstNameInput;
            }
            set
            {
                _firstNameInput = value;
                OnPropertyChanged();
            }
        }
        public string lastNameInput
        {
            get
            {
                return _lastNameInput;
            }
            set
            {
                _lastNameInput = value;
                OnPropertyChanged();
            }
        }
        public string emailAdresInput
        {
            get
            {
                return _emailAdresInput;
            }
            set
            {
                _emailAdresInput = value;
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
        public string passwordRepeatInput
        {
            get
            {
                return _passwordRepeatInput;
            }
            set
            {
                _passwordRepeatInput = value;
                OnPropertyChanged();
            }
        }
        public string rolInput
        {
            get
            {
                return _rolInput;
            }
            set
            {
                _rolInput = value;
                OnPropertyChanged();
            }
        }
        #endregion


      

}
}

