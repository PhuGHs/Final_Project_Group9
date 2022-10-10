using QuanLyNhaHang.State.Navigator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace QuanLyNhaHang.ViewModel
{

    public class MainViewModel : BaseViewModel
    {
        public INavigator Navigator { get; set; } = new Navigator();
        public HeaderViewModel Header { get; set; } = new HeaderViewModel();
    }
}
