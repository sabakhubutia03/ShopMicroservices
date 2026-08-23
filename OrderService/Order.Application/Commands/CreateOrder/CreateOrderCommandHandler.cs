using MediatR;
using Microsoft.Extensions.Configuration;
using Order.Application.DTOs;
using Order.Application.Interface;
using Order.Domain.Exceptions;

namespace Order.Application.Commands.CreateOrder;

public class CreateOrderCommandHandler :IRequestHandler<CreateOrderCommand, OrderResponseDto>
{ 
    private readonly IConfiguration _configuration;
    private readonly IOrderRepository _orderRepository;
    private readonly HttpClient _httpClient;

    public CreateOrderCommandHandler(IConfiguration configuration, IOrderRepository orderRepository, HttpClient httpClient)
    {
        _configuration = configuration;
        _orderRepository = orderRepository;
        _httpClient = httpClient;
    }
    public async Task<OrderResponseDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var userUrl =  _configuration["ServiceUrls:UserService"];
        var productUrl = _configuration["ServiceUrls:ProductService"];

        var userRepo = await _httpClient.GetAsync
            ($"{userUrl}/api/user/{request.UserId}");
        if (!userRepo.IsSuccessStatusCode)
        {
            throw new ApiException(
                "User not found",
                "NotFound",
                404,
                "User not found",
                "User not found"
            );
        }
        var productRepo = await _httpClient.GetAsync($"{productUrl}/api/product/{request.ProductId}");
        if (!productRepo.IsSuccessStatusCode)
        {
            throw new ApiException(
                "Product not found",
                "NotFound",
                404,
                "Product not found",
                "Product not found"
            );
        }

        var order = new Domain.Entities.Order
        {
            UserId = request.UserId,
            ProductId = request.ProductId,
            Quantity = request.Quantity,
            Price = request.Price,
            TotalPrice = request.Price * request.Quantity,
            Date = DateTime.UtcNow
        }; 
        var create =  await _orderRepository.Create(order);

        return new OrderResponseDto
        {
            Id = create.Id,
            Price = create.Price,
            ProductId = create.ProductId,
            Quantity = create.Quantity,
            TotalPrice = create.TotalPrice,
            UserId = create.UserId,
            Date = create.Date
        };
    }
}