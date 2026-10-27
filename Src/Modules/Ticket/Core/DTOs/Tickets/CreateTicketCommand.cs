using System;

namespace Ticket.Core.DTOs.Tickets
{
    public class CreateTicketCommand 
    {
        public Guid UserId { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}