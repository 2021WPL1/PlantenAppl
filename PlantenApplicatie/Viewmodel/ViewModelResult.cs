using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using Planten2021.Data;
using Planten2021.Domain.Models;
using PlantenApplicatie.View.UserControls;
using PlantenApplicatie.ViewModel;

namespace PlantenApplicatie.Viewmodel
{
    public class ViewModelResult : ViewModelBase
    {
        private DAO _context;
        private int _selectedPlant;

        public ViewModelResult(DAO dataService)
        {
            listboxResult = new ObservableCollection<string>();
            listboxDetails = new ObservableCollection<string>();

            

            this._context = dataService;
        }
        public ObservableCollection<string> listboxResult { get; set; }
        public ObservableCollection<string> listboxDetails { get; set; }

        public int Selectedplant
        {
            get { return _selectedPlant; }
            set
            {
                _selectedPlant = value;
                OnPropertyChanged();
            }
        }

        public void LoadDetails(int plantId, List<string> list)
        {
            var ListResult = _context._readObjectProperties<Plant>(plantId, list);
            listboxDetails.Clear();
            foreach (var item in list)
            {
                listboxDetails.Add(item);
            }
        }
    }
}
