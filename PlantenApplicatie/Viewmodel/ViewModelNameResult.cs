using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using Planten2021.Data;
using Planten2021.Domain.Models;
using PlantenApplicatie.Services;
using PlantenApplicatie.Services.HelpClasses;
using PlantenApplicatie.Services.Interfaces;
using PlantenApplicatie.ViewModel;
using Prism.Commands;


namespace PlantenApplicatie.Viewmodel
{
    public class ViewModelNameResult : ViewModelBase
    {
        //private ServiceProvider _serviceProvider;
        private static SimpleIoc iocc = SimpleIoc.Default;
        private ISearchService _searchService = iocc.GetInstance<ISearchService>();

        public ViewModelNameResult(ISearchService searchService)
        {

            this._searchService = searchService;
            //_searchService = new SearchService();

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
            SearchCommand = new RelayCommand(ApplyFilterClick);
            ResetCommand = new RelayCommand(ResetClick);

            //These comboboxes will already be filled with data on startup
            _searchService.fillComboBoxType(cmbTypes);
            _searchService.fillComboBoxFamilie(SelectedType, cmbFamilies);
            _searchService.fillComboBoxGeslacht(SelectedFamilie, cmbGeslacht);
            _searchService.fillComboBoxSoort(SelectedGeslacht, cmbSoort);
            _searchService.fillComboBoxVariant(cmbVariant);
            _searchService.fillComboBoxRatioBloeiBlad(cmbRatioBladBloei);
        }

        #region tussenFunctie voor knoppen met parameters

        public void ResetClick()
        {
            filteredPlantResults.Clear();
            var listPlants = this._searchService.Reset(SelectedType, SelectedFamilie,SelectedGeslacht,SelectedSoort,SelectedVariant,SelectedNederlandseNaam,SelectedRatioBloeiBlad);
            foreach (var item in listPlants)
            {
                filteredPlantResults.Add(item);
            }
        }

        public void ApplyFilterClick()
        {
            filteredPlantResults.Clear();
            var listPlants = this._searchService.ApplyFilter(SelectedType,SelectedFamilie,SelectedGeslacht,SelectedSoort,SelectedVariant,SelectedNederlandseNaam,SelectedRatioBloeiBlad);
            foreach (var item in listPlants)
            {
                filteredPlantResults.Add(item);
            }
        }
        #endregion

        #region Fill result test

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
        public RelayCommand SearchCommand { get; set; }
        public RelayCommand ResetCommand { get; set; }

        #endregion
        //Robin, Owen
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

                _searchService.fillComboBoxFamilie(SelectedType, cmbFamilies);
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

                _searchService.fillComboBoxGeslacht(SelectedFamilie, cmbGeslacht);
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

                _searchService.fillComboBoxSoort(SelectedGeslacht,cmbSoort);
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
            get { return _selectedPlantInResult; }
            set
            {
                _selectedPlantInResult = value;
                FillAllImages();
                OnPropertyChanged();
                _searchService.FillDetailPlantResult(detailsSelectedPlant, SelectedPlantInResult);
            }
        }
                FillDetailPlantResult();
            }
        }

        #endregion

        #region FillImages

        public void FillAllImages()
        {
            ImageBlad = GetImageLocation("blad");
            ImageBloei = GetImageLocation("bloei");
            ImageHabitus = GetImageLocation("habitus");
        }

        public ImageSource GetImageLocation(string ImageCatogrie)
        {
            string location = "";
            if (SelectedPlantInResult != null)
            {
                location = _dao.GetImages(SelectedPlantInResult.PlantId, ImageCatogrie);
            }

            //  var fullFilePath = @"https://images0.persgroep.net/rcs/XUun1kAJgb9KiAVBcZnA9YeZMKM/diocontent/123887379/_fitwidth/763?appId=93a17a8fd81db0de025c8abd1cca1279&quality=0.8";

            if (location != null)
              {
                      BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(location, UriKind.Absolute);
                bitmap.EndInit();

                return bitmap;
              }

              return null;

        }

        private ImageSource _imageBloei;

        public ImageSource ImageBloei
        {
            get { return _imageBloei; }
            set
            {
                _imageBloei = value;
                OnPropertyChanged();
            }
        }



        private ImageSource _imageHabitus;

        public ImageSource ImageHabitus
        {
            get { return _imageHabitus; }
            set
            {
                _imageHabitus = value;
                OnPropertyChanged();
            }
        }

        private ImageSource _imageBlad;

        public ImageSource ImageBlad
        {
            get { return _imageBlad; }
            set
            {
                _imageBlad = value;
                OnPropertyChanged();
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




        #endregion


    }
}

