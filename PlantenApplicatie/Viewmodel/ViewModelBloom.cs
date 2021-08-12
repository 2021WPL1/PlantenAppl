using PlantenApplicatie.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using GalaSoft.MvvmLight.Ioc;
using Planten2021.Data;
using Planten2021.Domain.Models;
using PlantenApplicatie.Services.Interfaces;
using GalaSoft.MvvmLight.Command;
using System.Linq;

namespace PlantenApplicatie.Viewmodel
{
    public class ViewModelBloom : ViewModelBase
    {
        // Using a DependencyProperty as the backing store for 
        //IsCheckBoxChecked.  This enables animation, styling, binding, etc...
       
       
        private static SimpleIoc iocc = SimpleIoc.Default;
        private static IDetailService _detailService = iocc.GetInstance<IDetailService>();
        private static ISearchService _SearchService = iocc.GetInstance<ISearchService>();
        private Plant _selectedPlant;
        private List<FenotypeMulti> _fenoTypeMulti;
       
                        
        public bool isChecked;

        public ViewModelBloom(IDetailService detailservice)
        {
            _detailService = detailservice;
            //_selectedPlant = _SearchService.ReturnSelectedPlant();
            
            //_fenoTypeMulti = _detailService.FilterFenoMulti(SelectedPlant.PlantId);
            cboFenoBloeiwijze = new ObservableCollection<FenoBloeiwijze>();
            _selectedFenotypeMonth = new List<FenotypeMulti>();
            cboBloeiHoogte = new ObservableCollection<string>();
            fillcboFenoBloeiwijze();
            fillCboBloeiHoogte();
        }

        public ObservableCollection<FenoBloeiwijze> cboFenoBloeiwijze { get; set; }
        public ObservableCollection<string> cboBloeiHoogte { get; set; }
        

        public void fillcboFenoBloeiwijze() 
        {
            var fenoBloeiwijze = _detailService.GetFenoBloeiwijzes();

            foreach (var item in fenoBloeiwijze)
            {
                cboFenoBloeiwijze.Add(item);
            }
        }

       public void fillCboBloeiHoogte()
        {
            
            cboBloeiHoogte.Add("240/250");
            cboBloeiHoogte.Add("230/239");

            cboBloeiHoogte.Add("220/229");

            cboBloeiHoogte.Add("210/219");
            cboBloeiHoogte.Add("200/209");

            cboBloeiHoogte.Add("190/199");

            cboBloeiHoogte.Add("180/189");

            cboBloeiHoogte.Add("170/179");

            cboBloeiHoogte.Add("160/169");

            cboBloeiHoogte.Add("150/159");

            cboBloeiHoogte.Add("140/149");

            cboBloeiHoogte.Add("130/139");

            cboBloeiHoogte.Add("120/129");

            cboBloeiHoogte.Add("110/119");

            cboBloeiHoogte.Add("100/109");

            cboBloeiHoogte.Add("90/99");

            cboBloeiHoogte.Add("80/89");


            cboBloeiHoogte.Add("70/79");

            cboBloeiHoogte.Add("60/69");

            cboBloeiHoogte.Add("50/59");

            cboBloeiHoogte.Add("40/49");

            cboBloeiHoogte.Add("30/39");

            cboBloeiHoogte.Add("20/29");


            cboBloeiHoogte.Add("10/19");


            cboBloeiHoogte.Add("0/9");
        }
        public Plant SelectedPlant
        {
            get
            {
                _selectedPlant = _SearchService.ReturnSelectedPlant();

                return _selectedPlant;
               
            }

            set
            {
                _selectedPlant = value;

                CheckMonth();
                CheckBloeiwijze();

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
                if (item.Eigenschap == "bloeikleur")
                {
                    switch (item.Waarde)
                    {
                        case "zwart":
                            SelectedCheckBoxBloeikleurZwart = true;
                            break;
                        case "wit":
                            SelectedCheckBoxBloeikleurWit = true;
                            break;
                        case "rosé":
                            SelectedCheckBoxBloeikleurRosé = true;
                            break;
                        case "rood":
                            SelectedCheckBoxBloeikleurRood = true;
                            break;
                        case "oranje":
                            SelectedCheckBoxBloeikleurOranje = true;
                            break;
                        case "lila":
                            SelectedCheckBoxBloeikleurLila = true;
                            break;
                        case "grijs":
                            SelectedCheckBoxBloeikleurGrijs = true;
                            break;
                        case "groen":
                            SelectedCheckBoxBloeikleurGroen = true;
                            break;
                        case "geel":
                            SelectedCheckBoxBloeikleurGeel = true;
                            break;
                        case "blauw":
                            SelectedCheckBoxBloeikleurBlauw = true;
                            break;
                        case "violet":
                            SelectedCheckBoxBloeikleurViolet = true;
                            break;
                        case "paars":
                            SelectedCheckBoxBloeikleurPaars = true;
                            break;
                        case "bruin":
                            SelectedCheckBoxBloeikleurBruin = true;
                            break;
                        default:
                            break;
                    }
                }

                               

                
            }
          

        }

