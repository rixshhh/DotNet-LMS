

using System.ComponentModel.DataAnnotations;

namespace LMSMinimalApiApp.Persistence
{
    public sealed class Books
    {
       [Key] public int Id { get; set; }
       
        public required string BookName { get; set; }

        public required string Author { get; set; }

        public required string Publisher { get; set; }
        public required decimal Price { get; set; }
        public int CategoryID { get; set; }


        public IList<BookIssued> BookIssueds { get; set; } = [];

    }
}
