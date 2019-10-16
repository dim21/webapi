namespace WebApi.Models.Base
{
    public interface IEntityBase<TId>
    {
        TId Id { get; }

        void SetNewId();

        void Patch(IEntityBase<TId> other);

        string CheckPost();
    }
}
