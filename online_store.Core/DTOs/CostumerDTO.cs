using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_store.Core.DTOs
{
    public class CostumerDTO
    {
        public int CostumerId { get; set; }
        public string Name { get; set; }
        public double TotalPrice { get; set; }
    }
}
