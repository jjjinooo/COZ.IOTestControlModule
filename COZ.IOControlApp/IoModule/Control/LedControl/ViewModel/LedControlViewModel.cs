using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace IoModule.Control.LedControl.ViewModel
{
    public class LedControlViewModel : ObservableObject
    {
        private int _checkio;
        public int CheckIo
        {
            get => _checkio;
            set => SetProperty(ref _checkio, value);
        }
    }
}
