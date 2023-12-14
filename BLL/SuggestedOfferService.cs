using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class SuggestedOfferService// : BaseService<SuggestedOffer>, ISuggestedOfferService
    {
        //private readonly ISuggestedOfferRepository repository;
        //private readonly IOrderService orderService;

        //public SuggestedOfferService(ISuggestedOfferRepository repository, IOrderService orderService) : base(repository)
        //{
        //    this.repository = repository;
        //    this.orderService = orderService;
        //}

        //public override List<SuggestedOffer> GetAll()
        //{
        //    List<Order> orders = orderService.GetAll();
        //    List<SuggestedOffer> currentOffers = base.GetAll();

        //    int previousMonthOrders = orders.Count(x => x.Date.Month == DateTime.Now.Month - 1);
        //    int currentMonthOrders = orders.Count(x => x.Date.Month == DateTime.Now.Month);

        //    if (DateTime.Now.Day >= 10 && currentMonthOrders < previousMonthOrders / 3)
        //    {
        //        currentOffers.Add(new SuggestedOffer()
        //        {
        //            Name = "Descuento General 10%",
        //            Discount = 10,
        //            Reason = $"Menor cantidad de ventas que mes anterior: actuales: {currentMonthOrders}, anterior: {previousMonthOrders}",
        //            Start = DateTime.Now
        //        });
        //    }

        //    return currentOffers;
        //}
    }
}
