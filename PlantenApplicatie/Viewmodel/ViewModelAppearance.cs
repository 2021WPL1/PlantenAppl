using PlantenApplicatie.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Planten2021.Data;
using PlantenApplicatie.Services.Interfaces;
using GalaSoft.MvvmLight.Ioc;
using Planten2021.Domain.Models;
using System.Collections.ObjectModel;

namespace PlantenApplicatie.Viewmodel
{
    public class ViewModelAppearance : ViewModelBase
    {

        private static SimpleIoc iocc = SimpleIoc.Default;
        private static IDetailService _detailService = iocc.GetInstance<IDetailService>();
        private static ISearchService _SearchService = iocc.GetInstance<ISearchService>();
        private Plant _selectedPlant;
        private List<FenotypeMulti> _fenoTypeMulti;

        public bool isChecked;

        public ViewModelAppearance(IDetailService detailservice)
        {
            _detailService = detailservice;
            _selectedFenotypeMonth = new List<FenotypeMulti>();
            cboBladHoogte = new ObservableCollection<string>();
            FillCboBladHoogte();
        }

        public ObservableCollection<string> cboBladHoogte { get; set; }


        public Plant SelectedPlant
        {
            get
            {
                _selectedPlant = _SearchService.ReturnSelectedPlant();
                CheckLevensvormen();
                CheckBladvormen();

                return _selectedPlant;

            }

            set
            {
                _selectedPlant = value;
                CheckMonth();
                SetFenoType();
                

                OnPropertyChanged();
            }
        }

        public List<FenotypeMulti> fenoTypeMulti
        {

            get
            {
                _selectedPlant = _SearchService.ReturnSelectedPlant();
                _fenoTypeMulti = _detailService.FilterFenoMulti(_selectedPlant.PlantId);

                return _fenoTypeMulti;
            }

            set
            {
                _fenoTypeMulti = value;

                OnPropertyChanged();
            }
        }

        private List<FenotypeMulti> _selectedFenotypeMonth;

        public List<FenotypeMulti> selectedFenotypeMonth
        {

            get
            {
                _selectedPlant = _SearchService.ReturnSelectedPlant();
                _selectedFenotypeMonth.Clear();
                CheckMonth();

                return _selectedFenotypeMonth;
            }

            set
            {
                _selectedFenotypeMonth = value;

                OnPropertyChanged();
            }
        }

        private Fenotype _selectedFenoType;

        public Fenotype selectedFenoType
        {

            get
            {
                
                return _selectedFenoType;
            }

            set
            {
                _selectedFenoType = value;

                OnPropertyChanged();
            }
        }

        public void FillCboBladHoogte()
        {

            cboBladHoogte.Add("240/250");
            cboBladHoogte.Add("230/239");

            cboBladHoogte.Add("220/229");

            cboBladHoogte.Add("210/219");
            cboBladHoogte.Add("200/209");

            cboBladHoogte.Add("190/199");

            cboBladHoogte.Add("180/189");

            cboBladHoogte.Add("170/179");

            cboBladHoogte.Add("160/169");

            cboBladHoogte.Add("150/159");

            cboBladHoogte.Add("140/149");

            cboBladHoogte.Add("130/139");

            cboBladHoogte.Add("120/129");

            cboBladHoogte.Add("110/119");

            cboBladHoogte.Add("100/109");

            cboBladHoogte.Add("90/99");

            cboBladHoogte.Add("80/89");


            cboBladHoogte.Add("70/79");

            cboBladHoogte.Add("60/69");

            cboBladHoogte.Add("50/59");

            cboBladHoogte.Add("40/49");

            cboBladHoogte.Add("30/39");

            cboBladHoogte.Add("20/29");


            cboBladHoogte.Add("10/19");


            cboBladHoogte.Add("0/9");
        }

        public void SetFenoType()
        {
            _selectedFenoType = _detailService.GetFenoTypes(SelectedPlant.PlantId);
        }

        public void CheckMonth()
        {
            _selectedPlant = _SearchService.ReturnSelectedPlant();
            fenoTypeMulti = _detailService.FilterFenoMulti(_selectedPlant.PlantId);

           
            foreach (var item in _fenoTypeMulti)
            {
                if (SelectedCboMaanden.Contains(item.Maand))
                {
                    _selectedFenotypeMonth.Add(item);
                }
            }

        }

