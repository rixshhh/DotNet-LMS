using LMSMinimalApiApp.Core.DTOs;
using LMSMinimalApiApp.Persistence;
using Microsoft.Extensions.Logging;

namespace LMSMinimalApiApp.Services
{
    public sealed class BookServices
    {
        private readonly AppDbContext _DbContext;
        private readonly ILogger<BookServices> _logger;

        public BookServices(AppDbContext dbContext, ILogger<BookServices> logger)
        {
            _DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _logger = logger;
        }

        public IEnumerable<BooksDTO> GetBooksList()
        {
            IReadOnlyList<BooksDTO> books = _DbContext.Books
                .Select(b => new BooksDTO(
                    b.Id,
                    b.BookName,
                    b.Author,
                    b.Publisher,
                    b.Price,
                    b.CategoryID
                )).ToList();

            return books;
        }
    }
}
