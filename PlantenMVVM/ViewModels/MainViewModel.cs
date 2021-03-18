using Planten2021.Data;
using Planten2021.Domain.Models;
using PlantenMVVM.Models;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        public List<TfgsvType> types { get; set; }

        //ICommands
        //zoekfunctie binden
        //de types in de combobox in de stoppen
        public ICommand typeInComboBox { get; set; }

        //DAO
        private PlantenDataService _plantenDataService { get; set; }

        //het huidige geselecteerde type in de combobox
        public TgsvFilter tgsvFilter { get; set; }

        //private TfgsvType _selectedType;

        //public TfgsvType SelectedType
        //{
        //    get { return _selectedType; }
        //    set
        //    {
        //        _selectedType = value;
        //        //als er een ander item wordt geselecteerd, verandert deze variabele mee
        //        //viewmodelbase code
        //        OnPropertyChanged();
        //    }
        //}

        public MainViewModel()
        {
            //Observable Collections

            //proberen om onze dictionary rechtstreeks te gebruiken in de OCs
            //TO TRY var collection = new ObservableCollection<KeyValuePair<TKey, TValue>>(); NOPE
            //To Try myCollection = new ObservableCollection<MyClass>(myDictionary.Values) NOPE

            tfgsvTypes = new ObservableCollection<string>();
            tfgsvFamilies = new ObservableCollection<string>();

            //eventueel nog zoeken hoe deze meegegeven kan worden in de constructor
            _plantenDataService = PlantenDataService.Instance();

            //deze command waarschijnlijk niet nodig
            //typeInComboBox = new DelegateCommand(fillTypeInComboBox);

            tgsvFilter = new TgsvFilter();
            tgsvFilter.PropertyChanged += TgsvFilter_PropertyChanged;
            types = _plantenDataService.fgsvTypes().ToList();
        }
        //
        private void TgsvFilter_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
         long typeId=   ((TgsvFilter)sender).TypeId;
            //throw new NotImplementedException();
        }

        //methods to call and bind
        public void fillTypeInComboBox()
        {
            //generic maken achteraf
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
        public void fillComboBoxFamilie()
        {
            //selected value nemen, in dit geval een string
            //adhv die type string gaan zoeken naar de ID,
            //type ID dan gebruiken 
            // lijst opvragen

            //lijst leegmaken
            //tfgsvFamilies.Clear();
            //if (_selectedType != null)
            //{
            //    var familie = _plantenDataService.fillTfgsvFamilie(_selectedType.Planttypeid).Values;

            //    foreach (var f in familie)
            //    {
            //        tfgsvFamilies.Add(f);
            //    }
            //}
            //var fillFamilie = _plantenDataService.fillTfgsvFamilie();
            // alle objecten in OC plaatsen

        }
    }
}
