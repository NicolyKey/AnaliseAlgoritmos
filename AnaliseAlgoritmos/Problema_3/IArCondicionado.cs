namespace AnaliseAlgoritmos.Problema_3;

public interface IArCondicionado
{
    public void ligar();
    public void desligar();
    public void aumentarTemperatura();
    public void diminuirTemperatura();
    public void definirTemperatura(int temperatura);
    public int obterTemperatura();
}