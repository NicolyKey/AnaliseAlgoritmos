
using AlgoritmosDotNet;

namespace AnaliseAlgoritmos.Problema_3.adapters;

public class NatLightAdapter : IPersiana
{
    private PersianaNatLight _persiana;

    public NatLightAdapter(PersianaNatLight persiana)
    {
        _persiana = persiana;
    }

    public void descerPersiana()
    {
        if (_persiana.EstaPalhetaAberta())
        {
            _persiana.FecharPalheta();
        }
        _persiana.DescerPalheta();
    }

    public void subirPersiana()
    {
        if (!_persiana.EstaPalhetaAberta())
        {
            _persiana.AbrirPalheta();
        }
        _persiana.SubirPalheta();
    }
}
