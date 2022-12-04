using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using OfficeOpenXml;
using QuanLyNhaHang.ViewModel;
using MaterialDesignThemes.Wpf;

namespace QuanLyNhaHang.View
{
    /// <summary>
    /// Interaction logic for LichSuBan.xaml
    /// </summary>
    public partial class LichSuBan : UserControl
    {
        public string Id { get; private set; }
        public string ProductName { get; private set; }
        
        public LichSuBan()
        {
            InitializeComponent();
            
           
        }
        public class UserInfo
        {
            public string Name { get; set; }
            public DateTime Birthday { get; set; }
        }
  

       /* private void FilterBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(_ListView.ItemsSource).Refresh();
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(_ListView.ItemsSource);
            result.Content = _ListView.Items.Count;
            view.Filter = Filter;
        }
        private bool Filter(object item)
        {
            if (String.IsNullOrEmpty(FilterBox.Text))
                return true;

            switch (cbbFilter.SelectedValue)
            {
                case "Mã đơn":
                    return ((item as LichSuBan).Id.ToString().IndexOf(FilterBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);

                case "Sản phẩm":
                    return ((item as LichSuBan).ProductName.IndexOf(FilterBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
                default:
                    return ((item as LichSuBan).Id.ToString().IndexOf(FilterBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }

        }*/



        private void filtercbb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cbb = sender as ComboBox;

            if (cbbmonth != null)
            {
                switch (cbb.SelectedIndex)
                {
                    case 0:
                        {
                            cbbmonth.Visibility = System.Windows.Visibility.Collapsed;

                            break;
                        }
                    case 1:
                        {
                            cbbmonth.Visibility = System.Windows.Visibility.Visible;
                            break;
                        }
                }
            }
        }
        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cbb = sender as ComboBox;

            if (cbbmonth != null && timepicker != null)
            {
                switch (cbb.SelectedIndex)
                {
                    case 0:
                        {
                            cbbmonth.Visibility = System.Windows.Visibility.Collapsed;
                            timepicker.Visibility = System.Windows.Visibility.Collapsed;
                            break;
                        }
                    case 1:
                        {
                            cbbmonth.Visibility = System.Windows.Visibility.Collapsed;
                            timepicker.Visibility = System.Windows.Visibility.Visible;
                            break;
                        }
                    case 2:
                        {
                            cbbmonth.Visibility = System.Windows.Visibility.Visible;
                            timepicker.Visibility = System.Windows.Visibility.Collapsed;
                            break;
                        }
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }


}
