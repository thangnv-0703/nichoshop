using NichoShop.Domain.SeedWork;
using System.Text.RegularExpressions;

namespace NichoShop.Domain.Shared;
public partial class PhoneNumber : ValueObject
{
    public string Value { get; private set; }
    public Regex regex = PhoneNumberRegex();

    private PhoneNumber() { }

    public PhoneNumber(string value)
    {
        Value = value;
        ValidateValueObject();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    protected void ValidateValueObject()
    {
        if (!regex.IsMatch(Value)) throw new Exception("Invalid phone number");
    }

    [GeneratedRegex(@"[\d]")]
    private static partial Regex PhoneNumberRegex();
}
