using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Dtos.Configurations
{
    public class TokenConfiguration
    {
        public string HasherKey { get; set; }
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
        public bool ValidateAudience { get; set; }
        public bool ValidateLifetime { get; set; }
        public bool IncludeErrorDetails { get; set; }
        public int TokenDuration { get; set; }
    }
}
