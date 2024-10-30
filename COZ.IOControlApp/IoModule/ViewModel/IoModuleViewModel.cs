using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoModule.Control.TabControl;
using IoModule.Control.TabControl.ViewModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Controls;

namespace IoModule.ViewModel
{
    public class IoModuleViewModel : ObservableObject
    {
        public IoModuleViewModel() { }
        public IoModuleViewModel(string no, string name)
        {
            TabControl = new TabControlViewModel();
            IoNumber = no;
            IoName = name;
        }

        private TabControlViewModel _tabctl;
        public TabControlViewModel TabControl
        {
            get => _tabctl;
            set => SetProperty(ref _tabctl, value);
        }

        private string _ion;
        public string IoNumber
        {
            get => _ion;
            set => SetProperty(ref _ion, value);
        }

        private string _ioname;
        public string IoName
        {
            get => _ioname;
            set => SetProperty(ref _ioname, value);
        }

  
    }
}
