using NichoShop.Domain.Exceptions;
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
        if (!regex.IsMatch(Value)) throw new DomainException { FieldError = "PhoneNumber", Message = "Invalid phone number" };
    }

    [GeneratedRegex(@"^84(?:3[2-9]|5[6|8|9]|7[0|6-9]|8[1-9]|9[0-9])\d{7}$")]
    private static partial Regex PhoneNumberRegex();
}
