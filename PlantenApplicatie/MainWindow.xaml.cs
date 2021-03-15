using Planten2021.Data;
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
            //   BtnbackgroundColor();
            fillComboBoxType();

          


        }



        private void Frame_Navigated()
        {
            // alle canvases verstoppen
            lstResultSearch.Visibility = Visibility.Hidden;
            CvsZoeken.Visibility = Visibility.Hidden;
            cvsHabitat.Visibility = Visibility.Hidden;
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

        private void BtnZoeken_Click(object sender, RoutedEventArgs e)
        {
            Frame_Navigated();
            BtnbackgroundColor();
            lstResultSearch.Visibility = Visibility.Visible;
            //simplify toepassen op inhoud textboxes

          
        

            //generates a list with all plants.
            var listPlants = dao.getAllPlants();

            lstResultSearch.ItemsSource = listPlants;
            lstResultSearch.DisplayMemberPath = "Value";
            lstResultSearch.SelectedValuePath = "Key";

            ////generate a string to show witch criteria we searched on
            // string criteria = "Dit is een gefilterde lijst van planten op onderstaande zoekcriteria. : " + Environment.NewLine + Environment.NewLine;

            //if (cmbType.SelectedValue != null)
            //{
            //    ComboBoxItem type = (ComboBoxItem)cmbType.SelectedItem;
            //    string value = type.Content.ToString();
            //    criteria += " type : " + value + Environment.NewLine;
            //    dao.narrowDownOnType(listPlants, value);
            //}

            //if (txtNaam.Text != string.Empty)
            //{
            //    criteria += " naam : " + txtNaam.Text.ToString() + Environment.NewLine;
            //    dao.narrowDownOnName(listPlants, txtNaam.Text.ToString());
            //}

            //if (txtFamilie.Text != string.Empty)
            //{
            //    criteria += " familie : " + txtFamilie.Text.ToString() + Environment.NewLine;
            //    dao.narrowDownOnFamily(listPlants, txtFamilie.Text.ToString());
            //}

            //if (txtCultivar.Text != string.Empty)
            //{
            //    criteria += " cultivar : " + txtCultivar.Text.ToString() + Environment.NewLine;
            //    dao.narrowDownOnVariant(listPlants, txtCultivar.Text.ToString());
            //}

            //if (txtSoort.Text != string.Empty)
            //{
            //    criteria += " soort : " + txtSoort.Text.ToString() + Environment.NewLine;
            //    dao.narrowDownOnSoort(listPlants, txtSoort.Text.ToString());

            //}

            //if (txtGeslacht.Text != string.Empty)
            //{
            //    criteria += " geslacht : " + txtGeslacht.Text.ToString() + Environment.NewLine;
            //    dao.narrowDownOnGeslacht(listPlants, txtGeslacht.Text.ToString());
            //}



            //PrintInfo(listPlants);
            // lblCriteria.Content = string.Empty;
            // lblCriteria.Content += criteria.ToString();
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
            var fillVariant = dao.fillTfgsvVariant(Convert.ToInt32(cmbSoort.SelectedValue));
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
            if (cmbGeslacht.SelectedValue != null)
            {
                var fillFilters = Simplify(cmbGeslacht.SelectedItem.ToString(), cmbGeslacht.SelectedValue.ToString());
                fillLstOpgeslagenFilters("cmbGeslacht", "Geslacht : " +fillFilters);
            }
           
        }

        private void cmbSoort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           fillComboBoxVariant();
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
                var fillFilters = Simplify(cmbVariant.SelectedItem.ToString(), cmbSoort.SelectedValue.ToString());
                fillLstOpgeslagenFilters("cmbVariant", "Variant : " +fillFilters);
            }
        }
        private void lstResultSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show(lstResultSearch.SelectedValue.ToString());
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            LstOpgeslagenFilters.Items.Clear();

            opgeslagenFilters.Clear();

            cmbType.SelectedIndex = -1;
            cmbFamilie.SelectedIndex = -1;
            cmbGeslacht.SelectedIndex = -1;
            cmbSoort.SelectedIndex = -1;
            cmbVariant.SelectedIndex = -1;
        }
    }
}
