using System;
using System.Collections.Generic;
using System.Text;

namespace LMSMinimalApiApp.Core.Requests
{
    public sealed class PostBookRequests
    {
        public required string BookName { get; init; }
        public required string Author { get; init; }
        public required string Publisher { get; init; }
        public decimal Price { get; init; }
        public int CategoryID { get; init; } // Foreign Key
    }
}
