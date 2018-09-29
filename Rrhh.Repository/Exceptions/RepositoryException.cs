using System;

namespace Rrhh.Repository.Exceptions
{
    public class RepositoryException : Exception
    {
        public RepositoryException(string message) : base(message)
        {
        }
    }
}
