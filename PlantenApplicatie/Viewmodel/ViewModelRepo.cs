using System;
using System.Collections.Generic;
using System.Text;
using Planten2021.Data;
using PlantenApplicatie.ViewModel;

namespace PlantenApplicatie.Viewmodel
{
   
        public class ViewModelRepo
        {
            private Dictionary<string, ViewModelBase> _viewModels = new Dictionary<string, ViewModelBase>();
         

            public ViewModelRepo()
            {
                //hier een extra lijn code per user control
                _viewModels.Add("VIEWNAME", new ViewModelNameResult());
                _viewModels.Add("VIEWHABITAT", new ViewModelHabitat());
                _viewModels.Add("VIEWRESULT", new ViewModelResult());
                _viewModels.Add("VIEWBLOOM", new ViewModelBloom());
                _viewModels.Add("VIEWGROW", new ViewModelGrow());
                _viewModels.Add("VIEWGROOMING", new ViewModelGrooming());
                _viewModels.Add("VIEWAPPEARANCE", new ViewModelAppearance());
        }
            public ViewModelBase GetViewModel(string modelName)
            {
                ViewModelBase result;
                var ok = this._viewModels.TryGetValue(modelName, out result);
                return ok ? result : null;
            }
        }
   
}
