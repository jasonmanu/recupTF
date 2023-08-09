using Entities;
using System.Collections.Generic;

namespace BLL.Contracts
{
    public interface IOfferService : IBaseService<Offer>
    {
        List<Offer> GetOffersByProductId(string id);
        float CalculateFinalPriceForProduct(string productId);
    }
}
