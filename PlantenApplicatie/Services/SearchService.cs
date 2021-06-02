using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Planten2021.Data;
using Planten2021.Domain.Models;
using PlantenApplicatie.Services.Interfaces;

namespace PlantenApplicatie.Services
{

    /*written by kenny from an example of Roy and some help of Killian*/
    public class SearchService : ISearchService, INotifyPropertyChanged
    {
        private DAO _dao;

        public event PropertyChangedEventHandler PropertyChanged;

        public SearchService()
        {
            this._dao = DAO.Instance();
        }

        #region RelayCommandMethods
        public void ApplyFilters(ObservableCollection<Plant> filteredPlantResults, ObservableCollection<TfgsvType> cmbTypes,
                                ObservableCollection<TfgsvFamilie> cmbFamilies, ObservableCollection<TfgsvGeslacht> cmbGeslacht,
                                ObservableCollection<TfgsvSoort> cmbSoort, ObservableCollection<TfgsvVariant> cmbVariant,
                                ObservableCollection<Fenotype> cmbRatioBladBloei, string selectedNederlandseNaam, TfgsvType selectedType,
                                TfgsvFamilie selectedFamilie, TfgsvGeslacht selectedGeslacht
                                )
        {

            filteredPlantResults.Clear();

            cmbTypes.Clear();
            cmbFamilies.Clear();
            cmbGeslacht.Clear();
            cmbSoort.Clear();
            cmbVariant.Clear();
            cmbRatioBladBloei.Clear();
            selectedNederlandseNaam = null;


            fillComboBoxType(cmbTypes);
            fillComboBoxFamilie(selectedType, cmbFamilies);
            fillComboBoxGeslacht(selectedFamilie, cmbGeslacht);
            fillComboBoxSoort(selectedGeslacht, cmbSoort);
            fillComboBoxVariant(cmbVariant);
            fillComboBoxRatioBloeiBlad(cmbRatioBladBloei);
        }

