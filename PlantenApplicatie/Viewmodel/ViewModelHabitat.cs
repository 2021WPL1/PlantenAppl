using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Planten2021.Data;
using Planten2021.Domain.Models;
using PlantenApplicatie.View.UserControls;
using ViewModelBase = PlantenApplicatie.ViewModel.ViewModelBase;

namespace PlantenApplicatie.Viewmodel
{
    public class ViewModelHabitat : ViewModelBase
    {
        private DAO _dao;

        public ViewModelHabitat()
        {
            this._dao = DAO.Instance();

        

        cmbPollenWaarde = new ObservableCollection<ExtraPollenwaarde>();
        cmbNectarWaarde = new ObservableCollection<ExtraNectarwaarde>();
        

            fillComboBoxPollenwaarde();
            fillComboBoxNectarwaarde();
            
        }

        public ObservableCollection<ExtraPollenwaarde> cmbPollenWaarde { get; set; }
        public ObservableCollection<ExtraNectarwaarde> cmbNectarWaarde { get; set; }

       
        public void fillComboBoxPollenwaarde()
        {
            var list = _dao.FillExtraPollenwaardes();
            
            foreach (var item in list)
            {
                
                cmbPollenWaarde.Add(item);

            }
        }

        private string _selectedPollenwaarde;

        public string SelectedPollenwaarde
        {
            get { return _selectedPollenwaarde; }
            set
            {
                _selectedPollenwaarde = value;
                OnPropertyChanged();

            }
        }

        public void fillComboBoxNectarwaarde()
        {
            var list = _dao.FillExtraNectarwaardes();

            foreach (var item in list)
            {
                cmbNectarWaarde.Add(item);
            }
        }

        private string _selectedNectarwaarde;

        public string SelectedNectarwaarde
        {
            get { return _selectedNectarwaarde; }
            set
            {
                _selectedNectarwaarde = value;
                OnPropertyChanged();

            }
        }

        private string _selectedOntwikkelsnelheid;

        public string SelectedOntwikkelsnelheid
        {
            get { return _selectedOntwikkelsnelheid; }
            set
            {
                _selectedOntwikkelsnelheid = value;

                MessageBox.Show(_selectedOntwikkelsnelheid);
                OnPropertyChanged();
            }
        }
    }
}
