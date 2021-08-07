using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Core.Exceptions
{
    public class DomainGlobalException : Exception
    {

        public DomainGlobalException(string message) : base(message)
        {
            this.StatusCode = HttpStatusCode.BadRequest;
        }

        public DomainGlobalException(string message, HttpStatusCode httpStatusCode) : base(message)
        {
            this.StatusCode = httpStatusCode;
        }

        public HttpStatusCode StatusCode { get; private set; }

    }
}
