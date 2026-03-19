using AnaliseAlgoritmos.Problema_2;

namespace Problema_2.Core;

public class BolsaDeValores
{
    private readonly List<Acao> _acoes = new();

    public void AdicionarAcao(Acao acao)
    {
        if (acao is null)
            throw new ArgumentNullException(nameof(acao));

        if (!_acoes.Contains(acao))
            _acoes.Add(acao);
    }

    public Acao? ObterAcao(string nome)
    {
        return _acoes.FirstOrDefault(a => a.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
    }

    public IReadOnlyList<Acao> ObterTodasAcoes() => _acoes.AsReadOnly();

    public void ProcessarOrdens(Acao acao)
    {
        if (acao is null)
            throw new ArgumentNullException(nameof(acao));

        var ordens = acao.ObterOrdens().ToList();
        var ordensCompra = ordens.Where(o => o.Tipo == TipoOrdem.Compra).OrderByDescending(o => o.Valor).ToList();
        var ordensVenda = ordens.Where(o => o.Tipo == TipoOrdem.Venda).OrderBy(o => o.Valor).ToList();

        foreach (var ordemCompra in ordensCompra.ToList())
        {
            foreach (var ordemVenda in ordensVenda.ToList())
            {
                if (ordemCompra.Valor.Equals(ordemVenda.Valor))
                {
                    var valorNegociacao = ordemVenda.Valor;
                    
                    acao.RemoverOrdem(ordemCompra);
                    acao.RemoverOrdem(ordemVenda);
                    
                    ordensCompra.Remove(ordemCompra);
                    ordensVenda.Remove(ordemVenda);
                    
                    acao.RegistrarMatch(valorNegociacao);
                    
                    break;
                }
            }
        }
    }

    public void ProcessarTodasOrdens()
    {
        foreach (var acao in _acoes)
        {
            ProcessarOrdens(acao);
        }
    }
}
