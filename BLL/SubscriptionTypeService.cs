using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SubscriptionTypeService : BaseService<SubscriptionType>, ISubscriptionTypeService
    {
        public SubscriptionTypeService(ISubscriptionTypeRepository subscriptionTypeRepository) : base(subscriptionTypeRepository)
        {
        }
    }
}
