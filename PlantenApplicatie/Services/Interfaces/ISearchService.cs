using System.Collections.Generic;
using System.Collections.ObjectModel;
using Planten2021.Domain.Models;

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

        void FillDetailPlantResult(ObservableCollection<string> detailsSelectedPlant, Plant SelectedPlantInResult);
        void FillSingleValuePlantDetails(ObservableCollection<string> detailsSelectedPlant, Plant SelectedPlantInResult);
        void FillDetailsPlantAbiotiek(ObservableCollection<string> detailsSelectedPlant, Plant SelectedPlantInResult);
        void FillDetailsPlantAbiotiekMulti(ObservableCollection<string> detailsSelectedPlant, Plant SelectedPlantInResult);

        void FillDetailsPlantBeheermaand(ObservableCollection<string> detailsSelectedPlant, Plant SelectedPlantInResult);
        void FillDetailsPlantCommensalisme(ObservableCollection<string> detailsSelectedPlant, Plant SelectedPlantInResult);
        void FillDetailsPlantCommensalismeMulti(ObservableCollection<string> detailsSelectedPlant, Plant SelectedPlantInResult);
        void FillExtraEigenschap(ObservableCollection<string> detailsSelectedPlant, Plant SelectedPlantInResult);
        void FillFenotype(ObservableCollection<string> detailsSelectedPlant, Plant SelectedPlantInResult);


        List<Plant> Reset(TfgsvType selectedType, TfgsvFamilie selectedFamilie, TfgsvGeslacht selectedGeslacht,
            TfgsvSoort selectedSoort, TfgsvVariant selectedVariant, string selectedNederlandseNaam, string selectedRatioBloeiBlad);

        List<Plant> ApplyFilter(TfgsvType SelectedtType, TfgsvFamilie SelectedFamilie, TfgsvGeslacht SelectedGeslacht,
            TfgsvSoort SelectedSoort,
            TfgsvVariant SelectedVariant, string SelectedNederlandseNaam, string SelectedRatioBloeiBlad);
    }
}