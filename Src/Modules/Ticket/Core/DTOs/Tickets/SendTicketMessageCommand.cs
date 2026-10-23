using System;

namespace Ticket.Core.DTOs.Tickets
{
    public class SendTicketMessageCommand
    {
        public Guid TicketId { get; set; } 
        public Guid UserId { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
    }
}