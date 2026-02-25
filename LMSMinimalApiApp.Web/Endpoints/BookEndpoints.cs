using LMSMinimalApiApp.Core.DTOs;
using LMSMinimalApiApp.Persistence;
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
            endpoints.MapGet("Books/{ID:int}", GetBook);
            endpoints.MapGet("Books/Search", Search);

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

        private static IResult Search(BookServices bookServices,string BookName)
        {
            IEnumerable<BooksDTO> books = bookServices.GetBookBySearch(BookName);

            return books == null ? TypedResults.NotFound() : TypedResults.Ok(books);

        }
    }
}
