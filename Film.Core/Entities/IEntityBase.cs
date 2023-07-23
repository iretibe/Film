namespace Film.Core.Entities
{
    public interface IEntityBase<TId>
    {
        TId Id { get; }
    }
}
