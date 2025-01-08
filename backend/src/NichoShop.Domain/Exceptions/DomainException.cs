using Newtonsoft.Json;
using NichoShop.Domain.Enums;

namespace NichoShop.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public List<DomainError> Errors { get; set; }
        public string MessageCode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(new
            {
                Errors,
                MessageCode,
            });
        }
    }
    public class DomainError
    {
        public string Field { get; set; }
        public string MessageCode { get; set; }
        public ErrorCode ErrorCode { get; set; }
    }
}
