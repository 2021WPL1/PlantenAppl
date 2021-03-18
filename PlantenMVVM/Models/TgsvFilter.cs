using System;
using System.Collections.Generic;
using System.Text;

namespace PlantenMVVM.Models
{
    public class TgsvFilter : BaseObservableModel
    {
        private long _typeId;
        //alle ids
        //aangemaakte id objecten gebruiken in cascade queries
        public long TypeId
        {
            get => _typeId;
            set
            {
                //
                SetProperty(ref _typeId, value);
            }

        }
    }
}
