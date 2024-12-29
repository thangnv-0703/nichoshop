using NichoShop.Common.Interface;

namespace NichoShop.TestDataLoader.Features.Models;
public class UserContextFake : IUserContext
{
    public bool IsAuthenticated => true;

    public Guid UserId => Guid.NewGuid();

    public string PhoneNumber => "";

    public string Email => "";
}
