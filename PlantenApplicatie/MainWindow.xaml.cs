﻿using Planten2021.Data;
using Planten2021.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PlantenApplicatie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DAO dao;
        
        public MainWindow()
        {
            InitializeComponent();
            //DAO instance 
            dao = DAO.Instance();

            Frame_Navigated();
            // De comboBoxen vullen.

            // new dictionary aanmaken hier komen de resultaten in met als long het plant id en string is de plant info
            var dictionaryresult = new Dictionary<long, string>();

            fillComboBoxType();

            fillComboBoxFamilie();
            fillComboBoxGeslacht();
            fillComboBoxSoort();
            fillComboBoxVariant();
        }



        private void Frame_Navigated()
        {
            // alle canvases verstoppen
            lstResultSearch.Visibility = Visibility.Hidden;
            CvsZoeken.Visibility = Visibility.Hidden;
            cvsHabitat.Visibility = Visibility.Hidden;
            cvsDetails.Visibility = Visibility.Hidden;
        }

        private void BtnbackgroundColor() 
        {
            // achtergrond van buttons terug normaal zetten
            btnNaam.Background = Brushes.Olive;
            btnHabitat.Background = Brushes.Olive;
            
        }

        private void BtnNaam_Click(object sender, RoutedEventArgs e)
        {
            Frame_Navigated();
            // de button highlighten van de geslecteerde zoek functie
            btnNaam.Background = Brushes.Olive;
            // canvas tonen
            CvsZoeken.Visibility = Visibility.Visible;
        }

        private void BtnFilterOpslaanZoeken_Click(object sender, RoutedEventArgs e)
        {
            // nu nog nie nodig
            Frame_Navigated();

        }


        public string SimplifyGetallPlants(string stringToSimplify, string key)
        {
            //alle onnodige tekens er uit halen
            string answer = stringToSimplify.Replace(key, "").Replace("[", "").Replace("]", "").Replace(",", "").Replace(" ","");
            return answer;
        }


        private void BtnZoeken_Click(object sender, RoutedEventArgs e)
        {
            Frame_Navigated();
            BtnbackgroundColor();
            lstResultSearch.Visibility = Visibility.Visible;
            cvsDetails.Visibility = Visibility.Visible;
            // de lijst planten op vragen
            var listPlants = dao.getAllPlants();
            
            // kijken over er iets in de combobox is aan geduid
            if (Convert.ToInt32(cmbType.SelectedValue) != 0)
            {
                // alle onnodige tekens er uit halen 
                var simp = SimplifyGetallPlants(cmbType.SelectedItem.ToString(), cmbType.SelectedValue.ToString());
                // alle items in list plant overlopen
                foreach (var item in listPlants.ToList())
                {                   
                    //als het zoekwoord er niet in voor komt verwijderen.
                    if (item.Type.Contains(simp) == false)
                    {
                        listPlants.Remove(item);
                    }
                }
            }// Zie commentaar lijn 91
            if (cmbFamilie.SelectedValue != null)
            {
                var simp = SimplifyGetallPlants(cmbFamilie.SelectedItem.ToString(), cmbFamilie.SelectedValue.ToString());

                foreach (var item in listPlants.ToList())
                {
                    
                    if (item.Familie.Contains(simp) == false)
                    {
                        listPlants.Remove(item);
                    }
                }
            }// Zie commentaar lijn 91
            if (cmbGeslacht.SelectedValue != null)
            {
                var simp = SimplifyGetallPlants(cmbGeslacht.SelectedItem.ToString(), cmbGeslacht.SelectedValue.ToString());

                foreach (var item in listPlants.ToList())
                {
                   
                    if (item.Geslacht.Contains(simp) == false)
                    {
                        listPlants.Remove(item);
                    }
                }
            }// Zie commentaar lijn 91
            if (cmbSoort.SelectedValue != null)
            {
                var simp = SimplifyGetallPlants(cmbSoort.SelectedItem.ToString(), cmbSoort.SelectedValue.ToString());
               
                foreach (var item in listPlants.ToList())
                {
                     
                    if (item.Soort.Contains(simp) == false)
                    {
                        listPlants.Remove(item);
                    }
                }
            }// Zie commentaar lijn 91
            if (cmbVariant.SelectedValue != null)
            {
                var simp = SimplifyGetallPlants(cmbVariant.SelectedItem.ToString(), cmbVariant.SelectedValue.ToString());
                MessageBox.Show(simp);
                foreach (var item in listPlants.ToList())
                {
                    if (item.Variant != null)
                    {
                        if (item.Variant.Contains(simp) == false)
                        {
                            listPlants.Remove(item);
                        }
                    }
                    else
                    {
                        listPlants.Remove(item);
                    }
                }
            }

            Dictionary<long, string> dictionaryresult = new Dictionary<long, string>();

            // dictionary clearen zo da je niet het bijft opvullen met hezelfde als je meerdere keren op zoeken clickt
            dictionaryresult.Clear();
            // alles toevoegen aan een dictionare met als plantid key en de rest spreek voor zich
            foreach (var plant in listPlants)
            {
                dictionaryresult.Add
                                    (plant.PlantId,
                                    "Plantnaam = " + plant.Fgsv + Environment.NewLine
                                    + "type = " + plant.Type + Environment.NewLine
                                    + "famillie = " + plant.Familie + Environment.NewLine
                                    + "geslacht = " + plant.Geslacht + Environment.NewLine
                                    + "soort = " + plant.Soort + Environment.NewLine
                                    + "variant = " + plant.Variant + Environment.NewLine
                                    + "nederlandse naam = " + plant.NederlandsNaam + Environment.NewLine
                                    + "plantendichtheid = Min: " + plant.PlantdichtheidMin.ToString() + " Max: " + plant.PlantdichtheidMax.ToString() + Environment.NewLine
                                    );
            }

            // alles laden in result
            lstResultSearch.ItemsSource = dictionaryresult;
            lstResultSearch.DisplayMemberPath = "Value";
            lstResultSearch.SelectedValuePath = "Key";


            
        }
        

        //this function will print the result in the listbox
        //needs to be repaced by MVVM
        public void PrintInfo(List<Plant> listPlants)
        {

            foreach (Plant plant in listPlants)
            {
             lstResultSearch.Items.Add
                                 ( "Plantnaam = " + plant.Fgsv + Environment.NewLine
                                 + "type = " + plant.Type + Environment.NewLine
                                 + "famillie = " + plant.Familie + Environment.NewLine
                                 + "geslacht = " + plant.Geslacht + Environment.NewLine
                                 + "soort = " + plant.Soort + Environment.NewLine
                                 + "variant = " + plant.Variant + Environment.NewLine
                                 + "nederlandse naam = " + plant.NederlandsNaam + Environment.NewLine
                                 + "plantendichtheid = Min: " + plant.PlantdichtheidMin.ToString() + " Max: " + plant.PlantdichtheidMax.ToString() + Environment.NewLine
                                 );

            }
        }

        private void BtnHabitat_Click(object sender, RoutedEventArgs e)
        {
            Frame_Navigated();
            BtnbackgroundColor();
            // de button highlighten van de geslecteerde zoek functie
            btnHabitat.Background = Brushes.Olive;
            // canvas tonen
            cvsHabitat.Visibility = Visibility.Visible;
        }
        public void showResult()
        {
            Page page = new Page();
            page.Width = 50;
            page.Height = 100;
        }
     

        /// <summary>
        /// /////////////////////////////// CASCADE SYSTEEM
        ///  bij de fillcombobox functie word de lijst opgevraagd van de functie in de dao dan waar het meegegeven aan de combobox valuepath zijn de ID's, memberpath zijn de namen
        ///  met de item source geef je de lijs mee aan de combobox
        /// </summary>

        public void fillComboBoxType()
        {        
            // lijst opvragen
            var filltype = dao.fillTfgsvType();
            // alle objecten in combobox plaatsen
            cmbType.ItemsSource = filltype;
            cmbType.DisplayMemberPath = "Value";
            cmbType.SelectedValuePath = "Key";
        }

        public void fillComboBoxFamilie()
        {         
            // lijst opvragen
            var fillFamilie = dao.fillTfgsvFamilie(Convert.ToInt32(cmbType.SelectedValue));
            // alle objecten in combobox plaatsen
            cmbFamilie.ItemsSource = fillFamilie;
            cmbFamilie.DisplayMemberPath = "Value";
            cmbFamilie.SelectedValuePath = "Key";
        }

        public void fillComboBoxGeslacht()
        {
            // lijst opvragen
            var fillGeslacht = dao.fillTfgsvGeslacht(Convert.ToInt32(cmbFamilie.SelectedValue));
            // alle objecten in combobox plaatsen
            cmbGeslacht.ItemsSource = fillGeslacht;
            cmbGeslacht.DisplayMemberPath = "Value";
            cmbGeslacht.SelectedValuePath = "Key";
        }
        public void fillComboBoxSoort()
        {
            // lijst opvragen
            var fillSoort = dao.fillTfgsvSoort(Convert.ToInt32(cmbGeslacht.SelectedValue));
            // alle objecten in combobox plaatsen
            cmbSoort.ItemsSource = fillSoort;
            cmbSoort.DisplayMemberPath = "Value";
            cmbSoort.SelectedValuePath = "Key";
        }
        public void fillComboBoxVariant()
        {
            // lijst opvragen
            var fillVariant = dao.fillTfgsvVariant(Convert.ToInt32(cmbGeslacht.SelectedValue));
            // alle objecten in combobox plaatsen
            cmbVariant.ItemsSource = fillVariant;
            cmbVariant.DisplayMemberPath = "Value";
            cmbVariant.SelectedValuePath = "Key";
        }

        public string Simplify(string stringToSimplify, string id)
        {
            string answer = stringToSimplify.Replace(id,"").Replace(",","").Replace("[","").Replace("]","");
            
            return answer;
        }

        Dictionary<string, string> opgeslagenFilters = new Dictionary<string, string>();

        private void fillLstOpgeslagenFilters(string Id, string Name)
        {
           
            //lijst opvragen
            if (opgeslagenFilters.ContainsKey(Id))
            {
                opgeslagenFilters.Remove(Id);
               
            }
            opgeslagenFilters.Add(Id,Name);

            LstOpgeslagenFilters.Items.Clear();
            //alle objecten in listbox plaatsen

            foreach (var item in opgeslagenFilters)
            {
                LstOpgeslagenFilters.Items.Add(item.Value);
            }


        }

        // Deze Events zijn als er iets veranderd in de combobox de er een nieuw lijst word aangemaakt voor de combobox te vullen

        private void cmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            
            fillComboBoxFamilie();
            if (cmbType.SelectedValue != null)
            {
                var fillFilters = Simplify(cmbType.SelectedItem.ToString(), cmbType.SelectedValue.ToString());
                fillLstOpgeslagenFilters("cmbType", "Type : " + fillFilters);
            }
            
        }

        private void cmbFamilie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillComboBoxGeslacht();
            if (cmbFamilie.SelectedValue != null)
            {
                var fillFilters = Simplify(cmbFamilie.SelectedItem.ToString(), cmbFamilie.SelectedValue.ToString());
                fillLstOpgeslagenFilters("cmbFamilie", "Familie : "+fillFilters);
            }
           
        }

        private void cmbGeslacht_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           fillComboBoxSoort();
           fillComboBoxVariant();
            if (cmbGeslacht.SelectedValue != null)
            {
                var fillFilters = Simplify(cmbGeslacht.SelectedItem.ToString(), cmbGeslacht.SelectedValue.ToString());
                fillLstOpgeslagenFilters("cmbGeslacht", "Geslacht : " +fillFilters);
            }
           
        }

        private void cmbSoort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { 
            if (cmbSoort.SelectedValue != null)
            {
                var fillFilters = Simplify(cmbSoort.SelectedItem.ToString(), cmbSoort.SelectedValue.ToString());
                fillLstOpgeslagenFilters("cmbSoort", "Soort : " +fillFilters);
            }
            
        }
        private void cmbVariant_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbVariant.SelectedValue != null)
            {
                var fillFilters = Simplify(cmbVariant.SelectedItem.ToString(), cmbVariant.SelectedValue.ToString());
                fillLstOpgeslagenFilters("cmbVariant", "Variant : " +fillFilters);
            }
        }
        private void lstResultSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstResultSearch.SelectedValue != null)
            {
                MessageBox.Show(lstResultSearch.SelectedValue.ToString());
                var plants = dao.detailsAanvullen(Convert.ToInt64(lstResultSearch.SelectedValue));

                foreach (var item in plants)
                {
                    lblFamilie.Content = item.Familie;
                    lblGeslacht.Content = item.Geslacht;
                    lblSoort.Content = item.Soort;
                    lblType.Content = item.Type;
                    lblVariant.Content = item.Variant;
                    lblNederlandseNaam.Content = item.NederlandsNaam;
                    lblPlantdichtheidMin.Content = item.PlantdichtheidMin;
                    lblPlanctdichtheidMax.Content = item.PlantdichtheidMax;
                    lblStatus.Content = item.Status;
                    lblPlantId.Content = item.PlantId;
                    //lblBezonning.Content = item.Bezonning;
                    //lblGrondsoort.Content = item.Grondsoort;
                    //lblVochtbehoefte.Content = item.Vochtbehoefte;
                    //lblVoedingsbehoefte.Content = item.Voedingsbehoefte;
                    //lblAntagonischeOmgeving.Content = item.AgantonischeOmgeving;
                    //lblCultivar.Content = item.Cultivar;
                    //Sociabiliteit lblGrondsoort.Content = item.Sociabiliteit;
                    //lblOntwikkelingsnelheid.Content = item.Ontwikkelingsnelheid;
                    //lblConcurrentieKracht.Content = item.ConcurrentieKracht;
                    //lblNectarwaarde.Content = item.Nectarwaarde;
                    //lblBijvriendelijk.Content = item.Bijvriendelijk;
                    //lblEetKruidbaar.Content = item.EetKruidbaar;
                    //lblGeurend.Content = item.Geurend;
                    //lblVlinderVriendelijk.Content = item.Vlindervriendelijk;
                    //lblVorstgevoelig.Content = item.Vorstgevoelig;
                    //lblBloeikleur.Content = item.Bloeikeur;
                    //lblBloeihoogte.Content = item.Bloeihoogte;
                    //lblBloeiwijze.Content = item.Bloeiwijze;
                    //Strategie lblStrategie.Content = item.Strategie;
                    //lblBladkleur.Content = item.Bladkleur;
                    //lblBladhoogte.Content = item.Bladhoogte;
                    //lblBladvormen.Content = item.Bladvormen;
                    //lblStengelvormen.Content = item.Stengelvormen;
                    //lblLevensvorm.Content = item.Levensvorm;
                    //lblSpruitfenologie.Content = item.Spruitfenologie;
                    //lblOptimalePlantdichtheid.Content = item.Plantdichtheid;



                    //lstDetails.Items.Add
                    //                    ("Plantnaam = " + plant.Fgsv + Environment.NewLine
                    //                    + "type = " + plant.Type + Environment.NewLine
                    //                    + "famillie = " + plant.Familie + Environment.NewLine
                    //                    + "geslacht = " + plant.Geslacht + Environment.NewLine
                    //                    + "soort = " + plant.Soort + Environment.NewLine
                    //                    + "variant = " + plant.Variant + Environment.NewLine
                    //                    + "nederlandse naam = " + plant.NederlandsNaam + Environment.NewLine
                    //                    + "plantendichtheid = Min: " + plant.PlantdichtheidMin.ToString() + " Max: " + plant.PlantdichtheidMax.ToString() + Environment.NewLine
                    //                    + "status = " + plant.Status.ToString()
                    //                    ); ;


                }
            }
            
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            LstOpgeslagenFilters.Items.Clear();
            


            lstResultSearch.ItemsSource = null;

            cmbType.SelectedIndex = -1;
            cmbFamilie.SelectedIndex = -1;
            cmbGeslacht.SelectedIndex = -1;
            cmbSoort.SelectedIndex = -1;
            cmbVariant.SelectedIndex = -1;

            Frame_Navigated();
        }
    }
}
