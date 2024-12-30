
using NichoShop.Domain.Enums;

namespace NichoShop.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public ErrorCode Code { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
