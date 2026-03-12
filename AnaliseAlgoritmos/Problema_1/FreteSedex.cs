namespace AnaliseAlgoritmos.Problema_1;

public class FreteSedex : CalculaPagamentoTipoEntrega
{
    private const double PrecoAte500G = 12.50;
    private const double PrecoAte1Kg = 20.0;
    private const double PrecoFixo1Kg = 46.00;
    private const double PrecoAcrescimo = 1.50;
    
    public double CalculaPrecoEntrega(double pesoEmGramas)
    {
        if(pesoEmGramas <= 500)
            return PrecoAte500G;

        if(pesoEmGramas > 500 & pesoEmGramas <= 1000 )
            return PrecoAte1Kg;
        
        if (pesoEmGramas > 1000)
        { 
           double valorVariavel;
           valorVariavel = ((pesoEmGramas - 1000.00) / 100) * PrecoAcrescimo;
           
           return PrecoFixo1Kg + valorVariavel;
        }
        
        throw new ArgumentException("Peso não aceito para Sedex.");
    }
}