using Common.Domain;
using Notification.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Notifications.Domain
{
    public class Notification : BaseEntity
    {
        public Guid UserId { get; set; }

        [MaxLength(300)]
        public string Title { get; set; }

        [MaxLength(2000)]
        public string Content { get; set; }

        public bool IsSeen { get; set; }

        public NotificationType Type { get; set; }
    }
}