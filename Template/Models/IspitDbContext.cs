using Microsoft.EntityFrameworkCore;
using Models;
using Template.Models;

namespace Models
{
    public class IspitDbContext : DbContext
    {
        // DbSet...
        public DbSet<Brend> Brendovi {get;set;}
        public DbSet<Komponenta> Komponente {get;set;}
        public DbSet<Prodavnica> Prodavnice {get;set;}
        public DbSet<Spoj> Spojevi {get;set;}
        public DbSet<Tip> Tipovi {get;set;}
        public IspitDbContext(DbContextOptions options) : base(options)
        { 
            

            
        }
    }
}