        public void CheckBloeiHoogteMin()
        {
            foreach (var item in _selectedFenotypeMonth)
            {
                if (item.Eigenschap == "bloeihoogte_min")
                {
                    switch (item.Waarde)
                    {
                        case "0/9":
                            SelectedCboBloeiHoogteMin = "0/9";
                            break;
                        case "10/19":
                            SelectedCboBloeiHoogteMin = "10/19";
                            break;
                        case "20/29":
                            SelectedCboBloeiHoogteMin = "20/29";
                            break;
                        case "30/39":
                            SelectedCboBloeiHoogteMin = "30/39";
                            break;
                        case "40/49":
                            SelectedCboBloeiHoogteMin = "40/49";
                            break;
                        case "50/59":
                            SelectedCboBloeiHoogteMin = "50/59";
                            break;
                        case "60/69":
                            SelectedCboBloeiHoogteMin = "60/69";
                            break;
                        case "70/79":
                            SelectedCboBloeiHoogteMin = "70/79";
                            break;
                        case "80/89":
                            SelectedCboBloeiHoogteMin = "80/89";
                            break;
                        case "90/99":
                            SelectedCboBloeiHoogteMin = "90/99";
                            break;
                        case "100/109":
                            SelectedCboBloeiHoogteMin = "100/109";
                            break;
                        case "110/119":
                            SelectedCboBloeiHoogteMin = "110/119";
                            break;
                        case "120/129":
                            SelectedCboBloeiHoogteMin = "120/129";
                            break;
                        case "130/139":
                            SelectedCboBloeiHoogteMin = "130/139";
                            break;
                        case "140/149":
                            SelectedCboBloeiHoogteMin = "140/149";
                            break;
                        case "150/159":
                            SelectedCboBloeiHoogteMin = "150/159";
                            break;
                        case "160/169":
                            SelectedCboBloeiHoogteMin = "160/169";
                            break;
                        case "170/179":
                            SelectedCboBloeiHoogteMin = "170/179";
                            break;
                        case "180/189":
                            SelectedCboBloeiHoogteMin = "180/189";
                            break;
                        case "190/199":
                            SelectedCboBloeiHoogteMin = "190/199";
                            break;
                        case "200/209":
                            SelectedCboBloeiHoogteMin = "200/209";
                            break;
                        case "210/219":
                            SelectedCboBloeiHoogteMin = "210/219";
                            break;
                        case "220/229":
                            SelectedCboBloeiHoogteMin = "220/229";
                            break;
                        case "230/239":
                            SelectedCboBloeiHoogteMin = "230/239";
                            break;
                        case "240/250":
                            SelectedCboBloeiHoogteMin = "240/250";
                            break;

                        default:
                            break;
                    }
                }
                

            }

        }

