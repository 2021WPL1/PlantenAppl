using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Planten2021.Data;
using Prism.Commands;
using PlantenApplicatie.View;
using GalaSoft.MvvmLight.Command;

namespace PlantenApplicatie.ViewModel
{
    class ViewModelMain:ViewModelBase
    {
        private DAO _dao;


        //private variables
        private Page _currentView;

        //ICommands
        public ICommand OpenTfgsvViewCommand { get; set; }

 
        public ViewModelMain(DAO dao, Page view)
        { 
            this._dao = dao;
        }

    }
}
