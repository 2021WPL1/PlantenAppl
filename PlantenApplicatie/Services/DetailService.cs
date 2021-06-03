using Planten2021.Data;
using PlantenApplicatie.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PlantenApplicatie.Services
{
    public class DetailService: IDetailService, INotifyPropertyChanged
    {
        private DAO _dao;
        private static DetailService _detailService;

        public event PropertyChangedEventHandler PropertyChanged;
        public DetailService()
        {
            this._dao = DAO.Instance();
        }

    }
}
