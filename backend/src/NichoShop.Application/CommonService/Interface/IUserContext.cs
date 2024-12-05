namespace NichoShop.Application.CommonService.Interface;
public interface IUserContext
{
    bool IsAuthenticated { get; }
    Guid UserId { get; }
    string PhoneNumber { get; }
}
