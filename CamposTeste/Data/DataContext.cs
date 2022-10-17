using CamposTeste.Entities;
using Microsoft.EntityFrameworkCore;

namespace CamposTeste.Data
{
    public class DataContext : DbContext
    {
        //Contexto para o EntityFramework
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

         
            base.OnModelCreating(modelBuilder);
        }


    }
}
