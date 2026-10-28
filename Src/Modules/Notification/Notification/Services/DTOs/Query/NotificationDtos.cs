using Notification.Enums;
using System;

namespace Notification.Services.DTOs.Query
{

    public class NotificationDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsSeen { get; set; }
        public DateTime CreationDate { get; set; }
        public NotificationType Type { get; set; }
    }
}