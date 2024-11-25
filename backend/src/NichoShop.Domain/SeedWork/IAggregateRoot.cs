using MediatR;

namespace NichoShop.Domain.Seedwork;

public interface IAggregateRoot 
{
    void AddDomainEvent(INotification eventItem);

    void RemoveDomainEvent(INotification eventItem);

    void ClearDomainEvents();
}
