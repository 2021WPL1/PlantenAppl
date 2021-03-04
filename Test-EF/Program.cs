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
            var test = context.TfgsvFamilie.FirstOrDefault(f => f.Familienaam == "ALLIACEAE");
            string nameTest = test.Familienaam;
            
            Console.WriteLine("De famillienaam = " + nameTest);
            Console.WriteLine("test");
        }
    }
}
