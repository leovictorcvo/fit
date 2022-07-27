using System;

namespace Backend.Dto
{
    public class CartItemToAddDto
    {
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
