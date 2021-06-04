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
        //Dit is de gebruiker in de databank. Dit is de gebruiker
        //die geregistreerd, of gecontroleerd wordt door de LoginUserService
        public Gebruiker gebruiker { get; set; }

        //Dit is een enum waarmee de LoginUserService kan controleren of een
        //Gebruiker ingelogd is of niet.
        public LoginStatus loginStatus {get; set; }

        //Deze string wordt opgevuld in de LoginUserService met een foutmelding
        //die kan weergegeven worden in de LoginWindow en RegisterWindow
        public string errorMessage { get; set; }

    }
}