        public void CheckBloeiHoogteMax()
        {
            foreach (var item in _selectedFenotypeMonth)
            {
                if (item.Eigenschap == "bloeihoogte_max")
                {
                    switch (item.Waarde)
                    {
                        case "0/9":
                            SelectedCboBloeiHoogteMax = "0/9";
                            break;
                        case "10/19":
                            SelectedCboBloeiHoogteMax = "10/19";
                            break;
                        case "20/29":
                            SelectedCboBloeiHoogteMax = "20/29";
                            break;
                        case "30/39":
                            SelectedCboBloeiHoogteMax = "30/39";
                            break;
                        case "40/49":
                            SelectedCboBloeiHoogteMax = "40/49";
                            break;
                        case "50/59":
                            SelectedCboBloeiHoogteMax = "50/59";
                            break;
                        case "60/69":
                            SelectedCboBloeiHoogteMax = "60/69";
                            break;
                        case "70/79":
                            SelectedCboBloeiHoogteMax = "70/79";
                            break;
                        case "80/89":
                            SelectedCboBloeiHoogteMax = "80/89";
                            break;
                        case "90/99":
                            SelectedCboBloeiHoogteMax = "90/99";
                            break;
                        case "100/109":
                            SelectedCboBloeiHoogteMax = "100/109";
                            break;
                        case "110/119":
                            SelectedCboBloeiHoogteMax = "110/119";
                            break;
                        case "120/129":
                            SelectedCboBloeiHoogteMax = "120/129";
                            break;
                        case "130/139":
                            SelectedCboBloeiHoogteMax = "130/139";
                            break;
                        case "140/149":
                            SelectedCboBloeiHoogteMax = "140/149";
                            break;
                        case "150/159":
                            SelectedCboBloeiHoogteMax = "150/159";
                            break;
                        case "160/169":
                            SelectedCboBloeiHoogteMax = "160/169";
                            break;
                        case "170/179":
                            SelectedCboBloeiHoogteMax = "170/179";
                            break;
                        case "180/189":
                            SelectedCboBloeiHoogteMax = "180/189";
                            break;
                        case "190/199":
                            SelectedCboBloeiHoogteMax = "190/199";
                            break;
                        case "200/209":
                            SelectedCboBloeiHoogteMax = "200/209";
                            break;
                        case "210/219":
                            SelectedCboBloeiHoogteMax = "210/219";
                            break;
                        case "220/229":
                            SelectedCboBloeiHoogteMax = "220/229";
                            break;
                        case "230/239":
                            SelectedCboBloeiHoogteMax = "230/239";
                            break;
                        case "240/250":
                            SelectedCboBloeiHoogteMax = "240/250";
                            break;

                        default:
                            break;
                    }

                }

            }


        }

        public void CheckBloeiwijze()
        {
            _selectedPlant = _SearchService.ReturnSelectedPlant();
            var fenoBloeiwijze = _detailService.GetFenoBloeiwijzes();

            foreach (var item in fenoBloeiwijze)
            {
                if (item.Naam == "bloeiwijze")
                {
                    switch (item.Naam)
                    {
                        case "aar":
                            SelectedCboFenoBloeiwijze = "aar";
                            break;
                        case "schermbloemig":
                            SelectedCboFenoBloeiwijze = "schermbloemig";
                            break;
                        case "pluim":
                            SelectedCboFenoBloeiwijze = "pluim";
                            break;
                        case "bol of knop":
                            SelectedCboFenoBloeiwijze = "bol of knop";
                            break;
                        case "margrietachtig":
                            SelectedCboFenoBloeiwijze = "margrietachtig";
                            break;
                        case "transparant":
                            SelectedCboFenoBloeiwijze = "transparant";
                            break;

                        default:
                            break;
                    }
                }
                
                   
            }

            
        }

