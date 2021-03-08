using System;
using System.Collections.Generic;
using System.Text;

namespace PlantenApplicatie.FiltersSearch
{
    class Habitat
    {
        public string ontwikkelingsSnelheid { get; set; }
        public string habitat { get; set; }
        public string bezonning { get; set; }
        public string sociabiliteit { get; set; }
        public string nectarWaardeMin { get; set; }
        public string nectarWaardeMax { get; set; }
        public string concurentieKracht { get; set; }
        public bool bijenvriendelijk { get; set; }
        public bool eetbaarKruid { get; set; }
        public bool geurend { get; set; }
        public bool vlinderVriendlijk { get; set; }
        public bool vorstgevoelig { get; set; }
        // levensduur nog uitzoeken hoe we dit doen.

    }
}
