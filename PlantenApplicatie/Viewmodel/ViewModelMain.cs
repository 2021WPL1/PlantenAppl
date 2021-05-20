using Planten2021.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.RightsManagement;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using PlantenApplicatie.HelpClasses;
using PlantenApplicatie.Viewmodel;
using Prism.Commands;

namespace PlantenApplicatie.ViewModel
{
    class ViewModelMain : ViewModelBase
    {


        private ViewModelBase _currentViewModel;

        public MyICommand<string> mainNavigationCommand { get; set; }

        

        public ViewModelBase currentViewModel
        {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel, value); }
        }

        private ViewModelRepo _viewModelsRepo = new ViewModelRepo();



        public ViewModelMain()
        {
            mainNavigationCommand = new MyICommand<string>(this._onNavigationChanged);
            //  dialogService.ShowMessageBox(this, "", "");
           

        }

      

        private void _onNavigationChanged(string userControlName)
        {
            //execute query
  if (userControlName == "VIEWRESULT")
            { 
                //singleton om boodschappen to broadcasten
                Messenger.Default.Send<PlantSearchAction>( new PlantSearchAction() );
            }
            this.currentViewModel = this._viewModelsRepo.GetViewModel(userControlName);
          


        }

    }


}
