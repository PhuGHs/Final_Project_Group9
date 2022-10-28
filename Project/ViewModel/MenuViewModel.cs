using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Menu.Models;

namespace QuanLyNhaHang.ViewModel
{
    public class MenuViewModel : BaseViewModel
    {
        public MenuViewModel()

        {

            //add event here

            DirectingFoodToOrderListCommand = new RelayCommand<MenuItem>((p) => true, (p) => OrderAnItem(p.ID));
            RemovingFoodFromOrderListCommand = new RelayCommand<MenuItem>((p) => true, (p) => RemoveAnItem(p.ID));
            
            LoadMenuItems();
            LoadOrderItems();
        }

        #region variable
            private ObservableCollection<MenuItem> selectedItems = new ObservableCollection<MenuItem>();
            private ObservableCollection<MenuItem> menuItems = new ObservableCollection<MenuItem>();
            public ObservableCollection<MenuItem> MenuItems
            {
                get { return menuItems; }
                set { menuItems = value; }
            }
            public ObservableCollection<MenuItem> SelectedItems 
            {
                get { return selectedItems; }
                set { selectedItems = value;  OnPropertyChanged(); }
            }
            private decimal dec_subtotal = 0;
            private string str_subtotal = "0 VND";

            public decimal DecSubtotal
            {   
                get
                {
                    return dec_subtotal;
                }
                set
                {
                    dec_subtotal = value; OnPropertyChanged();
                }
            }
        
            public string Subtotal
            {
                get
                {
                    return str_subtotal;
                }
                set
                {
                    str_subtotal = value; OnPropertyChanged();
                }
            }

            public string Day
            {
                get {
                    return DateTime.Today.DayOfWeek.ToString() + ", " + DateTime.Now.ToString("dd/MM/yyyy");
                }
            }
        #endregion
            


        #region commands
            public ICommand DirectingFoodToOrderListCommand { get; set; }
            public ICommand RemovingFoodFromOrderListCommand { get; set; }
            public ICommand FilterFoodCommand { get; set; }

        #endregion
       
        public void LoadMenuItems()
        {
            menuItems.Add(new MenuItem { FoodImage = "pack://application:,,,/images/menuitem_1.png", ID = 1, FoodName = "Phở Bò", Price = 45000 });
            menuItems.Add(new MenuItem { FoodImage = "pack://application:,,,/images/menuitem_2.png", ID = 2, FoodName = "Canh Chua", Price = 20000 });
            menuItems.Add(new MenuItem { FoodImage = "pack://application:,,,/images/menuitem_3.png", ID = 3, FoodName = "Lẩu Hải Sản", Price = 140000 });
            menuItems.Add(new MenuItem { FoodImage = "pack://application:,,,/images/menuitem_4.jpg", ID = 4, FoodName = "Mì tôm", Price = 10000 });
            menuItems.Add(new MenuItem { FoodImage = "pack://application:,,,/images/menuitem_5.jpg", ID = 5, FoodName = "Hàu nướng", Price = 200000 });
            menuItems.Add(new MenuItem { FoodImage = "pack://application:,,,/images/menuitem_6.jpg", ID = 6, FoodName = "Cá Ngừ", Price = 1000000 });
            menuItems.Add(new MenuItem { FoodImage = "pack://application:,,,/images/menuitem_6.jpg", ID = 7, FoodName = "Cá Ngừ Đại Dương", Price = 1000000 });
            menuItems.Add(new MenuItem { FoodImage = "pack://application:,,,/images/menuitem_6.jpg", ID = 8, FoodName = "Cá Ngừ Đại Dương", Price = 1000000 });
            menuItems.Add(new MenuItem { FoodImage = "pack://application:,,,/images/menuitem_6.jpg", ID = 9, FoodName = "Cá Ngừ Đại Dương", Price = 1000000 });

            MenuItems = menuItems;
        }

        public void LoadOrderItems()
        {
            
            SelectedItems = selectedItems;

            //SelectedItems.Add(new MenuItem { FoodImage = "pack://application:,,,/images/menuitem_6.jpg", ID = 9, FoodName = "Cá Ngừ Đại Dương", Price = 1000000 });
        }

        public void OrderAnItem(int ID)
        {
            //We can use for loop to get the item by id or using linq for short
            for(int i = 0; i < MenuItems.Count; i++)
            {
                if (MenuItems[i].ID == ID)
                {
                    DecSubtotal += MenuItems[i].Price;
                    Subtotal = String.Format("{0:0,0 VND}", DecSubtotal);
                    SelectedItems.Add(MenuItems[i]);
                }
            } 
        }

        //public string CalculatingSubtotal()
        //{
        //    decimal total = 0;
        //    for(int i = 0; i < SelectedItems.Count; i++)
        //    {
        //        total += SelectedItems[i].Price;
        //    }
        //    return String.Format("{0:0,0 VND}", total);
        //}

        public void RemoveAnItem(int ID)
        {
            for(int i = 0; i < SelectedItems.Count; i++)
            {
                if(SelectedItems[i].ID == ID)
                {
                    DecSubtotal -= SelectedItems[i].Price;
                    Subtotal = String.Format("{0:0,0 VND}", DecSubtotal);
                    SelectedItems.RemoveAt(i);
                }
            }
        }
    }
}
