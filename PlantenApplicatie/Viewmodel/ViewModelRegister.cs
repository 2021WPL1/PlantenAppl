using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using Planten2021.Data;
using PlantenApplicatie.View.Home;
using PlantenApplicatie.ViewModel;

namespace PlantenApplicatie.Viewmodel
{
    //written by kenny
    public class ViewModelRegister : ViewModelBase
    {
        private DAO _searchService;
        public RelayCommand registerCommand { get; set; }
        public ViewModelRegister()
        {
            this._searchService = DAO.Instance();
            registerCommand = new RelayCommand(RegisterButton);
        }
        #region MVVM TextFieldsBinding
        private string _vivesNrInput;
        private string _firstNameInput;
        private string _lastNameInput;
        private string _emailAdresInput;
        private string _passwordInput;
        private string _passwordRepeatInput;
        private string _rolInput;

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


        public void RegisterButton()
        {
            if (vivesNrInput != null && 
                firstNameInput != null && 
                lastNameInput != null && 
                emailAdresInput != null && 
                passwordInput != null && 
                passwordRepeatInput != null &&
                rolInput != null)
            {
                if (emailAdresInput != null && emailAdresInput.Contains("@student.vives.be") && _searchService.CheckIfEmailAlreadyExists(emailAdresInput))
                {
                    if (passwordInput == passwordRepeatInput)
                    {
                        _searchService.RegisterUser(vivesNrInput, firstNameInput, lastNameInput, rolInput, emailAdresInput, passwordInput);
                        MessageBox.Show($"{firstNameInput}, je bent succevol geregistreerd, uw gebruikersnaam is {emailAdresInput} en uw wachtwoord is {passwordInput} .");
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

}
}

