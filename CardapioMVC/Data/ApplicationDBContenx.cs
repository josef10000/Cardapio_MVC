using CardapioMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CardapioMVC.Data
{
    public class ApplicationDBContenx : DbContext
    {
        public ApplicationDBContenx(DbContextOptions<ApplicationDBContenx> options)
            : base(options)
        {
        }

        public DbSet<ItemPratoModel> Items { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemPratoModel>().HasKey(i => new { i.ProdutoId, i.PratoId });

       


            // outras configurações de modelo

            base.OnModelCreating(modelBuilder);
        }
    }
}
