using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Contracts
{
    public interface IPurchaseService : IBaseService<Purchase>
    {
        List<RevenuePerMonth> GetRevenuePerMonths(int year);
        List<PurchasePerMonth> GetPurchasesPerMonths(int year);
    }
}
