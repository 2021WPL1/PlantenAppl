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
            cmbType = new Dictionary<long, string>();
            cmbFamilie = new Dictionary<long, string>();
            cmbGeslacht = new Dictionary<long, string>();
            cmbSoort = new Dictionary<long, string>();
            cmbVariant = new Dictionary<long, string>();

            this._dao = dao;
            fillComboBoxType();
            fillComboBoxFamilie();
            fillComboBoxGeslacht();
            fillComboBoxSoort();
            fillComboBoxVariant();
        }


        //public ICommand FillComboBoxType { get; set; }

        public Dictionary<long, string> cmbType { get; set; }
        public Dictionary<long, string> cmbFamilie { get; set; }

        public Dictionary<long, string> cmbGeslacht { get; set; }
        public Dictionary<long, string> cmbSoort { get; set; }
        public Dictionary<long, string> cmbVariant { get; set; }



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

        private int _selectedGeslachtId;
        public int SelectedGeslachtId
        {
            get { return _selectedGeslachtId; }
            set
            {
                _selectedGeslachtId = value;
                OnPropertyChanged();
            }
        }

        private int _selectedSoortId;
        public int SelectedSoortId
        {
            get { return _selectedSoortId; }
            set
            {
                _selectedSoortId = value;
                OnPropertyChanged();
            }
        }

        private int _selectedVariantId;
        public int SelectedVariantId
        {
            get { return _selectedVariantId; }
            set
            {
                _selectedVariantId = value;
                OnPropertyChanged();
            }
        }

        //private GameStoreDataService _dataservice;    

        //private Inventory _selectedInventory;
        //private Product _selectedProduct;

        public void fillComboBoxType()
        {
            var list = _dao.fillTfgsvType();

            foreach (var item in list)
            {
                cmbType.Add(item.Key, item.Value);
            }

        }

        public void fillComboBoxFamilie()
        {
            var list = _dao.fillTfgsvFamilie(_selectedTypeId);

            foreach (var item in list)
            {
                cmbFamilie.Add(item.Key, item.Value);
            }

        }

        public void fillComboBoxGeslacht()
        {
            var list = _dao.fillTfgsvGeslacht(_selectedFamilieId);

            foreach (var item in list)
            {
                cmbGeslacht.Add(item.Key, item.Value);
            }

        }

        public void fillComboBoxSoort()
        {
            var list = _dao.fillTfgsvSoort(_selectedGeslachtId);

            foreach (var item in list)
            {
                cmbSoort.Add(item.Key, item.Value);
            }

        }

        public void fillComboBoxVariant()
        {
            var list = _dao.fillTfgsvVariant(_selectedGeslachtId);

            foreach (var item in list)
            {
                cmbVariant.Add(item.Key, item.Value);
            }

        }

    }
}