        public List<Plant> Reset(TfgsvType selectedType, TfgsvFamilie selectedFamilie, TfgsvGeslacht selectedGeslacht, TfgsvSoort selectedSoort,
                          TfgsvVariant selectedVariant, string selectedNederlandseNaam, string selectedRatioBloeiBlad)
        {
            var listPlants = _dao.getAllPlants();

            if (selectedType != null)
            {

                foreach (var item in listPlants.ToList())
                {

                    if (item.TypeId != selectedType.Planttypeid)
                    {
                        listPlants.Remove(item);
                    }
                }
            }
            if (selectedFamilie != null)
            {

                foreach (var item in listPlants.ToList())
                {

                    if (item.FamilieId != selectedFamilie.FamileId)
                    {
                        listPlants.Remove(item);
                    }
                }
            }
            if (selectedGeslacht != null)
            {

                foreach (var item in listPlants.ToList())
                {

                    if (item.GeslachtId != selectedGeslacht.GeslachtId)
                    {
                        listPlants.Remove(item);
                    }
                }
            }
            if (selectedSoort != null)
            {

                foreach (var item in listPlants.ToList())
                {

                    if (item.SoortId != selectedSoort.Soortid)
                    {
                        listPlants.Remove(item);
                    }
                }
            }
            if (selectedVariant != null)
            {

                foreach (var item in listPlants.ToList())
                {

                    if (item.VariantId != null)
                    {

                        if (item.VariantId != selectedVariant.VariantId)
                        {

                            listPlants.Remove(item);
                        }
                    }
                    else if (item.VariantId == null)
                    {
                        listPlants.Remove(item);
                    }

                }
            }

            if (selectedNederlandseNaam != null)
            {
                foreach (var item in listPlants.ToList())
                {

                    if (item.NederlandsNaam != null)
                    {
                        if (!item.NederlandsNaam.Contains(selectedNederlandseNaam))
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

            if (selectedRatioBloeiBlad != null)
            {

                foreach (var item in listPlants.ToList())
                {
                    if (item.Fenotype.Count != 0)
                    {
                        foreach (var itemFenotype in item.Fenotype)
                        {

                            if (itemFenotype.RatioBloeiBlad != null || itemFenotype.RatioBloeiBlad != String.Empty)
                            {

                                if (itemFenotype.RatioBloeiBlad != selectedRatioBloeiBlad)
                                {

                                    listPlants.Remove(item);
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
            return listPlants;

        }
        #endregion
        #region Fill methods
        //Simplifiy method so that the words are more presentable
        //A function that takes a string, puts it to lowercase, 
        //changes all the ' and " chars and replaces them by a space
        //next it deletes al the spaces and returns the string.
        public string Simplify(string stringToSimplify)
        {
            string answer = stringToSimplify.Replace(",", "").Replace("'", "").Replace("__", "");
            answer = String.Concat(answer.Where(c => !Char.IsWhiteSpace(c)));
            return answer;
        }
        public void fillComboBoxType(ObservableCollection<TfgsvType> cmbTypeCollection)
        {
            var list = _dao.fillTfgsvType();

            foreach (var item in list)
            {
                cmbTypeCollection.Add(item);
            }
        }
        public void fillComboBoxFamilie(TfgsvType selectedType, ObservableCollection<TfgsvFamilie> cmbFamilieCollection)
        {

            var list = new List<TfgsvFamilie>(); /*Enumerable.Empty<TfgsvFamilie>().AsQueryable();*/

            //use the typeId, selected in the combobox to filter the list and load the remaining plant families in the family combobox
            // checking if selected type is selected to prevent null exception
            if (selectedType != null)
            {
                // Requesting te list of families 
                list = _dao.fillTfgsvFamilie(Convert.ToInt32(selectedType.Planttypeid)).ToList();

            }
            else
            {
                // Requesting te list of families  with 0 because there is noting selected in the combobox of type.
                list = _dao.fillTfgsvFamilie(0).ToList();
            }


            // clearing te content of te combobox of familie
            cmbFamilieCollection.Clear();
            // a list to add type that have been added to the combobox. this is used for preventing two of the same type in the combo box
            var ControleList = new List<string>();
            //adding or list to the combobox
            foreach (var item in list)
            {
                if (!ControleList.Contains(item.Familienaam))
                {
                    cmbFamilieCollection.Add(item);
                    ControleList.Add(item.Familienaam);
                }
            }
        }
        public void fillComboBoxGeslacht(TfgsvFamilie selectedFamilie, ObservableCollection<TfgsvGeslacht> cmbGeslachtCollection)
        {
            var list = Enumerable.Empty<TfgsvGeslacht>().AsQueryable();

            //use the FamilieId, selected in the combobox to filter the list and load the remaining plant geslacht in the geslacht combobox
            // checking if selected geslacht is selected to prevent null exception
            if (selectedFamilie != null)
            {
                // Requesting te list of geslacht 
                list = _dao.fillTfgsvGeslacht(Convert.ToInt32(selectedFamilie.FamileId));
            }
            else
            {
                // Requesting te list of Geslacht  with 0 because there is noting selected in the combobox of type.
                list = _dao.fillTfgsvGeslacht(0);
            }

            // clearing te content of te combobox of geslacht
            cmbGeslachtCollection.Clear();
            // a list to add type that have been added to the combobox. this is used for preventing two of the same type in the combo box
            var ControleList = new List<string>();
            //adding or list to the combobox
            foreach (var item in list)
            {

                if (!ControleList.Contains(item.Geslachtnaam))
                {
                    cmbGeslachtCollection.Add(item);
                    ControleList.Add(item.Geslachtnaam);
                }
            }

        }
        public void fillComboBoxSoort(TfgsvGeslacht selectedGeslacht, ObservableCollection<TfgsvSoort> cmbSoortCollection)
        {
            var list = Enumerable.Empty<TfgsvSoort>().AsQueryable();

            //use the GeslachtId, selected in the combobox to filter the list and load the remaining plant Soort in the Soort combobox
            // checking if selected Soort is selected to prevent null exception
            if (selectedGeslacht != null)
            {
                // Requesting te list of Soort 
                list = _dao.fillTfgsvSoort(Convert.ToInt32(selectedGeslacht.GeslachtId));
            }
            else
            {
                // Requesting te list of Soort  with 0 because there is noting selected in the combobox of type.
                list = _dao.fillTfgsvSoort(0);
            }

            // clearing te content of te combobox of Soort
            cmbSoortCollection.Clear();
            // a list to add type that have been added to the combobox. this is used for preventing two of the same type in the combo box
            var ControleList = new List<string>();
            //adding or list to the combobox
            foreach (var item in list)
            {
                if (!ControleList.Contains(item.Soortnaam))
                {
                    cmbSoortCollection.Add(item);
                    ControleList.Add(item.Soortnaam);
                }
            }
        }
        public void fillComboBoxVariant(ObservableCollection<TfgsvVariant> cmbVariantCollection)
        {

            // Requesting te list of Variant  with 0 because there is noting selected in the combobox of type.
            var list = _dao.fillTfgsvVariant();
            // clearing te content of te combobox of Variant
            cmbVariantCollection.Clear();
            // a list to add type that have been added to the combobox. this is used for preventing two of the same type in the combo box
            var ControleList = new List<string>();
            //adding or list to the combobox
            foreach (var item in list)
            {
                if (!ControleList.Contains(item.Variantnaam))
                {
                    ControleList.Add(item.Variantnaam);
                    Simplify(item.Variantnaam);
                    cmbVariantCollection.Add(item);
                }
            }
        }
        public void fillComboBoxRatioBloeiBlad(ObservableCollection<Fenotype> cmbRatioBladBloeiCollection)
        {
            //not currently used in the cascade search
            //will be adjusted later (dao)
            var list = _dao.fillFenoTypeRatioBloeiBlad();
            // a list to add type that have been added to the combobox. this is used for preventing two of the same type in the combo box
            var ControleList = new List<string>();
            //adding or list to the combobox
            foreach (var item in list)
            {
                if (!ControleList.Contains(item.RatioBloeiBlad))
                {
                    cmbRatioBladBloeiCollection.Add(item);
                    ControleList.Add(item.RatioBloeiBlad);
                }
            }
        }

        #endregion


        public List<Plant> ApplyFilter(TfgsvType SelectedtType, TfgsvFamilie SelectedFamilie, TfgsvGeslacht SelectedGeslacht, TfgsvSoort SelectedSoort,
            TfgsvVariant SelectedVariant, string SelectedNederlandseNaam, string SelectedRatioBloeiBlad )
        {

            var listPlants = _dao.getAllPlants();

            if (SelectedtType != null)
            {

                foreach (var item in listPlants.ToList())
                {

                    if (item.TypeId != SelectedtType.Planttypeid)
                    {
                        listPlants.Remove(item);
                    }
                }
            }
            if (SelectedFamilie != null)
            {

                foreach (var item in listPlants.ToList())
                {

                    if (item.FamilieId != SelectedFamilie.FamileId)
                    {
                        listPlants.Remove(item);
                    }
                }
            }
            if (SelectedGeslacht != null)
            {

                foreach (var item in listPlants.ToList())
                {

                    if (item.GeslachtId != SelectedGeslacht.GeslachtId)
                    {
                        listPlants.Remove(item);
                    }
                }
            }
            if (SelectedSoort != null)
            {

                foreach (var item in listPlants.ToList())
                {

                    if (item.SoortId != SelectedSoort.Soortid)
                    {
                        listPlants.Remove(item);
                    }
                }
            }
            if (SelectedVariant != null)
            {

                foreach (var item in listPlants.ToList())
                {

                    if (item.VariantId != null)
                    {

                        if (item.VariantId != SelectedVariant.VariantId)
                        {

                            listPlants.Remove(item);
                        }
                    }
                    else if (item.VariantId == null)
                    {
                        listPlants.Remove(item);
                    }

                }
            }

            if (SelectedNederlandseNaam != null)
            {
                foreach (var item in listPlants.ToList())
                {

                    if (item.NederlandsNaam != null)
                    {
                        if (!item.NederlandsNaam.Contains(SelectedNederlandseNaam))
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

            if (SelectedRatioBloeiBlad != null)
            {

                foreach (var item in listPlants.ToList())
                {
                    if (item.Fenotype.Count != 0)
                    {
                        foreach (var itemFenotype in item.Fenotype)
                        {

                            if (itemFenotype.RatioBloeiBlad != null || itemFenotype.RatioBloeiBlad != String.Empty)
                            {

                                if (itemFenotype.RatioBloeiBlad != SelectedRatioBloeiBlad)
                                {

                                    listPlants.Remove(item);
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

            return listPlants;
        }
    }
}


