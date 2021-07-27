using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Planten2021.Data;
using Planten2021.Domain.Models;
using PlantenApplicatie.Services.Interfaces;
using PlantenApplicatie.ViewModel;

namespace PlantenApplicatie.Viewmodel
{
    public class ViewModelGrooming : ViewModelBase
    {
        private DAO _dao;

        public ViewModelGrooming(IDetailService detailservice)
        {
            this._dao = DAO.Instance();

            cmbBeheerdaad = new ObservableCollection<string>();

            fillComboBoxBeheerdaad();
        }
        //geschreven door christophe, op basis van een voorbeeld van owen
        public ObservableCollection<string> cmbBeheerdaad { get; set; }

        public void fillComboBoxBeheerdaad()
        {
            var list = _dao.FillBeheerdaad().ToList();

            
                foreach (var item in list)
                {
                    //if (item != null)
                    //{
                        cmbBeheerdaad.Add(item.Beheerdaad);
                    //}
                    
                }
            
            
        }

        private string _selectedBeheerdaad;

        public string SelectedBeheerdaad
        {
            get { return _selectedBeheerdaad; }
            set
            {
                _selectedBeheerdaad = value;
                OnPropertyChanged();

            }
        }

        #region Binding checkboxen Beheerdaad maand

        private bool _selectedCheckBoxJan;

        public bool SelectedCheckBoxJan
        {
            get { return _selectedCheckBoxJan; }

            set
            {
                _selectedCheckBoxJan = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxFeb;
        public bool SelectedCheckBoxFeb
        {
            get { return _selectedCheckBoxFeb; }

            set
            {
                _selectedCheckBoxFeb = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxMar;
        public bool SelectedCheckBoxMar
        {
            get { return _selectedCheckBoxMar; }

            set
            {
                _selectedCheckBoxMar = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxApr;
        public bool SelectedCheckBoxApr
        {
            get { return _selectedCheckBoxApr; }

            set
            {
                _selectedCheckBoxApr = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxMay;
        public bool SelectedCheckBoxFMay
        {
            get { return _selectedCheckBoxMay; }

            set
            {
                _selectedCheckBoxMay = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxJun;
        public bool SelectedCheckBoxJun
        {
            get { return _selectedCheckBoxJun; }

            set
            {
                _selectedCheckBoxJun = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxJul;
        public bool SelectedCheckBoxJul
        {
            get { return _selectedCheckBoxJul; }

            set
            {
                _selectedCheckBoxJul = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxAug;
        public bool SelectedCheckBoxAug
        {
            get { return _selectedCheckBoxAug; }

            set
            {
                _selectedCheckBoxAug = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxSep;
        public bool SelectedCheckBoxSep
        {
            get { return _selectedCheckBoxSep; }

            set
            {
                _selectedCheckBoxSep = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxOct;
        public bool SelectedCheckBoxOct
        {
            get { return _selectedCheckBoxOct; }

            set
            {
                _selectedCheckBoxOct = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxNov;
        public bool SelectedCheckBoxNov
        {
            get { return _selectedCheckBoxNov; }

            set
            {
                _selectedCheckBoxNov = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxDec;
        public bool SelectedCheckBoxDec
        {
            get { return _selectedCheckBoxDec; }

            set
            {
                _selectedCheckBoxDec = value;
                OnPropertyChanged();
            }
        }












        #endregion
    }
}
