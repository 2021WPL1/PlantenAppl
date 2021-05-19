using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
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
            this._dao = dao;

            cmbType = new Dictionary<long, string>();
            cmbFamilie = new Dictionary<long, string>();
           


            fillComboBoxType();
            fillComboBoxFamilie();



        }


        //public ICommand FillComboBoxType { get; set; }

          public Dictionary<long, string> cmbType { get; set; }
          public Dictionary<long, string> cmbFamilie { get; set; }


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


        private int _selectedFamilieId;

        public int SelectedFamilieId
        {
            get { return _selectedFamilieId; }
            set
            {
                _selectedFamilieId = value;
                OnPropertyChanged();
            }
        }
        //private GameStoreDataService _dataservice;    

        //private Inventory _selectedInventory;
        //private Product _selectedProduct;
        
        /// <summary>
        /// Fill  combobox functies
        /// </summary>


        public void fillComboBoxType()
        {
            // Request the list of type's
            var list = _dao.fillTfgsvType();
            // adding them to the dictionary that is binded with the combobox van type
            foreach (var item in list)
            {
                cmbType.Add(item.Key, item.Value);
            }

        }

        public void fillComboBoxFamilie()
        {
            // Request the list of type's
            var list = _dao.fillTfgsvFamilie(SelectedTypeId);
            // adding them to the dictionary that is binded with the combobox van type
            foreach (var item in list)
            {
                cmbFamilie.Add(item.Key, item.Value);
            }

        }

    }
}
