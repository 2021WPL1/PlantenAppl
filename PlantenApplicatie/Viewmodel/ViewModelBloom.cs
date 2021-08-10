using PlantenApplicatie.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Printing;
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
        //public Plant _selectedPlant { get; set; }

        public List<FenotypeMulti> fenoTypeMulti { get; set; }


        public RelayCommand resetBloom { get; set; }
        public bool isChecked;

        private Plant _selectedPlant;

        public ViewModelBloom(IDetailService detailservice)
        {
            _detailService = detailservice;
            //_selectedPlant = _SearchService.ReturnSelectedPlant();
            resetBloom = new RelayCommand(ResetBloomCommand);

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
                OnPropertyChanged();
            }
        }

        private void ResetBloomCommand()
        {
            
            //_selectedPlant = _SearchService.ReturnSelectedPlant();
            fenoTypeMulti = _detailService.FilterFenoMulti(_selectedPlant.PlantId);
            if (_selectedPlant == null)
            {
                MessageBox.Show("Je hebt nog geen plant geselecteerd!");
            }
            else
            {

                //_detailService.FilterFenoMulti(_selectedPlant.PlantId);
                //MessageBox.Show(_selectedPlant.Familie + " tadaah");
                //DoesItNeedToBeChecked();
            }

        }

        public bool CheckColor(string color, string month)
        {
            var plant = _SearchService.ReturnSelectedPlant();
            fenoTypeMulti = _detailService.FilterFenoMulti(plant.PlantId);
            //isChecked = true;
            foreach (var fenotypeMulti in fenoTypeMulti)
            {
                if (fenotypeMulti.Waarde == color && fenotypeMulti.Eigenschap == "bloeikleur" && fenotypeMulti.Maand == month)
                {
                    isChecked = true;
                }
                else
                {
                    isChecked = false;
                }
            }
            return isChecked;
        }


