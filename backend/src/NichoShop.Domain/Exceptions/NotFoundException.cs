namespace NichoShop.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public string Message { get; set; }
        public object Data { get; set; }

        public NotFoundException(string message)
        {
            Message = message;
        }
    }
}
