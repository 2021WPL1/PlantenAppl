using Planten2021.Data.Models;
using System;
using System.Linq;

namespace Test_EF
{
    class Program
    {
        private static Planten2021Context context = new Planten2021Context();
        static void Main(string[] args)
        {
            test();
        }

        public static void test()
        {
            var test = context.TfgsvFamilie.FirstOrDefault(f => f.Familienaam == "ALLIACEAE");
            string nameTest = test.Familienaam;

            Console.WriteLine("De famillienaam = " + nameTest);
            Console.WriteLine("test");
            Console.WriteLine(test2());
            test3("dit is een test");
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
