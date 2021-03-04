using System;
using System.Collections.Generic;
using System.Text;

namespace PlantenApplicatie.GUI
{
    public class BasisGui
    {
        public void Frame_Navigated()
        {
            CvsZoeken.Visibility = Visibility.Hidden;
        }

        private void BtnbackgroundColor()
        {
            btnZoeken.Background = Brushes.Transparent;
        }
    }
}
