using QuanLyNhaHang.Command;
using QuanLyNhaHang.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyNhaHang.State.Navigator
{
    public class Navigator : ObservableObject, INavigator
    {
        private BaseViewModel _currentViewModel;
        private string _currentTitle;
        public BaseViewModel CurrentViewModel { 
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }
        public string CurrentTitle
        {
            get
            {
                return _currentTitle;
            }
            set
            {
                _currentTitle = value;
                OnPropertyChanged(nameof(CurrentTitle));
            }
        }

        public ICommand SelectViewModelCommand => new SelectViewModelCommand(this, this);
    }
}
