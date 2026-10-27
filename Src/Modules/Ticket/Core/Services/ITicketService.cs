using AutoMapper;
using Common.Application;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticket.Core.DTOs.Tickets;
using Ticket.Data;
using Ticket.Data.Entity;

namespace Ticket.Core.Services
{
    public interface ITicketService 
    {
        Task<OperationResult<Guid>> CreateTicket(CreateTicketCommand command);
        Task<OperationResult> SendTicket(SendTicketMessageCommand command);
        Task<OperationResult> CloseTicket(Guid ticketId);
        Task<TicketDto> GetTickets(Guid ticketId);
    }

    public class TicketService : ITicketService
    {
        private readonly TicketContext _context;
        private readonly IMapper _mapper;

        public TicketService(TicketContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OperationResult<Guid>> CreateTicket(CreateTicketCommand command)
        {
            var ticket = _mapper.Map<Ticket.Data.Entity.Ticket>(command);
            ticket.Id = Guid.NewGuid();
            ticket.CreationDate = DateTime.Now;
            ticket.Status = TicketStatus.Open;
            ticket.Department = TicketDepartment.TechnicalSupport;

            await _context.Tickets.AddAsync(ticket);
            await _context.SaveChangesAsync();

            return OperationResult<Guid>.Success(ticket.Id);
        }

        public async Task<OperationResult> SendTicket(SendTicketMessageCommand command)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == command.TicketId);
            if (ticket == null)
                return OperationResult.Error("تیکت یافت نشد.");

            if (ticket.Status == TicketStatus.Closed)
                return OperationResult.Error("این تیکت بسته شده است و امکان ارسال پیام وجود ندارد.");

            var message = new TicketMessage
            {
                Id = Guid.NewGuid(),
                TicketId = command.TicketId,
                UserId = command.UserId,
                Author = command.Author,
                Content = command.Content,
                CreationDate = DateTime.Now
            };

            await _context.TicketMessages.AddAsync(message);

            ticket.Status = TicketStatus.InProgress;
            _context.Tickets.Update(ticket);

            await _context.SaveChangesAsync();

            return OperationResult.Success();
        }

        public async Task<OperationResult> CloseTicket(Guid ticketId)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == ticketId);
            if (ticket == null)
                return OperationResult.Error("تیکت یافت نشد.");

            ticket.Status = TicketStatus.Closed;
            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync();

            return OperationResult.Success();
        }

        public async Task<TicketDto> GetTickets(Guid ticketId)
        {
            var ticket = await _context.Tickets
                .AsNoTracking()
                .Include(t => t.Messages)
                .FirstOrDefaultAsync(t => t.Id == ticketId);

            if (ticket == null) return null;

            ticket.Messages = ticket.Messages?.OrderBy(m => m.CreationDate).ToList();

            return _mapper.Map<TicketDto>(ticket);
        }
    }
}