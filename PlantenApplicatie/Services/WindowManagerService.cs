using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Planten2021.Data;
using PlantenApplicatie.Services.Interfaces;

namespace PlantenApplicatie.Services
{
    public class WindowManagerService: IWindowManagerService, INotifyPropertyChanged
    {
        private DAO _dao;

        public event PropertyChangedEventHandler PropertyChanged;
        public WindowManagerService()
        {
            this._dao = DAO.Instance();
        }
    }
}
