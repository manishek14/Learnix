using Common.Infrastructure.Repository;
using Notifications.Context;
using Notifications.Domain;

namespace Notifications.Services
{
    public class NotificationRepository : BaseRepository<Domain.Notification, NotificationContext>, INotificationRepository
    {
        public NotificationRepository(NotificationContext context) : base(context)
        {
        }
    }
}