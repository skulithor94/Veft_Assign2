using System;
namespace assign2.Exceptions
{
    public class NoCourseException : Exception
    {
        public NoCourseException(string message) : base(message)
        {
        }
    }
}