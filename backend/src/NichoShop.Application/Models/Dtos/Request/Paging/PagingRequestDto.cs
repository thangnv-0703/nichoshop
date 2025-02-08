using NichoShop.Domain.Enums;
using NichoShop.Domain.Shared;

namespace NichoShop.Application.Models.Dtos.Request.Paging
{
    public class PagingRequestDto
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public Dictionary<string, FilterItem> Filters { get; set; }

        // sort, filter
    }
}
