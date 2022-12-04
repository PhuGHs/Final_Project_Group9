using QuanLyNhaHang.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyNhaHang.State.Navigator
{
    public enum TypeOfView
    {
        NhanVien,
        Kho,
        Menu,
        LichSuBan,
        TinhTrangBan,
        CaiDat,
        DangXuat,
        ThongKe,
        Bep

    }
    public interface INavigator
    {
        BaseViewModel CurrentViewModel { get; set; }
        string CurrentTitle { get; set; }
        ICommand SelectViewModelCommand { get;  }
    }
}
