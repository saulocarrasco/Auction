using Auction.Domain.Dtos;
using Auction.Domain.Dtos.Request;
using Auction.Domain.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Contracts.Services
{
    public interface IBitService
    {
        Task<CreateBitResponseDto> CreateBitAsync(CreateBitRequestDto request);
    }
}
