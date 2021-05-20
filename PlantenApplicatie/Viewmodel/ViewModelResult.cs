using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using GalaSoft.MvvmLight.Messaging;
using Planten2021.Data;
using Planten2021.Domain.Models;
using PlantenApplicatie.HelpClasses;
using PlantenApplicatie.View.UserControls;
using PlantenApplicatie.ViewModel;

namespace PlantenApplicatie.Viewmodel
{
    public class ViewModelResult : ViewModelBase
    {

        private DAO _dao;

        public ViewModelResult()
        {
           
            Messenger.Default.Register<List<Plant>>(this, FilllistResult);

            listboxDetails = new ObservableCollection<string>();
            listboxResult = new ObservableCollection<Plant>();

            this._dao = DAO.Instance();
        }

        private void FilllistResult()
        {
            fillListResult(FilllistResult);
            var action = List<Plant>;
        }

        public ObservableCollection<string> listboxDetails { get; set; }
        public ObservableCollection<Plant> listboxResult { get; set; }

        private Plant _selectedPlant;

        public Plant Selectedplant
        {
            get { return _selectedPlant; }
            set
            {
                _selectedPlant = value;
                LoadDetails(value.PlantId);
                OnPropertyChanged();
            }
        }

        public void fillListResult(List<Plant> list)
        {
            foreach (var item in list)
            {
                listboxResult.Add(item);
            }
        }

        public void LoadDetails(long SelectedPlantId)
        {
            var ListResult = _dao._readObjectProperties<Plant>(SelectedPlantId);
            listboxDetails.Clear();
            foreach (var item in ListResult)
            {
                listboxDetails.Add(item);
            }
        }

    }
}