//        public void SetBloomPage(string month)
//        {
//            switch (month)
//	{
//                case "januari":
//                    if (CheckColor("zwart","januari"))
//                    {
//                        SelectedCheckBoxBloeikleurZwart = true;
//                    }
//                    if (CheckColor("wit","januari"))
//                    {
//                        SelectedCheckBoxBloeikleurWit = true;
//                    }
//                    break;
//		default:
//	}
//}
        //public void DoesItNeedToBeChecked()
        //{
        //    isChecked = true;
        //    foreach (var fenotypeMulti in fenoTypeMulti)
        //    {
        //        if (fenotypeMulti.Maand == "oktober" && fenotypeMulti.Waarde == "zwart")
        //        {
        //            isChecked = true;
        //            MessageBox.Show(fenotypeMulti.Waarde);
        //        }
        //        else
        //        {
        //            isChecked = false;
        //            MessageBox.Show("nope");
        //        }
        //    }
        //}
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
                //isChecked = true;

                _selectedPlant = _SearchService.ReturnSelectedPlant();
                //DoesItNeedToBeChecked();
                if (CheckColor("zwart", "januari"))
                {
                    isChecked = true;
                }
                else
                {
                    isChecked = false;
                }
                _selectedCheckBoxBloeikleurZwart = isChecked;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeikleurWit;
        public bool SelectedCheckBoxBloeikleurWit
        {
            get
            {
                _selectedPlant = _SearchService.ReturnSelectedPlant();
                //DoesItNeedToBeChecked();
                if (CheckColor("wit", "mei"))
                {
                    isChecked = true;
                }
                else
                {
                    isChecked = false;
                }
                _selectedCheckBoxBloeikleurZwart = isChecked;
                return _selectedCheckBoxBloeikleurWit;
            }

            set
            {
                _selectedCheckBoxBloeikleurWit = true;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeikleurRosé;
        public bool SelectedCheckBoxBloeikleurRosé
        {
            get
            {
                _selectedPlant = _SearchService.ReturnSelectedPlant();
                //DoesItNeedToBeChecked();
                if (true)
                {
                    isChecked = true;
                }
                else
                {
                    isChecked = false;
                }
                _selectedCheckBoxBloeikleurRosé = isChecked;
                return _selectedCheckBoxBloeikleurZwart;
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
            get { return _selectedCheckBoxBloeikleurRood; }

            set
            {
                _selectedCheckBoxBloeikleurRood = value;
               OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeikleurOranje;
        public bool SelectedCheckBoxBloeikleurOranje
        {
            get { return _selectedCheckBoxBloeikleurOranje; }

            set
            {
                _selectedCheckBoxBloeikleurOranje = value;
               OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeikleurLila;
        public bool SelectedCheckBoxBloeikleurLila
        {
            get { return _selectedCheckBoxBloeikleurLila; }

            set
            {
                _selectedCheckBoxBloeikleurLila = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeikleurGrijs;
        public bool SelectedCheckBoxBloeikleurGrijs
        {
            get { return _selectedCheckBoxBloeikleurGrijs; }

            set
            {
                _selectedCheckBoxBloeikleurGrijs = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeikleurGroen;
        public bool SelectedCheckBoxBloeikleurGroen
        {
            get { return _selectedCheckBoxBloeikleurGroen; }

            set
            {
                _selectedCheckBoxBloeikleurGroen = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeikleurGeel;
        public bool SelectedCheckBoxBloeikleurGeel
        {
            get { return _selectedCheckBoxBloeikleurGeel; }

            set
            {
                _selectedCheckBoxBloeikleurGeel= value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeikleurBlauw;
        public bool SelectedCheckBoxBloeikleurBlauw
        {
            get { return _selectedCheckBoxBloeikleurBlauw; }

            set
            {
                _selectedCheckBoxBloeikleurBlauw = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeikleurViolet;
        public bool SelectedCheckBoxBloeikleurViolet
        {
            get { return _selectedCheckBoxBloeikleurViolet; }

            set
            {
                _selectedCheckBoxBloeikleurViolet = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeikleurPaars;
        public bool SelectedCheckBoxBloeikleurPaars
        {
            get { return _selectedCheckBoxBloeikleurPaars; }

            set
            {
                _selectedCheckBoxBloeikleurPaars = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeikleurBruin;
        public bool SelectedCheckBoxBloeikleurBruin
        {
            get { return _selectedCheckBoxBloeikleurBruin; }

            set
            {
                _selectedCheckBoxBloeikleurBruin = value;
                OnPropertyChanged();
            }
        }

        #endregion
        private string _selectedBloeiHoogte;

        public string SelectedBloeiHoogte
        {
            get { return _selectedBloeiHoogte; }
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
            get { return _selectedCboBloeiHoogteMinJan; }

            set
            {
                _selectedCboBloeiHoogteMinJan = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCboBloeiHoogteMaxJan;
        public bool SelectedCboBloeiHoogteMaxJan
        {
            get { return _selectedCboBloeiHoogteMaxJan; }

            set
            {
                _selectedCboBloeiHoogteMaxJan = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCboBloeiHoogteMinFeb;
        public bool SelectedCboBloeiHoogteMinFeb
        {
            get { return _selectedCboBloeiHoogteMinFeb; }

            set
            {
                _selectedCboBloeiHoogteMinFeb = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCboBloeiHoogteMaxFeb;
        public bool SelectedCboBloeiHoogteMaxFeb
        {
            get { return _selectedCboBloeiHoogteMaxFeb; }

            set
            {
                _selectedCboBloeiHoogteMaxFeb = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCboBloeiHoogteMinMar;
        public bool SelectedCboBloeiHoogteMinMar
        {
            get { return _selectedCboBloeiHoogteMinMar; }

            set
            {
                _selectedCboBloeiHoogteMinMar = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCboBloeiHoogteMaxMar;
        public bool SelectedCboBloeiHoogteMaxMar
        {
            get { return _selectedCboBloeiHoogteMaxMar; }

            set
            {
                _selectedCboBloeiHoogteMaxMar = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCboBloeiHoogteMinApr;
        public bool SelectedCboBloeiHoogteMinApr
        {
            get { return _selectedCboBloeiHoogteMinApr; }

            set
            {
                _selectedCboBloeiHoogteMinApr = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCboBloeiHoogteMaxApr;
        public bool SelectedCboBloeiHoogteMaxApr
        {
            get { return _selectedCboBloeiHoogteMaxApr; }

            set
            {
                _selectedCboBloeiHoogteMaxApr = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCboBloeiHoogteMinMay;
        public bool SelectedCboBloeiHoogteMinMay
        {
            get { return _selectedCboBloeiHoogteMinMay; }

            set
            {
                _selectedCboBloeiHoogteMinMay = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCboBloeiHoogteMaxMay;
        public bool SelectedCboBloeiHoogteMaxMay
        {
            get { return _selectedCboBloeiHoogteMaxMay; }

            set
            {
                _selectedCboBloeiHoogteMaxMay = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCboBloeiHoogteMinJun;
        public bool SelectedCboBloeiHoogteMinJun
        {
            get { return _selectedCboBloeiHoogteMinJun; }

            set
            {
                _selectedCboBloeiHoogteMinJun = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCboBloeiHoogteMaxJun;
        public bool SelectedCboBloeiHoogteMaxJun
        {
            get { return _selectedCboBloeiHoogteMaxJun; }

            set
            {
                _selectedCboBloeiHoogteMaxJun = value;
                OnPropertyChanged();
            }
        }
        private bool _selectedCboBloeiHoogteMinJul;
        public bool SelectedCboBloeiHoogteMinJul
        {
            get { return _selectedCboBloeiHoogteMinJul; }

            set
            {
                _selectedCboBloeiHoogteMinJul = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCboBloeiHoogteMaxJul;
        public bool SelectedCboBloeiHoogteMaxJul
        {
            get { return _selectedCboBloeiHoogteMaxJul; }

            set
            {
                _selectedCboBloeiHoogteMaxJul = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCboBloeiHoogteMinAug;
        public bool SelectedCboBloeiHoogteMinAug
        {
            get { return _selectedCboBloeiHoogteMinAug; }

            set
            {
                _selectedCboBloeiHoogteMinAug = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCboBloeiHoogteMaxAug;
        public bool SelectedCboBloeiHoogteMaxAug
        {
            get { return _selectedCboBloeiHoogteMaxAug; }

            set
            {
                _selectedCboBloeiHoogteMaxAug = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCboBloeiHoogteMinSep;
        public bool SelectedCboBloeiHoogteMinSep
        {
            get { return _selectedCboBloeiHoogteMinSep; }

            set
            {
                _selectedCboBloeiHoogteMinSep = value;
                OnPropertyChanged();
            }
        }
        private bool _selectedCboBloeiHoogteMaxSep;
        public bool SelectedCboBloeiHoogteMaxSep
        {
            get { return _selectedCboBloeiHoogteMaxSep; }

            set
            {
                _selectedCboBloeiHoogteMaxSep = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCboBloeiHoogteMinOct;
        public bool SelectedCboBloeiHoogteMinOct
        {
            get { return _selectedCboBloeiHoogteMinOct; }

            set
            {
                _selectedCboBloeiHoogteMinOct = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCboBloeiHoogteMaxOct;
        public bool SelectedCboBloeiHoogteMaxOct
        {
            get { return _selectedCboBloeiHoogteMaxOct; }

            set
            {
                _selectedCboBloeiHoogteMaxOct = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCboBloeiHoogteNov;
        public bool SelectedCboBloeiHoogteNov
        {
            get { return _selectedCboBloeiHoogteNov; }

            set
            {
                _selectedCboBloeiHoogteNov = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCboBloeiHoogteMaxNov;
        public bool SelectedCboBloeiHoogteMaxNov
        {
            get { return _selectedCboBloeiHoogteMaxNov; }

            set
            {
                _selectedCboBloeiHoogteMaxNov = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCboBloeiHoogteMinDec;
        public bool SelectedCboBloeiHoogteDec
        {
            get { return _selectedCboBloeiHoogteMinDec; }

            set
            {
                _selectedCboBloeiHoogteMinDec = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCboBloeiHoogteMaxDec;
        public bool SelectedCboBloeiHoogteMaxDec
        {
            get { return _selectedCboBloeiHoogteMaxDec; }

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
            get { return _selectedCheckBoxBloeitInJan; }

            set
            {
                _selectedCheckBoxBloeitInJan = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeitInFeb;
        public bool SelectedCheckBoxBloeitInFeb
        {
            get { return _selectedCheckBoxBloeitInFeb; }

            set
            {
                _selectedCheckBoxBloeitInFeb = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeitInMar;
        public bool SelectedCheckBoxBloeitInMar
        {
            get { return _selectedCheckBoxBloeitInMar; }

            set
            {
                _selectedCheckBoxBloeitInMar = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeitInApr;
        public bool SelectedCheckBoxBloeitInApr
        {
            get { return _selectedCheckBoxBloeitInApr; }

            set
            {
                _selectedCheckBoxBloeitInApr = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeitInMay;
        public bool SelectedCheckBoxBloeitInMay
        {
            get { return _selectedCheckBoxBloeitInMay; }

            set
            {
                _selectedCheckBoxBloeitInMay = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeitInJun;
        public bool SelectedCheckBoxBloeitInJun
        {
            get { return _selectedCheckBoxBloeitInJun; }

            set
            {
                _selectedCheckBoxBloeitInJun = value;
                OnPropertyChanged();
            }
        }
        private bool _selectedCheckBoxBloeitInJul;
        public bool SelectedCheckBoxBloeitInJul
        {
            get { return _selectedCheckBoxBloeitInJul; }

            set
            {
                _selectedCheckBoxBloeitInJul = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeitInAug;
        public bool SelectedCheckBoxBloeitInAug
        {
            get { return _selectedCheckBoxBloeitInAug; }

            set
            {
                _selectedCheckBoxBloeitInAug = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeitInSep;
        public bool SelectedCheckBoxBloeitInSep
        {
            get { return _selectedCheckBoxBloeitInSep; }

            set
            {
                _selectedCheckBoxBloeitInSep = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeitInOct;
        public bool SelectedCheckBoxBloeitInOct
        {
            get { return _selectedCheckBoxBloeitInOct; }

            set
            {
                _selectedCheckBoxBloeitInOct = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeitInNov;
        public bool SelectedCheckBoxBloeitInNov
        {
            get { return _selectedCheckBoxBloeitInNov; }

            set
            {
                _selectedCheckBoxBloeitInNov = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBloeitInDec;
        public bool SelectedCheckBoxBloeitInDec
        {
            get { return _selectedCheckBoxBloeitInDec; }

            set
            {
                _selectedCheckBoxBloeitInDec = value;
                OnPropertyChanged();
            }
        }


        #endregion

        #region Binding Combobox Bloeiwijze

        //public void fillComboBoxBloeiwijze()
        //{
        //    var list = _dao.fillComboboxBloeiwijze();

        //    foreach (var item in list)
        //    {

        //        CboBloeiwijze.Add(item);

        //    }
        //}

        private string _selectedCboBloeiwijze;

        public string SelectedCboBloeiwijze
        {
            get { return _selectedCboBloeiwijze; }
            set
            {
                _selectedCboBloeiwijze = value;
                OnPropertyChanged();

            }
        }
        #endregion

        //    #region Binding checkboxes Bloeiwijzevorm

        //    private bool _selectedCheckBoxBloeiwijzeVorm1;
        //    public bool SelectedCheckBoxBloeiwijzeVorm1
        //    {
        //        get { return _selectedCheckBoxBloeiwijzeVorm1; }

        //        set
        //        {
        //            _selectedCheckBoxBloeiwijzeVorm1 = value;
        //            OnPropertyChanged();
        //        }
        //    }

        //    private bool _selectedCheckBoxBloeiwijzeVorm2;
        //    public bool SelectedCheckBoxBloeiwijzeVorm2
        //    {
        //        get { return _selectedCheckBoxBloeiwijzeVorm2; }

        //        set
        //        {
        //            _selectedCheckBoxBloeiwijzeVorm2 = value;
        //            OnPropertyChanged();
        //        }
        //    }

        //    private bool _selectedCheckBoxBloeiwijzeVorm3;
        //    public bool SelectedCheckBoxBloeiwijzeVorm3
        //    {
        //        get { return _selectedCheckBoxBloeiwijzeVorm3; }

        //        set
        //        {
        //            _selectedCheckBoxBloeiwijzeVorm3 = value;
        //            OnPropertyChanged();
        //        }
        //    }

        //    private bool _selectedCheckBoxBloeiwijzeVorm4;
        //    public bool SelectedCheckBoxBloeiwijzeVorm4
        //    {
        //        get { return _selectedCheckBoxBloeiwijzeVorm4; }

        //        set
        //        {
        //            _selectedCheckBoxBloeiwijzeVorm4 = value;
        //            OnPropertyChanged();
        //        }
        //    }

        //    private bool _selectedCheckBoxBloeiwijzeVorm5;
        //    public bool SelectedCheckBoxBloeiwijzeVorm5
        //    {
        //        get { return _selectedCheckBoxBloeiwijzeVorm5; }

        //        set
        //        {
        //            _selectedCheckBoxBloeiwijzeVorm5 = value;
        //            OnPropertyChanged();
        //        }
        //    }

        //    private bool _selectedCheckBoxBloeiwijzeVorm6;
        //    public bool SelectedCheckBoxBloeiwijzeVorm6
        //    {
        //        get { return _selectedCheckBoxBloeiwijzeVorm6; }

        //        set
        //        {
        //            _selectedCheckBoxBloeiwijzeVorm6 = value;
        //            OnPropertyChanged();
        //        }
        //    }

        //    #endregion

        #region Binding checkboxen BladHoogte

        private bool _selectedCheckBoxBladHoogteJan;
        public bool SelectedCheckBoxBladHoogteJan
        {
            get { return _selectedCheckBoxBladHoogteJan; }

            set
            {
                _selectedCheckBoxBladHoogteJan = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladHoogteFeb;
        public bool SelectedCheckBoxBladHoogteFeb
        {
            get { return _selectedCheckBoxBladHoogteFeb; }

            set
            {
                _selectedCheckBoxBladHoogteFeb = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladHoogteMar;
        public bool SelectedCheckBoxBladHoogteMar
        {
            get { return _selectedCheckBoxBladHoogteMar; }

            set
            {
                _selectedCheckBoxBladHoogteMar = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladHoogteApr;
        public bool SelectedCheckBoxBladHoogteApr
        {
            get { return _selectedCheckBoxBladHoogteApr; }

            set
            {
                _selectedCheckBoxBladHoogteApr = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladHoogteMay;
        public bool SelectedCheckBoxBladHoogteMay
        {
            get { return _selectedCheckBoxBladHoogteMay; }

            set
            {
                _selectedCheckBoxBladHoogteMay = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladHoogteJun;
        public bool SelectedCheckBoxBladHoogteJun
        {
            get { return _selectedCheckBoxBladHoogteJun; }

            set
            {
                _selectedCheckBoxBladHoogteJun = value;
                OnPropertyChanged();
            }
        }
        private bool _selectedCheckBoxBladHoogteJul;
        public bool SelectedCheckBoxBladHoogteJul
        {
            get { return _selectedCheckBoxBladHoogteJul; }

            set
            {
                _selectedCheckBoxBladHoogteJul = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladHoogteAug;
        public bool SelectedCheckBoxBladHoogteAug
        {
            get { return _selectedCheckBoxBladHoogteAug; }

            set
            {
                _selectedCheckBoxBladHoogteAug = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladHoogteSep;
        public bool SelectedCheckBoxBladHoogteSep
        {
            get { return _selectedCheckBoxBladHoogteSep; }

            set
            {
                _selectedCheckBoxBladHoogteSep = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladHoogteOct;
        public bool SelectedCheckBoxBladHoogteOct
        {
            get { return _selectedCheckBoxBladHoogteOct; }

            set
            {
                _selectedCheckBoxBladHoogteOct = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladHoogteNov;
        public bool SelectedCheckBoxBladHoogteNov
        {
            get { return _selectedCheckBoxBladHoogteNov; }

            set
            {
                _selectedCheckBoxBladHoogteNov = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladHoogteDec;
        public bool SelectedCheckBoxBladHoogteDec
        {
            get { return _selectedCheckBoxBladHoogteDec; }

            set
            {
                _selectedCheckBoxBladHoogteDec = value;
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

        private bool _selectedCheckBoxBladvormenVorm6;
        public bool SelectedCheckBoxBladvormenVorm6
        {
            get { return _selectedCheckBoxBladvormenVorm6; }

            set
            {
                _selectedCheckBoxBladvormenVorm6 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladvormenVorm7;
        public bool SelectedCheckBoxBladvormenVorm7
        {
            get { return _selectedCheckBoxBladvormenVorm7; }

            set
            {
                _selectedCheckBoxBladvormenVorm7 = value;
                MessageBox.Show(SelectedCheckBoxBladvormenVorm7.ToString());
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladvormenVorm8;
        public bool SelectedCheckBoxBladvormenVorm8
        {
            get { return _selectedCheckBoxBladvormenVorm8; }

            set
            {
                _selectedCheckBoxBladvormenVorm8 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxBladvormenVorm9;
        public bool SelectedCheckBoxBladvormenVorm9
        {
            get { return _selectedCheckBoxBladvormenVorm9; }

            set
            {
                _selectedCheckBoxBladvormenVorm9 = value;
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

        private bool _selectedCheckBoxLevensvormenVorm7;
        public bool SelectedCheckBoxLevensvormenVorm7
        {
            get { return _selectedCheckBoxLevensvormenVorm7; }

            set
            {
                _selectedCheckBoxLevensvormenVorm7 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxLevensvormenVorm8;
        public bool SelectedCheckBoxLevensvormenVorm8
        {
            get { return _selectedCheckBoxLevensvormenVorm8; }

            set
            {
                _selectedCheckBoxLevensvormenVorm8 = value;
                OnPropertyChanged();
            }
        }

        private bool _selectedCheckBoxLevensvormenVorm9;
        public bool SelectedCheckBoxLevensvormenVorm9
        {
            get { return _selectedCheckBoxLevensvormenVorm9; }

            set
            {
                _selectedCheckBoxLevensvormenVorm9 = value;
                OnPropertyChanged();
            }
        }


        #endregion
    }
}

