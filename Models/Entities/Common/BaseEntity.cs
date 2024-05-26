namespace BigonApp.Models.Entities.Common
{
    public abstract class BaseEntity<TKey> : AuditableEntity
        where TKey : struct
    {
        public TKey Id { get; set; }
    }
}
