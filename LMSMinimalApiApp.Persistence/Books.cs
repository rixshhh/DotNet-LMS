

using System.ComponentModel.DataAnnotations;

namespace LMSMinimalApiApp.Persistence
{
    public sealed class Books
    {
       [Key] public int Id { get; init; }
       
        public required string BookName { get; init; }

        public required string Author { get; init; }

        public required string Publisher { get; init; }
        public required decimal Price { get; init; }
        public int CategoryID { get; init; }
        
    }
}
