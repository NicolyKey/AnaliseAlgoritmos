using AlgoritmosDotNet;
using AnaliseAlgoritmos.Problema_3;
using AnaliseAlgoritmos.Problema_3.adapters;
using Xunit;

namespace AnaliseAlgoritmos.Tests.Problema_3;

public class CasaInteligenteTests
{
    [Fact]
    public void ModoSono_DeveDesligarTudoEFecharPersiana()
    {
        var arCondicionado = new ArCondicionadoVentoBaumn();
        var lampada = new LampadaShoyouMi();
        var persiana = new PersianaSolarius();
        
        var arAdapter = new VentoBaumnAdapter(arCondicionado);
        var lampadaAdapter = new ShoyouMiAdapter(lampada);
        var persianaAdapter = new SolariusAdapter(persiana);
        
        var casa = new CasaInteligente(arAdapter, lampadaAdapter, persianaAdapter);
        
        lampadaAdapter.ligar();
        arAdapter.ligar();
        persianaAdapter.subirPersiana();
        
        casa.ModoSono();
        
        Assert.False(lampadaAdapter.estaLigada());
        Assert.False(arCondicionado.EstaLigado());
        Assert.False(persiana.EstaAberta());
    }

    [Fact]
    public void ModoTrabalho_DeveLigarTudoComTemperatura25()
    {
        var arCondicionado = new ArCondicionadoGellaKaza();
        var lampada = new LampadaPhelippes();
        var persiana = new PersianaNatLight();
        
        var arAdapter = new GellaKazaAdaptern(arCondicionado);
        var lampadaAdapter = new PhelippesAdapter(lampada);
        var persianaAdapter = new NatLightAdapter(persiana);
        
        var casa = new CasaInteligente(arAdapter, lampadaAdapter, persianaAdapter);
        
        casa.ModoTrabalho();
        
        Assert.True(lampadaAdapter.estaLigada());
        Assert.True(arCondicionado.EstaAtivado());
        Assert.Equal(25, arAdapter.obterTemperatura());
        Assert.True(persiana.EstaErguida());
    }

    [Fact]
    public void ModoTrabalho_DeveFuncionarComDiferentesFabricantes()
    {
        var arCondicionado = new ArCondicionadoVentoBaumn();
        var lampada = new LampadaShoyouMi();
        var persiana = new PersianaSolarius();
        
        var arAdapter = new VentoBaumnAdapter(arCondicionado);
        var lampadaAdapter = new ShoyouMiAdapter(lampada);
        var persianaAdapter = new SolariusAdapter(persiana);
        
        var casa = new CasaInteligente(arAdapter, lampadaAdapter, persianaAdapter);
        
        casa.ModoTrabalho();
        
        Assert.True(lampadaAdapter.estaLigada());
        Assert.True(arCondicionado.EstaLigado());
        Assert.Equal(25, arAdapter.obterTemperatura());
        Assert.True(persiana.EstaAberta());
    }
}
