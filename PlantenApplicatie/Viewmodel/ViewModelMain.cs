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
using PlantenApplicatie.Services.Interfaces;
using PlantenApplicatie.Viewmodel;
using GalaSoft.MvvmLight.Ioc;

namespace PlantenApplicatie.ViewModel
{
    public class ViewModelMain :ViewModelBase
    {
        private SimpleIoc iocc =
            SimpleIoc.Default;
        private ViewModelRepo _viewModelRepo;

        private ViewModelBase _currentViewModel;

        public MyICommand<string> mainNavigationCommand { get; set; }
        public ViewModelBase currentViewModel
        {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel, value); }
        }

        private IloginUserService _loginUserService;
        private ISearchService _searchService;
        public ViewModelMain(IloginUserService loginUserService, ISearchService searchService)
        {

            this._viewModelRepo = iocc.GetInstance<ViewModelRepo>();
            this._searchService = searchService;
            this._loginUserService = loginUserService;

            mainNavigationCommand = new MyICommand<string>(this._onNavigationChanged);
            //  dialogService.ShowMessageBox(this, "", "");
        }

        private void _onNavigationChanged(string userControlName)
        {
            this.currentViewModel = this._viewModelRepo.GetViewModel(userControlName);
        }
    }
}
