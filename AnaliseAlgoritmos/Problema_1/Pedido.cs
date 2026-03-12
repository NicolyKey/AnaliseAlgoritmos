namespace AnaliseAlgoritmos.Problema_1;

public class Pedido
{
    private Produto[] produtos { get; set; }
    public Pedido(Produto[] produtos)
    {
        this.produtos = produtos;
    }

    public double calculaValorPedido(Produto[] produtos, TipoEntrega tipoEntrega)
    {
        double valorProdutos = 0;
        double pesoTotal = 0;

        foreach(var produto in produtos)
        {
            valorProdutos += produto.valor;
            pesoTotal += produto.pesoEmGramas;
        }

        double valorFrete = CalculaPrecoFrete(pesoTotal, tipoEntrega);
        return valorProdutos + valorFrete;
    }

    public double CalculaPrecoFrete(double pesoTotalPedidoEmGramas, TipoEntrega tipoEntrega)
    {
        double valorFrete = 0;

        switch(tipoEntrega)
        {
            case TipoEntrega.PAC:
                EncomendaPAC pac = new EncomendaPAC();
                valorFrete = pac.CalculaPrecoEntrega(pesoTotalPedidoEmGramas);
                break;

            case TipoEntrega.SEDEX:
                FreteSedex sedex = new FreteSedex();
                valorFrete = sedex.CalculaPrecoEntrega(pesoTotalPedidoEmGramas);
                break;
            
            case TipoEntrega.RETIRADA_LOJA:
                valorFrete = 0.0;
                break;
        }
        return  valorFrete;
    }

}