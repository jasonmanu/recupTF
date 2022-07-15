using Entities;
using System.Collections.Generic;

namespace BLL.Contracts
{
    public interface IOrderService : IBaseService<Order>
    {
        List<RevenuePerMonth> GetRevenuePerMonths(int year);
        List<PurchasePerMonth> GetPurchasesPerMonths(int year);
    }
}
