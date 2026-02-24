using System.ComponentModel.DataAnnotations;

namespace LMSMinimalApiApp.Persistence
{
    public sealed class Categories
    {
        [Key]
        public int ID { get; init; }
        [StringLength(50)] public required string CategoryName { get; init; }
    }
}
