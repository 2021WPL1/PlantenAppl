using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
//using Planten2021.Data.Models;
using Planten2021.Domain.Models;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
//using System.Windows.Controls;

namespace Planten2021.Data
{
    public class PlantenDataService
    {
        //Vernieuwde naam van onze DAO
        private static readonly PlantenDataService instance = new PlantenDataService();
        private readonly Planten2021Context context;

        public static PlantenDataService Instance()
        {
            return instance;
        }
        //private contructor
        private PlantenDataService()
        {
            this.context = new Planten2021Context();
        }

        //search functions

        /* NARROW DOWN FUNCTIONS */

        //A function that looks if the given list of plants contains the given string in plant.type .
        //if this is the case the plant will stay in the list.
        //if this is not the case, the plant will be deleted out of the list.
        public void narrowDownOnType(List<Plant> listPlants, string type)
        {
            foreach (Plant plant in listPlants.ToList())
            {
                if (plant.Type != null)
                {
                    var simplifyString = Simplify(plant.Type.ToString());
                    if (simplifyString.Contains(Simplify(type)) != true)
                    {
                        listPlants.Remove(plant);
                    }
                }
            }
        }

        //A function that looks if the given list of plants contains the given string in plant.geslacht .
        //if this is the case the plant will stay in the list.
        //if this is not the case, the plant will be deleted out of the list.

        public void narrowDownOnGeslacht(List<Plant> listPlants, string geslacht)
        {
            foreach (Plant plant in listPlants.ToList())
            {
                if (plant.Geslacht != null)
                {
                    var simplifyString = Simplify(plant.Geslacht.ToString());
                    if (simplifyString.Contains(Simplify(geslacht)) != true)
                    {
                        listPlants.Remove(plant);
                    }
                }
            }
        }
        //A function that looks if the given list of plants contains the given string in plant.Family .
        //if this is the case the plant will stay in the list.
        //if this is not the case, the plant will be deleted out of the list.
        public void narrowDownOnFamily(List<Plant> listPlants, string Familie)
        {
            foreach (Plant plant in listPlants.ToList())
            {
                if (plant.Familie != null)
                {
                    var simplifyString = Simplify(plant.Familie.ToString());
                    if (simplifyString.Contains(Simplify(Familie)) != true)
                    {
                        listPlants.Remove(plant);
                    }
                }
            }
        }
        //A function that looks if the given list of plants contains the given string in plant.soort .
        //if this is the case the plant will stay in the list.
        //if this is not the case, the plant will be deleted out of the list.
        public void narrowDownOnSoort(List<Plant> listPlants, string soort)
        {
            foreach (Plant plant in listPlants.ToList())
            {
                if (plant.Soort != null)
                {
                    var simplifyString = Simplify(plant.Soort.ToString());
                    if (simplifyString.Contains(Simplify(soort)) != true)
                    {
                        listPlants.Remove(plant);
                    }
                }
            }
        }
        //A function that looks if the given list of plants contains the given string in plant.naam .
        //if this is the case the plant will stay in the list.
        //if this is not the case, the plant will be deleted out of the list.
        public void narrowDownOnName(List<Plant> listPlants, string naam)
        {
            foreach (Plant plant in listPlants.ToList())
            {
                if (plant.Fgsv != null)
                {
                    var simplifyString = Simplify(plant.Fgsv.ToString());
                    if (simplifyString.Contains(Simplify(naam)) != true)
                    {
                        listPlants.Remove(plant);
                    }
                }
            }
        }
        //A function that looks if the given list of plants contains the given string in plant.variant .
        //if this is the case the plant will stay in the list.
        //if this is not the case, the plant will be deleted out of the list.
        public void narrowDownOnVariant(List<Plant> listPlants, string variant)
        {
            foreach (Plant plant in listPlants.ToList())
            {
                if (plant.Variant != null)
                {
                    var simplifyString = Simplify(plant.Variant.ToString());
                    if (simplifyString.Contains(Simplify(variant)) != true)
                    {
                        listPlants.Remove(plant);
                    }
                }
            }
        }
        //A function that returns a list of plants
        //the returned list are all the plants that contain the given string in their geslacht
        
        //Robin: removed "static", couldn't reach context
        public List<Plant> OnGeslacht(string geslacht)
        {
            var listPlants = context.Plant.Where(p => p.Geslacht.Contains(geslacht)).ToList();
            return listPlants;
        }
        //A function that returns a list of plants
        //the returned list are all the plants that contain the given string in their latin name
        public List<Plant> OnName(string name)
        {
            var listPlants = context.Plant.Where(p => p.Fgsv.Contains(name)).ToList();
            return listPlants;
        }
        public List<Plant> OnVariant(string variant)
        {
            var listPlants = context.Plant.Where(p => p.Variant.Contains(variant)).ToList();
            return listPlants;
        }
        //A function that returns a list of plants
        //the returned list are al the plants that contain the given string in their family
        public List<Plant> OnFamily(string family)
        {
            var listPlants = context.Plant.Where(p => p.Familie.Contains(family)).ToList();
            return listPlants;
        }
        /* HELP FUNCTIONS */

