namespace BigonApp.Models.Entities.Common;

public abstract class AuditableEntity
{
    public int CreatedBy { get; set; }
    public int? ModifiedBy { get; set; }
    public int? DeletedBy { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
