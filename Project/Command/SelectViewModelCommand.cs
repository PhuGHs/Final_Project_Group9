﻿using QuanLyNhaHang.State.Navigator;
using QuanLyNhaHang.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyNhaHang.Command
{
    public class SelectViewModelCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly INavigator _navigator;
        private readonly INavigator _navigator1;

        public SelectViewModelCommand(INavigator navigator, INavigator navigator1) // Constructor
        {
            //start up page
            navigator.CurrentViewModel = new MenuViewModel();
            navigator1.CurrentTitle = "Menu";
            _navigator = navigator;
            _navigator1 = navigator1;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if(parameter is TypeOfView)
            {
                TypeOfView viewType = (TypeOfView)parameter;
                switch(viewType)
                {
                    case TypeOfView.ThongKe:
                        _navigator1.CurrentTitle = "Thống kê";
                        _navigator.CurrentViewModel = new ThongKeViewModel();
                        break;
                    case TypeOfView.Menu:
                        _navigator1.CurrentTitle = "Menu";
                        _navigator.CurrentViewModel = new MenuViewModel();
                        break;
                    case TypeOfView.LichSuBan:
                        _navigator1.CurrentTitle = "Lịch sử bàn";
                        _navigator.CurrentViewModel = new LichSuBanViewModel();
                        break;
                    case TypeOfView.NhanVien:
                        _navigator1.CurrentTitle = "Nhân Viên";
                        _navigator.CurrentViewModel = new NhanVienViewModel();
                        break;
                    case TypeOfView.Kho:
                        _navigator1.CurrentTitle = "Kho";
                        _navigator.CurrentViewModel = new KhoViewModel();
                        break;
                    case TypeOfView.TinhTrangBan:
                        _navigator1.CurrentTitle = "Tình trạng bàn";
                        _navigator.CurrentViewModel = new TinhTrangBanViewModel();
                        break;
                    case TypeOfView.CaiDat:
                        _navigator1.CurrentTitle = "Cài đặt";
                        _navigator.CurrentViewModel = new CaiDatViewModel();
                        break;
                    case TypeOfView.Bep:
                        _navigator1.CurrentTitle = "Bếp";
                        _navigator.CurrentViewModel = new BepViewModel();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