        public void CheckColor()
        {

            //isChecked = true;
            foreach (var item in _selectedFenotypeMonth)
            {
                if (item.Eigenschap == "bladkleur")
                {
                    switch (item.Waarde)
                    {
                        case "zwart":
                            SelectedCheckBoxBladkleurZwart = true;
                            break;
                        case "wit":
                            SelectedCheckBoxBladkleurWit = true;
                            break;
                        case "rosé":
                            SelectedCheckBoxBladkleurRosé = true;
                            break;
                        case "rood":
                            SelectedCheckBoxBladkleurRood = true;
                            break;
                        case "oranje":
                            SelectedCheckBoxBladkleurOranje = true;
                            break;
                        case "lila":
                            SelectedCheckBoxBladkleurLila = true;
                            break;
                        case "grijs":
                            SelectedCheckBoxBladkleurGrijs = true;
                            break;
                        case "groen":
                            SelectedCheckBoxBladkleurGroen = true;
                            break;
                        case "geel":
                            SelectedCheckBoxBladkleurGeel = true;
                            break;
                        case "blauw":
                            SelectedCheckBoxBladkleurBlauw = true;
                            break;
                        case "violet":
                            SelectedCheckBoxBladkleurViolet = true;
                            break;
                        case "paars":
                            SelectedCheckBoxBladkleurPaars = true;
                            break;
                        case "bruin":
                            SelectedCheckBoxBladkleurBruin = true;
                            break;
                        default:
                            break;
                    }
                }
                


            }



        }

        public void CheckBladHoogteMin()
        {
            foreach (var item in _selectedFenotypeMonth)
            {
                if (item.Eigenschap == "bladhoogte_min")
                {
                    switch (item.Waarde)
                    {
                        case "0/9":
                            SelectedCboBladHoogteMin = "0/9";
                            break;
                        case "10/19":
                            SelectedCboBladHoogteMin = "10/19";
                            break;
                        case "20/29":
                            SelectedCboBladHoogteMin = "20/29";
                            break;
                        case "30/39":
                            SelectedCboBladHoogteMin = "30/39";
                            break;
                        case "40/49":
                            SelectedCboBladHoogteMin = "40/49";
                            break;
                        case "50/59":
                            SelectedCboBladHoogteMin = "50/59";
                            break;
                        case "60/69":
                            SelectedCboBladHoogteMin = "60/69";
                            break;
                        case "70/79":
                            SelectedCboBladHoogteMin = "70/79";
                            break;
                        case "80/89":
                            SelectedCboBladHoogteMin = "80/89";
                            break;
                        case "90/99":
                            SelectedCboBladHoogteMin = "90/99";
                            break;
                        case "100/109":
                            SelectedCboBladHoogteMin = "100/109";
                            break;
                        case "110/119":
                            SelectedCboBladHoogteMin = "110/119";
                            break;
                        case "120/129":
                            SelectedCboBladHoogteMin = "120/129";
                            break;
                        case "130/139":
                            SelectedCboBladHoogteMin = "130/139";
                            break;
                        case "140/149":
                            SelectedCboBladHoogteMin = "140/149";
                            break;
                        case "150/159":
                            SelectedCboBladHoogteMin = "150/159";
                            break;
                        case "160/169":
                            SelectedCboBladHoogteMin = "160/169";
                            break;
                        case "170/179":
                            SelectedCboBladHoogteMin = "170/179";
                            break;
                        case "180/189":
                            SelectedCboBladHoogteMin = "180/189";
                            break;
                        case "190/199":
                            SelectedCboBladHoogteMin = "190/199";
                            break;
                        case "200/209":
                            SelectedCboBladHoogteMin = "200/209";
                            break;
                        case "210/219":
                            SelectedCboBladHoogteMin = "210/219";
                            break;
                        case "220/229":
                            SelectedCboBladHoogteMin = "220/229";
                            break;
                        case "230/239":
                            SelectedCboBladHoogteMin = "230/239";
                            break;
                        case "240/250":
                            SelectedCboBladHoogteMin = "240/250";
                            break;

                        default:
                            break;
                    }
                }


            }


        }

