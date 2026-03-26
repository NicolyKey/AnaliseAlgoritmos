using AnaliseAlgoritmos.Problema_2;
using Problema_2.Core;
using Xunit;

namespace AnaliseAlgoritmos.Tests.Problema_2;

public class AcaoTests
{
    [Fact]
    public void DeveCriarAcaoComNomeEValorInicial()
    {
        var acao = new Acao("PETR4", 30.00m);

        Assert.Equal("PETR4", acao.Nome);
        Assert.Equal(30.00m, acao.ValorAtual);
    }

    [Fact]
    public void DeveAdicionarOrdem()
    {
        var acao = new Acao("VALE3", 70.00m);
        var ordem = new Ordem("Investidor1", TipoOrdem.Compra, 71.00m);

        acao.AdicionarOrdem(ordem);

        var ordens = acao.ObterOrdens();
        Assert.Single(ordens);
        Assert.Equal(ordem, ordens[0]);
    }

    [Fact]
    public void DeveRemoverOrdem()
    {
        var acao = new Acao("BBAS3", 24.00m);
        var ordem = new Ordem("Investidor1", TipoOrdem.Venda, 24.50m);

        acao.AdicionarOrdem(ordem);
        acao.RemoverOrdem(ordem);

        Assert.Empty(acao.ObterOrdens());
    }

    [Fact]
    public void DeveAtualizarValorAoRegistrarMatch()
    {
        var acao = new Acao("ITUB4", 25.00m);

        acao.RegistrarMatch(26.50m);

        Assert.Equal(26.50m, acao.ValorAtual);
    }

    [Fact]
    public void DeveNotificarAssinantesQuandoValorAtualizado()
    {
        var acao = new Acao("WEGE3", 40.00m);
        var investidor = new Investidor("João");

        acao.Inscrever(investidor);
        acao.RegistrarMatch(42.00m);

        var notificacoes = investidor.ObterNotificacoes();
        Assert.Single(notificacoes);
        Assert.Contains("WEGE3", notificacoes[0]);
        Assert.Contains("42,00", notificacoes[0]);
    }

    [Fact]
    public void DeveNotificarMultiplosAssinantes()
    {
        var acao = new Acao("MGLU3", 5.00m);
        var investidor1 = new Investidor("Maria");
        var investidor2 = new Investidor("Carlos");
        var investidor3 = new Investidor("Ana");

        acao.Inscrever(investidor1);
        acao.Inscrever(investidor2);
        acao.Inscrever(investidor3);

        acao.RegistrarMatch(5.50m);

        Assert.Single(investidor1.ObterNotificacoes());
        Assert.Single(investidor2.ObterNotificacoes());
        Assert.Single(investidor3.ObterNotificacoes());
    }

    [Fact]
    public void NaoDeveAdicionarAssinanteDuplicado()
    {
        var acao = new Acao("PETR4", 30.00m);
        var investidor = new Investidor("Pedro");

        acao.Inscrever(investidor);
        acao.Inscrever(investidor);

        acao.RegistrarMatch(31.00m);

        Assert.Single(investidor.ObterNotificacoes());
    }

    [Fact]
    public void DeveDesinscreverAssinante()
    {
        var acao = new Acao("VALE3", 70.00m);
        var investidor = new Investidor("Lucia");

        acao.Inscrever(investidor);
        acao.RegistrarMatch(71.00m);

        acao.Desinscrever(investidor);
        acao.RegistrarMatch(72.00m);

        Assert.Single(investidor.ObterNotificacoes());
    }

    [Fact]
    public void DeveLancarExcecaoAoAdicionarOrdemNula()
    {
        var acao = new Acao("BBAS3", 24.00m);

        Assert.Throws<ArgumentNullException>(() => acao.AdicionarOrdem(null!));
    }

    [Fact]
    public void DeveLancarExcecaoAoInscreverAssinanteNulo()
    {
        var acao = new Acao("ITUB4", 25.00m);

        Assert.Throws<ArgumentNullException>(() => acao.Inscrever(null!));
    }
}
