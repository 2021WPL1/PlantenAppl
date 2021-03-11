using Planten2021.Data;
using Planten2021.Domain.Models;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace PlantenApplicatie.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        //Observable collections
        //objects
        public ObservableCollection<TfgsvFamilie> tfgsvFamilies{get;set;}

        //ICommands
        public ICommand searchCommand { get; set; }
        //DAO
        private PlantenDataService _plantenDataService { get; set; }

        public MainViewModel(PlantenDataService plantenDataService)
        {
            tfgsvFamilies = new ObservableCollection<TfgsvFamilie>();

            searchCommand = new DelegateCommand(search);
            this._plantenDataService = plantenDataService;
        }

        public void search()
        {
           
        }


    }
}
