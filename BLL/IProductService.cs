using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Contracts
{
    public interface IProductService : IBaseService<Product>
    {
        List<ProductDto> GetExtendedProducts();
    }
}
