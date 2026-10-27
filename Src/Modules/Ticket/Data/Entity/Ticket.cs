using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ticket.Data.Entity
{
    public class Ticket : BaseEntity
    {
        public Guid UserId { get; set; }
        [MaxLength(100)]
        public string Author { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        public string Content { get; set; }
        public TicketStatus Status { get; set; }
        public TicketDepartment Department { get; set; }
        public List<TicketMessage> Messages { get; set; }
    }

    public enum TicketStatus { Open = 1, Closed = 2, InProgress = 3 }

    public enum TicketDepartment
    {
        TechnicalSupport = 1, Finance = 2, Education = 3, UserAccount = 4, SalesConsulting = 5, Management = 6
    }

    public class TicketMessage : BaseEntity 
    {
        public Guid UserId { get; set; }
        public Guid TicketId { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
    }
}