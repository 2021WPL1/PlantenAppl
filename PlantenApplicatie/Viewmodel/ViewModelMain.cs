using Planten2021.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Prism.Commands;

namespace PlantenApplicatie.ViewModel
{
    class ViewModelMain:ViewModelBase
    {
        private DAO _dao;
 
        private ViewModelSearchTfgsv viewModelTFGSV;

       

        //private variables
        private Page _currentView;

        //ICommands
        public ICommand OpenTfgsvViewCommand { get; set; }

        
 
        public ViewModelMain(DAO dao)
        {
            this._dao = dao;

            viewModelTFGSV = new ViewModelSearchTfgsv(dao);

            viewModelTFGSV = new ViewModelSearchTfgsv(dao);


        }
    
    }

}
