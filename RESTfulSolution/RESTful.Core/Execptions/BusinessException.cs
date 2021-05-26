using System;

namespace RESTful.Core.Execptions
{
    public class BusinessException : Exception
    {
        public BusinessException()
        {}

        public BusinessException(string message) : base(message)
        {
        }

    }
}
