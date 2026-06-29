using System;

namespace DataStructuresAssignment
{
    public class Product : IComparable<Product>
    {
        public string ProductId { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;

        public int CompareTo(Product? other)
        {
            if (other == null) return 1;
            return string.Compare(this.ProductId, other.ProductId, StringComparison.Ordinal);
        }
    }

    public class SearchProgram
    {
        // 1. Linear Search Implementation
        public static Product? LinearSearch(Product[] products, string targetId)
        {
            foreach (var product in products)
            {
                if (product.ProductId == targetId)
                    return product;
            }
            return null;
        }

        // 2. Binary Search Implementation (Requires sorted array)
        public static Product? BinarySearch(Product[] products, string targetId)
        {
            int left = 0;
            int right = products.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int comparison = string.Compare(products[mid].ProductId, targetId, StringComparison.Ordinal);

                if (comparison == 0)
                    return products[mid];
                if (comparison < 0)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return null;
        }

        public static void Main(string[] args)
        {
            // Setup sample data (sorted by ProductId for Binary Search compatibility)
            Product[] products = new Product[]
            {
                new Product { ProductId = "P101", ProductName = "Laptop", Category = "Electronics" },
                new Product { ProductId = "P105", ProductName = "Smartphone", Category = "Electronics" },
                new Product { ProductId = "P120", ProductName = "Desk Chair", Category = "Furniture" },
                new Product { ProductId = "P202", ProductName = "Running Shoes", Category = "Apparel" }
            };

            string searchId = "P120";
            Console.WriteLine($"--- Executing E-commerce Search Optimization for ID: {searchId} ---");

            // Test Linear Search
            var resultLinear = LinearSearch(products, searchId);
            Console.WriteLine(resultLinear != null 
                ? $"[Linear Search] Found: {resultLinear.ProductName} in {resultLinear.Category}" 
                : "[Linear Search] Product not found.");

            // Test Binary Search
            var resultBinary = BinarySearch(products, searchId);
            Console.WriteLine(resultBinary != null 
                ? $"[Binary Search] Found: {resultBinary.ProductName} in {resultBinary.Category}" 
                : "[Binary Search] Product not found.");
        }
    }
}