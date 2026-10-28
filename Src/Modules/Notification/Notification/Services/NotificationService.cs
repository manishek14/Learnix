using AutoMapper;
using Common.Application;
using Notification.Services.DTOs.Command;
using Notification.Services.DTOs.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notifications.Services
{
    public interface INotificationService
    {
        Task<OperationResult> Send(SendNotificationCommand command);
        Task<OperationResult> MarkAsSeen(Guid notificationId);
        Task<OperationResult> MarkAllAsSeen(Guid userId);
        Task<List<NotificationDto>> GetUserNotifications(Guid userId);
        Task<int> GetUnseenCount(Guid userId);
    }

    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _repository;
        private readonly IMapper _mapper;

        public NotificationService(INotificationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult> Send(SendNotificationCommand command)
        {
            if (command.UserId == Guid.Empty)
                return OperationResult.Error("شناسه کاربر نامعتبر است.");

            var notification = _mapper.Map<Domain.Notification>(command);
            notification.Id = Guid.NewGuid();
            notification.CreationDate = DateTime.Now;
            notification.IsSeen = false;

            await _repository.AddAsync(notification);
            await _repository.Save();

            return OperationResult.Success();
        }

        public async Task<OperationResult> MarkAsSeen(Guid notificationId)
        {
            var notification = await _repository.GetTracking(notificationId);
            if (notification == null)
                return OperationResult.Error("نوتیفیکیشن یافت نشد.");

            if (!notification.IsSeen)
            {
                notification.IsSeen = true;
                _repository.Update(notification);
                await _repository.Save();
            }
            return OperationResult.Success();
        }

        public async Task<OperationResult> MarkAllAsSeen(Guid userId)
        {
            var unseen = await _repository.GetListAsync(n => n.UserId == userId && !n.IsSeen);
            if (unseen.Any())
            {
                foreach (var item in unseen)
                {
                    item.IsSeen = true;
                    _repository.Update(item);
                }
                await _repository.Save();
            }
            return OperationResult.Success();
        }

        public async Task<List<NotificationDto>> GetUserNotifications(Guid userId)
        {
            var notifications = await _repository.GetListAsync(n => n.UserId == userId);
            var sorted = notifications.OrderByDescending(n => n.CreationDate).ToList();
            return _mapper.Map<List<NotificationDto>>(sorted);
        }

        public async Task<int> GetUnseenCount(Guid userId)
        {
            return await _repository.CountAsync(n => n.UserId == userId && !n.IsSeen);
        }
    }
}