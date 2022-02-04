using online_store.Core.DTOs;
using online_store.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_store.Core.Interfaces
{
    public interface ICostumerRepository : IRepository<Costumer,int>
    {
        List<CostumerDTO> GetBestCoatumers();
        List<SearchCostumerDTO> GetCostumersByProduct(string product);
    }
}
