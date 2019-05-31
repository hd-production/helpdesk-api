namespace HdProduction.HelpDesk.Domain.Entities
{
  public interface IEntity<TKey>
  {
    TKey Key { get; }
  }
}