using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using QuanLyNhaHang.View.LoginView;
using Project;

namespace QuanLyNhaHang.ViewModel.LoginVM
{
    public class LoginWindowVM : BaseViewModel
    {
        public bool IsLoggedIn { get; set; }
        public ICommand CloseLoginCM { get; set; }
        public ICommand LoginCM { get; set; }
        public LoginWindowVM()
        {
            IsLoggedIn = false;
            CloseLoginCM = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null) return;
                p.Close();
            });
            LoginCM = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Login(p);
                if (IsLoggedIn)
                {
                    p.Hide();
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    p.Close();
                    return;
                }    
            });
            void Login(Window p)
            {
                if (p == null) return;
                IsLoggedIn = true;
            }
        }
    }
}
