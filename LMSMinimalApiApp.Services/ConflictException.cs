using System;
using System.Collections.Generic;
using System.Text;

namespace LMSMinimalApiApp.Services
{
    public sealed class ConflictException(string message) : Exception(message);
}
