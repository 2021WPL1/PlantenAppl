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
       


        public RelayCommand resetBloom { get; set; }

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
                if (fenoTypeMulti != null)
                {
                    foreach (var fenotypeMulti in fenoTypeMulti)
                    {
                        if (fenotypeMulti.Eigenschap == "BloeikleurRosé")
                        {
                            isChecked = true;
                        }

                        else
                        {
                            isChecked = false;
                        }

                       
                    }
                    _selectedCheckBoxBloeikleurRosé = isChecked;
                }

                else
                {
                    MessageBox.Show("");
                }

                

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
                if (fenoTypeMulti != null)
                {
                    foreach (var fenotypeMulti in fenoTypeMulti)
                    {
                        if (fenotypeMulti.Eigenschap == "BloeikleurRood")
                        {
                            isChecked = true;
                        }

                        else
                        {
                            isChecked = false;
                        }

                        
                    }

                    _selectedCheckBoxBloeikleurRood = isChecked;
                }

                else
                {
                    MessageBox.Show("");
                }

               

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
                if (fenoTypeMulti != null)
                {
                    foreach (var fenotypeMulti in fenoTypeMulti)
                    {
                        if (fenotypeMulti.Eigenschap == "BloeikleurOranje")
                        {
                            isChecked = true;
                        }

                        else
                        {
                            isChecked = false;
                        }

                        
                    }

                    _selectedCheckBoxBloeikleurOranje = isChecked;
                }

                else
                {
                    MessageBox.Show("");
                }

               

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
                if (fenoTypeMulti != null)
                {
                    foreach (var fenotypeMulti in fenoTypeMulti)
                    {
                        if (fenotypeMulti.Eigenschap == "BloeikleurLila")
                        {
                            isChecked = true;
                        }

                        else
                        {
                            isChecked = false;
                        }

                        
                    }

                    _selectedCheckBoxBloeikleurLila = isChecked;
                }

                else
                {
                    MessageBox.Show("");
                }

                

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
                if (fenoTypeMulti != null)
                {
                    foreach (var fenotypeMulti in fenoTypeMulti)
                    {
                        if (fenotypeMulti.Eigenschap == "BloeikleurGrijs")
                        {
                            isChecked = true;
                        }

                        else
                        {
                            isChecked = false;
                        }

                        
                    }

                    _selectedCheckBoxBloeikleurGrijs = isChecked;
                }

                else
                {
                    MessageBox.Show("");
                }

                

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
                if (fenoTypeMulti != null)
                {
                    foreach (var fenotypeMulti in fenoTypeMulti)
                    {
                        if (fenotypeMulti.Eigenschap == "BloeikleurGroen")
                        {
                            isChecked = true;
                        }

                        else
                        {
                            isChecked = false;
                        }

                       
                    }

                    _selectedCheckBoxBloeikleurGroen = isChecked;
                }

                else
                {
                    MessageBox.Show("");
                }

                

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
                if (fenoTypeMulti != null)
                {
                    foreach (var fenotypeMulti in fenoTypeMulti)
                    {
                        if (fenotypeMulti.Eigenschap == "BloeikleurGeel")
                        {
                            isChecked = true;
                        }

                        else
                        {
                            isChecked = false;
                        }

                       
                    }

                    _selectedCheckBoxBloeikleurGeel = isChecked;
                }

                else
                {
                    MessageBox.Show("");
                }

               

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
                
                if (fenoTypeMulti != null)
                {
                    foreach (var fenotypeMulti in fenoTypeMulti)
                    {
                        if (fenotypeMulti.Eigenschap == "BloeikleurBlauw")
                        {
                            isChecked = true;
                        }

                        else
                        {
                            isChecked = false;
                        }

                        
                    }

                    _selectedCheckBoxBloeikleurBlauw = isChecked;
                }

                else
                {
                    MessageBox.Show("");
                }

               

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
                if (fenoTypeMulti != null)
                {
                    foreach (var fenotypeMulti in fenoTypeMulti)
                    {
                        if (fenotypeMulti.Eigenschap == "BloeikleurViolet")
                        {
                            isChecked = true;
                        }

                        else
                        {
                            isChecked = false;
                        }

                        
                    }

                    _selectedCheckBoxBloeikleurViolet = isChecked;
                }

                else
                {
                    MessageBox.Show("");
                }

               
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
                if (fenoTypeMulti != null)
                {
                    foreach (var fenotypeMulti in fenoTypeMulti)
                    {
                        if (fenotypeMulti.Eigenschap == "BloeikleurPaars")
                        {
                            isChecked = true;
                        }

                        else
                        {
                            isChecked = false;
                        }

                        
                    }

                    _selectedCheckBoxBloeikleurPaars = isChecked;
                }

                else
                {
                    MessageBox.Show("");
                }

                
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
                if (fenoTypeMulti != null)
                {
                    foreach (var fenotypeMulti in fenoTypeMulti)
                    {
                        if (fenotypeMulti.Eigenschap == "BloeikleurBruin")
                        {
                            isChecked = true;
                        }

                        else
                        {
                            isChecked = false;
                        }

                        
                    }

                    _selectedCheckBoxBloeikleurBruin = isChecked;
                }

                else
                {
                    MessageBox.Show("");
                }

               
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

        private bool _selectedCboBloeiHoogteMinJan;
        public bool SelectedCboBloeiHoogteMinJan
        {
            get
            {

                return _selectedCboBloeiHoogteMinJan;
            }

            set
            {
                _selectedCboBloeiHoogteMinJan = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCboBloeiHoogteMaxJan;
        public bool SelectedCboBloeiHoogteMaxJan
        {
            get
            {
                
                return _selectedCboBloeiHoogteMaxJan;
            }

            set
            {
                _selectedCboBloeiHoogteMaxJan = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCboBloeiHoogteMinFeb;
        public bool SelectedCboBloeiHoogteMinFeb
        {
            get
            {
                
                
                return _selectedCboBloeiHoogteMinFeb;
            }

            set
            {
                _selectedCboBloeiHoogteMinFeb = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCboBloeiHoogteMaxFeb;
        public bool SelectedCboBloeiHoogteMaxFeb
        {
            get
            {
                               
                return _selectedCboBloeiHoogteMaxFeb;
            }

            set
            {
                _selectedCboBloeiHoogteMaxFeb = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCboBloeiHoogteMinMar;
        public bool SelectedCboBloeiHoogteMinMar
        {
            get {
               
                return _selectedCboBloeiHoogteMinMar;
            }

            set
            {
                _selectedCboBloeiHoogteMinMar = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCboBloeiHoogteMaxMar;
        public bool SelectedCboBloeiHoogteMaxMar
        {
            get {
                
                return _selectedCboBloeiHoogteMaxMar;
            }

            set
            {
                _selectedCboBloeiHoogteMaxMar = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCboBloeiHoogteMinApr;
        public bool SelectedCboBloeiHoogteMinApr
        {
            get
            {
                
                return _selectedCboBloeiHoogteMinApr;
            }

            set
            {
                _selectedCboBloeiHoogteMinApr = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCboBloeiHoogteMaxApr;
        public bool SelectedCboBloeiHoogteMaxApr
        {
            get {
               
                return _selectedCboBloeiHoogteMaxApr;
            }

            set
            {
                _selectedCboBloeiHoogteMaxApr = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCboBloeiHoogteMinMay;
        public bool SelectedCboBloeiHoogteMinMay
        {
            get {
                
                return _selectedCboBloeiHoogteMinMay;
            }

            set
            {
                _selectedCboBloeiHoogteMinMay = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCboBloeiHoogteMaxMay;
        public bool SelectedCboBloeiHoogteMaxMay
        {
            get {
               
                return _selectedCboBloeiHoogteMaxMay;
            }

            set
            {
                _selectedCboBloeiHoogteMaxMay = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCboBloeiHoogteMinJun;
        public bool SelectedCboBloeiHoogteMinJun
        {
            get
            {
               
                return _selectedCboBloeiHoogteMinJun;
            }

            set
            {
                _selectedCboBloeiHoogteMinJun = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCboBloeiHoogteMaxJun;
        public bool SelectedCboBloeiHoogteMaxJun
        {
            get {
                
                return _selectedCboBloeiHoogteMaxJun;
            }

            set
            {
                _selectedCboBloeiHoogteMaxJun = value;
                OnPropertyChanged();
            }
        }
        private bool _selectedCboBloeiHoogteMinJul;
        public bool SelectedCboBloeiHoogteMinJul
        {
            get
            {
                
                return _selectedCboBloeiHoogteMinJul;
            }

            set
            {
                _selectedCboBloeiHoogteMinJul = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCboBloeiHoogteMaxJul;
        public bool SelectedCboBloeiHoogteMaxJul
        {
            get {
                
                return _selectedCboBloeiHoogteMaxJul;
            }

            set
            {
                _selectedCboBloeiHoogteMaxJul = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCboBloeiHoogteMinAug;
        public bool SelectedCboBloeiHoogteMinAug
        {
            get {
                
                return _selectedCboBloeiHoogteMinAug;
            }

            set
            {
                _selectedCboBloeiHoogteMinAug = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCboBloeiHoogteMaxAug;
        public bool SelectedCboBloeiHoogteMaxAug
        {
            get {
                
                return _selectedCboBloeiHoogteMaxAug;
            }

            set
            {
                _selectedCboBloeiHoogteMaxAug = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCboBloeiHoogteMinSep;
        public bool SelectedCboBloeiHoogteMinSep
        {
            get {
                
                return _selectedCboBloeiHoogteMinSep;
            }

            set
            {
                _selectedCboBloeiHoogteMinSep = value;
                OnPropertyChanged();
            }
        }
        private bool _selectedCboBloeiHoogteMaxSep;
        public bool SelectedCboBloeiHoogteMaxSep
        {
            get {
                
                return _selectedCboBloeiHoogteMaxSep;
            }

            set
            {
                _selectedCboBloeiHoogteMaxSep = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCboBloeiHoogteMinOct;
        public bool SelectedCboBloeiHoogteMinOct
        {
            get {
                
                return _selectedCboBloeiHoogteMinOct;
            }

            set
            {
                _selectedCboBloeiHoogteMinOct = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCboBloeiHoogteMaxOct;
        public bool SelectedCboBloeiHoogteMaxOct
        {
            get {
                
                return _selectedCboBloeiHoogteMaxOct;
            }

            set
            {
                _selectedCboBloeiHoogteMaxOct = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCboBloeiHoogteMinNov;
        public bool SelectedCboBloeiHoogteMinNov
        {
            get {
                
                return _selectedCboBloeiHoogteMinNov;
            }

            set
            {
                _selectedCboBloeiHoogteMinNov = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCboBloeiHoogteMaxNov;
        public bool SelectedCboBloeiHoogteMaxNov
        {
            get {
               
                return _selectedCboBloeiHoogteMaxNov;
            }

            set
            {
                _selectedCboBloeiHoogteMaxNov = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCboBloeiHoogteMinDec;
        public bool SelectedCboBloeiHoogteMinDec
        {
            get {
               
                return _selectedCboBloeiHoogteMinDec;
            }

            set
            {
                _selectedCboBloeiHoogteMinDec = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCboBloeiHoogteMaxDec;
        public bool SelectedCboBloeiHoogteMaxDec
        {
            get {
                
                return _selectedCboBloeiHoogteMaxDec;
            }

            set
            {
                _selectedCboBloeiHoogteMaxDec = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Binding Checkbox Bloeit In

        private bool _selectedCheckBoxBloeitInJan;
        
        public bool SelectedCheckBoxBloeitInJan
        {
            get {

                
                return _selectedCheckBoxBloeitInJan;
            }

            set
            {
                _selectedCheckBoxBloeitInJan = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeitInFeb;
        public bool SelectedCheckBoxBloeitInFeb
        {
            get {

                
                return _selectedCheckBoxBloeitInFeb;
            }

            set
            {
                _selectedCheckBoxBloeitInFeb = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeitInMar;
        public bool SelectedCheckBoxBloeitInMar
        {
            get {

                
                return _selectedCheckBoxBloeitInMar;
            }

            set
            {
                _selectedCheckBoxBloeitInMar = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeitInApr;
        public bool SelectedCheckBoxBloeitInApr
        {
            get {

                
                return _selectedCheckBoxBloeitInApr;
            }

            set
            {
                _selectedCheckBoxBloeitInApr = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeitInMay;
        public bool SelectedCheckBoxBloeitInMay
        {
            get {

                
                return _selectedCheckBoxBloeitInMay;
            }

            set
            {
                _selectedCheckBoxBloeitInMay = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeitInJun;
        public bool SelectedCheckBoxBloeitInJun
        {
            get {

                
                return _selectedCheckBoxBloeitInJun;
            }

            set
            {
                _selectedCheckBoxBloeitInJun = value;
                OnPropertyChanged();
            }
        }
        private bool _selectedCheckBoxBloeitInJul;
        public bool SelectedCheckBoxBloeitInJul
        {
            get {
                                               
                return _selectedCheckBoxBloeitInJul;
            }

            set
            {
                _selectedCheckBoxBloeitInJul = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeitInAug;
        public bool SelectedCheckBoxBloeitInAug
        {   
            
            get {

                return _selectedCheckBoxBloeitInAug;
            }

            set
            {
                _selectedCheckBoxBloeitInAug = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeitInSep;
        public bool SelectedCheckBoxBloeitInSep
        {
            get {
               
                return _selectedCheckBoxBloeitInSep;
            }

            set
            {
                _selectedCheckBoxBloeitInSep = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeitInOct;
        public bool SelectedCheckBoxBloeitInOct
        {
            get {
                
                return _selectedCheckBoxBloeitInOct;
            }

            set
            {
                _selectedCheckBoxBloeitInOct = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeitInNov;
        public bool SelectedCheckBoxBloeitInNov
        {
            get
            {
                       
                return _selectedCheckBoxBloeitInNov;
            }

            set
            {
                _selectedCheckBoxBloeitInNov = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeitInDec;
        public bool SelectedCheckBoxBloeitInDec
        {
            get {
                                
                return _selectedCheckBoxBloeitInDec;
            }

            set
            {
                _selectedCheckBoxBloeitInDec = value;
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

       
        //    #endregion
    }
}

