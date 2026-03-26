using AlgoritmosDotNet;

namespace AnaliseAlgoritmos.Problema_3.adapters;

public class PhelippesAdapter : ILampada
{
    private LampadaPhellipes _lampada;

    public PhelippesAdapter(LampadaPhellipes lampada)
    {
        _lampada = lampada;
    }

    public void ligar()
    {
        _lampada.SetIntensidade(100);
    }

    public void desligar()
    {
        _lampada.SetIntensidade(0);
    }

    public bool estaLigada()
    {
        return _lampada.GetIntensidade() > 0;
    }
}
