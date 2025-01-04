using NichoShop.Domain.Enums;
using NichoShop.Domain.Exceptions;
using NichoShop.Domain.SeedWork;

namespace NichoShop.Domain.Shared;
public class Money : ValueObject
{
    public double Amount { get; private set; }

    public Currency Currency { get; private set; }

    public Money(double amount, Currency currency)
    {
        Amount = amount;
        Currency = currency;
        if (IsInvalid())
        {
            throw new DomainException
            {
                Message = "Invalid money",
                FieldError = "Amount"
            };
        }
    }

    private bool IsInvalid()
    {
        return Amount <= 0;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}
