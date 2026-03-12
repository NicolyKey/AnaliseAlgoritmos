namespace AnaliseAlgoritmos.Problema_1;

public class EncomendaPAC : CalculaPagamentoTipoEntrega
{
    private const double PesoMaximo = 2000;
    private const double PrecoAte1Kg = 10.0;
    private const double PrecoAte2Kg = 15.0;

    public double CalculaPrecoEntrega(double pesoEmGramas)
    {
        if (pesoEmGramas > PesoMaximo)
            throw new ArgumentException("Peso não aceito para PAC.");

        if (pesoEmGramas <= 1000)
            return PrecoAte1Kg;

        return PrecoAte2Kg;
    }
}