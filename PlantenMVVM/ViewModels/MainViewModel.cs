using System;
using System.Collections.Generic;
using System.Text;

namespace PlantenMVVM.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        //Observable collections
        //objects
        public ObservableCollection<TfgsvFamilie> tfgsvFamilies { get; set; }

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
