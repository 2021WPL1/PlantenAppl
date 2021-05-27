using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using Planten2021.Data;
using Planten2021.Domain.Models;
using PlantenApplicatie.HelpClasses;
using PlantenApplicatie.View;
using PlantenApplicatie.View.UserControls;
using PlantenApplicatie.ViewModel;
using Prism.Commands;
using PlantenApplicatie.View.UserControls;

namespace PlantenApplicatie.Viewmodel
{
    public class ViewModelNameResult : ViewModelBase
    {
        private DAO _dao;
        //private ViewModelData _viewModelData;

        public ViewModelNameResult()
        {

            this._dao = DAO.Instance();
            //this._viewModelData = ViewModelData.Instance();

            //Observable Collections 
            ////Obserbable collections to fill with the necessary objects to show in the comboboxes
            cmbTypes = new ObservableCollection<TfgsvType>();
            cmbFamilies = new ObservableCollection<TfgsvFamilie>();
            cmbGeslacht = new ObservableCollection<TfgsvGeslacht>();
            cmbSoort = new ObservableCollection<TfgsvSoort>();
            cmbVariant = new ObservableCollection<TfgsvVariant>();
            cmbRatioBladBloei = new ObservableCollection<Fenotype>();

            ////Observable Collections to bind to listboxes
            filteredPlantResults = new ObservableCollection<Plant>();
            detailsSelectedPlant = new ObservableCollection<string>();

            //ICommands
            ////These will be used to bind our buttons in the xaml and to give them functionality
            SearchCommand = new DelegateCommand(ApplyFilter);
            ResetCommand = new DelegateCommand(Reset);

            //These comboboxes will already be filled with data on startup
            fillComboBoxType();
            fillComboBoxFamilie();
            fillComboBoxGeslacht();
            fillComboBoxSoort();
            fillComboBoxVariant();
            fillComboBoxRatioBloeiBlad();
        }


        #region Fill result test
        public void FillPlantResult()
        {
            var list = _dao.getAllPlants();

            foreach (var item in list)
            {
                filteredPlantResults.Add(item);
            }
        }
        #endregion

        //Observable collections
        ////Bind to comboboxes
        public ObservableCollection<TfgsvType> cmbTypes { get; set; }
        public ObservableCollection<TfgsvFamilie> cmbFamilies { get; set; }
        public ObservableCollection<TfgsvGeslacht> cmbGeslacht { get; set; }
        public ObservableCollection<TfgsvSoort> cmbSoort { get; set; }
        public ObservableCollection<TfgsvVariant> cmbVariant { get; set; }
        public ObservableCollection<Fenotype> cmbRatioBladBloei { get; set; }

        ////Bind to ListBoxes
        public ObservableCollection<Plant> filteredPlantResults { get; set; }
        public ObservableCollection<String> detailsSelectedPlant { get; set; }
        ////


        #region icommands

        //ICommands
        public ICommand SearchCommand { get; set; }
        public ICommand ResetCommand { get; set; }

        #endregion

        #region Selected Item variables for each combobox

        private TfgsvType _selectedType;

