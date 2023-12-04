using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mttechne.Backend.Junior.Data.Model;


namespace Mttechne.Backend.Junior.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Produto>(p => 
            {
                p.HasKey(p => p.ProdutoId);
                p.Property(p => p.Nome).HasMaxLength(15);
                p.Property(p => p.Valor);
            });

            Seed(modelBuilder);

        }

        private void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().HasData(
                new Produto { ProdutoId = 1, Nome = "Placa de Vídeo", Valor = 1000 },
                new Produto { ProdutoId = 2, Nome = "Placa de Vídeo", Valor = 1500 },
                new Produto { ProdutoId = 3, Nome = "Placa de Vídeo", Valor = 1350 },
                new Produto { ProdutoId = 4, Nome = "Processador", Valor = 2000 },
                new Produto { ProdutoId = 5, Nome = "Processador", Valor = 2100 },
                new Produto { ProdutoId = 6, Nome = "Memória", Valor = 300 },
                new Produto { ProdutoId = 7, Nome = "Memória", Valor = 350 },
                new Produto { ProdutoId = 8, Nome = "Placa mãe", Valor = 1100 }
            );
        }
    }
}