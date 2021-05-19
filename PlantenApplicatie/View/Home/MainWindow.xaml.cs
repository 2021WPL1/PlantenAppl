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
using PlantenApplicatie.ViewModel;

namespace PlantenApplicatie.View
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

            //Frame_Navigated();
            //// De comboBoxen vullen.


            //fillComboBoxType();

            //fillComboBoxFamilie();
            //fillComboBoxGeslacht();
            //fillComboBoxSoort();
            //fillComboBoxVariant();
        }

        // new dictionary aanmaken hier komen de resultaten in met als long het plant id en string is de plant info
        //Dictionary<long, string> dictionaryresult = new Dictionary<long, string>();
        // dit is de lijst waar geslecteerde filters inkomen men als eerste string  bv. de combobox naam en als 2 string de info
        //Dictionary<string, string> opgeslagenFilters = new Dictionary<string, string>();

        //private void Frame_Navigated()
        //{
        //    // alle canvases verstoppen
        //    lstResultSearch.Visibility = Visibility.Hidden;
        //    CvsZoeken.Visibility = Visibility.Hidden;
        //    cvsHabitat.Visibility = Visibility.Hidden;
        //    cvsDetails.Visibility = Visibility.Hidden;
        //}

        //private void BtnbackgroundColor() 
        //{
        //    // achtergrond van buttons terug normaal zetten
        //    btnNaam.Background = Brushes.Olive;
        //    btnHabitat.Background = Brushes.Olive;
            
        //}

        //private void BtnNaam_Click(object sender, RoutedEventArgs e)
        //{
        //    Frame_Navigated();
        //    // de button highlighten van de geslecteerde zoek functie
        //    btnNaam.Background = Brushes.Olive;
        //    // canvas tonen
        //    CvsZoeken.Visibility = Visibility.Visible;
        //}


        //private void BtnZoeken_Click(object sender, RoutedEventArgs e)
        //{
        //    Frame_Navigated();
        //    BtnbackgroundColor();
        //     lstResultSearch.Visibility = Visibility.Visible;
        //    cvsDetails.Visibility = Visibility.Visible;
        //    // de lijst planten op vragen
        //    var listPlants = dao.getAllPlants();

        //    lstResultSearch.Items.Refresh();

        //    // kijken over er iets in de combobox is aan geduid
        //    if (Convert.ToInt32(cmbType.SelectedValue) != 0)
        //    {
        //        // alle onnodige tekens er uit halen 
        //        var simp = Simplify(cmbType.SelectedItem.ToString(), cmbType.SelectedValue.ToString());
        //        // alle items in list plant overlopen
        //        foreach (var item in listPlants.ToList())
        //        {                   
        //            //als het zoekwoord er niet in voor komt verwijderen.
        //            if (item.Type.Contains(simp) == false)
        //            {
        //                listPlants.Remove(item);
        //            }
        //        }
        //    }// Zie commentaar lijn 91
        //    if (cmbFamilie.SelectedValue != null)
        //    {
        //        var simp = Simplify(cmbFamilie.SelectedItem.ToString(), cmbFamilie.SelectedValue.ToString());

        //        foreach (var item in listPlants.ToList())
        //        {
                    
        //            if (item.Familie.Contains(simp) == false)
        //            {
        //                listPlants.Remove(item);
        //            }
        //        }
        //    }// Zie commentaar lijn 91
        //    if (cmbGeslacht.SelectedValue != null)
        //    {
        //        var simp = Simplify(cmbGeslacht.SelectedItem.ToString(), cmbGeslacht.SelectedValue.ToString());

        //        foreach (var item in listPlants.ToList())
        //        {
                   
        //            if (item.Geslacht.Contains(simp) == false)
        //            {
        //                listPlants.Remove(item);
        //            }
        //        }
        //    }// Zie commentaar lijn 91
        //    if (cmbSoort.SelectedValue != null)
        //    {
        //        var simp = Simplify(cmbSoort.SelectedItem.ToString(), cmbSoort.SelectedValue.ToString());
               
        //        foreach (var item in listPlants.ToList())
        //        {
                     
        //            if (item.Soort.Contains(simp) == false)
        //            {
        //                listPlants.Remove(item);
        //            }
        //        }
        //    }// Zie commentaar lijn 91
        //    if (cmbVariant.SelectedValue != null)
        //    {
        //        var simp = Simplify(cmbVariant.SelectedItem.ToString(), cmbVariant.SelectedValue.ToString());
        //        MessageBox.Show(simp);
        //        foreach (var item in listPlants.ToList())
        //        {
        //            if (item.Variant != null)
        //            {
        //                if (item.Variant.Contains(simp) == false)
        //                {
        //                    listPlants.Remove(item);
        //                }
        //            }
        //            else
        //            {
        //                listPlants.Remove(item);
        //            }
        //        }
        //    }

            

        //    // dictionary clearen zo da je niet het bijft opvullen met hezelfde als je meerdere keren op zoeken clickt
        //    dictionaryresult.Clear();
        //    // alles toevoegen aan een dictionare met als plantid key en de rest spreek voor zich
        //    foreach (var plant in listPlants)
        //    {
        //        dictionaryresult.Add
        //                            (plant.PlantId,
        //                            "Plantnaam = " + plant.Fgsv + Environment.NewLine
        //                            + "type = " + plant.Type + Environment.NewLine
        //                            + "famillie = " + plant.Familie + Environment.NewLine
        //                            + "geslacht = " + plant.Geslacht + Environment.NewLine
        //                            + "soort = " + plant.Soort + Environment.NewLine
        //                            + "variant = " + plant.Variant + Environment.NewLine
        //                            + "nederlandse naam = " + plant.NederlandsNaam + Environment.NewLine
        //                            + "plantendichtheid = Min: " + plant.PlantdichtheidMin.ToString() + " Max: " + plant.PlantdichtheidMax.ToString() + Environment.NewLine
        //                            );
        //    }

        //    // alles laden in result
        //    lstResultSearch.ItemsSource = dictionaryresult;
        //    lstResultSearch.DisplayMemberPath = "Value";
        //    lstResultSearch.SelectedValuePath = "Key";

        //}

        //private void BtnHabitat_Click(object sender, RoutedEventArgs e)
        //{
        //    Frame_Navigated();
        //    BtnbackgroundColor();
        //    // de button highlighten van de geslecteerde zoek functie
        //    btnHabitat.Background = Brushes.Olive;
        //    // canvas tonen
        //    cvsHabitat.Visibility = Visibility.Visible;
        //}


        ///// <summary>
        ///// /////////////////////////////// CASCADE SYSTEEM
        /////  bij de fillcombobox functie word de lijst opgevraagd van de functie in de dao dan waar het meegegeven aan de combobox valuepath zijn de ID's, memberpath zijn de namen
        /////  met de item source geef je de lijs mee aan de combobox
        ///// </summary>

        //public void fillComboBoxType()
        //{        
        //    // lijst opvragen
        //    var filltype = dao.fillTfgsvType();
           
        //    // alle objecten in combobox plaatsen
        //    cmbType.ItemsSource = filltype;
        //    cmbType.DisplayMemberPath = "Value";
        //    cmbType.SelectedValuePath = "Key";
        //}

        //public void fillComboBoxFamilie()
        //{         
        //    // lijst opvragen
        //    var fillFamilie = dao.fillTfgsvFamilie(Convert.ToInt32(cmbType.SelectedValue));
        //    // alle objecten in combobox plaatsen

        //    cmbFamilie.ItemsSource = fillFamilie ;
        //    cmbFamilie.DisplayMemberPath = "Value";
        //    cmbFamilie.SelectedValuePath = "Key";
        //}

        //public void fillComboBoxGeslacht()
        //{
        //    // lijst opvragen
        //    var fillGeslacht = dao.fillTfgsvGeslacht(Convert.ToInt32(cmbFamilie.SelectedValue));
        //    // alle objecten in combobox plaatsen
        //    cmbGeslacht.ItemsSource = fillGeslacht;
        //    cmbGeslacht.DisplayMemberPath = "Value";
        //    cmbGeslacht.SelectedValuePath = "Key";
        //}
        //public void fillComboBoxSoort()
        //{
        //    // lijst opvragen
        //    var fillSoort = dao.fillTfgsvSoort(Convert.ToInt32(cmbGeslacht.SelectedValue));

        //    foreach (var item in fillSoort)
        //    {
        //        if (item.Value.Contains("__"))
        //        {
        //            fillSoort.Remove(item.Key);
        //        }
        //    }
        //    // alle objecten in combobox plaatsen
        //    cmbSoort.ItemsSource = fillSoort;
        //    cmbSoort.DisplayMemberPath = "Value";
        //    cmbSoort.SelectedValuePath = "Key";
        //}
        //public void fillComboBoxVariant()
        //{
        //    // lijst opvragen
        //    var fillVariant = dao.fillTfgsvVariant(Convert.ToInt32(cmbGeslacht.SelectedValue));
        //    // alle objecten in combobox plaatsen
        //    cmbVariant.ItemsSource = fillVariant;
        //    cmbVariant.DisplayMemberPath = "Value";
        //    cmbVariant.SelectedValuePath = "Key";
        //}

        //public string Simplify(string stringToSimplify, string id)
        //{
        //    // Door dictionary moeten we een string simplifyen zo dat we deze kunnen gebruiken
        //    string answer = stringToSimplify.Replace(id, "").Replace(",", "").Replace("[", "").Replace("]", "");
        //    answer = String.Concat(answer.Where(c => !Char.IsWhiteSpace(c)));
        //    return answer;
        //}

        

        //private void fillLstOpgeslagenFilters(string Id, string Name)
        //{
           
        //    //lijst opvragen kijken of een bepaalde compo box al eens voor komt in de opgeslagen lijst is dat zo dan word die verwijderd
        //    if (opgeslagenFilters.ContainsKey(Id))
        //    {
        //        opgeslagenFilters.Remove(Id);
               
        //    }
        //    // voegt niewe filter toe aan opgeslagen filter
        //    opgeslagenFilters.Add(Id,Name);
            
        //    // de list box clearen
        //    LstOpgeslagenFilters.Items.Clear();
        //    //alle objecten in listbox plaatsen

        //    foreach (var item in opgeslagenFilters)
        //    {
               
        //        LstOpgeslagenFilters.Items.Add(item.Value);
        //    }

        //}

        //// Deze Events zijn als er iets veranderd in de combobox de er een nieuw lijst word aangemaakt voor de combobox te vullen

        //private void cmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{            
        //    fillComboBoxFamilie();
        //    if (cmbType.SelectedValue != null)
        //    {
        //        var fillFilters = Simplify(cmbType.SelectedItem.ToString(), cmbType.SelectedValue.ToString());
        //        fillLstOpgeslagenFilters("cmbType", "Type : " + fillFilters);
        //    }
            
        //}

        //private void cmbFamilie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    fillComboBoxGeslacht();
        //    if (cmbFamilie.SelectedValue != null)
        //    {
        //        var fillFilters = Simplify(cmbFamilie.SelectedItem.ToString(), cmbFamilie.SelectedValue.ToString());
        //        fillLstOpgeslagenFilters("cmbFamilie", "Familie : "+fillFilters);
        //    }
           
        //}

        //private void cmbGeslacht_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //   fillComboBoxSoort();
        //   fillComboBoxVariant();
        //    if (cmbGeslacht.SelectedValue != null)
        //    {
        //        var fillFilters = Simplify(cmbGeslacht.SelectedItem.ToString(), cmbGeslacht.SelectedValue.ToString());
        //        fillLstOpgeslagenFilters("cmbGeslacht", "Geslacht : " +fillFilters);
        //    }
           
        //}

        //private void cmbSoort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{ 
        //    if (cmbSoort.SelectedValue != null)
        //    {
        //        cmbVariant.SelectedIndex = -1;
        //        foreach (var item in opgeslagenFilters)
        //        {
        //            if (opgeslagenFilters.ContainsKey("cmbVariant"))
        //            {
        //                opgeslagenFilters.Remove("cmbVariant");
        //            }
        //        }
               
        //        var fillFilters = Simplify(cmbSoort.SelectedItem.ToString(), cmbSoort.SelectedValue.ToString());
        //        fillLstOpgeslagenFilters("cmbSoort", "Soort : " +fillFilters);
        //    }
            
        //}
        //private void cmbVariant_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (cmbVariant.SelectedValue != null)
        //    {
        //        cmbSoort.SelectedIndex = -1;
        //        foreach (var item in opgeslagenFilters)
        //        {   
        //            if (opgeslagenFilters.ContainsKey("cmbSoort"))
        //            {
        //                opgeslagenFilters.Remove("cmbSoort");
        //            }
        //        }
        //        var fillFilters = Simplify(cmbVariant.SelectedItem.ToString(), cmbVariant.SelectedValue.ToString());
        //        fillLstOpgeslagenFilters("cmbVariant", "Variant : " +fillFilters);
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>

        //private void lstResultSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (lstResultSearch.SelectedValue != null)
        //    {
        //        //MessageBox.Show(lstResultSearch.SelectedValue.ToString());
        //        var plants = dao.detailsAanvullen(Convert.ToInt64(lstResultSearch.SelectedValue));
        //       foreach (var item in plants)
        //        {
        //            lblFamilie.Content = item.Familie;
        //            lblGeslacht.Content = item.Geslacht;
        //            lblSoort.Content = item.Soort;
        //            lblType.Content = item.Type;
        //            lblVariant.Content = item.Variant;
        //            lblNederlandseNaam.Content = item.NederlandsNaam;
        //            lblPlantdichtheidMin.Content = item.PlantdichtheidMin;
        //            lblPlanctdichtheidMax.Content = item.PlantdichtheidMax;
        //            lblStatus.Content = item.Status;
        //            lblPlantId.Content = item.PlantId;
                    
        //            //Plant.Abiotiek moet ook apart worden uitgelezen
        //            foreach(var abItem in item.Abiotiek)
        //            {
        //                lblBezonning.Content = abItem.Bezonning;
        //                lblVochtbehoefte.Content = abItem.Vochtbehoefte;

        //                //De onderstaande code is ter voorbereiding van de nieuwe data
        //                //deze columns zijn nu nog NULL
        //                //lblGrondsoort.Content = abItem.Grondsoort;
        //                //lblVoedingsbehoefte.Content = abItem.AntagonischeOmgeving;
        //            }
                    

        //            //Deze zijn ter voorbereiding van de nog te komen data
        //            //lblGrondsoort.Content = item.Grondsoort;
        //            //lblVochtbehoefte.Content = item.Vochtbehoefte;
        //            //lblVoedingsbehoefte.Content = item.Voedingsbehoefte;
        //            //lblAntagonischeOmgeving.Content = item.AgantonischeOmgeving;
        //            //lblCultivar.Content = item.Cultivar;
        //            //Sociabiliteit lblGrondsoort.Content = item.Sociabiliteit;
        //            //lblOntwikkelingsnelheid.Content = item.Ontwikkelingsnelheid;
        //            //lblConcurrentieKracht.Content = item.ConcurrentieKracht;
        //            //lblNectarwaarde.Content = item.Nectarwaarde;
        //            //lblBijvriendelijk.Content = item.Bijvriendelijk;
        //            //lblEetKruidbaar.Content = item.EetKruidbaar;
        //            //lblGeurend.Content = item.Geurend;
        //            //lblVlinderVriendelijk.Content = item.Vlindervriendelijk;
        //            //lblVorstgevoelig.Content = item.Vorstgevoelig;
        //            //lblBloeikleur.Content = item.Bloeikeur;
        //            //lblBloeihoogte.Content = item.Bloeihoogte;
        //            //lblBloeiwijze.Content = item.Bloeiwijze;
        //            //Strategie lblStrategie.Content = item.Strategie;
        //            //lblBladkleur.Content = item.Bladkleur;
        //            //lblBladhoogte.Content = item.Bladhoogte;
        //            //lblBladvormen.Content = item.Bladvormen;
        //            //lblStengelvormen.Content = item.Stengelvormen;
        //            //lblLevensvorm.Content = item.Levensvorm;
        //            //lblSpruitfenologie.Content = item.Spruitfenologie;
        //            //lblOptimalePlantdichtheid.Content = item.Plantdichtheid;
               
        //        }
        //        //foreach(var abiotiekType in plantAbiotiek)
        //        //{
        //        //    lblBezonning.Content = abiotiekType.Bezonning;
        //        //}
        //    }
            
        //}

        //private void btnReset_Click(object sender, RoutedEventArgs e)
        //{
        //    LstOpgeslagenFilters.Items.Clear();
        //    opgeslagenFilters.Clear();

        //    dictionaryresult.Clear();
            
        //    cmbType.SelectedIndex = -1;
        //    cmbFamilie.SelectedIndex = -1;
        //    cmbGeslacht.SelectedIndex = -1;
        //    cmbSoort.SelectedIndex = -1;
        //    cmbVariant.SelectedIndex = -1;

        //    Frame_Navigated();
        //}
        //private void getAbiothiekDetails()
        //{

        //}
    }
}
