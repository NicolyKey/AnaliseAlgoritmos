using AnaliseAlgoritmos.Problema_2;
using Problema_2.Core.Interfaces;

namespace Problema_2.Core;

public class Investidor : IAssinante
{
    private readonly List<string> _notificacoes = new();

    public string Nome { get; }

    public Investidor(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome do investidor é obrigatório", nameof(nome));

        Nome = nome;
    }

    public void RegistrarOrdem(Acao acao, TipoOrdem tipo, double valor)
    {
        if (acao is null)
            throw new ArgumentNullException(nameof(acao));

        var ordem = new Ordem(Nome, tipo, valor);
        acao.AdicionarOrdem(ordem);
    }

    public void InscreverEmAcao(Acao acao)
    {
        if (acao is null)
            throw new ArgumentNullException(nameof(acao));

        acao.Inscrever(this);
    }

    public void DesinscreverDeAcao(Acao acao)
    {
        if (acao is null)
            throw new ArgumentNullException(nameof(acao));

        acao.Desinscrever(this);
    }

    public void Atualizar(string nomeAcao, double novoValor)
    {
        var mensagem = $"Ação {nomeAcao} atualizada para R${novoValor:F2}";
        _notificacoes.Add(mensagem);
    }

    public IReadOnlyList<string> ObterNotificacoes() => _notificacoes.AsReadOnly();

    public void LimparNotificacoes() => _notificacoes.Clear();
}
