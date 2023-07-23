namespace Film.Core.Entities
{
    public abstract class EntityBase<TId> : IEntityBase<TId>
    {
        public virtual TId Id { get; protected set; }
    }
}
