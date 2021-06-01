using PlantenApplicatie.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
