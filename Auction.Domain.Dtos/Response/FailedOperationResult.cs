﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Dtos.Response
{
    public class FailedOperationResult
    {
        public string Title { get; set; }
        public int Status { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public string TraceId { get; set; }
        public string Detail { get; set; }
    }
}
