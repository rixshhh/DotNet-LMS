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

        public BooksDTO? GetBookById(int ID)
        {
            Books? book = _DbContext.Books
                   .FirstOrDefault(b => b.Id == ID);

            if (book is null) return null;

            BooksDTO dto = new(
                book.Id,
                book.BookName,
                book.Author,
                book.Publisher,
                book.Price,
                book.CategoryID
            );

            return dto;
        }

        public IEnumerable<BooksDTO> GetBookBySearch( string? BookName)
        {
            var query = _DbContext.Books.AsQueryable();

            if (!string.IsNullOrWhiteSpace(BookName))
            {
                query = query.Where(b => b.BookName.Contains(BookName));
            }

            var result = query
                 .Select(b => new BooksDTO
                 (
                     b.Id,
                     b.BookName,
                     b.Author,
                     b.Publisher,
                     b.Price,
                     b.CategoryID
                 )).ToList();

            return result;
        }
    }
}
