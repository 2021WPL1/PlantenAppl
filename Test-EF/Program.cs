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
            string stringAwkward = "                            AA\" BB CC \"DD ee' Ff l      ";
            Console.WriteLine(stringAwkward);
            string stringAwkward2 = simplify(stringAwkward);
            Console.WriteLine(stringAwkward2);
            Console.WriteLine(simplify(stringAwkward2));
        }

        //Not even an Asian uderstands it but it works
        public static string simplify(string stringToSimplify)
        {
            string answer = stringToSimplify.ToLower().Trim().Replace("\'", " ").Replace("\"", " ");
            answer = String.Concat(answer.Where(c => !Char.IsWhiteSpace(c)));
            return answer;
        }
    }
}
