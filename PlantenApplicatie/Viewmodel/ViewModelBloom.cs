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
            fillcboFenoBloeiwijze();
        }

        public ObservableCollection<FenoBloeiwijze> cboFenoBloeiwijze { get; set; }

        

        public void fillcboFenoBloeiwijze() 
        {
            var fenoBloeiwijze = _detailService.GetFenoBloeiwijzes();

            foreach (var item in fenoBloeiwijze)
            {
                cboFenoBloeiwijze.Add(item);
            }
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
            MessageBox.Show(SelectedCboMaanden);
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
             
                switch(item.Waarde)
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
                        SelectedCheckBoxBloeiKleurOranje = true;
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

        public void CheckBloeiHoogteMin()
        {
            foreach (var item in _selectedFenotypeMonth)
            {

                switch (item.Waarde)
                {
                    case "0/9":
                        SelectedCboBloeiHoogteMin = true;
                        break;
                    case "10/19":
                        SelectedCboBloeiHoogteMin = true;
                        break;
                    case "20/29":
                        SelectedCboBloeiHoogteMin = true;
                        break;
                    case "30/39":
                        SelectedCboBloeiHoogteMin = true;
                        break;
                    case "40/49":
                        SelectedCboBloeiHoogteMin = true;
                        break;
                    case "50/59":
                        SelectedCboBloeiHoogteMin = true;
                        break;
                    case "60/69":
                        SelectedCboBloeiHoogteMin = true;
                        break;
                    case "70/79":
                        SelectedCboBloeiHoogteMin = true;
                        break;
                    case "80/89":
                        SelectedCboBloeiHoogteMin = true;
                        break;
                    case "90/99":
                        SelectedCboBloeiHoogteMin = true;
                        break;
                    case "100/109":
                        SelectedCboBloeiHoogteMin = true;
                        break;
                    case "110/119":
                        SelectedCboBloeiHoogteMin = true;
                        break;
                    case "120/129":
                        SelectedCboBloeiHoogteMin = true;
                        break;
                    case "130/139":
                        SelectedCboBloeiHoogteMin = true;
                        break;
                    case "140/149":
                        SelectedCboBloeiHoogteMin = true;
                        break;
                    case "150/159":
                        SelectedCboBloeiHoogteMin = true;
                        break;
                    case "160/169":
                        SelectedCboBloeiHoogteMin = true;
                        break;
                    case "170/179":
                        SelectedCboBloeiHoogteMin = true;
                        break;
                    case "180/189":
                        SelectedCboBloeiHoogteMin = true;
                        break;
                    case "190/199":
                        SelectedCboBloeiHoogteMin = true;
                        break;
                    case "200/209":
                        SelectedCboBloeiHoogteMin = true;
                        break;
                    case "210/219":
                        SelectedCboBloeiHoogteMin = true;
                        break;
                    case "220/229":
                        SelectedCboBloeiHoogteMin = true;
                        break;
                    case "230/239":
                        SelectedCboBloeiHoogteMin = true;
                        break;
                    case "240/250":
                        SelectedCboBloeiHoogteMin = true;
                        break;
                    
                    default:
                        break;
                }

            }

        }

        public void CheckBloeiHoogteMax()
        {
            foreach (var item in _selectedFenotypeMonth)
            {

                switch (item.Waarde)
                {
                    case "0/9":
                        SelectedCboBloeiHoogteMax = true;
                        break;
                    case "10/19":
                        SelectedCboBloeiHoogteMax = true;
                        break;
                    case "20/29":
                        SelectedCboBloeiHoogteMax = true;
                        break;
                    case "30/39":
                        SelectedCboBloeiHoogteMax = true;
                        break;
                    case "40/49":
                        SelectedCboBloeiHoogteMax = true;
                        break;
                    case "50/59":
                        SelectedCboBloeiHoogteMax = true;
                        break;
                    case "60/69":
                        SelectedCboBloeiHoogteMax = true;
                        break;
                    case "70/79":
                        SelectedCboBloeiHoogteMax = true;
                        break;
                    case "80/89":
                        SelectedCboBloeiHoogteMax = true;
                        break;
                    case "90/99":
                        SelectedCboBloeiHoogteMax = true;
                        break;
                    case "100/109":
                        SelectedCboBloeiHoogteMax = true;
                        break;
                    case "110/119":
                        SelectedCboBloeiHoogteMax = true;
                        break;
                    case "120/129":
                        SelectedCboBloeiHoogteMax = true;
                        break;
                    case "130/139":
                        SelectedCboBloeiHoogteMax = true;
                        break;
                    case "140/149":
                        SelectedCboBloeiHoogteMax = true;
                        break;
                    case "150/159":
                        SelectedCboBloeiHoogteMax = true;
                        break;
                    case "160/169":
                        SelectedCboBloeiHoogteMax = true;
                        break;
                    case "170/179":
                        SelectedCboBloeiHoogteMax = true;
                        break;
                    case "180/189":
                        SelectedCboBloeiHoogteMax = true;
                        break;
                    case "190/199":
                        SelectedCboBloeiHoogteMax = true;
                        break;
                    case "200/209":
                        SelectedCboBloeiHoogteMax = true;
                        break;
                    case "210/219":
                        SelectedCboBloeiHoogteMax = true;
                        break;
                    case "220/229":
                        SelectedCboBloeiHoogteMax = true;
                        break;
                    case "230/239":
                        SelectedCboBloeiHoogteMax = true;
                        break;
                    case "240/250":
                        SelectedCboBloeiHoogteMax = true;
                        break;

                    default:
                        break;
                }

            }


        }

        public void CheckBloeiwijze()
        {
            _selectedPlant = _SearchService.ReturnSelectedPlant();
            var fenoBloeiwijze = _detailService.GetFenoBloeiwijzes();

            foreach (var item in fenoBloeiwijze)
            {

                switch (item.Naam)
                {
                    case "aar":
                        SelectedCboFenoBloeiwijze.Contains(item.Naam);
                        break;
                    case "schermbloemig":
                        SelectedCboFenoBloeiwijze.Contains(item.Naam);
                        break;
                    case "pluim":
                        SelectedCboFenoBloeiwijze.Contains(item.Naam);
                        break;
                    case "bol of knop":
                        SelectedCboFenoBloeiwijze.Contains(item.Naam);
                        break;
                    case "margrietachtig":
                        SelectedCboFenoBloeiwijze.Contains(item.Naam);
                        break;
                    case "transparant":
                        SelectedCboFenoBloeiwijze.Contains(item.Naam);
                        break;

                    default:
                        break;
                }


            }

            
        }

        public void CheckBloeitIn()
        {
            foreach (var item in fenoTypeMulti)
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
                _selectedCheckBoxBloeikleurWit = isChecked;

                

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
                _selectedCheckBoxBloeikleurRosé = isChecked;
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
                _selectedCheckBoxBloeikleurRood = isChecked;
               OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeikleurOranje;
        public bool SelectedCheckBoxBloeiKleurOranje
        {
            get {
               
                return _selectedCheckBoxBloeikleurOranje;
            }

            set
            {
                _selectedCheckBoxBloeikleurOranje = isChecked;
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
                _selectedCheckBoxBloeikleurLila = isChecked;
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
                _selectedCheckBoxBloeikleurGrijs = isChecked;
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
                _selectedCheckBoxBloeikleurGroen = isChecked;
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
                _selectedCheckBoxBloeikleurGeel= isChecked;
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
                _selectedCheckBoxBloeikleurViolet = isChecked;
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
                _selectedCheckBoxBloeikleurPaars = isChecked;
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
                _selectedCheckBoxBloeikleurBruin = isChecked;
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
        private string _selectedBloeiHoogte;

        public string SelectedBloeiHoogte
        {   

            get
            {
                return _selectedBloeiHoogte;
            }
            set
            {
                _selectedBloeiHoogte = value;
                OnPropertyChanged();


            }
        }
        #region Binding Combobox BloeiHoogte

        private bool _selectedCboBloeiHoogteMin;
        public bool SelectedCboBloeiHoogteMin
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

        private bool _selectedCboBloeiHoogteMax;
        public bool SelectedCboBloeiHoogteMax
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

