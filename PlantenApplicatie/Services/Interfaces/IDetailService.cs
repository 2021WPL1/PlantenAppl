using Planten2021.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlantenApplicatie.Services.Interfaces
{
    public interface IDetailService
    {
        public Plant ReturnSelectedPlant();
        public List<FenotypeMulti> FilterFenoMulti(long plantId);
        public List<FenoBloeiwijze> GetFenoBloeiwijzes();

    }
}
