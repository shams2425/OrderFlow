using InventoryService.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace InventoryService.Infrastructure.Data;

public class InventoryDbContext :DbContext
{
    public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
    {
        
    }

    public DbSet<Stock> Stocks { get; set; }
}
