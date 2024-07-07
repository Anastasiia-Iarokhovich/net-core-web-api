using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.data;
using api.DTOs.Order;
using api.interfaces;
using api.models;
using Microsoft.EntityFrameworkCore;

namespace api.repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDBContext _context;
        public OrderRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            var orders = await _context.Orders
                .Include(x => x.Products)
                .ToListAsync();

            return orders;
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            var order = await _context.Orders
                .Include(x => x.Products)
                .FirstOrDefaultAsync(o => o.Id == id);

            return order;
        }

        public async Task<Order> CreateAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order?> UpdateAsync(int id, UpdateOrderRequestDto orderDto)
        {
            var existingOrder = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);

            if (existingOrder == null) 
            {
                return null;
            }

            existingOrder.CreatedOn = orderDto.CreatedOn;
            existingOrder.TotalPrice = orderDto.TotalPrice;
            existingOrder.Status = orderDto.Status;

            await _context.SaveChangesAsync();

            return existingOrder;
        }

        public async Task<Order?> DeleteAsync(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
            
            if (order == null) 
            {
                return null;
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}