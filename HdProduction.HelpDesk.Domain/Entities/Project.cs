namespace HdProduction.HelpDesk.Domain.Entities
{
    public class Project : EntityBase<long>
    {
        public long DashboardId { get; set; }
        public string Name { get; set; }
    }
}