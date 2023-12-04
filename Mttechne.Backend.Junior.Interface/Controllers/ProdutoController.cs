using Microsoft.AspNetCore.Mvc;
using Mttechne.Backend.Junior.Services.Model;
using Mttechne.Backend.Junior.Services.Services;

namespace Mttechne.Backend.Junior.Interface.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoService _service;

    public ProdutoController(IProdutoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetListaProdutos() => Ok(_service.GetListaProdutos());

    [HttpGet("{nome?}")]   
    public IActionResult GetListaProdutosPorNome([FromRoute] string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            return BadRequest("É necessário informar um nome para realizarmos sua busca.");
        }

        var produtos = _service.GetListaProdutosPorNome(nome);

        if (produtos == null || produtos.Count == 0)
        {
            return NotFound("Nenhum produto encontrado.");
        }

        return Ok(produtos);
    }

    [HttpGet("ordenados")]
    public IActionResult GetListaProdutosOrdenados([FromQuery] bool ordenacaoCrescente)
    {
        var produtosOrdenados = _service.GetListaProdutosOrdenadosPorValor(ordenacaoCrescente);

        if (produtosOrdenados == null || produtosOrdenados.Count == 0)
        {
            return NotFound("Nenhum produto encontrado.");
        }

        return Ok(produtosOrdenados);
    }

    [HttpGet("regua-valor")]
    public IActionResult GetProdutosNaReguaDeValor([FromQuery] decimal valorInicial, [FromQuery] decimal valorFinal)
    {
        if (valorInicial > valorFinal)
        {
            return BadRequest("O valor inicial não pode ser maior que o valor final.");
        }

        var produtosNaFaixaDeValor = _service.GetListaProdutosNaReguaDeValor(valorInicial, valorFinal);

        if (produtosNaFaixaDeValor == null || produtosNaFaixaDeValor.Count == 0)
        {
            return NotFound("Nenhum produto encontrado na faixa de valores especificada.");
        }

        return Ok(produtosNaFaixaDeValor);
    }

    [HttpGet("valores-maximos")]
    public IActionResult GetValoresMaximosPorProduto()
    {
        var produtosMaximos = _service.GetValoresMaximosPorProduto();

        if (produtosMaximos == null || produtosMaximos.Count == 0)
        {
            return NotFound("Nenhum produto encontrado com valor máximo.");
        }

        return Ok(produtosMaximos);
    }

    [HttpGet("valores-minimos")]
    public IActionResult GetValoresMinimosPorProduto()
    {
        var produtosMinimos = _service.GetValoresMinimosPorProduto();

        if (produtosMinimos == null || produtosMinimos.Count == 0)
        {
            return NotFound("Nenhum produto encontrado com valor mínimo.");
        }

        return Ok(produtosMinimos);
    }
}