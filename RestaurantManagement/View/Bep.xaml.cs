using System;
using System.Collections.Generic;
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
using static QuanLyNhaHang.View.Bep;
namespace RestaurantManagement.View.Bep
{
    /// <summary>
    /// Interaction logic for Bep.xaml
    /// </summary>
    public partial class Bep : UserControl
    {
        public Bep()
        {

           
            List<User> items = new List<User>();
           
            items.Add(new User() { STT = 1, Table = 1, Name = "Lòng xào", TT = "Xong" });
            items.Add(new User() { STT = 2, Table = 2, Name = "Gà chiên", TT = "Chưa xong" });
           
        }
        public class User
        {
            public int STT { get; set; }

            public int Table { get; set; }

            public string? Name { get; set; }

            public string TT { get; set; }


        }
    }
}
