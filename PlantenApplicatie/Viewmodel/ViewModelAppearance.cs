using PlantenApplicatie.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Planten2021.Data;

namespace PlantenApplicatie.Viewmodel
{
    public class ViewModelAppearance : ViewModelBase
    {
        private DAO _dao;

        public ViewModelAppearance()
        {
            this._dao = DAO.Instance();
        }

        private string _selectedBladHoogte;

        public string SelectedBladHoogte
        {
            get { return _selectedBladHoogte; }
            set
            {
                _selectedBladHoogte = value;
                OnPropertyChanged();

            }
        }

        #region Binding checkboxen Bladkleur

        private bool _selectedCheckBoxBladkleurZwart;
        public bool SelectedCheckBoxBladkleurZwart
        {
            get { return _selectedCheckBoxBladkleurZwart; }

            set
            {
                _selectedCheckBoxBladkleurZwart = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladkleurWit;
        public bool SelectedCheckBoxBladkleurWit
        {
            get { return _selectedCheckBoxBladkleurWit; }

            set
            {
                _selectedCheckBoxBladkleurWit = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladkleurRosé;
        public bool SelectedCheckBoxBladkleurRosé
        {
            get { return _selectedCheckBoxBladkleurRosé; }

            set
            {
                _selectedCheckBoxBladkleurRosé = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladkleurRood;
        public bool SelectedCheckBoxBladkleurRood
        {
            get { return _selectedCheckBoxBladkleurRood; }

            set
            {
                _selectedCheckBoxBladkleurRood = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladkleurOranje;
        public bool SelectedCheckBoxBladkleurOranje
        {
            get { return _selectedCheckBoxBladkleurOranje; }

            set
            {
                _selectedCheckBoxBladkleurOranje = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladkleurLila;
        public bool SelectedCheckBoxBladkleurLila
        {
            get { return _selectedCheckBoxBladkleurLila; }

            set
            {
                _selectedCheckBoxBladkleurLila = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladkleurGrijs;
        public bool SelectedCheckBoxBladkleurGrijs
        {
            get { return _selectedCheckBoxBladkleurGrijs; }

            set
            {
                _selectedCheckBoxBladkleurGrijs = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladkleurGroen;
        public bool SelectedCheckBoxBladkleurGroen
        {
            get { return _selectedCheckBoxBladkleurGroen; }

            set
            {
                _selectedCheckBoxBladkleurGroen = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladkleurGeel;
        public bool SelectedCheckBoxBladkleurGeel
        {
            get { return _selectedCheckBoxBladkleurGeel; }

            set
            {
                _selectedCheckBoxBladkleurGeel = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladkleurBlauw;
        public bool SelectedCheckBoxBladkleurBlauw
        {
            get { return _selectedCheckBoxBladkleurBlauw; }

            set
            {
                _selectedCheckBoxBladkleurBlauw = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladkleurViolet;
        public bool SelectedCheckBoxBladkleurViolet
        {
            get { return _selectedCheckBoxBladkleurViolet; }

            set
            {
                _selectedCheckBoxBladkleurViolet = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladkleurPaars;
        public bool SelectedCheckBoxBladkleurPaars
        {
            get { return _selectedCheckBoxBladkleurPaars; }

            set
            {
                _selectedCheckBoxBladkleurPaars = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladkleurBruin;
        public bool SelectedCheckBoxBladkleurBruin
        {
            get { return _selectedCheckBoxBladkleurBruin; }

            set
            {
                _selectedCheckBoxBladkleurBruin = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Binding checkboxen BladHoogte

        private bool _selectedCheckBoxBladHoogteJan;
        public bool SelectedCheckBoxBladHoogteJan
        {
            get { return _selectedCheckBoxBladHoogteJan; }

            set
            {
                _selectedCheckBoxBladHoogteJan = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladHoogteFeb;
        public bool SelectedCheckBoxBladHoogteFeb
        {
            get { return _selectedCheckBoxBladHoogteFeb; }

            set
            {
                _selectedCheckBoxBladHoogteFeb = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladHoogteMar;
        public bool SelectedCheckBoxBladHoogteMar
        {
            get { return _selectedCheckBoxBladHoogteMar; }

            set
            {
                _selectedCheckBoxBladHoogteMar = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladHoogteApr;
        public bool SelectedCheckBoxBladHoogteApr
        {
            get { return _selectedCheckBoxBladHoogteApr; }

            set
            {
                _selectedCheckBoxBladHoogteApr = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladHoogteMay;
        public bool SelectedCheckBoxBladHoogteMay
        {
            get { return _selectedCheckBoxBladHoogteMay; }

            set
            {
                _selectedCheckBoxBladHoogteMay = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladHoogteJun;
        public bool SelectedCheckBoxBladHoogteJun
        {
            get { return _selectedCheckBoxBladHoogteJun; }

            set
            {
                _selectedCheckBoxBladHoogteJun = value;
                OnPropertyChanged();
            }
        }
        private bool _selectedCheckBoxBladHoogteJul;
        public bool SelectedCheckBoxBladHoogteJul
        {
            get { return _selectedCheckBoxBladHoogteJul; }

            set
            {
                _selectedCheckBoxBladHoogteJul = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladHoogteAug;
        public bool SelectedCheckBoxBladHoogteAug
        {
            get { return _selectedCheckBoxBladHoogteAug; }

            set
            {
                _selectedCheckBoxBladHoogteAug = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladHoogteSep;
        public bool SelectedCheckBoxBladHoogteSep
        {
            get { return _selectedCheckBoxBladHoogteSep; }

            set
            {
                _selectedCheckBoxBladHoogteSep = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladHoogteOct;
        public bool SelectedCheckBoxBladHoogteOct
        {
            get { return _selectedCheckBoxBladHoogteOct; }

            set
            {
                _selectedCheckBoxBladHoogteOct = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladHoogteNov;
        public bool SelectedCheckBoxBladHoogteNov
        {
            get { return _selectedCheckBoxBladHoogteNov; }

            set
            {
                _selectedCheckBoxBladHoogteNov = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladHoogteDec;
        public bool SelectedCheckBoxBladHoogteDec
        {
            get { return _selectedCheckBoxBladHoogteDec; }

            set
            {
                _selectedCheckBoxBladHoogteDec = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Binding checkboxen Bladvormen

        private bool _selectedCheckBoxBladvormenVorm1;
        public bool SelectedCheckBoxBladvormenVorm1
        {
            get { return _selectedCheckBoxBladvormenVorm1; }

            set
            {
                _selectedCheckBoxBladvormenVorm1 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladvormenVorm2;
        public bool SelectedCheckBoxBladvormenVorm2
        {
            get { return _selectedCheckBoxBladvormenVorm2; }

            set
            {
                _selectedCheckBoxBladvormenVorm2 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladvormenVorm3;
        public bool SelectedCheckBoxBladvormenVorm3
        {
            get { return _selectedCheckBoxBladvormenVorm3; }

            set
            {
                _selectedCheckBoxBladvormenVorm3 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladvormenVorm4;
        public bool SelectedCheckBoxBladvormenVorm4
        {
            get { return _selectedCheckBoxBladvormenVorm4; }

            set
            {
                _selectedCheckBoxBladvormenVorm4 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladvormenVorm5;
        public bool SelectedCheckBoxBladvormenVorm5
        {
            get { return _selectedCheckBoxBladvormenVorm5; }

            set
            {
                _selectedCheckBoxBladvormenVorm5 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladvormenVorm6;
        public bool SelectedCheckBoxBladvormenVorm6
        {
            get { return _selectedCheckBoxBladvormenVorm6; }

            set
            {
                _selectedCheckBoxBladvormenVorm6 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladvormenVorm7;
        public bool SelectedCheckBoxBladvormenVorm7
        {
            get { return _selectedCheckBoxBladvormenVorm7; }

            set
            {
                _selectedCheckBoxBladvormenVorm7 = value;
                MessageBox.Show(SelectedCheckBoxBladvormenVorm7.ToString());
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladvormenVorm8;
        public bool SelectedCheckBoxBladvormenVorm8
        {
            get { return _selectedCheckBoxBladvormenVorm8; }

            set
            {
                _selectedCheckBoxBladvormenVorm8 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladvormenVorm9;
        public bool SelectedCheckBoxBladvormenVorm9
        {
            get { return _selectedCheckBoxBladvormenVorm9; }

            set
            {
                _selectedCheckBoxBladvormenVorm9 = value;
                OnPropertyChanged();
            }
        }


        #endregion

        #region Binding checkboxen Stengelvormen

        private bool _selectedCheckBoxStengelvormenVorm1;
        public bool SelectedCheckBoxStengelvormenVorm1
        {
            get { return _selectedCheckBoxStengelvormenVorm1; }

            set
            {
                _selectedCheckBoxStengelvormenVorm1 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxStengelvormenVorm2;
        public bool SelectedCheckBoxStengelvormenVorm2
        {
            get { return _selectedCheckBoxStengelvormenVorm2; }

            set
            {
                _selectedCheckBoxStengelvormenVorm2 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxStengelvormenVorm3;
        public bool SelectedCheckBoxStengelvormenVorm3
        {
            get { return _selectedCheckBoxStengelvormenVorm3; }

            set
            {
                _selectedCheckBoxStengelvormenVorm3 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxStengelvormenVorm4;
        public bool SelectedCheckBoxStengelvormenVorm4
        {
            get { return _selectedCheckBoxStengelvormenVorm4; }

            set
            {
                _selectedCheckBoxStengelvormenVorm4 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxStengelvormenVorm5;
        public bool SelectedCheckBoxStengelvormenVorm5
        {
            get { return _selectedCheckBoxStengelvormenVorm5; }

            set
            {
                _selectedCheckBoxStengelvormenVorm5 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxStengelvormenVorm6;
        public bool SelectedCheckBoxStengelvormenVorm6
        {
            get { return _selectedCheckBoxStengelvormenVorm6; }

            set
            {
                _selectedCheckBoxStengelvormenVorm6 = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Binding checkboxen Levensvormen

        private bool _selectedCheckBoxLevensvormenVorm1;
        public bool SelectedCheckBoxLevensvormenVorm1
        {
            get { return _selectedCheckBoxLevensvormenVorm1; }

            set
            {
                _selectedCheckBoxLevensvormenVorm1 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxLevensvormenVorm2;
        public bool SelectedCheckBoxLevensvormenVorm2
        {
            get { return _selectedCheckBoxLevensvormenVorm2; }

            set
            {
                _selectedCheckBoxLevensvormenVorm2 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxLevensvormenVorm3;
        public bool SelectedCheckBoxLevensvormenVorm3
        {
            get { return _selectedCheckBoxLevensvormenVorm3; }

            set
            {
                _selectedCheckBoxLevensvormenVorm3 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxLevensvormenVorm4;
        public bool SelectedCheckBoxLevensvormenVorm4
        {
            get { return _selectedCheckBoxLevensvormenVorm4; }

            set
            {
                _selectedCheckBoxLevensvormenVorm4 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxLevensvormenVorm5;
        public bool SelectedCheckBoxLevensvormenVorm5
        {
            get { return _selectedCheckBoxLevensvormenVorm5; }

            set
            {
                _selectedCheckBoxLevensvormenVorm5 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxLevensvormenVorm6;
        public bool SelectedCheckBoxLevensvormenVorm6
        {
            get { return _selectedCheckBoxLevensvormenVorm6; }

            set
            {
                _selectedCheckBoxLevensvormenVorm6 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxLevensvormenVorm7;
        public bool SelectedCheckBoxLevensvormenVorm7
        {
            get { return _selectedCheckBoxLevensvormenVorm7; }

            set
            {
                _selectedCheckBoxLevensvormenVorm7 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxLevensvormenVorm8;
        public bool SelectedCheckBoxLevensvormenVorm8
        {
            get { return _selectedCheckBoxLevensvormenVorm8; }

            set
            {
                _selectedCheckBoxLevensvormenVorm8 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxLevensvormenVorm9;
        public bool SelectedCheckBoxLevensvormenVorm9
        {
            get { return _selectedCheckBoxLevensvormenVorm9; }

            set
            {
                _selectedCheckBoxLevensvormenVorm9 = value;
                OnPropertyChanged();
            }
        }


        #endregion
    }
}
