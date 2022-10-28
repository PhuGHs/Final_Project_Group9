using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyNhaHang.ViewModel
{
    public class NhanVienViewModel : BaseViewModel
    {
        public ICommand AddCM { get; set; }
        public ICommand EditCM { get; set; }
        public ICommand DeleteCM { get; set; }
        public ICommand CheckCM { get; set; }
        public NhanVienViewModel()
        {
            AddCM = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                MyMessageBox mess = new MyMessageBox("Thêm thành công!");
                mess.ShowDialog();
            });
            EditCM = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                MyMessageBox mess = new MyMessageBox("Sửa thành công!");
                mess.ShowDialog();
            });
            DeleteCM = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                MyMessageBox yesno = new MyMessageBox("Bạn có chắc chắn xóa ?", true);
                yesno.ShowDialog();
                if (yesno.ACCEPT())
                {
                    MyMessageBox mess = new MyMessageBox("Xóa thành công!");
                    mess.ShowDialog();
                }
            });
            CheckCM = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                MyMessageBox mess = new MyMessageBox("Bảng chấm công");
                mess.ShowDialog();
            });
        }
    }
}
