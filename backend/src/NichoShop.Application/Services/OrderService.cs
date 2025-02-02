﻿using NichoShop.Application.Interfaces;
using NichoShop.Application.Models.Dtos.Request.ShoppingCart;
using NichoShop.Common.Interface;
using NichoShop.Domain.AggergateModels.OrderAggregate;
using NichoShop.Domain.AggergateModels.UserAggregate;
using NichoShop.Domain.Enums;
using NichoShop.Domain.Exceptions;
using NichoShop.Domain.Repositories;

namespace NichoShop.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserAddressService _userAddressService;
        private readonly IUserContext _userContext;
        private readonly ISkuService _skuService;
        private readonly IShoppingCartService _shoppingCartService;

        public OrderService(IUserContext userContext, IOrderRepository orderRepository, ISkuService skuSerive, IShoppingCartService shoppingCartService, IUserAddressService userAddressService)
        {
            _userContext = userContext;
            _orderRepository = orderRepository;
            _skuService = skuSerive;
            _shoppingCartService = shoppingCartService;
            _userAddressService = userAddressService;
        }
        public async Task<Guid> CreateOrder(CreateOrderRequestDto param)
        {
            UserAddress userAddress = await _userAddressService.GetByIdAsync(param.UserAddressID);
            ShippingAddressProps shippingAddressProps = new ShippingAddressProps
            {
                FullName = userAddress.FullName,
                PhoneNumber = userAddress.PhoneNumber.Value,
                OtherDetails = "",
                Street = userAddress.Street,
                Ward = userAddress.Ward,
                District = userAddress.District,
                Province = userAddress.Province,
                Country = userAddress.Country
            };

            var cart = await _shoppingCartService.GetShoppingCartByUserIdAsync();
            var products = cart.Items.FindAll(x => x.IsSelected);

            var filtersWithComparison = new Dictionary<string, (object Value, SqlOperator Comparison)>
            {
                { "Id", (products.Select(x=>x.SkuId), SqlOperator.In) },
            };

            var skus = _skuService.GetByFitlers(filtersWithComparison) ?? throw new NotFoundException("i18nOrder.messages.notFoundSku");

            bool isOutOfStock = skus.Any(x =>
            {
                return products.Any(product => product.SkuId == x.Id && product.Quantity > x.Quantity);
            });

            if (isOutOfStock)
            {
                throw new DomainException
                {
                    MessageCode = "i18nOrder.messages.outOfStock"
                };
            }
            List<OrderItemProps> orderItemProps = products.Select(product =>
            {
                return new OrderItemProps
                {
                    SkuId = product.SkuId,
                    ProductName = product.ProductName,
                    VariantName = product.ProductVariantName,
                    Thumbnail = "https://down-vn.img.susercontent.com/file/vn-11134207-7ras8-m4k9lc59h3v355@resize_w80_nl.webp",
                    Quantity = product.Quantity,
                    Amount = (double)product.Amount,
                    Currency = Currency.VND,
                };
            }).ToList();

            //Transaction
            var order = new Order(
                _userContext.UserId,
                0,
                0,
                DateTimeOffset.UtcNow,
                shippingAddressProps,
                param.PaymentMethod,
                orderItemProps
                );
            _orderRepository.Add(order);

            //Giảm số lượng trong kho tương ứng với số lượng trong đơn hàng
            await _skuService.UpdateSkus(skus.Select(sku =>
            {
                var product = products.Find(product => product.SkuId == sku.Id) ?? throw new NotFoundException("i18nOrder.messages.notFoundSku");
                sku.UpdateQuantity(sku.Quantity - product.Quantity);
                return sku;
            }).ToList());

            // Xóa trong cart
            List<Guid> cartItemIds = products.Select(x => x.Id).ToList();
            await _shoppingCartService.DeleteCartItems(cartItemIds);

            int res = await _orderRepository.SaveChangesAsync();
            return res > 0 ? order.Id : Guid.Empty;
        }
    }
}
