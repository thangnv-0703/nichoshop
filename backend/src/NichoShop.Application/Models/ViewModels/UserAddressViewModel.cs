namespace NichoShop.Application.Models.ViewModels
{
    public class UserAddressViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Ward { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Province { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public bool IsDefault { get; set; } = false;
    }
}
