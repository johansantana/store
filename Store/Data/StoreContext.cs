using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Model;

namespace Store.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext (DbContextOptions<StoreContext> options)
            : base(options)
        {
        }

        public DbSet<Store.Model.Item> Item { get; set; } = default!;
        public DbSet<Store.Model.Vendor> Vendor { get; set; } = default!;
    }
}
