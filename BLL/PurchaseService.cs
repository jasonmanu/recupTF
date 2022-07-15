using BLL.Contracts;
using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PurchaseService : BaseService<Purchase>, IPurchaseService
    {
        public PurchaseService(IBaseRepository<Purchase> repository) : base(repository)
        {
        }

        public override void Create(Purchase entity)
        {
            base.Create(entity);
        }

        public List<RevenuePerMonth> GetRevenuePerMonths(int year)
        {
            List<Purchase> purchases = base.GetAll().Where(x => x.Date.Year == year).ToList();
            if (purchases != null && purchases.Count > 0)
            {
                List<RevenuePerMonth> revenuePerMonth = purchases.GroupBy(x => x.Date.Month).Select(cl => new RevenuePerMonth() { Revenue = cl.Sum(w => w.TotalPrice), Month = cl.Key }).ToList();
                return revenuePerMonth;
            }

            return new List<RevenuePerMonth>() { };
        }

        public List<PurchasePerMonth> GetPurchasesPerMonths(int year)
        {
            List<Purchase> purchases = base.GetAll().Where(x => x.Date.Year == year).ToList();

            if (purchases != null && purchases.Count > 0)
            {
                List<PurchasePerMonth> revenuePerMonth = purchases.GroupBy(x => x.Date.Month).Select(cl => new PurchasePerMonth() { Purchases = cl.Count(), Month = cl.Key }).ToList();
                return revenuePerMonth;
            }

            return new List<PurchasePerMonth>() { };
        }
    }
}
