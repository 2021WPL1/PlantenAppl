using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight.Ioc;
using Planten2021.Data;
using PlantenApplicatie.Services.Interfaces;
using PlantenApplicatie.ViewModel;

namespace PlantenApplicatie.Viewmodel
{

    public class ViewModelRepo
    {   //singleton pattern
        private static SimpleIoc iocc = SimpleIoc.Default;
        private static ViewModelRepo instance;

        private Dictionary<string, ViewModelBase> _viewModels = new Dictionary<string, ViewModelBase>();
       
        private static IServiceProvider _serviceProvider;
        private static ISearchService _searchService = iocc.GetInstance<ISearchService>();
        
        public static ViewModelRepo Instance()
        {
            return instance;
        }
        public static void CreateInstance()
        {
            instance = new ViewModelRepo();
        }
        private ViewModelNameResult viewModelNameResult = new ViewModelNameResult(_searchService);
        private ViewModelHabitat viewModelHabitat = new ViewModelHabitat();
        private ViewModelBloom viewModelBloom = new ViewModelBloom();
        private ViewModelGrow viewModelGrow = new ViewModelGrow();
        private ViewModelAppearance viewModelAppearance = new ViewModelAppearance();
        private ViewModelGrooming viewModelGrooming = new ViewModelGrooming();

        private ViewModelRepo()
        {
            //hier een extra lijn code per user control
            _viewModels.Add("VIEWNAME", viewModelNameResult);
            _viewModels.Add("VIEWHABITAT", viewModelHabitat);
            _viewModels.Add("VIEWBLOOM", viewModelBloom);
            _viewModels.Add("VIEWGROW", viewModelGrow);
            _viewModels.Add("VIEWAPPEARANCE", viewModelAppearance);
            _viewModels.Add("VIEWGROOMING",viewModelGrooming);
        }
        //
        public ViewModelBase GetViewModel(string modelName)
        {
            ViewModelBase result;
            var ok = this._viewModels.TryGetValue(modelName, out result);
            return ok ? result : null;
        }
    }

}
