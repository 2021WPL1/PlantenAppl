﻿using PlantenApplicatie.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using Planten2021.Data;
using PlantenApplicatie.Services.Interfaces;

namespace PlantenApplicatie.Viewmodel
{
    public class ViewModelBloom : ViewModelBase
    {
        // Using a DependencyProperty as the backing store for 
        //IsCheckBoxChecked.  This enables animation, styling, binding, etc...
       
        private DAO _dao;

        public ViewModelBloom(IDetailService detailservice)
        {
            this._dao = DAO.Instance();
            
        }

       private string _selectedBloeiHoogte;

        public string SelectedBloeiHoogte
        {
            get { return _selectedBloeiHoogte; }
            set
            {
                _selectedBloeiHoogte = value;
                OnPropertyChanged();

            }
        }

        #region Binding Checkbox BloeiHoogte

        private bool _selectedCheckBoxBloeiHoogteJan;
        public bool SelectedCheckBoxBloeiHoogteJan
        {
            get { return _selectedCheckBoxBloeiHoogteJan; }

            set
            {
                _selectedCheckBoxBloeiHoogteJan = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeiHoogteFeb;
        public bool SelectedCheckBoxBloeiHoogteFeb
        {
            get { return _selectedCheckBoxBloeiHoogteFeb; }

            set
            {
                _selectedCheckBoxBloeiHoogteFeb = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeiHoogteMar;
        public bool SelectedCheckBoxBloeiHoogteMar
        {
            get { return _selectedCheckBoxBloeiHoogteMar; }

            set
            {
                _selectedCheckBoxBloeiHoogteMar = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeiHoogteApr;
        public bool SelectedCheckBoxBloeiHoogteApr
        {
            get { return _selectedCheckBoxBloeiHoogteApr; }

            set
            {
                _selectedCheckBoxBloeiHoogteApr = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeiHoogteMay;
        public bool SelectedCheckBoxBloeiHoogteMay
        {
            get { return _selectedCheckBoxBloeiHoogteMay; }

            set
            {
                _selectedCheckBoxBloeiHoogteMay = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeiHoogteJun;
        public bool SelectedCheckBoxBloeiHoogteJun
        {
            get { return _selectedCheckBoxBloeiHoogteJun; }

            set
            {
                _selectedCheckBoxBloeiHoogteJun = value;
                OnPropertyChanged();
            }
        }
        private bool _selectedCheckBoxBloeiHoogteJul;
        public bool SelectedCheckBoxJul
        {
            get { return _selectedCheckBoxBloeiHoogteJul; }

            set
            {
                _selectedCheckBoxBloeiHoogteJul = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeiHoogteAug;
        public bool SelectedCheckBoxBloeiHoogteAug
        {
            get { return _selectedCheckBoxBloeiHoogteAug; }

            set
            {
                _selectedCheckBoxBloeiHoogteAug = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeiHoogteSep;
        public bool SelectedCheckBoxBloeiHoogteSep
        {
            get { return _selectedCheckBoxBloeiHoogteSep; }

            set
            {
                _selectedCheckBoxBloeiHoogteSep = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeiHoogteOct;
        public bool SelectedCheckBoxBloeiHoogteOct
        {
            get { return _selectedCheckBoxBloeiHoogteOct; }

            set
            {
                _selectedCheckBoxBloeiHoogteOct = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeiHoogteNov;
        public bool SelectedCheckBoxBloeiHoogteNov
        {
            get { return _selectedCheckBoxBloeiHoogteNov; }

            set
            {
                _selectedCheckBoxBloeiHoogteNov = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeiHoogteDec;
        public bool SelectedCheckBoxBloeiHoogteDec
        {
            get { return _selectedCheckBoxBloeiHoogteDec; }

            set
            {
                _selectedCheckBoxBloeiHoogteDec = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Binding Checkbox Bloeit In

        private bool _selectedCheckBoxBloeitInJan;
        
        public bool SelectedCheckBoxBloeitInJan
        {
            get { return _selectedCheckBoxBloeitInJan; }

            set
            {
                _selectedCheckBoxBloeitInJan = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeitInFeb;
        public bool SelectedCheckBoxBloeitInFeb
        {
            get { return _selectedCheckBoxBloeitInFeb; }

            set
            {
                _selectedCheckBoxBloeitInFeb = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeitInMar;
        public bool SelectedCheckBoxBloeitInMar
        {
            get { return _selectedCheckBoxBloeitInMar; }

            set
            {
                _selectedCheckBoxBloeitInMar = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeitInApr;
        public bool SelectedCheckBoxBloeitInApr
        {
            get { return _selectedCheckBoxBloeitInApr; }

            set
            {
                _selectedCheckBoxBloeitInApr = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeitInMay;
        public bool SelectedCheckBoxBloeitInMay
        {
            get { return _selectedCheckBoxBloeitInMay; }

            set
            {
                _selectedCheckBoxBloeitInMay = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeitInJun;
        public bool SelectedCheckBoxBloeitInJun
        {
            get { return _selectedCheckBoxBloeitInJun; }

            set
            {
                _selectedCheckBoxBloeitInJun = value;
                OnPropertyChanged();
            }
        }
        private bool _selectedCheckBoxBloeitInJul;
        public bool SelectedCheckBoxBloeitInJul
        {
            get { return _selectedCheckBoxBloeitInJul; }

            set
            {
                _selectedCheckBoxBloeitInJul = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeitInAug;
        public bool SelectedCheckBoxBloeitInAug
        {
            get { return _selectedCheckBoxBloeitInAug; }

            set
            {
                _selectedCheckBoxBloeitInAug = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeitInSep;
        public bool SelectedCheckBoxBloeitInSep
        {
            get { return _selectedCheckBoxBloeitInSep; }

            set
            {
                _selectedCheckBoxBloeitInSep = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeitInOct;
        public bool SelectedCheckBoxBloeitInOct
        {
            get { return _selectedCheckBoxBloeitInOct; }

            set
            {
                _selectedCheckBoxBloeitInOct = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeitInNov;
        public bool SelectedCheckBoxBloeitInNov
        {
            get { return _selectedCheckBoxBloeitInNov; }

            set
            {
                _selectedCheckBoxBloeitInNov = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeitInDec;
        public bool SelectedCheckBoxBloeitInDec
        {
            get { return _selectedCheckBoxBloeiHoogteDec; }

            set
            {
                _selectedCheckBoxBloeiHoogteDec = value;
                OnPropertyChanged();
            }
        }


        #endregion

        #region Binding checkboxes Bloeiwijzevorm

        private bool _selectedCheckBoxBloeiwijzeVorm1;
        public bool SelectedCheckBoxBloeiwijzeVorm1
        {
            get { return _selectedCheckBoxBloeiwijzeVorm1; }

            set
            {
                _selectedCheckBoxBloeiwijzeVorm1 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeiwijzeVorm2;
        public bool SelectedCheckBoxBloeiwijzeVorm2
        {
            get { return _selectedCheckBoxBloeiwijzeVorm2; }

            set
            {
                _selectedCheckBoxBloeiwijzeVorm2 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeiwijzeVorm3;
        public bool SelectedCheckBoxBloeiwijzeVorm3
        {
            get { return _selectedCheckBoxBloeiwijzeVorm3; }

            set
            {
                _selectedCheckBoxBloeiwijzeVorm3 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeiwijzeVorm4;
        public bool SelectedCheckBoxBloeiwijzeVorm4
        {
            get { return _selectedCheckBoxBloeiwijzeVorm4; }

            set
            {
                _selectedCheckBoxBloeiwijzeVorm4 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeiwijzeVorm5;
        public bool SelectedCheckBoxBloeiwijzeVorm5
        {
            get { return _selectedCheckBoxBloeiwijzeVorm5; }

            set
            {
                _selectedCheckBoxBloeiwijzeVorm5 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeiwijzeVorm6;
        public bool SelectedCheckBoxBloeiwijzeVorm6
        {
            get { return _selectedCheckBoxBloeiwijzeVorm6; }

            set
            {
                _selectedCheckBoxBloeiwijzeVorm6 = value;
                OnPropertyChanged();
            }
        }

        #endregion
    }
}

