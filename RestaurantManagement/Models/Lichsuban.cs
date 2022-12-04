    using QuanLyNhaHang.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LichSuBan.Models
{

    public class LichSuBanModel
    {
        private string ten;
        private int tondu;
        private string donvi;
        private string dongia;
        public string Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ImportPrice { get; set; }

        public int Quantity { get; set; }

        public Nullable<System.DateTime> CreatedAt { get; set; }

        public LichSuBanModel(string ten, int tondu, string donvi, string dongia)
        {
            this.ten = ten;
            this.tondu = tondu;
            this.donvi = donvi;
            this.dongia = dongia;
        }
    }
    
    public class ListProduct : BaseViewModel
    {

        private string _TenSanPham;
        public string TenSanPham { get => _TenSanPham; set { _TenSanPham = value; } }
        private int _TonDu;
        public int TonDu { get => _TonDu; set { _TonDu = value; } }
        private string _DonVi;
        public string DonVi { get => _DonVi; set { _DonVi = value; } }
        private string _DonGia;
        public string DonGia { get => _DonGia; set { _DonGia = value; } }
      

        public ListProduct(string ten, int tondu, string donvi, string dongia)
        {
            TenSanPham = ten;
            TonDu = tondu;
            DonVi = donvi;
            DonGia = dongia;
            
        }
    }
}


