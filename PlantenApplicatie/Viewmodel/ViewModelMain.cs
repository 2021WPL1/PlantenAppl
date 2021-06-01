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

namespace PlantenApplicatie.ViewModel
{
    public class ViewModelMain :ViewModelBase
    {
        private ViewModelRepo _viewModelsRepo;
        private ViewModelBase _currentViewModel;

        public MyICommand<string> mainNavigationCommand { get; set; }
        public ViewModelBase currentViewModel
        {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel, value); }
        }

        private IloginUserService _loginUserService;
        public ViewModelMain(IloginUserService loginUserService)
        {
            this._loginUserService = loginUserService;
            this._viewModelsRepo = ViewModelRepo.Instance();

            mainNavigationCommand = new MyICommand<string>(this._onNavigationChanged);
            //  dialogService.ShowMessageBox(this, "", "");
        }

        private void _onNavigationChanged(string userControlName)
        {
            this.currentViewModel = this._viewModelsRepo.GetViewModel(userControlName);
        }


    }
}
