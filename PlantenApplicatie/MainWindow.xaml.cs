﻿using Planten2021.Data;
using Planten2021.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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

            cmbType.IsEditable = true;
            cmbFamilie.IsEditable = true;
            cmbGeslacht.IsEditable = true;
            cmbSoort.IsEditable = true;
            cmbVariant.IsEditable = true;
           

            fillComboBoxType();
            fillComboBoxFamilie();
            fillComboBoxGeslacht();
            fillComboBoxSoort();
            fillComboBoxVariant();
            fillComboBoxRatioBladBloei();

        }

        // new dictionary aanmaken hier komen de resultaten in met als long het plant id en string is de plant info
        Dictionary<long, string> dictionaryresult = new Dictionary<long, string>();
        // dit is de lijst waar geslecteerde filters inkomen men als eerste string  bv. de combobox naam en als 2 string de info
        Dictionary<string, string> opgeslagenFilters = new Dictionary<string, string>();
        // THis is for the detail screen
        Dictionary<long, string> Detailsresult = new Dictionary<long, string>();

        private void Frame_Navigated()
        {
            // alle canvases verstoppen
            lstResultSearch.Visibility = Visibility.Hidden;
            CvsZoeken.Visibility = Visibility.Hidden;
            cvsHabitat.Visibility = Visibility.Hidden;
            lstDetails.Visibility = Visibility.Hidden;
        }

        private void BtnbackgroundColor()
        {
           
            var DefaultColor = new SolidColorBrush(Color.FromArgb(255, (71), (64), (41)));
            // achtergrond van buttons terug normaal zetten
            btnNaam.Background = DefaultColor;
            btnHabitat.Background = DefaultColor;
            
        }

        private void BtnNaam_Click(object sender, RoutedEventArgs e)
        {
            Frame_Navigated();

            BtnbackgroundColor();
            // de button highlighten van de geslecteerde zoek functie
            btnNaam.Background = Brushes.Olive;
            // canvas tonen
            CvsZoeken.Visibility = Visibility.Visible;
        }


        private void BtnZoeken_Click(object sender, RoutedEventArgs e)
        {
            Frame_Navigated();
            BtnbackgroundColor();
            lstResultSearch.Visibility = Visibility.Visible;
            lstDetails.Visibility = Visibility.Visible;
      
            // de lijst planten op vragen
            var listPlants = dao.getAllPlants();
            
            lstResultSearch.Items.Refresh();


            // kijken over er iets in de combobox is aan geduid
            if (cmbType.SelectedValue != null)
            {
                // alle onnodige tekens er uit halen 
                var ControlString = Simplify(cmbType.SelectedItem.ToString(), cmbType.SelectedValue.ToString());
                // alle items in list plant overlopen
                foreach (var item in listPlants.ToList())
                {                   
                    //als het zoekwoord er niet in voor komt verwijderen.
                    if (item.Type.Contains(ControlString) == false)
                    {
                        listPlants.Remove(item);
                    }
                }
            }// Zie commentaar lijn 91
            if (cmbFamilie.SelectedValue != null)
            {
                var ControlString = Simplify(cmbFamilie.SelectedItem.ToString(), cmbFamilie.SelectedValue.ToString());

                foreach (var item in listPlants.ToList())
                {
                    
                    if (item.Familie.Contains(ControlString) == false)
                    {
                        listPlants.Remove(item);
                    }
                }
            }// Zie commentaar lijn 91
            if (cmbGeslacht.SelectedValue != null)
            {
                var ControlString = Simplify(cmbGeslacht.SelectedItem.ToString(), cmbGeslacht.SelectedValue.ToString());

                foreach (var item in listPlants.ToList())
                {
                   
                    if (item.Geslacht.Contains(ControlString) == false)
                    {
                        listPlants.Remove(item);
                    }
                }
            }// Zie commentaar lijn 91
            if (cmbSoort.SelectedValue != null)
            {
                var ControlString = Simplify(cmbSoort.SelectedItem.ToString(), cmbSoort.SelectedValue.ToString());
               
                foreach (var item in listPlants.ToList())
                {
                     
                    if (item.Soort.Contains(ControlString) == false)
                    {
                        listPlants.Remove(item);
                    }
                }
            }// Zie commentaar lijn 91
            if (cmbVariant.SelectedValue != null)
            {
                var ControlString = Simplify(cmbVariant.SelectedItem.ToString(), cmbVariant.SelectedValue.ToString());

                foreach (var item in listPlants.ToList())
                {
                   
                    if (item.Variant != null)
                    {

                        if (Simplify(item.Variant, "0")  != ControlString)
                        {
                            
                            listPlants.Remove(item);
                        }
                    }
                    else if (item.Variant == null)
                    {
                         listPlants.Remove(item);
                    }

                }
            }

            if (txtNederlandseNaam.Text != "")
            {
                foreach (var item in listPlants.ToList())
                {

                    if (item.NederlandsNaam != null)
                    {
                        if (item.NederlandsNaam.Contains(txtNederlandseNaam.Text) == false)
                        {
                            listPlants.Remove(item);
                        }

                    }
                    else if (item.NederlandsNaam == null)
                    {
                        listPlants.Remove(item);
                    }

                }
            }

            if (cmbRatioBladBloei.SelectedValue != null)
            {
                var ControlString = Simplify(cmbRatioBladBloei.SelectedItem.ToString(), cmbRatioBladBloei.SelectedValue.ToString());

                foreach (var item in listPlants.ToList())
                {
                    if (item.Fenotype.Count != 0)
                    {
                        foreach (var itemFenotype in item.Fenotype)
                        {

                            if (itemFenotype.RatioBloeiBlad != null || itemFenotype.RatioBloeiBlad != String.Empty)
                            {

                                if (Simplify(itemFenotype.RatioBloeiBlad, "0") != ControlString)
                                {

                                    //listPlants.Remove(item);
                                    listPlants.Remove(item);
                                }
                            }
                            else
                            {
                                listPlants.Remove(item);
                            }
                        }
                    }
                    else
                    {
                        listPlants.Remove(item);
                    }

                }

            }


            CheckBox dynamicCheckBox = new CheckBox();

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

        private void BtnHabitat_Click(object sender, RoutedEventArgs e)
        {
            Frame_Navigated();
            BtnbackgroundColor();
            // de button highlighten van de geslecteerde zoek functie
            btnHabitat.Background = Brushes.Olive;
            // canvas tonen
            cvsHabitat.Visibility = Visibility.Visible;
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

            cmbFamilie.ItemsSource = fillFamilie ;
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

            foreach (var item in fillSoort)
            {
                if (item.Value.Contains("__"))
                {
                    fillSoort.Remove(item.Key);
                }
            }
            // alle objecten in combobox plaatsen
            cmbSoort.ItemsSource = fillSoort;
            cmbSoort.DisplayMemberPath = "Value";
            cmbSoort.SelectedValuePath = "Key";
        }
        public void fillComboBoxVariant()
        {
            // lijst opvragen
            var fillVariant = dao.fillTfgsvVariant(Convert.ToInt32(cmbGeslacht.SelectedValue));
            var Variant = new Dictionary<long,string>();
            foreach (var item in fillVariant)
            {
                Variant.Add(item.Key,Simplify(item.Value,"0"));
            }
            // alle objecten in combobox plaatsen
            cmbVariant.ItemsSource = Variant;
            cmbVariant.DisplayMemberPath = "Value";
            cmbVariant.SelectedValuePath = "Key";
        }
        public void fillComboBoxRatioBladBloei()
        {
            // lijst opvragen
            var fillRatio = dao.fillFenetypeRatiobladbloei();
            var Ratio = new Dictionary<long, string>();
            foreach (var item in fillRatio)
            {
                Ratio.Add(item.Key, Simplify(item.Value, "1"));
            }
            // alle objecten in combobox plaatsen
            cmbRatioBladBloei.ItemsSource = Ratio;
            cmbRatioBladBloei.DisplayMemberPath = "Value";
            cmbRatioBladBloei.SelectedValuePath = "Key";
        }

        public string Simplify(string stringToSimplify, string id)
        {
            // Door dictionary moeten we een string simplifyen zo dat we deze kunnen gebruiken
            string answer = stringToSimplify.Replace(id, "").Replace(",", "").Replace("[", "").Replace("]", "").Replace("'", "");
            answer = String.Concat(answer.Where(c => !Char.IsWhiteSpace(c)));
            //answer.Trim();
            return answer;
        }


        public string SimplifyForVariant(string stringToSimplify, string id)
        {
            // Door dictionary moeten we een string simplifyen zo dat we deze kunnen gebruiken
            string answer = stringToSimplify.Replace(id, "").Replace(",", "").Replace("[", "").Replace("]", "");
           // answer = String.Concat(answer.Where(c => !Char.IsWhiteSpace(c)));
            answer.Trim();
            return answer;
        }





        private void fillLstOpgeslagenFilters(string Id, string Name)
        {
           
            //lijst opvragen kijken of een bepaalde compo box al eens voor komt in de opgeslagen lijst is dat zo dan word die verwijderd
            if (opgeslagenFilters.ContainsKey(Id))
            {
                opgeslagenFilters.Remove(Id);
               
            }
            // voegt niewe filter toe aan opgeslagen filter
            opgeslagenFilters.Add(Id,Name);
            
            // de list box clearen
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

                cmbGeslacht.ItemsSource = null;
                cmbSoort.ItemsSource = null;
                cmbVariant.ItemsSource = null;

                // Dit is omdat het op dit moment niet mogelijk is om variant in het cascade systeem te steken omdat het soort idee nodig heeft en soms geen soorten heeft!
                cmbVariant.IsEnabled = false;
            }
            
        }

        private void cmbFamilie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillComboBoxGeslacht();
            if (cmbFamilie.SelectedValue != null)
            {
                cmbType.IsEnabled = false;

                var fillFilters = Simplify(cmbFamilie.SelectedItem.ToString(), cmbFamilie.SelectedValue.ToString());
                fillLstOpgeslagenFilters("cmbFamilie", "Familie : "+fillFilters);

                cmbSoort.ItemsSource = null;
                cmbVariant.ItemsSource = null;

                // Dit is omdat het op dit moment niet mogelijk is om variant in het cascade systeem te steken omdat het soort idee nodig heeft en soms geen soorten heeft!
                cmbVariant.IsEnabled = false;
            }
           
        }

        private void cmbGeslacht_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           fillComboBoxSoort();
           fillComboBoxVariant();
            if (cmbGeslacht.SelectedValue != null)
            {
                cmbType.IsEnabled = false;
                cmbFamilie.IsEnabled = false;

                // Dit is omdat het op dit moment niet mogelijk is om variant in het cascade systeem te steken omdat het soort idee nodig heeft en soms geen soorten heeft!
                cmbVariant.IsEnabled = false;

                var fillFilters = Simplify(cmbGeslacht.SelectedItem.ToString(), cmbGeslacht.SelectedValue.ToString());
                fillLstOpgeslagenFilters("cmbGeslacht", "Geslacht : " +fillFilters);
            }
           
        }

        private void cmbSoort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { 
            if (cmbSoort.SelectedValue != null)
            {
                cmbType.IsEnabled = false;
                cmbFamilie.IsEnabled = false;
                cmbGeslacht.IsEnabled = false;

                // Dit is omdat het op dit moment niet mogelijk is om variant in het cascade systeem te steken omdat het soort idee nodig heeft en soms geen soorten heeft!
                cmbVariant.IsEnabled = false;

                cmbVariant.SelectedIndex = -1;
                foreach (var item in opgeslagenFilters)
                {
                    if (opgeslagenFilters.ContainsKey("cmbVariant"))
                    {
                        opgeslagenFilters.Remove("cmbVariant");
                    }
                }
               
                var fillFilters = Simplify(cmbSoort.SelectedItem.ToString(), cmbSoort.SelectedValue.ToString());
                fillLstOpgeslagenFilters("cmbSoort", "Soort : " +fillFilters);
            }
            
        }
        private void cmbVariant_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbVariant.SelectedValue != null)
            {
                cmbType.IsEnabled = false;
                cmbFamilie.IsEnabled = false;
                cmbGeslacht.IsEnabled = false;


                cmbSoort.SelectedIndex = -1;
                foreach (var item in opgeslagenFilters)
                {   
                    if (opgeslagenFilters.ContainsKey("cmbSoort"))
                    {
                        opgeslagenFilters.Remove("cmbSoort");
                    }
                }
                var fillFilters = Simplify(cmbVariant.SelectedItem.ToString(), cmbVariant.SelectedValue.ToString());
                fillLstOpgeslagenFilters("cmbVariant", "Variant : " +fillFilters);
            }
        }

        /// <summary>
        /// 
        /// </summary>

        private void lstResultSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            // de lijst planten op vragen
            var listPlants = dao.getAllPlants();

            Detailsresult.Clear();

            //foreach (var plant in listPlants)
            //{
            //    Detailsresult.Add
            //    (plant.PlantId,
            //        "Plantnaam = " + plant.Fgsv + Environment.NewLine
            //        + "type = " + plant.Type + Environment.NewLine
            //        + "famillie = " + plant.Familie + Environment.NewLine
            //        + "geslacht = " + plant.Geslacht + Environment.NewLine
            //        + "soort = " + plant.Soort + Environment.NewLine
            //        + "variant = " + plant.Variant + Environment.NewLine
            //        + "nederlandse naam = " + plant.NederlandsNaam + Environment.NewLine
            //        + "plantendichtheid = Min: " + plant.PlantdichtheidMin.ToString() + " Max: " + plant.PlantdichtheidMax.ToString() + Environment.NewLine

            //    );
            //}

            Detailsresult.Add(1,"1");
            Detailsresult.Add(2,"2");

            // alles laden in result
            lstDetails.ItemsSource = Detailsresult;
            lstDetails.DisplayMemberPath = "Value";
            lstDetails.SelectedValuePath = "Key";

        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            BtnbackgroundColor();

            cmbType.IsEnabled = true;
            cmbFamilie.IsEnabled = true;
            cmbGeslacht.IsEnabled = true;
            cmbVariant.IsEnabled = true;

            LstOpgeslagenFilters.Items.Clear();
            opgeslagenFilters.Clear();
            




            cmbType.ItemsSource = null;
            cmbFamilie.ItemsSource = null;
            cmbGeslacht.ItemsSource = null;
            cmbSoort.ItemsSource = null;
            cmbVariant.ItemsSource = null;
            cmbRatioBladBloei.ItemsSource = null;

            fillComboBoxType();
            fillComboBoxFamilie();
            fillComboBoxGeslacht();
            fillComboBoxSoort();
            fillComboBoxVariant();
            fillComboBoxRatioBladBloei();

            lstResultSearch.ItemsSource = null;
            lstDetails.ItemsSource = null;

            Frame_Navigated();
        }

        private void getAbiothiekDetails()
        {

        }
    }
}