        public void CheckBladHoogteMax()
        {
            foreach (var item in _selectedFenotypeMonth)
            {
                if (item.Eigenschap == "bladhoogte_max")
                {
                    switch (item.Waarde)
                    {
                        case "0/9":
                            SelectedCboBladHoogteMax = "0/9";
                            break;
                        case "10/19":
                            SelectedCboBladHoogteMax = "10/19";
                            break;
                        case "20/29":
                            SelectedCboBladHoogteMax = "20/29";
                            break;
                        case "30/39":
                            SelectedCboBladHoogteMax = "30/39";
                            break;
                        case "40/49":
                            SelectedCboBladHoogteMax = "40/49";
                            break;
                        case "50/59":
                            SelectedCboBladHoogteMax = "50/59";
                            break;
                        case "60/69":
                            SelectedCboBladHoogteMax = "60/69";
                            break;
                        case "70/79":
                            SelectedCboBladHoogteMax = "70/79";
                            break;
                        case "80/89":
                            SelectedCboBladHoogteMax = "80/89";
                            break;
                        case "90/99":
                            SelectedCboBladHoogteMax = "90/99";
                            break;
                        case "100/109":
                            SelectedCboBladHoogteMax = "100/109";
                            break;
                        case "110/119":
                            SelectedCboBladHoogteMax = "110/119";
                            break;
                        case "120/129":
                            SelectedCboBladHoogteMax = "120/129";
                            break;
                        case "130/139":
                            SelectedCboBladHoogteMax = "130/139";
                            break;
                        case "140/149":
                            SelectedCboBladHoogteMax = "140/149";
                            break;
                        case "150/159":
                            SelectedCboBladHoogteMax = "150/159";
                            break;
                        case "160/169":
                            SelectedCboBladHoogteMax = "160/169";
                            break;
                        case "170/179":
                            SelectedCboBladHoogteMax = "170/179";
                            break;
                        case "180/189":
                            SelectedCboBladHoogteMax = "180/189";
                            break;
                        case "190/199":
                            SelectedCboBladHoogteMax = "190/199";
                            break;
                        case "200/209":
                            SelectedCboBladHoogteMax = "200/209";
                            break;
                        case "210/219":
                            SelectedCboBladHoogteMax = "210/219";
                            break;
                        case "220/229":
                            SelectedCboBladHoogteMax = "220/229";
                            break;
                        case "230/239":
                            SelectedCboBladHoogteMax = "230/239";
                            break;
                        case "240/250":
                            SelectedCboBladHoogteMax = "240/250";
                            break;

                        default:
                            break;
                    }

                }

            }

        }

        public void CheckBladvormen()
        {
           
                switch (selectedFenoType.Bladvorm)
                {
                    case "naald -en priemvormig":
                        SelectedCheckBoxBladvormenVorm1 = true;
                        break;
                    case "lancetvormig":
                        SelectedCheckBoxBladvormenVorm2 = true;
                        break;
                    case "rond":
                        SelectedCheckBoxBladvormenVorm3 = true;
                        break;
                    case "samengesteld grof":
                        SelectedCheckBoxBladvormenVorm4 = true;
                        break;
                    case "samengesteld verfijnd":
                        SelectedCheckBoxBladvormenVorm5 = true;
                        break;
                                        
                    default:
                        break;
                }


            
        }

        
        public void CheckLevensvormen()
        {
            
                switch (selectedFenoType.Levensvorm)
                {
                    case "Hydrofyten - waterplanten":
                        SelectedCheckBoxLevensvormenVorm1 = true;
                        break;
                    case "Helofyten - winterknoppen onder water, bloeiende planten boven water":
                        SelectedCheckBoxLevensvormenVorm2 = true;
                        break;
                    case "Cryptofyten of Geofyten - winterknoppen onder de grond":
                        SelectedCheckBoxLevensvormenVorm3 = true;
                        break;
                    case "HemiCryptofyten - winterknoppen op of iets onder de grond":
                        SelectedCheckBoxLevensvormenVorm4 = true;
                        break;
                    case "Chamaefyten - winterknoppen tot 50 cm boven de grond":
                        SelectedCheckBoxLevensvormenVorm5 = true;
                        break;
                    case "P¨hanerofyten - winterknoppen minstens 50 cm boven de grond":
                        SelectedCheckBoxLevensvormenVorm6 = true;
                        break;                   

                    default:
                        break;
                }


            
        }


