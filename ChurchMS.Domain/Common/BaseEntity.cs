using System.ComponentModel.DataAnnotations;

namespace ChurchMS.Domain.Common;

public abstract class BaseEntity<IdType>
{
    [Key]
    public IdType Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime ModifiedAt { get; set; } = DateTime.UtcNow;
    public string CreatedBy { get; set; }
    public string ModifiedBy { get; set; }
}