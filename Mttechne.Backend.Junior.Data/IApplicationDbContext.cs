using Microsoft.EntityFrameworkCore;
using Mttechne.Backend.Junior.Data.Model;

public interface IApplicationDbContext
{
    DbSet<Produto> Produtos { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}