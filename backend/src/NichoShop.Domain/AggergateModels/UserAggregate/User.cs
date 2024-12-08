using NichoShop.Domain.Enums;
using NichoShop.Domain.SeedWork;
using NichoShop.Domain.Shared;

namespace NichoShop.Domain.AggergateModels.UserAggregate;
public class User : AggregateRoot<Guid>
{
    public string? FullName { get; private set; }

    public string UserName { get; private set; }

    public string? Email { get; private set; }

    public PhoneNumber PhoneNumber { get; private set; }

    public string PasswordHashed { get; private set; }

    public Gender? Gender { get; private set; }

    private readonly List<UserAddress> _addresses = [];
    public IReadOnlyCollection<UserAddress> Addresses => _addresses.AsReadOnly();

    private User() { }

    public User( 
        string phoneNumber, 
        string password, 
        string userName, 
        string? fullName, 
        string? email, 
        Gender? gender = null)
    {
        PhoneNumber = new PhoneNumber(phoneNumber);
        PasswordHashed = password;
        UserName = userName;
        FullName = fullName;
        Email = email;
        Gender = gender;
    }

    public List<UserAddress> GetUserAddresses()
    {
        return _addresses;
    }

    public void AddAddress(UserAddressProps props)
    {
        var address = new UserAddress(props);
        _addresses.Add(address);
    }

    public void RemoveAddress(Guid userAddressId)
    {
        var deletedAddressIndex = _addresses.FindIndex(x => x.Id == userAddressId);
        if (deletedAddressIndex == -1) throw new Exception("Address not found");
        _addresses.RemoveAt(deletedAddressIndex);
    }

    public void UpdateAddress(Guid userAddressId, UserAddressProps props)
    {
        var address = _addresses.Find(x => x.Id == userAddressId) ?? throw new Exception("Address not found");
        address.UpdateAddress(props);
    }

    public void UpdateUserInfo(string? fullName, string? email, string? phoneNumber, Gender? gender)
    {
        if(!string.IsNullOrWhiteSpace(fullName)) FullName = fullName;
        if(!string.IsNullOrWhiteSpace(email)) Email = email;
        if(!string.IsNullOrWhiteSpace(phoneNumber) && PhoneNumber.Value != phoneNumber) PhoneNumber = new PhoneNumber(phoneNumber);
        if(gender is not null) Gender = (Gender)gender;
    }

    public void SetDefaultAddress(Guid userAddressId)
    {
        var address = _addresses.Find(x => x.Id == userAddressId) ?? throw new Exception("Address not found");
        _addresses.ForEach(x => x.SetDefault(false));
        address.SetDefault(true);
    }

    public UserAddress? GetUserAddressById(Guid userAddressId)
    {
        var userAddress = _addresses.Find(x => x.Id == userAddressId);
        return userAddress;
    }
}
