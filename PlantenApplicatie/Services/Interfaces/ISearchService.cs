using Planten2021.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PlantenApplicatie.Services.Interfaces
{
    public interface ISearchService
    {
       
        //Button command methods
        void Reset();
        void ApplyFilters();
        public void FillComboBoxType(ObservableCollection<TfgsvType> cmbTypesCollection);
    }
}
