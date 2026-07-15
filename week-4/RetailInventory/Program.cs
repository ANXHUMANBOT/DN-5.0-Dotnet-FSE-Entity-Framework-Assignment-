using RetailInventory;
using Microsoft.EntityFrameworkCore;

using var context = new AppDbContext();

var product = await context.Products.FirstAsync();
product.StockQuantity += 5;

try
{
    await context.SaveChangesAsync();
    Console.WriteLine("Update succeeded, no conflict.");
}
catch (DbUpdateConcurrencyException)
{
    Console.WriteLine("Concurrency conflict detected.");
}