using NichoShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NichoShop.Domain.Shared
{
    public class FilterItem
    {
        public object Value { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SqlOperator Comparison { get; set; }
    }
}
