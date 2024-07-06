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
        public static OrderDto ToOrderDto(this Order orderModel)
        {
            return new OrderDto
            {
                Id = orderModel.Id,
                CreatedOn = orderModel.CreatedOn
            };
        }

        public static Order ToOrderFromCreateDto(this CreateOrderRequestDto orderDto)
        {
            return new Order
            {
                CreatedOn = orderDto.CreatedOn
            };
        }
    }
}