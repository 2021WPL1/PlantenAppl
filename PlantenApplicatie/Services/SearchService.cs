using Planten2021.Data;
using PlantenApplicatie.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlantenApplicatie.Services
{
    public class SearchService:ISearchService
    {
        private DAO _dao;
        public SearchService()
        {
            this._dao = DAO.Instance();
        }

        public void ApplyFilters()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            
        }
    }
}
