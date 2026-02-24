namespace LMSMinimalApiApp.Core.DTOs
{
    public sealed class BooksDTO(
        int ID,
        string BookName,
        string Author,
        string Publisher,
        decimal Price,
        int CategoryID
    )
    {
        public int ID { get; } = ID;
        public string BookName { get;} = BookName;
        public string Author { get;} = Author;
        public string Publisher { get;} = Publisher;
        public decimal Price { get; } = Price;
        public int CategoryID   { get;} = CategoryID;
    }
}
