using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using LichSuBan.Models;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;
using LicenseContext = OfficeOpenXml.LicenseContext;
using System.IO;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;
using DataTable = System.Data.DataTable;
using SaveFileDialog = System.Windows.Forms.SaveFileDialog;
using System.Linq;

namespace QuanLyNhaHang.ViewModel
{
    public class LichSuBanViewModel : BaseViewModel
    {



        private bool isGettingSource;
        public bool IsGettingSource
        {
            get { return isGettingSource; }
            set { isGettingSource = value; OnPropertyChanged(); }
        }

        private DateTime _getCurrentDate;
        public DateTime GetCurrentDate
        {
            get { return _getCurrentDate; }
            set { _getCurrentDate = value; }
        }
        private string _setCurrentDate;
        public string SetCurrentDate
        {
            get { return _setCurrentDate; }
            set { _setCurrentDate = value; }
        }

        private DateTime selectedDate;
        public DateTime SelectedDate
        {
            get { return selectedDate; }
            set { selectedDate = value; OnPropertyChanged(); }
        }
        private ComboBoxItem _SelectedItemFilter;
        public ComboBoxItem SelectedItemFilter
        {
            get { return _SelectedItemFilter; }
            set { _SelectedItemFilter = value; OnPropertyChanged(); }
        }
        private ComboBoxItem _SelectedImportItemFilter;
        public ComboBoxItem SelectedImportItemFilter
        {
            get { return _SelectedImportItemFilter; }
            set { _SelectedImportItemFilter = value; OnPropertyChanged(); }
        }
        private int _SelectedMonth;
        public int SelectedMonth
        {
            get { return _SelectedMonth; }
            set { _SelectedMonth = value; OnPropertyChanged(); }
        }

        private int _SelectedImportMonth;
        public int SelectedImportMonth
        {
            get { return _SelectedImportMonth; }
            set { _SelectedImportMonth = value; OnPropertyChanged(); }
        }


        private ObservableCollection<LichSuBanModel> _ListProduct;
        public ObservableCollection<LichSuBanModel> ListProduct
        {
            get { return _ListProduct; }
            set { _ListProduct = value; OnPropertyChanged(); }
        }

        private ObservableCollection<HoaDon> _ListBill;
        public ObservableCollection<HoaDon> ListBill
        {
            get { return _ListBill; }
            set { _ListBill = value; OnPropertyChanged(); }
        }
        private string timkiem;
        public string Search
        {
            get { return timkiem; }
            set
            {
                timkiem = value;
                string str;
                OnPropertyChanged();
                if (!String.IsNullOrEmpty(Search))
                {
                    str = "SELECT * FROM HOADON WHERE SoHD LIKE '%" + Search + "%'";
                }
                else
                    str = "SELECT * FROM HOADON";
                ListViewDisplay(str);
            }
        }
        private string strCon = @"Data Source=.\DESKTOP-ADQ1342;Initial Catalog=QuanLyNhaHan;Integrated Security=True";
        private SqlConnection sqlCon = null;

        public ICommand LoadImportPageCM { get; set; }
        public ICommand LoadExportPageCM { get; set; }
        public ICommand ExportFileCM { get; set; }
        public ICommand CheckImportItemFilterCM { get; set; }
        public ICommand SelectedImportMonthCM { get; set; }
        public ICommand SelectedMonthCM { get; set; }
        public ICommand CheckCM { get; set; }

        public ICommand CheckItemFilterCM { get; set; }
        public int SelectedView = 0;


