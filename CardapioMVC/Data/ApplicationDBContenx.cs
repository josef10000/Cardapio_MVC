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

        public DbSet<ProdutoModel> Produtos { get; set; }


        
        }
    }

