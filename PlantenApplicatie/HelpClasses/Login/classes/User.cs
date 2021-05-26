using System;
using System.Collections.Generic;
using System.Text;
using Planten2021.Domain.Models;
using PlantenApplicatie.HelpClasses.Login.enums;

namespace PlantenApplicatie.HelpClasses.Login.classes
{
    class User
    {
        public Gebruiker gebruiker { get; set; }
        public LoginStatus loginStatus {get; set; }
    }
}
