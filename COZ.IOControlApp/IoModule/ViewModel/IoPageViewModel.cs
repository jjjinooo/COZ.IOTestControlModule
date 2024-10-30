using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace IoModule.ViewModel
{
    public class IoPageViewModel : ObservableObject
    {
        private int numberOfControls;
        public ObservableCollection<IoModuleViewModel> UserControls { get; } = new ObservableCollection<IoModuleViewModel>();

        public IoPageViewModel() { CreateUserControls(); }
        private void CreateUserControls()
        {
            UserControls.Clear();
            for (int i = 0; i < 10; i++)
            {
                UserControls.Add(new IoModuleViewModel(($"{i + 1}"), ($"Control {i + 1}")));
            }
        }
    }
}
