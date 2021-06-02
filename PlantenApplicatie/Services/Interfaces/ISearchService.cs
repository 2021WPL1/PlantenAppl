using Planten2021.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PlantenApplicatie.Services.Interfaces
{
    public interface ISearchService
    {
        //Relay command methods
        void Reset();
        void ApplyFilters();
        
        #region Fill ObservableCollections to fill comboboxes
        //cascade search
        void fillComboBoxType(ObservableCollection<TfgsvType> cmbTypeList);
        void fillComboBoxFamilie(TfgsvType selectedType, ObservableCollection<TfgsvFamilie> cmbFamilieCollection);
        void fillComboBoxGeslacht(TfgsvFamilie selectedFamilie, ObservableCollection<TfgsvGeslacht> cmbGeslachtCollection);
        void fillComboBoxSoort(TfgsvGeslacht selectedGeslacht, ObservableCollection<TfgsvSoort> cmbSoortCollection);
        void fillComboBoxVariant(ObservableCollection<TfgsvVariant> cmbVariantCollection);
        void fillComboBoxRatioBloeiBlad(ObservableCollection<Fenotype> cmbRatioBladBloeiCollection);
        #endregion
    }
}
