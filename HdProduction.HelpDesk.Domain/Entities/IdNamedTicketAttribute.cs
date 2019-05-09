namespace HdProduction.HelpDesk.Domain.Entities
{
    public abstract class IdNamedTicketAttribute : EntityBase<int>
    {
        protected IdNamedTicketAttribute()
        {
        }

        public string Name { set; get; }
            
        public const int MaxNameLength = 32;
    }
}