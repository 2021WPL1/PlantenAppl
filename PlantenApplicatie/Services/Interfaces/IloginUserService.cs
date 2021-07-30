using System.Runtime.CompilerServices;
using Planten2021.Domain.Models;
using PlantenApplicatie.HelpClasses.Login.classes;

namespace PlantenApplicatie.Services.Interfaces
{/*written by kenny*/
    public interface IloginUserService
    {
        LoginResult CheckCredentials(string userNameInput, string passwordInput);
        string RegisterButton(string vivesNrInput, string lastNameInput,
            string firstNameInput, string emailAdresInput,
            string passwordInput, string passwordRepeatInput, string rolInput);
        string LoggedInMessage();
        public void ConfigureRoll(Gebruiker gebruiker);
    }
}