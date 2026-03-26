using AlgoritmosDotNet;

namespace AnaliseAlgoritmos.Problema_3.adapters;

public class SolariusAdapter : IPersiana
{
    private PersianaSolarius _persiana;

    public SolariusAdapter(PersianaSolarius persiana)
    {
        _persiana = persiana;
    }

    public void descerPersiana()
    {
        _persiana.DescerPersiana();
    }

    public void subirPersiana()
    {
        _persiana.SubirPersiana();
    }
}
