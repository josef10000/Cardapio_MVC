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
        public DbSet<Prato_Model> Pratos { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }
    }
}

