using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<ProductDto>? Products { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}