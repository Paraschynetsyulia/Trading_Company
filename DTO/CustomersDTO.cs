using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CustomersDTO
    {
        public int CustomerID  { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int OrderID { get; set; }
        public int Discount { get; set; }
        public string OrderName { get; set; }
        public DateTime RowInsertTime { get; set; }
        public DateTime RowUpdateTime { get; set; }
    }
}
