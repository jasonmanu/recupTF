using Entities;
using System.Collections.Generic;

namespace BLL.Contracts
{
    public interface IOfferService : IBaseService<Offer>
    {
        List<Offer> GetOffersByProductId(int id);
        float CalculateFinalPriceForProduct(int productId);
    }
}
