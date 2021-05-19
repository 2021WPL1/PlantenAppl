using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Planten2021.Data;
using Planten2021.Domain.Models;
using Prism.Commands;

namespace PlantenApplicatie.ViewModel
{
    class ViewModelSearchTfgsv : ViewModelBase
    {
        private DAO _dao;

        public ViewModelSearchTfgsv(DAO dao)
        {
            Dictionary<long, string> cmbType = new Dictionary<long, string>();

            this._dao = dao;
            fillComboBoxType();

        }


        //public ICommand FillComboBoxType { get; set; }

        public Dictionary<long, string> cmbType { get; set; }


        private int _selectedTypeId;

        public int SelectedTypeId
        {
            get { return _selectedTypeId; }
            set
            {
                _selectedTypeId = value;
                OnPropertyChanged();
            }
        }

        //private GameStoreDataService _dataservice;    

        //private Inventory _selectedInventory;
        //private Product _selectedProduct;

        public void fillComboBoxType()
        {
        //    var list = _dao.fillTfgsvType();

        //    foreach (var item in list)
        //    {
        //        cmbType.Add(item.Key, item.Value);
        //    }

        }



    }
}
