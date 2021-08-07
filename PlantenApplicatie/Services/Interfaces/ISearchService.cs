using Planten2021.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Media;

namespace PlantenApplicatie.Services.Interfaces
{
    public interface ISearchService
    {
        void fillComboBoxType(ObservableCollection<TfgsvType> cmbTypeCollection);
        void fillComboBoxFamilie(TfgsvType selectedType, ObservableCollection<TfgsvFamilie> cmbFamilieCollection);
        void fillComboBoxGeslacht(TfgsvFamilie selectedFamilie, ObservableCollection<TfgsvGeslacht> cmbGeslachtCollection);
        void fillComboBoxSoort(TfgsvGeslacht selectedGeslacht, ObservableCollection<TfgsvSoort> cmbSoortCollection);
        void fillComboBoxVariant(ObservableCollection<TfgsvVariant> cmbVariantCollection);
        void fillComboBoxRatioBloeiBlad(ObservableCollection<Fenotype> cmbRatioBladBloeiCollection);
        Plant SetSelectedPlant(Plant selectedPlantResult);
        Plant ReturnSelectedPlant();
        string UpdateLoggedInMessage();
        void FillDetailPlantResult(ObservableCollection<string> detailsSelectedPlant, Plant SelectedPlantInResult);

        ImageSource GetImageLocation(string ImageCatogrie, Plant SelectedPlantInResult);


        List<Plant> ApplyFilter(TfgsvType selectedType, TfgsvFamilie selectedFamilie, TfgsvGeslacht selectedGeslacht,
            TfgsvSoort selectedSoort, TfgsvVariant selectedVariant, string selectedNederlandseNaam, string selectedRatioBloeiBlad);

        //void Reset(ObservableCollection<Plant> filteredPlantResults, ObservableCollection<TfgsvType> cmbTypes,
        //    ObservableCollection<TfgsvFamilie> cmbFamilies, ObservableCollection<TfgsvGeslacht> cmbGeslacht,
        //    ObservableCollection<TfgsvSoort> cmbSoort, ObservableCollection<TfgsvVariant> cmbVariant,
        //    ObservableCollection<Fenotype> cmbRatioBladBloei, string selectedNederlandseNaam, TfgsvType selectedType,
        //    TfgsvFamilie selectedFamilie, TfgsvGeslacht selectedGeslacht
        //);


    }
}
