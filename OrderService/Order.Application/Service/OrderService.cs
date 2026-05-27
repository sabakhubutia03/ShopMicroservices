using Microsoft.Extensions.Configuration;
using Order.Application.DTOs;
using Order.Application.Interface;
using Order.Domain.Exceptions;

namespace Order.Application.Service;

public class OrderService : IOrderService
{  
    private readonly IOrderRepository _orderRepository;
    private readonly HttpClient _httpClient;
    private readonly IConfiguration  _configuration;

    public OrderService(IOrderRepository orderRepository, HttpClient httpClient, IConfiguration configuration)
    {
        _orderRepository = orderRepository;
        _httpClient = httpClient;
        _configuration = configuration;
    }
    
    public async Task<IEnumerable<OrderResponseDto>> GetAllOrders()
    {
        var getAll = await _orderRepository.GetAll();
        return getAll.Select(o => new OrderResponseDto
        {
            Id = o.Id,
            Price = o.Price,
            ProductId = o.ProductId,
            Quantity = o.Quantity,
            TotalPrice = o.TotalPrice,
            UserId = o.UserId,
            Date = o.Date
        });
    }

    public async Task<OrderResponseDto> GetOrderById(int id)
    {
        var getOrderById = await _orderRepository.GetById(id);
        if (getOrderById == null)
        {
            throw new ApiException(
                "Invalid order id",
                "NotFound",
                404,
                "Order not found",
                "Order not found"
            );
        }

        return new OrderResponseDto
        {
            Id = getOrderById.Id,
            Price = getOrderById.Price,
            ProductId = getOrderById.ProductId,
            Quantity = getOrderById.Quantity,
            TotalPrice = getOrderById.TotalPrice,
            UserId = getOrderById.UserId,
            Date = getOrderById.Date
        };
    }

    public async Task<OrderResponseDto> Create(OrderCreateDto orderCreateDto)
    {
        var userUrl =  _configuration["ServiceUrls:UserService"];
        var productUrl = _configuration["ServiceUrls:ProductService"];

        var userRepo = await _httpClient.GetAsync
            ($"{userUrl}/api/user/{orderCreateDto.UserId}");
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
        var productRepo = await _httpClient.GetAsync($"{productUrl}/api/product/{orderCreateDto.ProductId}");
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
            UserId = orderCreateDto.UserId,
            ProductId = orderCreateDto.ProductId,
            Quantity = orderCreateDto.Quantity,
            Price = orderCreateDto.Price,
            TotalPrice = orderCreateDto.Price * orderCreateDto.Quantity,
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

    public async Task<OrderResponseDto> Update(int id, OrderUpdateDto orderUpdateDto)
    {
        var getOrderById = await _orderRepository.GetById(id);
        if (getOrderById == null)
        {
            throw new ApiException(
                "Invalid order id",
                "NotFound",
                404,
                "Order not found",
                "Order not found"
            );
        }

        if (orderUpdateDto.Price != null)
        {
            getOrderById.Price = orderUpdateDto.Price.Value;
        }

        if (orderUpdateDto.Quantity != null)
        {
            getOrderById.Quantity = orderUpdateDto.Quantity.Value;
        }
        
        getOrderById.TotalPrice = getOrderById.Price * getOrderById.Quantity;
        
        await _orderRepository.Update(getOrderById);

        return new OrderResponseDto
        {
            Id = getOrderById.Id,
            Price = getOrderById.Price,
            ProductId = getOrderById.ProductId,
            Quantity = getOrderById.Quantity,
            TotalPrice = getOrderById.TotalPrice,
            UserId = getOrderById.UserId,
            Date = getOrderById.Date
        };
    }

    public async Task Delete(int id)
    {
        var deleteId = await _orderRepository.GetById(id);
        if (deleteId == null)
        {
            throw new ApiException(
                "Invalid order id",
                "BedRequest",
                400,
                "Order Id not found",
                "Order not found"
            );
        }
        await _orderRepository.Delete(deleteId);
    }
}