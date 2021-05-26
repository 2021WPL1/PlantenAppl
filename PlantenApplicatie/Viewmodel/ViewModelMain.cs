using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Planten2021.Data;
using Prism.Commands;
using PlantenApplicatie.View;
using GalaSoft.MvvmLight.Command;
using PlantenApplicatie.HelpClasses;
using MvvmHelpers;
using PlantenApplicatie.Viewmodel;

namespace PlantenApplicatie.ViewModel
{
    class ViewModelMain :ViewModelBase
    {
        private ViewModelNameResult viewModelNameResult = new ViewModelNameResult();
        private ViewModelBase _currentViewModel;

        public MyICommand<string> mainNavigationCommand { get; set; }
        public MyICommand<string> mainNavigationCommandSearch { get; set; }
        public ViewModelBase currentViewModel
        {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel, value); }
        }

        private ViewModelRepo _viewModelsRepo = new ViewModelRepo();



        public ViewModelMain()
        {
            mainNavigationCommand = new MyICommand<string>(this._onNavigationChanged);
            mainNavigationCommandSearch = new MyICommand<string>(this._onNavigationChangedSearch);
            //  dialogService.ShowMessageBox(this, "", "");


        }

        private void _onNavigationChanged(string userControlName)
        {
            this.currentViewModel = this._viewModelsRepo.GetViewModel(userControlName);
        }
        private void _onNavigationChangedSearch(string userControlName)
        {
            this.currentViewModel = this._viewModelsRepo.GetViewModel(userControlName);
            viewModelNameResult.BtnZoeken();


        }

    }
}
