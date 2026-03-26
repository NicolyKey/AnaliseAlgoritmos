using AlgoritmosDotNet;

namespace AnaliseAlgoritmos.Problema_3.adapters;

public class GellaKazaAdaptern: IArCondicionado
{

    private ArCondicionadoGellaKaza _arCondicionado;

    public GellaKazaAdaptern(ArCondicionadoGellaKaza _arCondicionado)
    {
        this._arCondicionado = _arCondicionado;
    }
    
    public void ligar()
    {
        _arCondicionado.Ativar();
    }

    public void desligar()
    {
        _arCondicionado.Desativar();
    }
    
    public void aumentarTemperatura()
    {
        _arCondicionado.AumentarTemperatura();
    }

    public void diminuirTemperatura()
    {
        _arCondicionado.DiminuirTemperatura();
    }

    public void definirTemperatura(int temperatura)
    {
        int temperaturaAtual = _arCondicionado.GetTemperatura();
        
        while (temperaturaAtual < temperatura)
        {
            _arCondicionado.AumentarTemperatura();
            temperaturaAtual++;
        }
        
        while (temperaturaAtual > temperatura)
        {
            _arCondicionado.DiminuirTemperatura();
            temperaturaAtual--;
        }
    }

    public int obterTemperatura()
    {
        return _arCondicionado.GetTemperatura();
    }
}