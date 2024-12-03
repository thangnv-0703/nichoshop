namespace NichoShop.Infrastructure.CommonService;
public interface IUserContext
{
    bool IsAuthenticated { get; }
    Guid UserId { get; }
    string PhoneNumber { get; }
}
