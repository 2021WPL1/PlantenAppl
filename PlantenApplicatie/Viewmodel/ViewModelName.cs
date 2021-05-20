using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Planten2021.Data;
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
            cmbType = new Dictionary<long, string>();
            cmbFamilie = new Dictionary<long, string>();
            cmbGeslacht = new Dictionary<long, string>();
            cmbSoort = new Dictionary<long, string>();
            cmbVariant = new Dictionary<long, string>();
            cmbRatioBloeiBlad = new Dictionary<long, string>();

            this._dao = DAO.Instance();

            fillComboBoxType();
            fillComboBoxFamilie();
            fillComboBoxGeslacht();
            fillComboBoxSoort();
            fillComboBoxVariant();
            fillComboBoxRatioBloeiBlad();

            searchCommand = new DelegateCommand(BtnZoeken);
        }

        #region Commands

        public ICommand searchCommand { get; set; }

        #endregion

        #region FillComboBoxes


        public Dictionary<long, string> cmbType { get; set; }
        public Dictionary<long, string> cmbFamilie { get; set; }

        public Dictionary<long, string> cmbGeslacht { get; set; }
        public Dictionary<long, string> cmbSoort { get; set; }
        public Dictionary<long, string> cmbVariant { get; set; }

        public Dictionary<long, string> cmbRatioBloeiBlad { get; set; }

        private int _selectedTypeId;
        public int SelectedTypeId
        {
            get { return _selectedTypeId; }
            set
            {
                _selectedTypeId = value; 
                fillComboBoxFamilie();
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
            var list = _dao.fillTfgsvFamilie(SelectedTypeId);

            foreach (var item in list)
            {
                cmbFamilie.Add(item.Key, item.Value);
            }

        }

        public void fillComboBoxGeslacht()
        {
            var list = _dao.fillTfgsvGeslacht(SelectedFamilieId);

            foreach (var item in list)
            {
                cmbGeslacht.Add(item.Key, item.Value);
            }

        }

        public void fillComboBoxSoort()
        {
            var list = _dao.fillTfgsvSoort(SelectedSoortId);

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

        public void fillComboBoxRatioBloeiBlad()
        {
           
            var list = _dao.fillFenoTypeRatioBloeiBlad();
            
            foreach (var item in list)
            {
                cmbRatioBloeiBlad.Add(item.Key, item.Value);
            }
            
        }



        #endregion

        #region Search function

        private string _selectedNederlandseNaam;

        public string SelectedNederlandseNaam
        {
            get { return _selectedNederlandseNaam; }
            set
            {
                _selectedNederlandseNaam = value;
                OnPropertyChanged();
            }
        }
        public string Simplify(string stringToSimplify, string id)
        {
            // Door dictionary moeten we een string simplifyen zo dat we deze kunnen gebruiken
            string answer = stringToSimplify.Replace(id, "").Replace(",", "").Replace("[", "").Replace("]", "").Replace("'", "");
            answer = String.Concat(answer.Where(c => !Char.IsWhiteSpace(c)));
            //answer.Trim();
            return answer;
        }

        private void BtnZoeken()
        {
            
            var listPlants = _dao.getAllPlants();

           
            if (SelectedTypeId != null)
            {

                foreach (var item in listPlants.ToList())
                {

                    if (item.TypeId != SelectedTypeId)
                    {
                        listPlants.Remove(item);
                    }
                }
            }
            if (SelectedFamilieId != null)
            {
                
                foreach (var item in listPlants.ToList())
                {

                    if (item.FamilieId != SelectedFamilieId)
                    {
                        listPlants.Remove(item);
                    }
                }
            }
            if (SelectedGeslachtId!= null)
            {
                
                foreach (var item in listPlants.ToList())
                {

                    if (item.GeslachtId != _selectedGeslachtId)
                    {
                        listPlants.Remove(item);
                    } 
                }
            }
            if (SelectedSoortId != null)
            {
               
                foreach (var item in listPlants.ToList())
                {

                    if (item.SoortId != SelectedSoortId)
                    {
                        listPlants.Remove(item);
                    }
                }
            }
            if (SelectedVariantId != null)
            {
                
                foreach (var item in listPlants.ToList())
                {

                    if (item.VariantId != null)
                    {

                        if (item.VariantId != SelectedVariantId)
                        {

                            listPlants.Remove(item);
                        } 
                    }
                    else if (item.VariantId == null)
                    {
                        listPlants.Remove(item);
                    }

                }
            }

            if (SelectedNederlandseNaam != string.Empty)
            {
                foreach (var item in listPlants.ToList())
                {

                    if (item.NederlandsNaam != null)
                    {
                        if (item.NederlandsNaam != SelectedNederlandseNaam)
                        {
                            listPlants.Remove(item);
                        }

                    } 
                    else if (item.NederlandsNaam == null)
                    {
                        listPlants.Remove(item);
                    }

                }
            }

            if (SelectedRatioBloeiBlad != null)
            {
                

                foreach (var item in listPlants.ToList())
                {
                    if (item.Fenotype.Count != 0)
                    {
                        foreach (var itemFenotype in item.Fenotype)
                        {

                            if (itemFenotype.RatioBloeiBlad != null || itemFenotype.RatioBloeiBlad != String.Empty)
                            {

                                if (itemFenotype.RatioBloeiBlad != SelectedRatioBloeiBlad)
                                {

                                    //listPlants.Remove(item);
                                    listPlants.Remove(item);
                                }
                            }
                            else
                            {
                                listPlants.Remove(item);
                            }
                        }
                    }
                    else
                    {
                        listPlants.Remove(item);
                    }

                }

            }

        }

        #endregion
    }
}
