using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Auction.Domain.Core.Helpers
{
    public class JsonHelper
    {
        private static JsonSerializerOptions _jsonSerializerOptions;
        public static JsonSerializerOptions GetSerializerOptions()
        {
            if (_jsonSerializerOptions != null)
            {
                _jsonSerializerOptions = new JsonSerializerOptions
                {
                    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.Always,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
            }
            return _jsonSerializerOptions;
        }
    }
}