        //get a list of all the plants.
        public Dictionary<long,string>getAllPlants()
        {
            //R: Needs adjustments after databaseupdate DONE
            var plants = context.Plant.ToList();
           // .ToDictionary(s => s.PlantId, s => s.Type);
            var dictionaryresult = new Dictionary<long, string>();
            int icount = 1;

            foreach (var plant in plants)
            {
                dictionaryresult.Add
                                    (icount,
                                    "Plantnaam = " + plant.Fgsv + Environment.NewLine
                                    + "type = " + plant.Type + Environment.NewLine
                                    + "famillie = " + plant.Familie + Environment.NewLine
                                    + "geslacht = " + plant.Geslacht + Environment.NewLine
                                    + "soort = " + plant.Soort + Environment.NewLine
                                    + "variant = " + plant.Variant + Environment.NewLine
                                    + "nederlandse naam = " + plant.NederlandsNaam + Environment.NewLine
                                    + "plantendichtheid = Min: " + plant.PlantdichtheidMin.ToString() + " Max: " + plant.PlantdichtheidMax.ToString() + Environment.NewLine
                                    );
                icount++;

            }

            return dictionaryresult;
        }
       
        //A function that takes a string, puts it to lowercase, 
        //changes all the ' and " chars and replaces them by a space
        //next it deletes al the spaces and returns the string.
        public string Simplify(string stringToSimplify)
        {
            string answer = stringToSimplify.ToLower().Replace("\'", " ").Replace("\"", " ");
            answer = String.Concat(answer.Where(c => !Char.IsWhiteSpace(c)));
            return answer;
        }


        /// <summary>
        ///                            FILL COMBOBOX
        ///            Deze functie zijn voor het cascade systeem.
        /// </summary>
        /// <returns></returns>

        public Dictionary<long,string> fillTfgsvType() 
        {
            // lijst type opvragen.
            // distinct om meerdere van de zelfde tegen te gaan.
            // to dictionary om er een dictionary van mee te geven  plantype is de key en planttypenaam is value
            var selection = context.TfgsvType.Distinct().ToDictionary(s => s.Planttypeid, s => s.Planttypenaam);         
            return selection;
        }

        public Dictionary<long, string> fillTfgsvFamilie(int selectedItem)
        {
            // lijst type opvragen.
            // distinct om meerdere van de zelfde tegen te gaan.
            // to dictionary om er een dictionary van mee te geven  plantype is de key en planttypenaam is value
            // De if else is er voor bij opstarten de comboboxen te vullen en geen error te krijgen omdat er niet geselecteerd is. en gebruikt dan gewoon geen where.
            if (selectedItem > 0)
            {              
                var selection = context.TfgsvFamilie.Distinct().Where(s => s.TypeTypeid == selectedItem).ToDictionary(s => s.FamileId, s => s.Familienaam);
                return selection;
            }
            else
            {
                var selection = context.TfgsvFamilie.Distinct().ToDictionary(s => s.FamileId, s => s.Familienaam);
                return selection;
            }
               
           
        }
        public Dictionary<long, string> fillTfgsvGeslacht(int selectedItem)
        {
            // lijst type opvragen.
            // distinct om meerdere van de zelfde tegen te gaan.
            // to dictionary om er een dictionary van mee te geven  plantype is de key en planttypenaam is value
            // De if else is er voor bij opstarten de comboboxen te vullen en geen error te krijgen omdat er niet geselecteerd is. en gebruikt dan gewoon geen where.
            if (selectedItem > 0)
            {
                var selection = context.TfgsvGeslacht.Where(s => s.FamilieFamileId == selectedItem).Distinct().ToDictionary(s => s.GeslachtId, s => s.Geslachtnaam);
                return selection;
            }
            else
            {
                var selection = context.TfgsvGeslacht.Distinct().ToDictionary(s => s.GeslachtId, s => s.Geslachtnaam);
                return selection;
            }
          
        }
        public Dictionary<long, string> fillTfgsvSoort(int selectedItem)
        {
            // lijst type opvragen.
            // distinct om meerdere van de zelfde tegen te gaan.
            // to dictionary om er een dictionary van mee te geven  plantype is de key en planttypenaam is value 
            // De if else is er voor bij opstarten de comboboxen te vullen en geen error te krijgen omdat er niet geselecteerd is. en gebruikt dan gewoon geen where.
            if (selectedItem > 0)
            {
                var selection = context.TfgsvSoort.Where(s => s.GeslachtGeslachtId == selectedItem).Distinct().ToDictionary(s => s.Soortid, s => s.Soortnaam);
                return selection;
            }
            else
            {
                var selection = context.TfgsvSoort.Distinct().ToDictionary(s => s.Soortid, s => s.Soortnaam);
                return selection;
            }        
        }

        public Dictionary<long, string> fillTfgsvVariant(int selectedItem)
        {
            // lijst type opvragen.
            // distinct om meerdere van de zelfde tegen te gaan.
            // to dictionary om er een dictionary van mee te geven  plantype is de key en planttypenaam is value
            // De if else is er voor bij opstarten de comboboxen te vullen en geen error te krijgen omdat er niet geselecteerd is. en gebruikt dan gewoon geen where.
            if (selectedItem > 0)
            {
                var selection = context.TfgsvVariant.Where(s => s.SoortSoortid == selectedItem).Distinct().ToDictionary(s => s.VariantId, s => s.Variantnaam);
                return selection;
            }
            else
            {
                var selection = context.TfgsvVariant.Distinct().ToDictionary(s => s.VariantId, s => s.Variantnaam);
                return selection;
            }



     
        }

    }
}
