using Microsoft.EntityFrameworkCore;

namespace Mttechne.Backend.Junior.Data.Model;

public class Produto
{
    public int ProdutoId { get; set; }
    public string Nome { get; set; } = null!;
    public int Valor { get; set; }

    public static implicit operator DbSet<object>(Produto v)
    {
        throw new NotImplementedException();
    }
}