using Common.Domain.Repository;
using Notifications.Domain;

namespace Notifications.Services
{
    public interface INotificationRepository : IBaseRepository<Domain.Notification>
    {
    }
}