using System;
using System.Collections.Generic;
using System.Text;
using Planten2021.Domain.Models;
using PlantenApplicatie.HelpClasses.Login.classes;

namespace PlantenApplicatie.Services
{
    public class LoginUserService : ILoginUserService
    {
        public User LoginSettings { get; }

        public LoginUserService() { this.LoginSettings = new User(); }
        public bool CheckCredentials(Gebruiker credentials)
        {
            //connect with authentication provider/backend to check logincredentials
            return true;
        }

    }
}