        public LichSuBanViewModel()
        {
            /* OpenConnect();*/
            /*  ListProduct = new ObservableCollection<LichSuBanModel>();


              ListViewDisplay("SELECT * FROM HOADON");
  */

            GetCurrentDate = DateTime.Today;
            SelectedDate = GetCurrentDate;
            SelectedMonth = DateTime.Now.Month - 1;
            SelectedImportMonth = DateTime.Now.Month - 1;
            SelectedMonthCM = new RelayCommand<System.Windows.Controls.ComboBox>((p) => { return true; }, async (p) =>
            {
                await CheckMonthFilter();
            });
            CheckCM = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                MyMessageBox mess = new MyMessageBox("Kiểm tra");
                mess.ShowDialog();

            });
            ExportFileCM = new RelayCommand<ListProduct>((p) => true, (p) => ExportToFileFunc());
            /* CloseConnect();*/
        }

        public void ExportToFileFunc()
        {
            string filepath = "";
            SaveFileDialog dialog = new SaveFileDialog();
            /* OpenFileDialog dialog = new OpenFileDialog();*/
            dialog.Filter = "Excel | *.xlsx | Excel 2016 | *.xls";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                filepath = dialog.FileName;
            }
            if (string.IsNullOrEmpty(filepath))
            {
                MyMessageBox mb = new MyMessageBox("Đường dẫn không hợp lệ");
                mb.ShowDialog();
                return;
            }
            /* List<ListProduct> sanpham = new List<ListProduct>();
             DataTable dt = new DataTable();
             dt.Columns.Add("ID");
             dt.Columns.Add("TEN SP");

             try
             {
                 var package = new ExcelPackage(new FileInfo(filepath));
                 ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                 ExcelWorksheet ws = package.Workbook.Worksheets[0];
                 for (int i = ws.Dimension.Start.Row + 2; i <= ws.Dimension.End.Row; i++)
                 {
                     try
                     {
                         int j = 1;
                         string id = ws.Cells[i, j++].Value.ToString();
                         string name = ws.Cells[i, j++].Value.ToString();
                         dt.Rows.Add(id, name);
                     }
                     catch
                     {
                         MyMessageBox mb = new MyMessageBox("Lỗi");
                         mb.ShowDialog();
                     }


                 }*/
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            try { 
            using (ExcelPackage p = new ExcelPackage())
            {

                string[] arrColumHeader =
            {
                 "Mã đơn",
                 "Tên sản phẩm",
                 "Số lượng",
                 "Tổng giá",
                 "Ngày nhập" };

                var countHeader = arrColumHeader.Count();




                p.Workbook.Properties.Title = "Lịch sử bàn";
                p.Workbook.Worksheets.Add("Test");

                ExcelWorksheet ws = p.Workbook.Worksheets[0];
                ws.Name = "Test";

                ws.Cells[1, 1].Value = "Lịch sử bàn";
                int colIndex = 0;
                int rowIndex = 0;
                foreach (var item in arrColumHeader)
                {
                    var cell = ws.Cells[rowIndex, colIndex];
                    cell.Value = item;
                    colIndex++;

                }
                Byte[] bin = p.GetAsByteArray();
                File.WriteAllBytes(filepath, bin);


            }
        }
         catch
         {
             MyMessageBox mb = new MyMessageBox("Lỗi");
        mb.ShowDialog();
         }
}


/*

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
                    Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                    app.Visible = false;
                    Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Add(1);
                    Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];


                    ws.Cells[1, 1] = "Mã đơn";
                    ws.Cells[1, 2] = "Tên sản phẩm";
                    ws.Cells[1, 3] = "Số lượng";
                    ws.Cells[1, 4] = "Tổng giá";
                    ws.Cells[1, 5] = "Ngày nhập";

                    int i2 = 2;
                    foreach (var item in ListProduct)
                    {

                        ws.Cells[i2, 1] = item.Id;
                        ws.Cells[i2, 2] = item.ProductName;
                        ws.Cells[i2, 3] = item.Quantity;
                        ws.Cells[i2, 4] = item.ImportPrice;
                        ws.Cells[i2, 5] = item.CreatedAt;

                        i2++;
                    }
                    ws.SaveAs(sfd.FileName);
                    wb.Close();
                    app.Quit();

                    Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;

                    MyMessageBox mb = new MyMessageBox("Xuất file thành công");
                    mb.ShowDialog();


                }
            }
        }
    
*/







private void OpenConnect()
            {
                if (sqlCon == null)
                {
                    sqlCon = new SqlConnection(strCon);
                }

                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }
            }

            private void CloseConnect()
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
            private void ListViewDisplay(string strQuery)
            {
                OpenConnect();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strQuery;
                cmd.Connection = sqlCon;
                SqlDataReader reader = cmd.ExecuteReader();
                ListProduct.Clear();
                while (reader.Read())
                {
                    string ten = reader.GetString(0);
                    int tondu = reader.GetInt16(1);
                    string donvi = reader.GetString(2);
                    string dongia = reader.GetSqlMoney(3).ToString();

                    ListProduct.Add(new LichSuBanModel(ten, tondu, donvi, dongia));
                }

                CloseConnect();
            }
            public async Task CheckMonthFilter()
            {
           /* try
            {
                ListBill = new ObservableCollection<HoaDon>(await BillService.Ins.GetBillByMonth(SelectedMonth + 1));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                MyMessageBox mb = new MyMessageBox("Lỗi");
                mb.ShowDialog();
            }*/

        }




    }
}

