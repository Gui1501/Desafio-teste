using Mttechne.Backend.Junior.Data.Model;
using Mttechne.Backend.Junior.Data;
using System.Globalization;
using System.Text;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Mttechne.Backend.Junior.Services.Model.Dtos;
using Mttechne.Backend.Junior.Services.Model;

namespace Mttechne.Backend.Junior.Services.Services;

public class ProdutoService : IProdutoService
{

    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
  
    public ProdutoService(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;  
    }

    public List<Model.Produto> GetListaProdutosMock()
    {
        Model.Produto produto1 = new Model.Produto() { Nome = "Placa de Vídeo", Valor = 1000 };
        Model.Produto produto2 = new Model.Produto() { Nome = "Placa de Vídeo", Valor = 1500 };
        Model.Produto produto3 = new Model.Produto() { Nome = "Placa de Vídeo", Valor = 1350 };
        Model.Produto produto4 = new Model.Produto() { Nome = "Processador", Valor = 2000 };
        Model.Produto produto5 = new Model.Produto() { Nome = "Processador", Valor = 2100 };
        Model.Produto produto6 = new Model.Produto() { Nome = "Memória", Valor = 300 };
        Model.Produto produto7 = new Model.Produto() { Nome = "Memória", Valor = 350 };
        Model.Produto produto8 = new Model.Produto() { Nome = "Placa mãe", Valor = 1100 };

        List<Model.Produto> produtosCadastrados = new List<Model.Produto>()
        {
            produto1, produto2, produto3, produto4, produto5, produto6, produto7, produto8
        };

        return produtosCadastrados;
    }

    public ProdutoService(){ }


    public List<ProdutoDto> GetListaProdutos()
    {
        var ProdutosDto = _mapper.Map<List<ProdutoDto>>(_dbContext.Produtos.ToList());        

        return ProdutosDto;
    }    



    public List<ProdutoDto> GetListaProdutosPorNome(string nome)
    {
        string nomeSemAcentos = RemoverAcentosEToLower(nome);

        var ProdutosDto = _mapper.Map<List<ProdutoDto>>(_dbContext.Produtos.ToList());

        return ProdutosDto
            .Where(x => RemoverAcentosEToLower(x.Nome).Contains(nomeSemAcentos))
            .ToList();
    }

    public string RemoverAcentosEToLower(string texto)
    {
        return new string(
            texto
                .Normalize(NormalizationForm.FormD)
                .Where(ch => CharUnicodeInfo.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                .ToArray()
        ).ToLower();
    }

    public List<ProdutoDto> GetListaProdutosOrdenadosPorValor(bool ordenacaoCrescente)
    {
        if (ordenacaoCrescente)
        {
            return _mapper.Map<List<ProdutoDto>>(_dbContext.Produtos.OrderBy(x => x.Valor).ToList());
        }
        else
        {
            return _mapper.Map<List<ProdutoDto>>(_dbContext.Produtos.OrderByDescending(x => x.Valor).ToList());
        }
    }

    public List<ProdutoDto> GetListaProdutosNaReguaDeValor(decimal valorInicial, decimal valorFinal)
    {
        var listaProdutos = _mapper.Map<List<ProdutoDto>>(GetListaProdutos());

        return listaProdutos
            .Where(x => x.Valor >= valorInicial && x.Valor <= valorFinal)
            .ToList();
    }

    public List<ProdutoDto> GetValoresMaximosPorProduto()
    {
        return _mapper.Map<List<ProdutoDto>>(
            _dbContext.Produtos
            .GroupBy(x => x.Nome)
            .Select(group => group.OrderByDescending(prod => prod.Valor).First())
            .ToList()
        );
    }

    public List<ProdutoDto> GetValoresMinimosPorProduto()
    {
        return _mapper.Map<List<ProdutoDto>>(_dbContext.Produtos
            .GroupBy(x => x.Nome)
            .Select(group => group.OrderBy(prod => prod.Valor).First())
            .ToList()
        );
    }
}