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
            endpoints.MapGet("{ID:int}", GetBook);

            return endpoints;
        }

        private static Ok<IEnumerable<BooksDTO>> GetBooks(BookServices bookServices)
        {
            IEnumerable<BooksDTO> books = bookServices.GetBooksList();

            return TypedResults.Ok(books);
        }

        private static IResult GetBook(BookServices bookServices, int ID)
        {
            BooksDTO? book = bookServices.GetBookById(ID);

            return book == null ? TypedResults.NotFound() : TypedResults.Ok(book);
        }
    }
}
