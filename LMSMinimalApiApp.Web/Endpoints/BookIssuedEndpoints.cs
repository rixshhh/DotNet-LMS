using LMSMinimalApiApp.Core.DTOs;
using LMSMinimalApiApp.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LMSMinimalApiApp.Web.Endpoints
{
    public static class BookIssuedEndpoints
    {
        public static IEndpointRouteBuilder MapBookIssuedEndpoints(this IEndpointRouteBuilder endpoints)
        {
            ArgumentNullException.ThrowIfNull(endpoints);

            endpoints.MapGet("BookIssued", GetBookIssued);

            return endpoints;
        }

        private static Ok<IEnumerable<BookIssuedDTO>> GetBookIssued(BookIssuedServices bookIssuedServices)
        {
            IEnumerable<BookIssuedDTO> books = bookIssuedServices.GetBookIssued();

            return TypedResults.Ok(books);
        }
    }
}
