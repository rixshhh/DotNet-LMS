using Azure.Core;
using LMSMinimalApiApp.Core.DTOs;
using LMSMinimalApiApp.Core.Requests;
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
            endpoints.MapPut("Books/{Id:int}", Update);
            endpoints.MapDelete("Books/{Id:int}", Delete);

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

        private static IResult Update(BookServices bookServices, PostBookRequests requests,int Id)
        {
            var result = bookServices.UpdateBook(Id,requests);

            return result is null
                ? TypedResults.Problem("There was some problem. See log for more details.")
                : TypedResults.Ok(result);
        }

        private static IResult Delete(BookServices bookServices,int Id)
        {
            var result = bookServices.DeleteBook(Id);

            return result is null
                ? TypedResults.Problem("There was some problem. See log for more details.")
                : TypedResults.Ok(result);
        }
    }
}
