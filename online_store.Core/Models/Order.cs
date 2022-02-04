using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_store.Core.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CostumerId { get; set; }
        public double TotalPrice { get; set; }
    }
}
