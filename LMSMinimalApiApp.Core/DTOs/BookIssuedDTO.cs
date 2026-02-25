using System;
using System.Collections.Generic;
using System.Text;

namespace LMSMinimalApiApp.Core.DTOs
{
    public sealed class BookIssuedDTO(
        int ID,
        string BookName,
        string UserName,
        DateOnly IssueDate,
        DateOnly RenewDate,
        DateOnly ReturnDate,
        decimal BookPrice
    )
    {
        public int ID { get; } = ID;
        public string BookName { get; } = BookName;
        public string UserName { get; } = UserName;
        public DateOnly IssueDate { get; } = IssueDate;
        public DateOnly RenewDate { get; } = RenewDate;
        public DateOnly ReturnDate { get; } = ReturnDate;
        public decimal BookPrice { get; } = BookPrice;

    }
}
