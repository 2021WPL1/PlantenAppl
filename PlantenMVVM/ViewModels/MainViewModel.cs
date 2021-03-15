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

        //string als type gebruiken in de OC om de comboboxvulling makkelijker te maken
        public ObservableCollection<string> tfgsvTypes { get; set; }
        public ObservableCollection<string> tfgsvFamilies { get; set; }
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
            //TO TRY var collection = new ObservableCollection<KeyValuePair<TKey, TValue>>();
            //To Try myCollection = new ObservableCollection<MyClass>(myDictionary.Values)
            tfgsvTypes = new ObservableCollection<string>();
            tfgsvFamilies = new ObservableCollection<string>();

            //eventueel nog zoeken hoe deze meegegeven kan worden in de constructor
            _plantenDataService = PlantenDataService.Instance();

            typeInComboBox = new DelegateCommand(fillTypeInComboBox);



            //searchCommand = new DelegateCommand(search);

        }
        //methods to call and bind
        public void fillTypeInComboBox()
        {
            //lijst opvragen
            var fillType = _plantenDataService.fillTfgsvType().Values;

            //lijst terug leeg maken
            tfgsvTypes.Clear();
            //elk type wordt aan de list toegevoegd
            //de list wordt gebruikt als ItemsSource voor de combobox type
            foreach (var type in fillType)
            {
                tfgsvTypes.Add(type);
            }

            // alle objecten in combobox plaatsen
            
            //cmbType.ItemsSource = filltype;
            //cmbType.DisplayMemberPath = "Value";
            //cmbType.SelectedValuePath = "Key";
        }
        public void fillComboBoxFamilie(string selectedTypeValue)
        {
            //selected value nemen, in dit geval een string
            //adhv die type string gaan zoeken naar de ID,
            //type ID dan gebruiken 
            // lijst opvragen

            //lijst leegmaken
            tfgsvFamilies.Clear();

            var familie = _plantenDataService.fillTfgsvFamilie(_plantenDataService.searchIdType(selectedTypeValue)).Values;

            foreach(var f in familie)
            {
                tfgsvFamilies.Add(f);
            }

            //var fillFamilie = _plantenDataService.fillTfgsvFamilie();
            // alle objecten in OC plaatsen

        }
    }
}
