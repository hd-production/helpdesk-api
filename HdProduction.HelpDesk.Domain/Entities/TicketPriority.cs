using System.Collections.Generic;

namespace HdProduction.HelpDesk.Domain.Entities
{
    public class TicketPriority : EntityBase<int>
    {
        public TicketPriority(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        
        public ICollection<Ticket> Tickets { get; set; } // ef

        public const int MaxNameLength = 32;
    }
}