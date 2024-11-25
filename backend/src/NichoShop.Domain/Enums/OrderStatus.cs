﻿namespace NichoShop.Domain.Enums;
public enum OrderStatus
{
    PendingApproval,
    Approved,
    AwaitingShipment,
    Shipping,
    Shipped,
    Canceled
}
