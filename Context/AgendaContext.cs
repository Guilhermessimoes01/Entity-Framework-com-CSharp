using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MODULOAPI.Entities;

namespace MODULOAPI.Context
{
    public class AgendaContext : DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> option) : base(option)
        {
            
        }

        public DbSet<Contatos> Contatos { get; set; }
    }
}