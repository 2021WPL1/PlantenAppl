using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using Planten2021.Data;
using Planten2021.Domain.Models;
using PlantenApplicatie.HelpClasses.Login.classes;
using PlantenApplicatie.HelpClasses.Login.enums;
using PlantenApplicatie.Services;
using PlantenApplicatie.Services.Interfaces;
using PlantenApplicatie.View;
using PlantenApplicatie.View.Home;
using PlantenApplicatie.ViewModel;
//written by kenny
namespace PlantenApplicatie.Viewmodel
{
    public class ViewModelLogin : ViewModelBase
    {
        private IloginUserService _loginService { get; }
        public ViewModelLogin( IloginUserService loginUserService)
        {
            this._loginService = loginUserService;
        }
    }
}
