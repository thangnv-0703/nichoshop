using Newtonsoft.Json;

namespace NichoShop.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public string FieldError { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(new
            {
                FieldError,
                Message,
            });
        }
    }
}
