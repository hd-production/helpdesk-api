namespace HdProduction.HelpDesk.Domain.Entities
{
    public abstract class TicketAttribute : EntityBase<int>
    {
        protected TicketAttribute()
        {
        }

        public string Name { set; get; }
        public bool Default { set; get; }
        public long ProjectId { set; get; }

        public const int MaxNameLength = 32;
    }
}