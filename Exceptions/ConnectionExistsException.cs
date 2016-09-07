using System;
namespace assign2.Exceptions
{
    public class ConnectionExistsException : Exception
    {
        public ConnectionExistsException(string message) : base(message)
        {
        }
    }
}