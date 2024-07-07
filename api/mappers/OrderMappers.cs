using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using api.DTOs.Order;
using api.models;

namespace api.mappers
{
    public static class OrderMappers
    {
        public static Order ToOrder(this CreateOrderRequestDto orderDto)
        {
            return new Order
            {
                CreatedOn = orderDto.CreatedOn,
                TotalPrice = orderDto.TotalPrice,
                Status = orderDto.Status,
            };
        }

        public static OrderDto ToOrderDto(this Order order)
        {
            return new OrderDto
            {
                CreatedOn = order.CreatedOn,
                TotalPrice = order.TotalPrice,
                Status = order.Status,
            };
        }
    }
}