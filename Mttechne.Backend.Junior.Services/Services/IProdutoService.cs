using Mttechne.Backend.Junior.Data;
using Mttechne.Backend.Junior.Data.Model;
using Mttechne.Backend.Junior.Services.Model.Dtos;

namespace Mttechne.Backend.Junior.Services.Services;

public interface IProdutoService
{
    List<ProdutoDto> GetListaProdutos();
    List<ProdutoDto> GetListaProdutosPorNome(string nome);
    List<ProdutoDto> GetListaProdutosOrdenadosPorValor(bool ordenacaoCrescente);
    List<ProdutoDto> GetListaProdutosNaReguaDeValor(decimal valorInicial, decimal valorFinal);
    List<ProdutoDto> GetValoresMaximosPorProduto();
    List<ProdutoDto> GetValoresMinimosPorProduto();
    string RemoverAcentosEToLower(string texto);


}