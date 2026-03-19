using System;

namespace AnaliseAlgoritmos.Problema_2
{
    public class Ordem
    {
        public string NomeInvestidor { get; }
        public TipoOrdem Tipo { get; }
        public double Valor { get; }

        public Ordem(string nomeInvestidor, TipoOrdem tipo, double valor)
        {
            if (string.IsNullOrWhiteSpace(nomeInvestidor))
                throw new ArgumentException("Nome do investidor é obrigatório", nameof(nomeInvestidor));

            if (valor <= 0)
                throw new ArgumentException("O valor da ordem deve ser positivo", nameof(valor));

            NomeInvestidor = nomeInvestidor;
            Tipo = tipo;
            Valor = valor;
        }
    }
}