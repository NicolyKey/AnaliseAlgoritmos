namespace AnaliseAlgoritmos.Problema_3;

public class CasaInteligente
{
    private IArCondicionado _arCondicionado;
    private ILampada _lampada;
    private IPersiana _persiana;

    public CasaInteligente(IArCondicionado arCondicionado, ILampada lampada, IPersiana persiana)
    {
        _arCondicionado = arCondicionado;
        _lampada = lampada;
        _persiana = persiana;
    }

    public void ModoSono()
    {
        _arCondicionado.desligar();
        _lampada.desligar();
        _persiana.descerPersiana();
    }

    public void ModoTrabalho()
    {
        _lampada.ligar();
        _arCondicionado.ligar();
        _arCondicionado.definirTemperatura(25);
        _persiana.subirPersiana();
    }
}
