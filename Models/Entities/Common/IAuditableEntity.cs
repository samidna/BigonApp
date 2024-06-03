namespace BigonApp.Models.Entities.Common
{
    public interface IAuditableEntity
    {
        int CreatedBy { get; set; }
        int? ModifiedBy { get; set; }
        int? DeletedBy { get; set; }

        DateTime CreatedAt { get; set; }
        DateTime? ModifiedAt { get; set; }
        DateTime? DeletedAt { get; set; }
    }
}
