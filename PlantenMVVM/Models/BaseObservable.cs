using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PlantenMVVM.Models
{

        public class BaseObservableModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;


            protected virtual void SetProperty<T>(ref T member, T val, [CallerMemberName] string propertyName = null)
            {
                if (object.Equals(member, val)) return;
                member = val;
                RaisePropertyChanged(propertyName);
            }

            protected void RaisePropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
