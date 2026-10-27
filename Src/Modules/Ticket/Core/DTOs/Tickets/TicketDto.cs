using System;
using System.Collections.Generic;

namespace Ticket.Core.DTOs.Tickets
{
    public class TicketDto 
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreationTime { get; set; }
        public List<TicketMessageDto> Messages { get; set; } 
    }
}