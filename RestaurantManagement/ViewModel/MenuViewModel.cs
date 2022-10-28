using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagement.View;
using System.Windows.Input;
using Menu.Models;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Documents;
using System.Printing;

namespace QuanLyNhaHang.ViewModel
{
    public class MenuViewModel : BaseViewModel
    {
        public MenuViewModel()
        {
            DirectingFoodToOrderListCommand = new RelayCommand<MenuItem>((p) => true, (p) => OrderAnItem(p.ID));
            RemovingFoodFromOrderListCommand = new RelayCommand<MenuItem>((p) => true, (p) => RemoveAnItem(p.ID));
            RemovingAllItemFromOrderList = new RelayCommand<object>((p) => true, (p) =>
            {
                MessageBoxResult result= System.Windows.MessageBox.Show("Bạn có muốn xoá tất cả các món đã đặt?", "Delete request", MessageBoxButton.YesNo, MessageBoxImage.Question);
                switch(result)
                {
                    case MessageBoxResult.Yes:
                        RemoveAllItemOL();
                        break;
                    case MessageBoxResult.No:
                        break; 
                }
            }) ;
            OpeningDetailOrder = new RelayCommand<object>((p) => true, (p) =>
            {
                Order OrderWindow = new Order();               
                OrderWindow.ShowDialog();
            });
            ShowPrintingDialog = new RelayCommand<object>((p) => true, (p) =>
            {            
                PrintPreviewDialog ppd = new PrintPreviewDialog();
                
                ppd.ShowDialog();
            });
            FoodCookingInform = new RelayCommand<object>((p) => true, (p) =>
            {
                System.Windows.MessageBox.Show("Báo chế biến thành công");
            });
            FilterFoodByPriceCommand = new RelayCommand<object>((p) => true, (p) =>
            {
                if (MyComboboxSelectedItem_2 == "DESC Price")
                {
                    MenuItems = new ObservableCollection<MenuItem>(MenuItems.OrderBy(i => i.Price));
                }
                else if (MyComboboxSelectedItem_2 == "A-Z")
                {
                    MenuItems = new ObservableCollection<MenuItem>(MenuItems.OrderBy(i => i.FoodName));
                }
                else
                {
                    MenuItems = new ObservableCollection<MenuItem>(MenuItems.OrderByDescending(i => i.FoodName));
                }
            });

            LoadMenuItems();
            LoadOrderItems();
            LoadComboBoxItems_2();
        }

        #region variable
            private ObservableCollection<MenuItem> selectedItems = new ObservableCollection<MenuItem>();
            private ObservableCollection<MenuItem> menuItems = new ObservableCollection<MenuItem>();
            private ObservableCollection<string> comboboxItems_2 = new ObservableCollection<string>();
            public ObservableCollection<MenuItem> MenuItems
            {
                get { return menuItems; }
                set {
                    if (value != menuItems)
                    {
                        menuItems = value;
                        OnPropertyChanged();
                    }
                }
            }
            public ObservableCollection<MenuItem> SelectedItems 
            {
                get { return selectedItems; }
                set { selectedItems = value;  OnPropertyChanged(); }
            }
            public ObservableCollection<string> ComboboxItems_2 { get; set; }
            private string myComboboxSelectedItem_2 = "A-Z";
            public string MyComboboxSelectedItem_2
        {
                get { return myComboboxSelectedItem_2; }
                set
                {
                    if (value != myComboboxSelectedItem_2)
                    {
                        myComboboxSelectedItem_2 = value;
                        OnPropertyChanged();
                    }
                    
                }
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
            public ICommand RemovingAllItemFromOrderList { get; set; }
            public ICommand FilterFoodByPriceCommand { get; set; }
            public ICommand ShowPrintingDialog { get; set; }
            public ICommand FoodCookingInform { get; set; }
            public ICommand OpeningDetailOrder { get; set; }   


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
            menuItems.Add(new MenuItem { FoodImage = "pack://application:,,,/images/menuitem_6.jpg", ID = 9, FoodName = "Cá Ngừ Đại Dương", Price = 1000000 });
            menuItems.Add(new MenuItem { FoodImage = "pack://application:,,,/images/menuitem_6.jpg", ID = 9, FoodName = "Cá Ngừ Đại Dương", Price = 1000000 });
            menuItems.Add(new MenuItem { FoodImage = "pack://application:,,,/images/menuitem_6.jpg", ID = 9, FoodName = "Cá Ngừ Đại Dương", Price = 1000000 });
            menuItems.Add(new MenuItem { FoodImage = "pack://application:,,,/images/menuitem_6.jpg", ID = 9, FoodName = "Cá Ngừ Đại Dương", Price = 1000000 });

            MenuItems = menuItems;
        }

        public void LoadOrderItems()
        {
            
            SelectedItems = selectedItems;

            SelectedItems.Add(new MenuItem { FoodImage = "pack://application:,,,/images/menuitem_6.jpg", ID = 9, FoodName = "Cá Ngừ Đại Dương", Price = 1000000 });
        }
        public void LoadComboBoxItems_2()
        {
            comboboxItems_2.Add("A-Z");
            comboboxItems_2.Add("Z-A");
            comboboxItems_2.Add("DESC Price");
            ComboboxItems_2 = comboboxItems_2;
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
                    MenuItem x = CheckIfSelectedItemsContain(MenuItems[i]);
                    if (x != null)
                    {
                        //get item through ID then increase the item's quantity by 1 unit.
                        x.Quantity += 1;
                        return;
                    }
                    SelectedItems.Add(MenuItems[i]);
                }
            } 
        }

        public void RemoveAnItem(int ID)
        {
            for(int i = 0; i < SelectedItems.Count; i++)
            {
                if(SelectedItems[i].ID == ID)
                {
                    DecSubtotal -= SelectedItems[i].Price;
                    Subtotal = String.Format("{0:0,0 VND}", DecSubtotal);

                    if(SelectedItems[i].Quantity <= 1)
                    {
                        SelectedItems.RemoveAt(i);
                    }
                    else
                    {
                        SelectedItems[i].Quantity -= 1;
                    }
                }
            }
        }

        public void RemoveAllItemOL()
        {
            SelectedItems.Clear();
            DecSubtotal = 0;
        }

        //OUTER FUNCTION
        public MenuItem CheckIfSelectedItemsContain(MenuItem x)
        {
            for(int i = 0; i < SelectedItems.Count; i++)
            {
                if (x.ID == SelectedItems[i].ID)
                    return SelectedItems[i];
            }
            return null;
        }
    }
}
