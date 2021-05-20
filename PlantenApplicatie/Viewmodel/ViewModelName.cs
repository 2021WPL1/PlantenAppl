using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Planten2021.Data;
using Planten2021.Domain.Models;
using PlantenApplicatie.View.UserControls;
using PlantenApplicatie.ViewModel;
using Prism.Commands;

namespace PlantenApplicatie.Viewmodel
{
    public class ViewModelName : ViewModelBase
    {
        private DAO _dao;


        public ViewModelName()
        {

            this._dao = DAO.Instance();

            //Observable Collections 
            ////Obserbable collections to fill with the necessary objects to show in our comboboxes
            cmbTypes = new ObservableCollection<TfgsvType>();
            cmbFamilies = new ObservableCollection<TfgsvFamilie>();
            cmbGeslacht = new ObservableCollection<TfgsvGeslacht>();
            cmbSoort = new ObservableCollection<TfgsvSoort>();
            cmbVariant = new ObservableCollection<TfgsvVariant>();
            cmbRatioBladBloei = new ObservableCollection<Fenotype>();

            //ICommands
            //SearchCommand = new DelegateCommand(BtnZoeken);

            fillComboBoxType();
            //fillComboBoxFamilie();
            //fillComboBoxGeslacht();
            //fillComboBoxSoort();
            //fillComboBoxVariant();
            fillComboBoxRatioBloeiBlad();

        }


        //Observable collections
        public ObservableCollection<TfgsvType> cmbTypes { get; set; }
        public ObservableCollection<TfgsvFamilie> cmbFamilies { get; set; }
        public ObservableCollection<TfgsvGeslacht> cmbGeslacht { get; set; }
        public ObservableCollection<TfgsvSoort> cmbSoort { get; set; }
        public ObservableCollection<TfgsvVariant> cmbVariant { get; set; }
        public ObservableCollection<Fenotype> cmbRatioBladBloei { get; set; }

        #region MyRegion

        //ICommands
        public ICommand SearchCommand { get; set; }

        #endregion



        private TfgsvType _selectedType;

        public TfgsvType SelectedType
        {
            get { return _selectedType; }
            set
            {
                _selectedType = value;
                fillComboBoxFamilie();
                OnPropertyChanged();
            }
        }

        private TfgsvFamilie _selectedFamilie;

        public TfgsvFamilie SelectedFamilie
        {
            get { return _selectedFamilie; }
            set
            {
                _selectedFamilie = value;
                fillComboBoxGeslacht();
                OnPropertyChanged();
            }
        }

        private TfgsvGeslacht _selectedGeslacht;

        public TfgsvGeslacht SelectedGeslacht
        {
            get { return _selectedGeslacht; }
            set
            {
                _selectedGeslacht = value;
                fillComboBoxSoort();
                OnPropertyChanged();
            }
        }

        private TfgsvSoort _selectedSoort;

        public TfgsvSoort SelectedSoort
        {
            get { return _selectedSoort; }
            set
            {
                _selectedSoort = value;
                fillComboBoxVariant();
                OnPropertyChanged();
            }
        }

        private TfgsvVariant _selectedVariant;

        public TfgsvVariant SelectedVariant
        {
            get { return _selectedVariant; }
            set
            {
                _selectedVariant = value;
                OnPropertyChanged();
            }
        }

        private string _selectedRatioBloeiBlad;

        public string SelectedRatioBloeiBlad
        {
            get { return _selectedRatioBloeiBlad; }
            set
            {
                _selectedRatioBloeiBlad = value;
                OnPropertyChanged();
            }
        }

        #region Fill combobox methods


        public void fillComboBoxType()
        {
            var list = _dao.fillTfgsvType();

            foreach (var item in list)
            {
                cmbTypes.Add(item);
            }
        }

        public void fillComboBoxFamilie()
        {
            //use the typeId, selected in the combodbox to filter the list load the remaining plant families in the family combobox
            var list = _dao.fillTfgsvFamilie(Convert.ToInt32(SelectedType.Planttypeid));

            cmbFamilies.Clear();

            foreach (var item in list)
            {
                cmbFamilies.Add(item);
            }

        }

