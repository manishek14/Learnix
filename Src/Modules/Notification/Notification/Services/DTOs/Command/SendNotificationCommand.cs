using Notification.Enums;

namespace Notification.Services.DTOs.Command
{
    public class SendNotificationCommand
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public NotificationType Type { get; set; }
    }
}