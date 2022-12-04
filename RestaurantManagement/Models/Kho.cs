using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.Models
{
    public class Kho
    {
        private string _TenSanPham;
        public string TenSanPham { get => _TenSanPham; set { _TenSanPham = value; } }
        private int _TonDu;
        public int TonDu { get => _TonDu; set { _TonDu = value; } }
        private string _DonVi;
        public string DonVi { get => _DonVi; set { _DonVi = value; } }
        private string _DonGia;
        public string DonGia { get => _DonGia; set { _DonGia = value; } }


        public Kho(string ten, int tondu, string donvi, string dongia)
        {
            TenSanPham = ten;
            TonDu = tondu;
            DonVi = donvi;
            DonGia = dongia;
        }
    }
}