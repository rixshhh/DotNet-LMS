using LMSMinimalApiApp.Core.DTOs;
using LMSMinimalApiApp.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LMSMinimalApiApp.Web.Endpoints
{
    public static class BookEndpoints
    {
        public static IEndpointRouteBuilder MapBookEndpoints(this IEndpointRouteBuilder endpoints)
        {
            ArgumentNullException.ThrowIfNull(endpoints);

            endpoints.MapGet("Books", GetBooks);

            return endpoints;
        }

        private static Ok<IEnumerable<BooksDTO>> GetBooks(BookServices bookServices)
        {
            IEnumerable<BooksDTO> books = bookServices.GetBooksList();

            return TypedResults.Ok(books);
        }
    }
}
