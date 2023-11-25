﻿using BLL.Contracts;
using DAL;
using Entities;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class OrderService : BaseService<Order>, IOrderService
    {
        private readonly IOrderRepository repository;

        public OrderService(IOrderRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public override void Create(Order entity)
        {
            base.Create(entity);
        }

        public List<RevenuePerMonth> GetRevenuePerMonths(int year)
        {
            List<Order> purchases = base.GetAll().Where(x => x.Date.Year == year).ToList();
            if (purchases != null && purchases.Count > 0)
            {
                List<RevenuePerMonth> revenuePerMonth = purchases.GroupBy(x => x.Date.Month).Select(cl => new RevenuePerMonth() { Revenue = cl.Sum(w => w.TotalPrice), Month = cl.Key }).ToList();
                return revenuePerMonth;
            }

            return new List<RevenuePerMonth>() { };
        }

        public List<PurchasePerMonth> GetPurchasesPerMonths(int year)
        {
            List<Order> purchases = base.GetAll().Where(x => x.Date.Year == year).ToList();

            if (purchases != null && purchases.Count > 0)
            {
                List<PurchasePerMonth> revenuePerMonth = purchases.GroupBy(x => x.Date.Month).Select(cl => new PurchasePerMonth() { Purchases = cl.Count(), Month = cl.Key }).ToList();
                return revenuePerMonth;
            }

            return new List<PurchasePerMonth>() { };
        }
    }
}