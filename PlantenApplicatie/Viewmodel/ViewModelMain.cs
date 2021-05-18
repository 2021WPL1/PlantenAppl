using System;
using System.Collections.Generic;
using System.Text;
using Planten2021.Data;

namespace PlantenApplicatie.ViewModel
{
    class ViewModelMain:ViewModelBase
    {
        private DAO _dao;

        public ViewModelMain(DAO dao)
        { 
            this._dao = dao;
        }
    }
}
