using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using panel.Models;

namespace panel.Data
{
    public class NodeContext : DbContext
    {
        public NodeContext (DbContextOptions<NodeContext> options)
            : base(options)
        {
        }

        public DbSet<panel.Models.Node>? Node { get; set; }
    }
}
