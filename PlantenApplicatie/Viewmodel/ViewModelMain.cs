﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
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
using Planten2021.Domain.Models;

namespace PlantenApplicatie.ViewModel
{
    public class ViewModelMain :ViewModelBase
    {
        //geschreven door kenny, adhv een voorbeeld van roy

        private SimpleIoc iocc = SimpleIoc.Default;
        private ViewModelRepo _viewModelRepo;

        private ViewModelBase _currentViewModel;



        public MyICommand<string> mainNavigationCommand { get; set; }
        public ViewModelBase currentViewModel
        {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel, value); }
        }


        public IloginUserService loginUserService;
        public ISearchService _searchService;
        public ViewModelMain(IloginUserService loginUserService, ISearchService searchService)
        {
            loggedInMessage = loginUserService.LoggedInMessage();
            //loggedInMessage += $" Geselecteerde plant: {SelectedPlant.Geslacht}";
            this._viewModelRepo = iocc.GetInstance<ViewModelRepo>();
            this.loginUserService = loginUserService;
            _searchService = searchService;

            mainNavigationCommand = new MyICommand<string>(this._onNavigationChanged);
            //  dialogService.ShowMessageBox(this, "", "");
        }

        private string _loggedInMessage { get; set; }
        public string loggedInMessage
        {
            get
            {
                return _loggedInMessage;
            }
            set
            {
                _loggedInMessage = value;

                RaisePropertyChanged("loggedInMessage");
            }
        }

        private void _onNavigationChanged(string userControlName)
        {
            this.currentViewModel = this._viewModelRepo.GetViewModel(userControlName);
            Plant selectedPlant = _searchService.ReturnSelectedPlant();
            if (selectedPlant != null)
            {
                MessageBox.Show(selectedPlant.Geslacht);
            }
           
        }
    }
}
