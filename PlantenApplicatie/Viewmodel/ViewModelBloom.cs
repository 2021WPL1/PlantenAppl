using PlantenApplicatie.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Planten2021.Data;


namespace PlantenApplicatie.Viewmodel
{
    public class ViewModelBloom : ViewModelBase
    {
        private DAO _dao;

        public ViewModelBloom()
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

    }
}

