using AnaliseAlgoritmos.Problema_2;
using Xunit;

namespace AnaliseAlgoritmos.Tests.Problema_2;

public class OrdemTests
{
    [Fact]
    public void DeveCriarOrdemDeCompra()
    {
        var ordem = new Ordem("João", TipoOrdem.Compra, 30.00);

        Assert.Equal("João", ordem.NomeInvestidor);
        Assert.Equal(TipoOrdem.Compra, ordem.Tipo);
        Assert.Equal(30.00, ordem.Valor);
    }

    [Fact]
    public void DeveCriarOrdemDeVenda()
    {
        var ordem = new Ordem("Maria", TipoOrdem.Venda, 25.50);

        Assert.Equal("Maria", ordem.NomeInvestidor);
        Assert.Equal(TipoOrdem.Venda, ordem.Tipo);
        Assert.Equal(25.50, ordem.Valor);
    }

    [Fact]
    public void DeveLancarExcecaoQuandoNomeInvestidorVazio()
    {
        Assert.Throws<ArgumentException>(() => new Ordem("", TipoOrdem.Compra, 30.00));
    }

    [Fact]
    public void DeveLancarExcecaoQuandoNomeInvestidorNulo()
    {
        Assert.Throws<ArgumentException>(() => new Ordem(null!, TipoOrdem.Compra, 30.00));
    }

    [Fact]
    public void DeveLancarExcecaoQuandoValorZero()
    {
        Assert.Throws<ArgumentException>(() => new Ordem("Carlos", TipoOrdem.Compra, 0));
    }

    [Fact]
    public void DeveLancarExcecaoQuandoValorNegativo()
    {
        Assert.Throws<ArgumentException>(() => new Ordem("Ana", TipoOrdem.Venda, -10.00));
    }
}