        public void CheckBloeitIn()
        {
            foreach (var item in fenoTypeMulti)
            {
                if (item.Eigenschap == "bloeit in")
                {
                    switch (item.Waarde)
                    {
                        case "januari":
                            SelectedCheckBoxBloeitIn = true;
                            break;
                        case "februari":
                            SelectedCheckBoxBloeitIn = true;
                            break;
                        case "maart":
                            SelectedCheckBoxBloeitIn = true;
                            break;
                        case "april":
                            SelectedCheckBoxBloeitIn = true;
                            break;
                        case "mei":
                            SelectedCheckBoxBloeitIn = true;
                            break;
                        case "juni":
                            SelectedCheckBoxBloeitIn = true;
                            break;
                        case "juli":
                            SelectedCheckBoxBloeitIn = true;
                            break;
                        case "augustus":
                            SelectedCheckBoxBloeitIn = true;
                            break;
                        case "september":
                            SelectedCheckBoxBloeitIn = true;
                            break;
                        case "oktober":
                            SelectedCheckBoxBloeitIn = true;
                            break;
                        case "november":
                            SelectedCheckBoxBloeitIn = true;
                            break;
                        case "december":
                            SelectedCheckBoxBloeitIn = true;
                            break;

                        default:
                            break;
                    }
                }
               


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
        

        #region Checkbox Bloeikleur

        
        private bool _selectedCheckBoxBloeikleurZwart;
        public bool SelectedCheckBoxBloeikleurZwart
        {
            get
            {
               

                return _selectedCheckBoxBloeikleurZwart;
            }

            set
            {

                _selectedCheckBoxBloeikleurZwart = value;
                OnPropertyChanged();
            }
        }



        private bool _selectedCheckBoxBloeikleurWit;
        public bool SelectedCheckBoxBloeikleurWit
        {
            get
            {
                
                return _selectedCheckBoxBloeikleurWit;
            }

            set
            {
                _selectedCheckBoxBloeikleurWit = value;

                

                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeikleurRosé;
        public bool SelectedCheckBoxBloeikleurRosé
        {
            get {
                
                return _selectedCheckBoxBloeikleurRosé;
            }

            set
            {
                _selectedCheckBoxBloeikleurRosé = value;
               OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeikleurRood;
        public bool SelectedCheckBoxBloeikleurRood
        {
            get {
                
                return _selectedCheckBoxBloeikleurWit;
            }

            set
            {
                _selectedCheckBoxBloeikleurRood = value;
               OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeikleurOranje;
        public bool SelectedCheckBoxBloeikleurOranje
        {
            get {
               
                return _selectedCheckBoxBloeikleurOranje;
            }

            set
            {
                _selectedCheckBoxBloeikleurOranje = value;
               OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeikleurLila;
        public bool SelectedCheckBoxBloeikleurLila
        {
            get
            {
                
                return _selectedCheckBoxBloeikleurLila;
            }

            set
            {
                _selectedCheckBoxBloeikleurLila = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeikleurGrijs;
        public bool SelectedCheckBoxBloeikleurGrijs
        {
            get
            {
               
                return _selectedCheckBoxBloeikleurGrijs;
            }

            set
            {
                _selectedCheckBoxBloeikleurGrijs = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeikleurGroen;
        public bool SelectedCheckBoxBloeikleurGroen
        {
            get {
                
                return _selectedCheckBoxBloeikleurGroen;
            }

            set
            {
                _selectedCheckBoxBloeikleurGroen = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeikleurGeel;
        public bool SelectedCheckBoxBloeikleurGeel
        {
            get {
               
                return _selectedCheckBoxBloeikleurGeel;
            }

            set
            {
                _selectedCheckBoxBloeikleurGeel= value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeikleurBlauw;
        public bool SelectedCheckBoxBloeikleurBlauw
        {
            get {
                
                
                return _selectedCheckBoxBloeikleurBlauw;
                }

            set
            {
                _selectedCheckBoxBloeikleurBlauw = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeikleurViolet;
        public bool SelectedCheckBoxBloeikleurViolet
        {
            get {
               
                return _selectedCheckBoxBloeikleurViolet; }

            set
            {
                _selectedCheckBoxBloeikleurViolet = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeikleurPaars;
        public bool SelectedCheckBoxBloeikleurPaars
        {
            get {
                                
                return _selectedCheckBoxBloeikleurPaars; }

            set
            {
                _selectedCheckBoxBloeikleurPaars = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeikleurBruin;
        public bool SelectedCheckBoxBloeikleurBruin
        {
            get {
                
                return _selectedCheckBoxBloeikleurBruin; }

            set
            {
                _selectedCheckBoxBloeikleurBruin = value;
                OnPropertyChanged();
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
                CheckBloeiHoogteMin();
                CheckBloeiHoogteMax();
                CheckBloeitIn();
                OnPropertyChanged();

            }
        }

       

        #endregion
       
        #region Binding Combobox BloeiHoogte

        private string _selectedCboBloeiHoogteMin;
        public string SelectedCboBloeiHoogteMin
        {
            get
            {

                return _selectedCboBloeiHoogteMin;
            }

            set
            {
                _selectedCboBloeiHoogteMin = value;
                
                OnPropertyChanged();
            }
        }

        private string _selectedCboBloeiHoogteMax;
        public string SelectedCboBloeiHoogteMax
        {
            get
            {
                
                return _selectedCboBloeiHoogteMax;
            }

            set
            {
                _selectedCboBloeiHoogteMax = value;
                OnPropertyChanged();
            }
        }

        

        #endregion

        #region Binding Checkbox Bloeit In

        private bool _selectedCheckBoxBloeitIn;
        
        public bool SelectedCheckBoxBloeitIn
        {
            get {

                
                return _selectedCheckBoxBloeitIn;
            }

            set
            {
                _selectedCheckBoxBloeitIn = value;
                OnPropertyChanged();
            }
        }

        


        #endregion

        #region Binding Combobox Bloeiwijze

        
        private string _selectedCboFenoBloeiwijze;

        public string SelectedCboFenoBloeiwijze
        {   
            
            get { return _selectedCboFenoBloeiwijze; }
            set
            {
                _selectedCboFenoBloeiwijze = value;
                OnPropertyChanged();

            }
        }
        #endregion
             
        
    }
}

