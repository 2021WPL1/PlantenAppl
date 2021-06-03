using System;
using System.Collections.Generic;
using System.Text;
using Planten2021.Domain.Models;
using PlantenApplicatie.HelpClasses.Login.enums;
//written by kenny
namespace PlantenApplicatie.HelpClasses.Login.classes
{  
    public class LoginResult
    {
        public Gebruiker gebruiker { get; set; }
        public LoginStatus loginStatus {get; set; }
        public string errorMessage { get; set; }

    }
}
