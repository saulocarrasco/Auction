﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Dtos.Request
{
    public class CreateBitRequestDto
    {
        public int ProductId { get; set; }
        public bool Active { get; set; }
    }
}