        public TfgsvType SelectedType
        {
            get { return _selectedType; }
            set
            {
                _selectedType = value;

                cmbFamilies.Clear();
                cmbGeslacht.Clear();
                cmbSoort.Clear();
                cmbVariant.Clear();

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


                cmbGeslacht.Clear();
                cmbSoort.Clear();
                cmbVariant.Clear();

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



                cmbSoort.Clear();
                cmbVariant.Clear();

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

                cmbVariant.Clear();

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

        private string _selectedNederlandseNaam;

        public string SelectedNederlandseNaam
        {
            get { return _selectedNederlandseNaam; }
            set
            {
                if (SelectedNederlandseNaam == "")
                {
                    _selectedNederlandseNaam = null;
                }
                else
                {
                    _selectedNederlandseNaam = value;
                }

                OnPropertyChanged();
            }
        }

        //This will update the selected plant in the result listbox
        //This will be used to show the selected plant details
        private Plant _selectedPlantInResult;

        public Plant SelectedPlantInResult
        {
            get
            {
                return _selectedPlantInResult;
            }
            set
            {
                _selectedPlantInResult = value;
                OnPropertyChanged();
                fillDetailPlantResult();
            }
        }
        #endregion

        //#region Fill combobox methods


        #region Fill combobox methods

        //Smplifiy method so that the words are more presentable
        //A function that takes a string, puts it to lowercase, 
        //changes all the ' and " chars and replaces them by a space
        //next it deletes al the spaces and returns the string.
        public string Simplify(string stringToSimplify)
        {
            // Door dictionary moeten we een string simplifyen zo dat we deze kunnen gebruiken
            string answer = stringToSimplify.Replace(",", "").Replace("'", "").Replace("__", "");
            answer = String.Concat(answer.Where(c => !Char.IsWhiteSpace(c)));
            return answer;
        }

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

            var list = new List<TfgsvFamilie>(); /*Enumerable.Empty<TfgsvFamilie>().AsQueryable();*/

            //use the typeId, selected in the combobox to filter the list and load the remaining plant families in the family combobox
            // checking if selected type is selected to prevent null exception
            if (SelectedType != null)
            {
                // Requesting te list of families 
                list = _dao.fillTfgsvFamilie(Convert.ToInt32(SelectedType.Planttypeid)).ToList();

            }
            else
            {
                // Requesting te list of families  with 0 because there is noting selected in the combobox of type.
                list = _dao.fillTfgsvFamilie(0).ToList();
            }


            // clearing te content of te combobox of familie
            cmbFamilies.Clear();
            // a list to add type that have been added to the combobox. this is used for preventing two of the same type in the combo box
            var ControleList = new List<string>();
            //adding or list to the combobox
            foreach (var item in list)
            {
                if (!ControleList.Contains(item.Familienaam))
                {
                    cmbFamilies.Add(item);
                    ControleList.Add(item.Familienaam);
                }
            }
        }


        public void fillComboBoxGeslacht()
        {

            var list = Enumerable.Empty<TfgsvGeslacht>().AsQueryable();

            //use the FamilieId, selected in the combobox to filter the list and load the remaining plant geslacht in the geslacht combobox
            // checking if selected geslacht is selected to prevent null exception
            if (SelectedFamilie != null)
            {
                // Requesting te list of geslacht 
                list = _dao.fillTfgsvGeslacht(Convert.ToInt32(SelectedFamilie.FamileId));
            }
            else
            {
                // Requesting te list of Geslacht  with 0 because there is noting selected in the combobox of type.
                list = _dao.fillTfgsvGeslacht(0);
            }

            // clearing te content of te combobox of geslacht
            cmbGeslacht.Clear();
            // a list to add type that have been added to the combobox. this is used for preventing two of the same type in the combo box
            var ControleList = new List<string>();
            //adding or list to the combobox
            foreach (var item in list)
            {

                if (!ControleList.Contains(item.Geslachtnaam))
                {
                    cmbGeslacht.Add(item);
                    ControleList.Add(item.Geslachtnaam);
                }
            }

        }

        public void fillComboBoxSoort()
        {
            var list = Enumerable.Empty<TfgsvSoort>().AsQueryable();

            //use the GeslachtId, selected in the combobox to filter the list and load the remaining plant Soort in the Soort combobox
            // checking if selected Soort is selected to prevent null exception
            if (SelectedGeslacht != null)
            {
                // Requesting te list of Soort 
                list = _dao.fillTfgsvSoort(Convert.ToInt32(SelectedGeslacht.GeslachtId));
            }
            else
            {
                // Requesting te list of Soort  with 0 because there is noting selected in the combobox of type.
                list = _dao.fillTfgsvSoort(0);
            }
            // clearing te content of te combobox of Soort
            cmbSoort.Clear();
            // a list to add type that have been added to the combobox. this is used for preventing two of the same type in the combo box
            var ControleList = new List<string>();
            //adding or list to the combobox
            foreach (var item in list)
            {
                if (!ControleList.Contains(item.Soortnaam))
                {
                    cmbSoort.Add(item);
                    ControleList.Add(item.Soortnaam);
                }
            }
        }

        public void fillComboBoxVariant()
        {

            // Requesting te list of Variant  with 0 because there is noting selected in the combobox of type.
            var list = _dao.fillTfgsvVariant();
            // clearing te content of te combobox of Variant
            cmbVariant.Clear();
            // a list to add type that have been added to the combobox. this is used for preventing two of the same type in the combo box
            var ControleList = new List<string>();
            //adding or list to the combobox
            foreach (var item in list)
            {
                if (!ControleList.Contains(item.Variantnaam))
                {
                    ControleList.Add(item.Variantnaam);
                    Simplify(item.Variantnaam);
                    cmbVariant.Add(item);

                }
            }
        }

        public void fillComboBoxRatioBloeiBlad()
        {
            //not currently used in the cascade search
            //will be adjusted later (dao)
            var list = _dao.fillFenoTypeRatioBloeiBlad();
            // a list to add type that have been added to the combobox. this is used for preventing two of the same type in the combo box
            var ControleList = new List<string>();
            //adding or list to the combobox
            foreach (var item in list)
            {
                if (!ControleList.Contains(item.RatioBloeiBlad))
                {
                    cmbRatioBladBloei.Add(item);
                    ControleList.Add(item.RatioBloeiBlad);
                }
            }
        }

        #endregion

        #region Fill plantDetail listbox

        public void fillDetailPlantResult()
        {
            detailsSelectedPlant.Clear();
            //Every property of the selected plant will be added to the OC
            //Now when I bind it to the list in the xaml, they will be displayed
            if (SelectedPlantInResult != null)
            {
                //Add every available plant property to the OC
                ////start with the properties consisting of a single value
                ////
                ////TOE TE VOEGEN FOUTAFHANDELING -> als een bepaalde property niet aanwezig is: niet toevoegen.
                ////(? -> PlantId, typeId, familieId, Geslachtid, soortId, variantId
                detailsSelectedPlant.Add("Plant Id: " + SelectedPlantInResult.PlantId);
                detailsSelectedPlant.Add("Nederlandse naam: " + SelectedPlantInResult.NederlandsNaam);
                detailsSelectedPlant.Add("Wetenschappelijke naam: " + SelectedPlantInResult.Fgsv);
                detailsSelectedPlant.Add("Type: " + SelectedPlantInResult.Type);
                detailsSelectedPlant.Add("Familie: " + SelectedPlantInResult.Familie);
                detailsSelectedPlant.Add("Geslacht: " + SelectedPlantInResult.Geslacht);
                detailsSelectedPlant.Add("Soort: " + SelectedPlantInResult.Soort);
                detailsSelectedPlant.Add("Variant: " + SelectedPlantInResult.Variant);
                detailsSelectedPlant.Add("Minimale plantdichtheid: " + SelectedPlantInResult.PlantdichtheidMin);
                detailsSelectedPlant.Add("Maximale plantdichtheid: " + SelectedPlantInResult.PlantdichtheidMax);
                detailsSelectedPlant.Add("status: " + SelectedPlantInResult.Status);
                detailsSelectedPlant.Add("Id Access: " + SelectedPlantInResult.IdAccess);

                //the following properties consist of multiple values, use a foreach
                ////Abiotiek
                
                foreach(var item in SelectedPlantInResult.Abiotiek)
                {
                    if (SelectedPlantInResult.PlantId == item.PlantId)
                    {
                        detailsSelectedPlant.Add("Antagonische omgeving: " + item.AntagonischeOmgeving);
                        detailsSelectedPlant.Add("Bezonning: " + item.Bezonning);
                        detailsSelectedPlant.Add("Grondsoort: " + item.Grondsoort);
                        detailsSelectedPlant.Add("Vochtbehoefte: " + item.Vochtbehoefte);
                        detailsSelectedPlant.Add("Voedingsbehoefte" + item.Voedingsbehoefte);
                    }
                  
                }
                //AbiotiekMulti

            }

        }

        #endregion
        #region Methods to use in our DelegateCommands

        #region ResetFunction

        public void Reset()
        {

            filteredPlantResults.Clear();

            cmbTypes.Clear();
            cmbFamilies.Clear();
            cmbGeslacht.Clear();
            cmbSoort.Clear();
            cmbVariant.Clear();
            cmbRatioBladBloei.Clear();
            SelectedNederlandseNaam = null;


            fillComboBoxType();
            fillComboBoxFamilie();
            fillComboBoxGeslacht();
            fillComboBoxSoort();
            fillComboBoxVariant();
            fillComboBoxRatioBloeiBlad();
        }

        #endregion

        #region SearchFunction

        public void ApplyFilter()
        {

            var listPlants = _dao.getAllPlants();

            if (SelectedType != null)
            {

                foreach (var item in listPlants.ToList())
                {

                    if (item.TypeId != SelectedType.Planttypeid)
                    {
                        listPlants.Remove(item);
                    }
                }
            }
            if (SelectedFamilie != null)
            {

                foreach (var item in listPlants.ToList())
                {

                    if (item.FamilieId != SelectedFamilie.FamileId)
                    {
                        listPlants.Remove(item);
                    }
                }
            }
            if (SelectedGeslacht != null)
            {

                foreach (var item in listPlants.ToList())
                {

                    if (item.GeslachtId != SelectedGeslacht.GeslachtId)
                    {
                        listPlants.Remove(item);
                    }
                }
            }
            if (SelectedSoort != null)
            {

                foreach (var item in listPlants.ToList())
                {

                    if (item.SoortId != SelectedSoort.Soortid)
                    {
                        listPlants.Remove(item);
                    }
                }
            }
            if (SelectedVariant != null)
            {

                foreach (var item in listPlants.ToList())
                {

                    if (item.VariantId != null)
                    {

                        if (item.VariantId != SelectedVariant.VariantId)
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

            if (SelectedNederlandseNaam != null)
            {
                foreach (var item in listPlants.ToList())
                {

                    if (item.NederlandsNaam != null)
                    {
                        if (!item.NederlandsNaam.Contains(SelectedNederlandseNaam))
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

                                    listPlants.Remove(item);
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
            //Clear observable collection everytime the searchbutton is clicked
            filteredPlantResults.Clear();

            //The listPlants is now completely filtered.
            //Add every listPlants plantobject to our observable collection
            foreach (var item in listPlants)
            {
                filteredPlantResults.Add(item);
            }
        }

        #endregion

        #endregion
    }
}

