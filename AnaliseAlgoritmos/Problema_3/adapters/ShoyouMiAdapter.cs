using AlgoritmosDotNet;

namespace AnaliseAlgoritmos.Problema_3.adapters;

public class ShoyouMiAdapter : ILampada
{
    private LampadaShoyuMi _lampada;

    public ShoyouMiAdapter(LampadaShoyuMi lampada)
    {
        _lampada = lampada;
    }

    public void ligar()
    {
        _lampada.Ligar();
    }

    public void desligar()
    {
        _lampada.Desligar();
    }

    public bool estaLigada()
    {
        return _lampada.EstaLigada();
    }
}
