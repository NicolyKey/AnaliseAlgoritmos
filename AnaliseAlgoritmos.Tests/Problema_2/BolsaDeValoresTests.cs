using AnaliseAlgoritmos.Problema_2;
using Problema_2.Core;
using Xunit;

namespace AnaliseAlgoritmos.Tests.Problema_2;

public class BolsaDeValoresTests
{
    [Fact]
    public void DeveAdicionarAcaoNaBolsa()
    {
        var bolsa = new BolsaDeValores();
        var acao = new Acao("PETR4", 30.00m);

        bolsa.AdicionarAcao(acao);

        var acoes = bolsa.ObterTodasAcoes();
        Assert.Single(acoes);
        Assert.Equal("PETR4", acoes[0].Nome);
    }

    [Fact]
    public void DeveObterAcaoPorNome()
    {
        var bolsa = new BolsaDeValores();
        var acao = new Acao("VALE3", 70.00m);
        bolsa.AdicionarAcao(acao);

        var acaoEncontrada = bolsa.ObterAcao("VALE3");

        Assert.NotNull(acaoEncontrada);
        Assert.Equal("VALE3", acaoEncontrada.Nome);
    }

    [Fact]
    public void DeveRealizarMatchEntreOrdemDeCompraEVenda()
    {
        var bolsa = new BolsaDeValores();
        var acao = new Acao("BBAS3", 24.00m);
        bolsa.AdicionarAcao(acao);

        var mariana = new Investidor("Mariana");
        var joaquim = new Investidor("Joaquim");

        mariana.RegistrarOrdem(acao, TipoOrdem.Venda, 24.00m);
        joaquim.RegistrarOrdem(acao, TipoOrdem.Compra, 24.00m);

        bolsa.ProcessarOrdens(acao);

        Assert.Equal(24.00m, acao.ValorAtual);
        Assert.Empty(acao.ObterOrdens());
    }

    [Fact]
    public void DeveRealizarMatchComValorDeCompraSuperirorAoDeVenda()
    {
        var bolsa = new BolsaDeValores();
        var acao = new Acao("ITUB4", 26.00m);
        bolsa.AdicionarAcao(acao);

        var investidor1 = new Investidor("Investidor1");
        var investidor2 = new Investidor("Investidor2");

        investidor1.RegistrarOrdem(acao, TipoOrdem.Venda, 26.00m);
        investidor2.RegistrarOrdem(acao, TipoOrdem.Compra, 26.00m);

        bolsa.ProcessarOrdens(acao);

        Assert.Equal(26.00m, acao.ValorAtual);
        Assert.Empty(acao.ObterOrdens());
    }

    [Fact]
    public void NaoDeveRealizarMatchQuandoValorDeCompraMenorQueVenda()
    {
        var bolsa = new BolsaDeValores();
        var acao = new Acao("MGLU3", 5.00m);
        bolsa.AdicionarAcao(acao);

        var investidor1 = new Investidor("Investidor1");
        var investidor2 = new Investidor("Investidor2");

        investidor1.RegistrarOrdem(acao, TipoOrdem.Venda, 6.00m);
        investidor2.RegistrarOrdem(acao, TipoOrdem.Compra, 5.50m);

        bolsa.ProcessarOrdens(acao);

        Assert.Equal(5.00m, acao.ValorAtual);
        Assert.Equal(2, acao.ObterOrdens().Count);
    }

    [Fact]
    public void DeveProcessarMultiplasOrdensEmSequencia()
    {
        var bolsa = new BolsaDeValores();
        var acao = new Acao("WEGE3", 40.00m);
        bolsa.AdicionarAcao(acao);

        var inv1 = new Investidor("Inv1");
        var inv2 = new Investidor("Inv2");
        var inv3 = new Investidor("Inv3");
        var inv4 = new Investidor("Inv4");

        inv1.RegistrarOrdem(acao, TipoOrdem.Venda, 40.00m);
        inv2.RegistrarOrdem(acao, TipoOrdem.Compra, 40.00m);
        inv3.RegistrarOrdem(acao, TipoOrdem.Venda, 40.00m);
        inv4.RegistrarOrdem(acao, TipoOrdem.Compra, 40.00m);

        bolsa.ProcessarOrdens(acao);

        Assert.Equal(40.00m, acao.ValorAtual);
        Assert.Empty(acao.ObterOrdens());
    }

    [Fact]
    public void DeveProcessarOrdensDeTodasAcoes()
    {
        var bolsa = new BolsaDeValores();
        var acao1 = new Acao("PETR4", 30.50m);
        var acao2 = new Acao("VALE3", 72.00m);
        bolsa.AdicionarAcao(acao1);
        bolsa.AdicionarAcao(acao2);

        var inv1 = new Investidor("Inv1");
        var inv2 = new Investidor("Inv2");

        inv1.RegistrarOrdem(acao1, TipoOrdem.Venda, 30.50m);
        inv2.RegistrarOrdem(acao1, TipoOrdem.Compra, 30.50m);

        inv1.RegistrarOrdem(acao2, TipoOrdem.Venda, 72.00m);
        inv2.RegistrarOrdem(acao2, TipoOrdem.Compra, 72.00m);

        bolsa.ProcessarTodasOrdens();

        Assert.Equal(30.50m, acao1.ValorAtual);
        Assert.Equal(72.00m, acao2.ValorAtual);
    }
}
