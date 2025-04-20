using System;
using Microsoft.Data.SqlClient;

namespace Exceptions
{
    // Custom exception to indicate that an asset cannot be maintained (for any maintenance-related errors)
    public class AssetNotMaintainException : Exception
    {
        // Default constructor
        public AssetNotMaintainException() { }

        // Constructor that takes a custom message
        public AssetNotMaintainException(string message) : base(message) { }

        // Constructor that takes a custom message and an inner exception for detailed error tracing
        public AssetNotMaintainException(string message, Exception inner) : base(message, inner) { }
    }
}
