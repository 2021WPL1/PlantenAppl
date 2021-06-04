using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight.Ioc;
using Planten2021.Data;
using PlantenApplicatie.Services.Interfaces;
using PlantenApplicatie.ViewModel;

namespace PlantenApplicatie.Viewmodel
{
    //geschreven door kenny adhv een voorbeeld van roy
    //herschreven door kenny voor gebruik met ioc
    public class ViewModelRepo
    {   //singleton pattern
        private static SimpleIoc iocc = SimpleIoc.Default;
        //private static ViewModelRepo instance;

        private Dictionary<string, ViewModelBase> _viewModels = new Dictionary<string, ViewModelBase>();
       
        private ViewModelNameResult viewModelNameResult = iocc.GetInstance<ViewModelNameResult>();
        private ViewModelRegister viewModelRegister = iocc.GetInstance<ViewModelRegister>();
        private ViewModelHabitat viewModelHabitat = iocc.GetInstance<ViewModelHabitat>();
        private ViewModelBloom viewModelBloom = iocc.GetInstance<ViewModelBloom>();
        private ViewModelGrow viewModelGrow = iocc.GetInstance<ViewModelGrow>();
        private ViewModelAppearance viewModelAppearance = iocc.GetInstance<ViewModelAppearance>();
        private ViewModelGrooming viewModelGrooming = iocc.GetInstance<ViewModelGrooming>();

        public ViewModelRepo()
        {
            //hier een extra lijn code per user control
            _viewModels.Add("VIEWNAME", viewModelNameResult);
            _viewModels.Add("VIEWHABITAT", viewModelHabitat);
            _viewModels.Add("VIEWBLOOM", viewModelBloom);
            _viewModels.Add("VIEWGROW", viewModelGrow);
            _viewModels.Add("VIEWAPPEARANCE", viewModelAppearance);
            _viewModels.Add("VIEWGROOMING",viewModelGrooming);
            _viewModels.Add("VIEWREGISTER", viewModelRegister);
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
