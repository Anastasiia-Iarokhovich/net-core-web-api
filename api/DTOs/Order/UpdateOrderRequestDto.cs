using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Order
{
    public class UpdateOrderRequestDto
    {
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public decimal TotalPrice { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}