using System;
using System.Collections.Generic;
using System.Text;

namespace Planten2021.Data
{
    public class Result
    {
        public int planId { get; set; }
        public string type { get; set; }
        public string familie { get; set; }
        public string geslacht { get; set; }
        public string soort { get; set; }
        public string variant { get; set; }
        public string naam { get; set; }
        public string nederlandseNaam { get; set; }
        public int plantenDichtheidMin { get; set; }
        public int plantenDichtheidMax { get; set; }
        public int status { get; set; }
    }
}
