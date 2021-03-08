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
            btnNaam.Background = Brushes.Transparent;
            btnHabitat.Background = Brushes.Transparent;
        }

        private void btnNaam_Click(object sender, RoutedEventArgs e)
        {
            Frame_Navigated();
            BtnbackgroundColor();
            // de button highlighten van de geslecteerde zoek functie
            btnNaam.Background = Brushes.Green;
            // canvas tonen
            CvsZoeken.Visibility = Visibility.Visible;
        }

        private void btnFilterOpslaanZoeken_Click(object sender, RoutedEventArgs e)
        {
            // nu nog nie nodig
            Frame_Navigated();
            BtnbackgroundColor();
        }

        private void btnZoeken_Click(object sender, RoutedEventArgs e)
        {
            Frame_Navigated();
            BtnbackgroundColor();
            lstResultSearch.Visibility = Visibility.Visible;
            //simplify toepassen op inhoud textboxes

            lstResultSearch.Items.Clear();
            //generates a list with all plants.
            var listPlants = dao.getAllPlants();

            //generate a string to show witch criteria we searched on
            string criteria = "Dit is een gefilterde lijst van planten op onderstaande zoekcriteria. : " + Environment.NewLine + Environment.NewLine;

            if (cmbType.SelectedValue != null)
            {
                ComboBoxItem type = (ComboBoxItem)cmbType.SelectedItem;
                string value = type.Content.ToString();
                criteria += " type : " + value + Environment.NewLine;
                dao.narrowDownOnType(listPlants, value);
            }

            if (txtNaam.Text != string.Empty)
            {
                criteria += " naam : " + txtNaam.Text.ToString() + Environment.NewLine;
                dao.narrowDownOnName(listPlants, txtNaam.Text.ToString());
            }

            if (txtFamilie.Text != string.Empty)
            {
                criteria += " familie : " + txtFamilie.Text.ToString() + Environment.NewLine;
                dao.narrowDownOnFamily(listPlants, txtFamilie.Text.ToString());
            }

            if (txtCultivar.Text != string.Empty)
            {
                criteria += " cultivar : " + txtCultivar.Text.ToString() + Environment.NewLine;
                dao.narrowDownOnVariant(listPlants, txtCultivar.Text.ToString());
            }

            if (txtSoort.Text != string.Empty)
            {
                criteria += " soort : " + txtSoort.Text.ToString() + Environment.NewLine;
                dao.narrowDownOnSoort(listPlants, txtSoort.Text.ToString());

            }

            if (txtGeslacht.Text != string.Empty)
            {
                criteria += " geslacht : " + txtGeslacht.Text.ToString() + Environment.NewLine;
                dao.narrowDownOnGeslacht(listPlants, txtGeslacht.Text.ToString());
            }
            printInfo(listPlants);
            lblCriteria.Content = string.Empty;
            lblCriteria.Content += criteria.ToString();
        }
        

        //this function will print the result in the listbox
        public void printInfo(List<Plant> listPlants)
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
                                 + "plantendichtheid = Min: " + plant.PlantdichteidMin.ToString() + " Max: " + plant.PlantdichtheidMax.ToString()
                                 + Environment.NewLine
                                 );

            }
        }

        private void btnHabitat_Click(object sender, RoutedEventArgs e)
        {
            Frame_Navigated();
            BtnbackgroundColor();
            // de button highlighten van de geslecteerde zoek functie
            btnHabitat.Background = Brushes.Red;
            // canvas tonen
            cvsHabitat.Visibility = Visibility.Visible;
        }
    }
}
