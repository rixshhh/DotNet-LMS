using Azure.Core;
using LMSMinimalApiApp.Core.DTOs;
using LMSMinimalApiApp.Core.Requests;
using LMSMinimalApiApp.Persistence;
using Microsoft.EntityFrameworkCore;
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

        public BooksDTO? UpdateBook(int Id, PostBookRequests requests)
        {
            try
            {
                var book = _DbContext.Books.Find(Id);

                if (book is null) return null;

                book.BookName = requests.BookName;
                book.Author = requests.Author;
                book.Publisher = requests.Publisher;
                book.Price = requests.Price;
                book.CategoryID = requests.CategoryID;

                _DbContext.SaveChanges();

                return new BooksDTO(
                    book.Id,
                    book.BookName,
                    book.Author,
                    book.Publisher,
                    book.Price,
                    book.CategoryID
                );
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex,
                    "Error while creating a Book.");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error while Updating a Book with name {@BookName}.", requests);
            }

            return null;
        }

        public BooksDTO? DeleteBook(int Id)
        {
            try
            {
                var book = _DbContext.Books.FirstOrDefault(b => b.Id == Id);

                if (book is null)
                {
                    throw new ConflictException($"Cannot find this Id {Id}");
                }

                _DbContext.Books.Remove(book);

                _DbContext.SaveChanges();

                return new BooksDTO(
                   book.Id,
                   book.BookName,
                   book.Author,
                   book.Publisher,
                   book.Price,
                   book.CategoryID
               );
            }
            catch (ConflictException ex)
            {
                _logger.LogError(ex, "Error while creating a state with BookId {Id}. Some conflicts occured.",
                    Id);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex,
                    "Error while Deleting a Book.");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error while Deleting a Book with name {@BookName}.", Id);
            }

            return null;
        }
    }
}
