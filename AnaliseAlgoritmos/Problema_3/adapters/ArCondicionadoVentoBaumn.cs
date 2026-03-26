using AlgoritmosDotNet;

namespace AnaliseAlgoritmos.Problema_3.adapters;

public class VentoBaumnAdapter : IArCondicionado
{
    private ArCondicionadoVentoBaumn _arCondicionado;

    public VentoBaumnAdapter(ArCondicionadoVentoBaumn arCondicionado)
    {
        _arCondicionado = arCondicionado;
    }

    public void ligar()
    {
        _arCondicionado.Ligar();
    }

    public void desligar()
    {
        _arCondicionado.Desligar();
    }

    public void aumentarTemperatura()
    {
        int temperaturaAtual = _arCondicionado.GetTemperatura();
        _arCondicionado.DefinirTemperatura(temperaturaAtual + 1);
    }

    public void diminuirTemperatura()
    {
        int temperaturaAtual = _arCondicionado.GetTemperatura();
        _arCondicionado.DefinirTemperatura(temperaturaAtual - 1);
    }

    public void definirTemperatura(int temperatura)
    {
        _arCondicionado.DefinirTemperatura(temperatura);
    }

    public int obterTemperatura()
    {
        return _arCondicionado.GetTemperatura();
    }
}