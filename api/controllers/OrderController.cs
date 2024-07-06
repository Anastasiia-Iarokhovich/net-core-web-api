using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.data;
using api.DTOs;
using api.DTOs.Order;
using api.mappers;
using api.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public OrdersController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAll()
        {
            var orders = await _context.Orders
                .Include(x => x.Products)
                .ToListAsync();

            var orderDtos = orders.Select(s => s.ToOrderDto()).ToList();

            return Ok(orderDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetById(int id)
        {
            var order = await _context.Orders
                .Include(x => x.Products)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order.ToOrderDto());
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateOrderRequestDto orderDto)
        {
            var orderModel = orderDto.ToOrderFromCreateDto();
            await _context.Orders.AddAsync(orderModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = orderModel.Id }, orderModel.ToOrderDto());
        }

    }
}