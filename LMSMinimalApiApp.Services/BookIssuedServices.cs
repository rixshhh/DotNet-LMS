using LMSMinimalApiApp.Core.DTOs;
using LMSMinimalApiApp.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LMSMinimalApiApp.Services
{
    public sealed class BookIssuedServices
    {
        private readonly AppDbContext _DbContext;
        private readonly ILogger<BookIssuedServices> _logger;

        public BookIssuedServices(AppDbContext dbContext, ILogger<BookIssuedServices> logger)
        {
            _DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _logger = logger;
        }

        public IEnumerable<BookIssuedDTO> GetBookIssued()
        {
            IReadOnlyList<BookIssuedDTO> issuedBooks = _DbContext.BookIssued
                    .Include(bi => bi.Book)
                    .Include(bi => bi.User)
                    .Select(bi => new BookIssuedDTO
                    (
                        bi.ID,
                        bi.Book.BookName,
                        bi.User.Name,
                        bi.IssueDate,
                        bi.RenewDate,
                        bi.ReturnDate,
                        bi.BookPrice
                    ))
                    .ToList();

            return issuedBooks;
        }
    }
}
