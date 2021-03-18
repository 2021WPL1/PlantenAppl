using Planten2021.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test_EF
{
    class Program
    {
        public string Simplify(string stringToSimplify)
        {
            string answer = stringToSimplify.Replace("\'", " ").Replace("\"", " ");
            answer = String.Concat(answer.Where(c => !Char.IsWhiteSpace(c)));
            return answer;
        }
        public void Main(string[] args)
        {
            Console.WriteLine(Simplify("vebkob  regeg"));

        }

            
        
    }
}
