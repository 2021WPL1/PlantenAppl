using Planten2021.Data;
using Planten2021.Domain.Models;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace PlantenMVVM.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        //Observable collections
        //objects
        public ObservableCollection<TfgsvType> tfgsvTypes { get; set; }
        //ICommands
        //zoekfunctie binden
        public ICommand searchCommand { get; set; }
        //de types in de combobox in de stoppen
        public ICommand typeInComboBox { get; set; }
        //DAO
        private PlantenDataService _plantenDataService { get; set; }

        public MainViewModel()
        {
            //Observable Collections
            tfgsvTypes = new ObservableCollection<TfgsvType>();

            //eventueel nog zoeken hoe deze meegegeven kan worden in de constructor
            _plantenDataService = PlantenDataService.Instance();

            typeInComboBox = new DelegateCommand(fillTypeInComboBox);

            //tfgsvFamilies = new ObservableCollection<TfgsvFamilie>();

            //searchCommand = new DelegateCommand(search);

        }

        public void fillTypeInComboBox()
        {
            // lijst opvragen
            var fillType = _plantenDataService.fillTfgsvType();
            tfgsvTypes.Clear();
            foreach (KeyValuePair<long, string> type in fillType)
            {
                // tfgsvTypes.Add(type.Value.);
            }
            // alle objecten in combobox plaatsen
            //cmbType.ItemsSource = filltype;
            //cmbType.DisplayMemberPath = "Value";
            //cmbType.SelectedValuePath = "Key";

        }
    }
}
