using QuanLyNhaHang.Models;
using QuanLyNhaHang.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace QuanLyNhaHang.ViewModel
{
    public class BepViewModel : BaseViewModel
    {
        private ObservableCollection<Bep> _ListBep;
        public ObservableCollection<Bep> ListBep { get => _ListBep; set { _ListBep = value; OnPropertyChanged(); } }
        private string _Search;
        public string Search
        {
            get => _Search;
            set
            {
                _Search = value;
                OnPropertyChanged();
            }
        }
        private string _STT;
        public string STT { get => _STT; set { _STT = value; OnPropertyChanged(); } }
        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }
        private int _SoBan;
        public int SoBan { get => _SoBan; set { _SoBan = value; OnPropertyChanged(); } }
        private string _TinhTrang;
        public string TinhTrang { get => _TinhTrang; set { _TinhTrang = value; OnPropertyChanged(); } }
        private string _Address;
        public ICommand AddCM { get; set; }
        public ICommand EditCM { get; set; }
        public ICommand DeleteCM { get; set; }
        public BepViewModel()
        {
            ListBep = new ObservableCollection<Bep>();



        }
    }
    }
