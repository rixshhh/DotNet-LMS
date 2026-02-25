using System;
using System.Collections.Generic;
using System.Text;

namespace LMSMinimalApiApp.Persistence
{
    public sealed class Users
    {
        public int ID { get; init; }
        public string Name { get; init; }
        public int UserTypeID { get; init; }

        public IList<BookIssued> BookIssueds { get; init; }
    }
}
