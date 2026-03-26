using AnaliseAlgoritmos.Problema_2;
using Problema_2.Core;
using Xunit;

namespace AnaliseAlgoritmos.Tests.Problema_2;

public class InvestidorTests
{
    [Fact]
    public void DeveCriarInvestidorComNome()
    {
        var investidor = new Investidor("João");

        Assert.Equal("João", investidor.Nome);
    }

    [Fact]
    public void DeveLancarExcecaoQuandoNomeVazio()
    {
        Assert.Throws<ArgumentException>(() => new Investidor(""));
    }

    [Fact]
    public void DeveRegistrarOrdemEmAcao()
    {
        var investidor = new Investidor("Maria");
        var acao = new Acao("BBAS3", 24.00m);

        investidor.RegistrarOrdem(acao, TipoOrdem.Compra, 25.00m);

        var ordens = acao.ObterOrdens();
        Assert.Single(ordens);
        Assert.Equal("Maria", ordens[0].NomeInvestidor);
        Assert.Equal(TipoOrdem.Compra, ordens[0].Tipo);
        Assert.Equal(25.00m, ordens[0].Valor);
    }

    [Fact]
    public void DeveInscreverEmAcaoEReceberNotificacoes()
    {
        var investidor = new Investidor("Carlos");
        var acao = new Acao("PETR4", 30.00m);

        investidor.InscreverEmAcao(acao);
        acao.RegistrarMatch(32.00m);

        var notificacoes = investidor.ObterNotificacoes();
        Assert.Single(notificacoes);
        Assert.Contains("PETR4", notificacoes[0]);
        Assert.Contains("32,00", notificacoes[0]);
    }

    [Fact]
    public void DeveReceberMultiplasNotificacoes()
    {
        var investidor = new Investidor("Ana");
        var acao = new Acao("VALE3", 70.00m);

        investidor.InscreverEmAcao(acao);
        acao.RegistrarMatch(71.00m);
        acao.RegistrarMatch(72.50m);
        acao.RegistrarMatch(73.00m);

        var notificacoes = investidor.ObterNotificacoes();
        Assert.Equal(3, notificacoes.Count);
    }

    [Fact]
    public void DeveDesinscreverDeAcaoEPararDeReceberNotificacoes()
    {
        var investidor = new Investidor("Pedro");
        var acao = new Acao("ITUB4", 25.00m);

        investidor.InscreverEmAcao(acao);
        acao.RegistrarMatch(26.00m);
        
        investidor.DesinscreverDeAcao(acao);
        acao.RegistrarMatch(27.00m);

        var notificacoes = investidor.ObterNotificacoes();
        Assert.Single(notificacoes);
    }

    [Fact]
    public void DeveLimparNotificacoes()
    {
        var investidor = new Investidor("Lucia");
        var acao = new Acao("WEGE3", 40.00m);

        investidor.InscreverEmAcao(acao);
        acao.RegistrarMatch(41.00m);
        acao.RegistrarMatch(42.00m);

        investidor.LimparNotificacoes();

        Assert.Empty(investidor.ObterNotificacoes());
    }

    [Fact]
    public void DeveRegistrarMultiplasOrdensEmDiferentesAcoes()
    {
        var investidor = new Investidor("Roberto");
        var acao1 = new Acao("PETR4", 30.00m);
        var acao2 = new Acao("VALE3", 70.00m);

        investidor.RegistrarOrdem(acao1, TipoOrdem.Compra, 31.00m);
        investidor.RegistrarOrdem(acao2, TipoOrdem.Venda, 69.00m);

        Assert.Single(acao1.ObterOrdens());
        Assert.Single(acao2.ObterOrdens());
    }
}
