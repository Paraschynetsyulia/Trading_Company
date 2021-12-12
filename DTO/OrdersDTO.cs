using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrdersDTO
    {
        public string OrderName { get; set; }
        public int OrderID { get; set; }
        public int Price { get; set; }
        public DateTime RowInsertTime { get; set; }

    }
}
