using System;

namespace Ticket.Core.DTOs.Tickets
{
    public class TicketMessageDto 
    {
        public Guid UserId { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime CreationTime { get; set; }
    }
}