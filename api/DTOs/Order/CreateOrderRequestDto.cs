using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Order
{
    public class CreateOrderRequestDto
    {
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}