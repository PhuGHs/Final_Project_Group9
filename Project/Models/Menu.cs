using QuanLyNhaHang.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Models
{
    public class MenuModel { }

    public class MenuItem : BaseViewModel
    {
        private int id;
        private string foodName;
        private Decimal price;
        private string foodImage;
        public int ID { get { return id; } set { id = value; } }    

        public string FoodName
        {
            get { return foodName; }
            set
            {
                if(foodName != value)
                {
                    foodName = value;
                    OnPropertyChanged("food name");
                }
            }
        }

        public Decimal Price
        {
            get { return price; }
            set 
            {
                if (price != value)
                {
                    price = value;
                    OnPropertyChanged("price");
                }
            }
        }

        public string FoodImage
        {
            get { return foodImage; }
            set
            {
                if (foodImage != value)
                {
                    foodImage = value;
                    OnPropertyChanged("food image");
                }
            }
        }

        public string PriceVNDCurrency
        {
            get { return String.Format("{0:0,0 VND}", Price); }
        }

        
    }
}