        public void fillComboBoxGeslacht()
        {
            var list = _dao.fillTfgsvGeslacht(Convert.ToInt32(SelectedFamilie.FamileId));
            
            cmbGeslacht.Clear();
            
            foreach (var item in list)
            {
                cmbGeslacht.Add(item);
            }

        }

        public void fillComboBoxSoort()
        {
            var list = _dao.fillTfgsvSoort(Convert.ToInt32(SelectedGeslacht.GeslachtId));

            cmbSoort.Clear();

            foreach (var item in list)
            {
                cmbSoort.Add(item);
            }

        }

        public void fillComboBoxVariant()
        {
            var list = _dao.fillTfgsvVariant(Convert.ToInt32(SelectedSoort.Soortid));

            cmbVariant.Clear();

            foreach (var item in list)
            {
                cmbVariant.Add(item);
            }
        }

        public void fillComboBoxRatioBloeiBlad()
        {

            var list = _dao.fillFenoTypeRatioBloeiBlad();

            foreach (var item in list)
            {
                cmbRatioBladBloei.Add(item);
            }

        }

        #endregion

        #region Methods to use in our DelegateCommands

        //private void BtnZoeken()
        //{

        //    var listPlants = _dao.getAllPlants();


        //    if (SelectedType != null)
        //    {

        //        foreach (var item in listPlants.ToList())
        //        {

        //            if (item.TypeId != SelectedType.Planttypeid)
        //            {
        //                listPlants.Remove(item);
        //            }
        //        }
        //    }
        //    if (SelectedFamilie != null)
        //    {

        //        foreach (var item in listPlants.ToList())
        //        {

        //            if (item.FamilieId != SelectedFamilie.FamileId)
        //            {
        //                listPlants.Remove(item);
        //            }
        //        }
        //    }
        //    if (SelectedGeslacht != null)
        //    {

        //        //foreach (var item in listPlants.ToList())
        //        //{

        //        //    if (item.Geslacht != SelectedGeslacht.)
        //        //    {
        //        //        listPlants.Remove(item);
        //        //    }
        //        //}
        //    }
        //    if (SelectedSoort != null)
        //    {

        //        foreach (var item in listPlants.ToList())
        //        {

        //            if (item.SoortId != SelectedSoort.Soortid)
        //            {
        //                listPlants.Remove(item);
        //            }
        //        }
        //    }
        //    if (SelectedVariant != null)
        //    {

        //        foreach (var item in listPlants.ToList())
        //        {

        //            if (item.VariantId != null)
        //            {

        //                if (item.VariantId != SelectedVariant.VariantId)
        //                {

        //                    listPlants.Remove(item);
        //                }
        //            }
        //            else if (item.VariantId == null)
        //            {
        //                listPlants.Remove(item);
        //            }

        //        }
        //    }

        //    //if (SelectedNederlandseNaam != string.Empty)
        //    //{
        //    //    foreach (var item in listPlants.ToList())
        //    //    {

        //    //        if (item.NederlandsNaam != null)
        //    //        {
        //    //            if (item.NederlandsNaam != SelectedNederlandseNaam)
        //    //            {
        //    //                listPlants.Remove(item);
        //    //            }

        //    //        }
        //    //        else if (item.NederlandsNaam == null)
        //    //        {
        //    //            listPlants.Remove(item);
        //    //        }

        //    //    }
        //    //}

        //    //if (SelectedRatioBloeiBlad != null)
        //    //{


        //    //    foreach (var item in listPlants.ToList())
        //    //    {
        //    //        if (item.Fenotype.Count != 0)
        //    //        {
        //    //            foreach (var itemFenotype in item.Fenotype)
        //    //            {

        //    //                if (itemFenotype.RatioBloeiBlad != null || itemFenotype.RatioBloeiBlad != String.Empty)
        //    //                {

        //    //                    if (itemFenotype.RatioBloeiBlad != SelectedRatioBloeiBlad)
        //    //                    {

        //    //                        //listPlants.Remove(item);
        //    //                        listPlants.Remove(item);
        //    //                    }
        //    //                }
        //    //                else
        //    //                {
        //    //                    listPlants.Remove(item);
        //    //                }
        //    //            }
        //    //        }
        //    //        else
        //    //        {
        //    //            listPlants.Remove(item);
        //    //        }

        //    //    }

        //    }

        //}


        #endregion
    }
}

