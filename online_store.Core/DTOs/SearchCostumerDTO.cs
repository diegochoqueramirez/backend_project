using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_store.Core.DTOs
{
    public class SearchCostumerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
    }
}
