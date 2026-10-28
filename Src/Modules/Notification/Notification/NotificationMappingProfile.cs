using AutoMapper;
using Notification.Services.DTOs.Command;
using Notification.Services.DTOs.Query;
using Notifications.Domain;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Notifications.Services
{
    public class NotificationMappingProfile : Profile
    {
        public NotificationMappingProfile()
        {
            CreateMap<SendNotificationCommand, Domain.Notification>();
            CreateMap<Domain.Notification, NotificationDto>();
        }
    }
}