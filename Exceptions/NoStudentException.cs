using System;
namespace assign2.Exceptions
{
    public class NoStudentException : Exception
    {
        public NoStudentException(string message) : base(message)
        {
        }
    }
}