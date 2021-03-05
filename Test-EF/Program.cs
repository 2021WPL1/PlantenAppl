using Planten2021.Data.Models;
using Planten2021.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test_EF
{
    class Program
    {
        private static Planten2021Context context = new Planten2021Context();
        static void Main(string[] args)
        {
          var list =  searchOnName("Aurinia");
            printInfo(list);
        }

        //A function that takes a string, puts it to lowercase, 
        //changes all the ' and " chars and replaces them by a space
        //next it deletes al the spaces and returns the string.
        public static string simplify(string stringToSimplify)
        {
            string answer = stringToSimplify.ToLower().Replace("\'", " ").Replace("\"", " ");
            answer = String.Concat(answer.Where(c => !Char.IsWhiteSpace(c)));
            return answer;
        }

        //work in progress

        public static List<Plant> searchOnName(string name)
        {
            var listPlants = getAllPlants();
            foreach (Plant plant in listPlants)
            {
                var plantToAdd = context.Plant.FirstOrDefault(p => p.Fgsv.Contains(name));
                listPlants.Add(plantToAdd);
            }
            
            return listPlants;
        }

        //This function prints all the info of the plants in the given list.
        public static void printInfo(List<Plant> listPlants)
        {
            foreach (Plant plant in listPlants)
            {
                Console.WriteLine( "Plantnaam = " + plant.Fgsv + Environment.NewLine
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

        //get a list of all the plants.
        public static List<Plant> getAllPlants()
        {
            var plants = context.Plant.ToList();
            return plants;
        }
    }
}
