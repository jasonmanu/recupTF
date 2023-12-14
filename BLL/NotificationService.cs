using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface INotificationService : IBaseService<Notification>
    {
    }

    public class NotificationService : BaseService<Notification>, INotificationService
    {
        public NotificationService(INotificationRepository notificationRepository) : base(notificationRepository)
        {
        }
    }
}
