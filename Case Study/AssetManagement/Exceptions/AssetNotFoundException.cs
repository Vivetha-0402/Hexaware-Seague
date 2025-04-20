using System;

namespace Exceptions
{
    // Custom exception to indicate that a specific asset was not found
    public class AssetNotFoundException : Exception
    {
        // Default constructor
        public AssetNotFoundException() { }

        // Constructor that takes a custom message
        public AssetNotFoundException(string message) : base(message) { }

        // Constructor that takes a custom message and an inner exception for detailed error tracing
        public AssetNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
