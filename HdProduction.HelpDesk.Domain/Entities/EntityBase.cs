namespace HdProduction.HelpDesk.Domain.Entities
{
  public abstract class EntityBase<T> : IEntity<T> where T : struct
  {
    public T Id { get; protected set; }
    public bool IsNew() => Id.Equals(default(T));
    public T Key => Id;
  }
}