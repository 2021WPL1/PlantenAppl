using Planten2021.Data.Models;
using Planten2021.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test_EF
{
    class Program
    {
        public static Planten2021Context context = new Planten2021Context();
        static void Main(string[] args)
        {
            var listName = searchOnName("Baptisia");
            printInfo(listName);

            var listVariant = searchOnVariant("Fire");
            printInfo(listVariant);

            var listFamily = searchOnFamily("BRASSICACEAE");
            printInfo(listFamily);

            var listSoort = searchOnSoort("australis");
            printInfo(listSoort);

            var lisGeslacht = searchOnGeslacht("Bergenia");
            printInfo(lisGeslacht);

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

        //A function that returns a list of plants
        //the returned list are all the plants that contain the given string in their geslacht
        public static List<Plant> searchOnGeslacht(string geslacht)
        {
            Console.WriteLine("\t SEARCH PLANTS THAT CONTAINS " + geslacht.ToUpper() + " IN THEIR GESLACHT."
                + Environment.NewLine);
            var listPlants = context.Plant.Where(p => p.Geslacht.Contains(geslacht)).ToList();
            return listPlants;
        }

        //A function that returns a list of plants
        //the returned list are all the plants that contain the given string in their soort
        public static List<Plant> searchOnSoort(string soort)
        {
            Console.WriteLine("\t SEARCH PLANTS THAT CONTAINS " + soort.ToUpper() + " IN THEIR SOORT."
                + Environment.NewLine);
            var listPlants = context.Plant.Where(p => p.Soort.Contains(soort)).ToList();
            return listPlants;
        }

        //A function that returns a list of plants
        //the returned list are all the plants that contain the given string in their latin name
        public static List<Plant> searchOnName(string name)
        {
            Console.WriteLine("\t SEARCH PLANTS THAT CONTAINS " + name.ToUpper() + " IN THEIR NAME."
                + Environment.NewLine);
            var listPlants = context.Plant.Where(p => p.Fgsv.Contains(name)).ToList();
            return listPlants;
        }

        //A function that returns a list of plants
        //the returned list are al the plants that contain the given string in their variant
        public static List<Plant> searchOnVariant(string variant)
        {
            Console.WriteLine( "\t SEARCH PLANTS THAT IS FROM THE  " + variant.ToUpper() + " VARIANT."
                + Environment.NewLine);
            var listPlants = context.Plant.Where(p => p.Variant.Contains(variant)).ToList();
            return listPlants;
        }

        //A function that returns a list of plants
        //the returned list are al the plants that contain the given string in their family
        public static List<Plant> searchOnFamily(string family)
        {
            Console.WriteLine("\t SEARCH PLANTS THAT IS FROM THE  " + family + " FAMILY."
                + Environment.NewLine);
            var listPlants = context.Plant.Where(p => p.Familie.Contains(family)).ToList();
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

        public static string test2()
        {
            string test3 = "hallo";
            return test3;
        }

        public static void test3(string lala)
        {
            Console.WriteLine(lala);
        }

            
        
    }
}
