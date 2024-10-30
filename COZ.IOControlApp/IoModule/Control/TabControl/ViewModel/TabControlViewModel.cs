using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoModule.Control.TabControl.ViewModel
{
    public delegate void TabEvent(int value);
    public class TabControlViewModel : ObservableObject
    {
        public event TabEvent _tabEvent;
        bool TabValue { get; set; }
        private RelayCommand<bool> _tabCommand;
        public RelayCommand<bool> TabCommand
        {
            get
            {
                return _tabCommand ?? (_tabCommand = new RelayCommand<bool>(execute: TabCommandControl));
            }
        }
        private bool _isEnableConnectionController;
        public bool IsEnableConnectionController
        {
            get { return _isEnableConnectionController; }
            set
            {
                //if (_isEnableConnectionController == value) return;

                _isEnableConnectionController = value;
                //SetProperty(ref _isEnableConnectionController, value);

                OnPropertyChanged(nameof(IsEnableConnectionController));
            }
        }

        private int _checkstatus;
        public int TabCheckStatus
        {
            get => _checkstatus;
            set
            {
                SetProperty(ref _checkstatus, value);
                _tabEvent?.Invoke(value);
            }


        }

        public TabControlViewModel()
        {
        }
        public void TabCommandControl(bool value) => TabValue = value;
        public int TabStatus() => _checkstatus;

    }
}