        public void doesItNeedToBeChecked()
        {
            //isChecked = true;

            foreach (var fenotypeMulti in fenoTypeMulti)
            {
                if (fenotypeMulti != null)
                {
                    isChecked = true;
                }

                else
                {
                    isChecked = false;
                }
            }

        }

        private string _selectedCboMaanden;

        public string SelectedCboMaanden
        {
            get { return _selectedCboMaanden; }
            set
            {
                _selectedCboMaanden = value.ToLower();
                CheckMonth();
                CheckColor();
                CheckBladHoogteMin();
                CheckBladHoogteMax();
                OnPropertyChanged();

            }
        }



        //geschreven door christophe op basis van owens code
        #region Binding checkboxen Bladkleur

        private bool _selectedCheckBoxBladkleurZwart;
        public bool SelectedCheckBoxBladkleurZwart
        {
            get { return _selectedCheckBoxBladkleurZwart; }

            set
            {
                _selectedCheckBoxBladkleurZwart = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladkleurWit;
        public bool SelectedCheckBoxBladkleurWit
        {
            get { return _selectedCheckBoxBladkleurWit; }

            set
            {
                _selectedCheckBoxBladkleurWit = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladkleurRosé;
        public bool SelectedCheckBoxBladkleurRosé
        {
            get { return _selectedCheckBoxBladkleurRosé; }

            set
            {
                _selectedCheckBoxBladkleurRosé = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladkleurRood;
        public bool SelectedCheckBoxBladkleurRood
        {
            get { return _selectedCheckBoxBladkleurRood; }

            set
            {
                _selectedCheckBoxBladkleurRood = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladkleurOranje;
        public bool SelectedCheckBoxBladkleurOranje
        {
            get { return _selectedCheckBoxBladkleurOranje; }

            set
            {
                _selectedCheckBoxBladkleurOranje = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladkleurLila;
        public bool SelectedCheckBoxBladkleurLila
        {
            get { return _selectedCheckBoxBladkleurLila; }

            set
            {
                _selectedCheckBoxBladkleurLila = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladkleurGrijs;
        public bool SelectedCheckBoxBladkleurGrijs
        {
            get { return _selectedCheckBoxBladkleurGrijs; }

            set
            {
                _selectedCheckBoxBladkleurGrijs = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladkleurGroen;
        public bool SelectedCheckBoxBladkleurGroen
        {
            get { return _selectedCheckBoxBladkleurGroen; }

            set
            {
                _selectedCheckBoxBladkleurGroen = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladkleurGeel;
        public bool SelectedCheckBoxBladkleurGeel
        {
            get { return _selectedCheckBoxBladkleurGeel; }

            set
            {
                _selectedCheckBoxBladkleurGeel = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladkleurBlauw;
        public bool SelectedCheckBoxBladkleurBlauw
        {
            get { return _selectedCheckBoxBladkleurBlauw; }

            set
            {
                _selectedCheckBoxBladkleurBlauw = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladkleurViolet;
        public bool SelectedCheckBoxBladkleurViolet
        {
            get { return _selectedCheckBoxBladkleurViolet; }

            set
            {
                _selectedCheckBoxBladkleurViolet = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladkleurPaars;
        public bool SelectedCheckBoxBladkleurPaars
        {
            get { return _selectedCheckBoxBladkleurPaars; }

            set
            {
                _selectedCheckBoxBladkleurPaars = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladkleurBruin;
        public bool SelectedCheckBoxBladkleurBruin
        {
            get { return _selectedCheckBoxBladkleurBruin; }

            set
            {
                _selectedCheckBoxBladkleurBruin = value;
                OnPropertyChanged();
            }
        }

        #endregion
        
        #region Binding comboboxen BladHoogte

        private string _selectedCboBladHoogteMin;
        public string SelectedCboBladHoogteMin
        {
            get { return _selectedCboBladHoogteMin; }

            set
            {
                _selectedCboBladHoogteMin = value;
                OnPropertyChanged();
            }
        }

        private string _selectedCboBladHoogteMax;
        public string SelectedCboBladHoogteMax
        {
            get { return _selectedCboBladHoogteMax; }

            set
            {
                _selectedCboBladHoogteMax = value;
                OnPropertyChanged();
            }
        }

       

        #endregion

        #region Binding checkboxen Bladvormen

        private bool _selectedCheckBoxBladvormenVorm1;
        public bool SelectedCheckBoxBladvormenVorm1
        {
            get { return _selectedCheckBoxBladvormenVorm1; }

            set
            {
                _selectedCheckBoxBladvormenVorm1 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladvormenVorm2;
        public bool SelectedCheckBoxBladvormenVorm2
        {
            get { return _selectedCheckBoxBladvormenVorm2; }

            set
            {
                _selectedCheckBoxBladvormenVorm2 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladvormenVorm3;
        public bool SelectedCheckBoxBladvormenVorm3
        {
            get { return _selectedCheckBoxBladvormenVorm3; }

            set
            {
                _selectedCheckBoxBladvormenVorm3 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladvormenVorm4;
        public bool SelectedCheckBoxBladvormenVorm4
        {
            get { return _selectedCheckBoxBladvormenVorm4; }

            set
            {
                _selectedCheckBoxBladvormenVorm4 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladvormenVorm5;
        public bool SelectedCheckBoxBladvormenVorm5
        {
            get { return _selectedCheckBoxBladvormenVorm5; }

            set
            {
                _selectedCheckBoxBladvormenVorm5 = value;
                OnPropertyChanged();
            }
        }

       

        #endregion

        #region Binding checkboxen Stengelvormen

        private bool _selectedCheckBoxStengelvormenVorm1;
        public bool SelectedCheckBoxStengelvormenVorm1
        {
            get { return _selectedCheckBoxStengelvormenVorm1; }

            set
            {
                _selectedCheckBoxStengelvormenVorm1 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxStengelvormenVorm2;
        public bool SelectedCheckBoxStengelvormenVorm2
        {
            get { return _selectedCheckBoxStengelvormenVorm2; }

            set
            {
                _selectedCheckBoxStengelvormenVorm2 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxStengelvormenVorm3;
        public bool SelectedCheckBoxStengelvormenVorm3
        {
            get { return _selectedCheckBoxStengelvormenVorm3; }

            set
            {
                _selectedCheckBoxStengelvormenVorm3 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxStengelvormenVorm4;
        public bool SelectedCheckBoxStengelvormenVorm4
        {
            get { return _selectedCheckBoxStengelvormenVorm4; }

            set
            {
                _selectedCheckBoxStengelvormenVorm4 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxStengelvormenVorm5;
        public bool SelectedCheckBoxStengelvormenVorm5
        {
            get { return _selectedCheckBoxStengelvormenVorm5; }

            set
            {
                _selectedCheckBoxStengelvormenVorm5 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxStengelvormenVorm6;
        public bool SelectedCheckBoxStengelvormenVorm6
        {
            get { return _selectedCheckBoxStengelvormenVorm6; }

            set
            {
                _selectedCheckBoxStengelvormenVorm6 = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Binding checkboxen Levensvormen

        private bool _selectedCheckBoxLevensvormenVorm1;
        public bool SelectedCheckBoxLevensvormenVorm1
        {
            get { return _selectedCheckBoxLevensvormenVorm1; }

            set
            {
                _selectedCheckBoxLevensvormenVorm1 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxLevensvormenVorm2;
        public bool SelectedCheckBoxLevensvormenVorm2
        {
            get { return _selectedCheckBoxLevensvormenVorm2; }

            set
            {
                _selectedCheckBoxLevensvormenVorm2 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxLevensvormenVorm3;
        public bool SelectedCheckBoxLevensvormenVorm3
        {
            get { return _selectedCheckBoxLevensvormenVorm3; }

            set
            {
                _selectedCheckBoxLevensvormenVorm3 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxLevensvormenVorm4;
        public bool SelectedCheckBoxLevensvormenVorm4
        {
            get { return _selectedCheckBoxLevensvormenVorm4; }

            set
            {
                _selectedCheckBoxLevensvormenVorm4 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxLevensvormenVorm5;
        public bool SelectedCheckBoxLevensvormenVorm5
        {
            get { return _selectedCheckBoxLevensvormenVorm5; }

            set
            {
                _selectedCheckBoxLevensvormenVorm5 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxLevensvormenVorm6;
        public bool SelectedCheckBoxLevensvormenVorm6
        {
            get { return _selectedCheckBoxLevensvormenVorm6; }

            set
            {
                _selectedCheckBoxLevensvormenVorm6 = value;
                OnPropertyChanged();
            }
        }
                
        #endregion
    }
}
