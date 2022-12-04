using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LichSuBan.Models
{
    public class HoaDon
    {
        public HoaDon()
        {
        }

        public string Id { get; set; }

        //Customer
        private string _CustomerId;

        public string CustomerId
        {
            get
            {
                if (_CustomerId is null)
                {
                    return "KH0000";
                }
                return _CustomerId;
            }
            set
            {
                _CustomerId = value;
            }
        }
        private string _CustomerName;
        public string CustomerName
        {
            get
            {
                if (_CustomerName is null)
                {
                    return "Khách vãng lai";
                }
                return _CustomerName;
            }
            set
            {
                _CustomerName = value;
            }
        }
        private string _PhoneNumber;
        public string PhoneNumber
        {
            get
            {
                return _PhoneNumber;
            }
            set
            {
                _PhoneNumber = value;
            }
        }

      

        //Price


        public decimal TotalPrice { get; set; }
        public string TotalPriceStr(decimal money)
        {

            {
                return String.Format(CultureInfo.InvariantCulture,
                               "{0:#,#} ₫", money);
            }
        }
   public List<int> VoucherIdList { get; set; }


        //Use 2 list when show details Bill
     /*   public List<ProductBillInfoDTO> ProductBillInfoes { get; set; }
        public TicketBillInfoDTO TicketInfo { get; set; }*/
}
}

