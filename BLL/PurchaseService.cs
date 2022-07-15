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
    }
}
