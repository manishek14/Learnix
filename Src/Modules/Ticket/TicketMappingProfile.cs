using AutoMapper;
using Ticket.Core.DTOs.Tickets;
using Ticket.Data.Entity;

namespace Ticket.Core.Services
{
    public class TicketMappingProfile : Profile
    {
        public TicketMappingProfile()
        {
            CreateMap<CreateTicketCommand, Ticket.Data.Entity.Ticket>();
            CreateMap<TicketMessage, TicketMessageDto>();
            CreateMap<Ticket.Data.Entity.Ticket, TicketDto>();
        }
    }
}