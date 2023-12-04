using Mttechne.Backend.Junior.Services.Model;
using Mttechne.Backend.Junior.Services.Services;
using Xunit.Sdk;
using Moq;
using Mttechne.Backend.Junior.Services.Model.Dtos;
using AutoMapper;

namespace Mttechne.Backend.Junior.UnitTests.Model;

public class ProdutoTest
{
        
    [Fact]
    public void ListarProdutos()
    {
       
        var service = new ProdutoService();

        var result = service.GetListaProdutosMock();

        Assert.Equal(8, result.Count);
    }


    [Fact]
    public void ListarProdutosPorNome()
    {
        var service = new ProdutoService();

        string nomeSemAcentos = service.RemoverAcentosEToLower("MóR");

        var produtosMock = service.GetListaProdutosMock();        

        var result = produtosMock
            .Where(x => service.RemoverAcentosEToLower(x.Nome).Contains(nomeSemAcentos))
            .ToList();

        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void OrdenarPorValor_Crescente()
    {
        var service = new ProdutoService();

        var produtosMock = service.GetListaProdutosMock();

        bool crescente = false;
        var result = new List<Produto>();

        if (crescente == false)
        {
            result =  produtosMock.OrderBy(x => x.Valor).ToList();
        }
        else
        {
            result = produtosMock.OrderByDescending(x => x.Valor).ToList();
        }

        Assert.Equal(300, result.First().Valor);
        Assert.Equal(2100, result.Last().Valor);
    }

    [Fact]
    public void NaFaixaDeValor()
    {
        var service = new ProdutoService();

        var produtosMock = service.GetListaProdutosMock();
        var valorInicial = 500;
        var valorFinal = 1500;

        var result = produtosMock
            .Where(x => x.Valor >= valorInicial && x.Valor <= valorFinal)
            .ToList();       

        Assert.Equal(4, result.Count);
        
    }

    [Fact]
    public void ValoresMaximosPorProduto()
    {
        var service = new ProdutoService();

        var produtosMock = service.GetListaProdutosMock();

        var result =
            produtosMock
            .GroupBy(x => x.Nome)
            .Select(group => group.OrderByDescending(prod => prod.Valor).First())
            .ToList();

        result = result.OrderBy(prod => prod.Valor).ToList();
       
        Assert.Equal(350, result.First().Valor);
        Assert.Equal(2100, result.Last().Valor);
    }

    [Fact]
    public void ValoresMinimosPorProduto()
    {
        var service = new ProdutoService();

        var produtosMock = service.GetListaProdutosMock();

        var result =
            produtosMock
            .GroupBy(x => x.Nome)
            .Select(group => group.OrderBy(prod => prod.Valor).First())
            .ToList();

        result = result.OrderBy(prod => prod.Valor).ToList();

        Assert.Equal(300, result.First().Valor);
        Assert.Equal(2000, result.Last().Valor);
    }

}