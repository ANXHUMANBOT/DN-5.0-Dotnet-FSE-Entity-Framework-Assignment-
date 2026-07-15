using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace RetailInventory
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public int StockQuantity { get; set; }
        public ProductDetail? ProductDetail { get; set; }
        public List<Tag> Tags { get; set; } = new List<Tag>();

        [Timestamp]
        public byte[]? RowVersion { get; set; }
    }
}