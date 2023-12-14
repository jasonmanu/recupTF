using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SubscriptionService : BaseService<Subscription>, ISubscriptionService
    {
        public SubscriptionService(ISubscriptionRepository subscriptionRepository) : base(subscriptionRepository)
        {
        }
    }
}
