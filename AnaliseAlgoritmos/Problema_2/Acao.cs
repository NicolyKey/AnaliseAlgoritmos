using AnaliseAlgoritmos.Problema_2;
using Problema_2.Core.Interfaces;

namespace Problema_2.Core;

public class Acao : IPublicador
{
    private readonly List<IAssinante> _assinantes = new();
    private readonly List<Ordem> _ordens = new();

    public string Nome { get; }
    public decimal ValorAtual { get; private set; }

    public Acao(string nome, decimal valorInicial)
    {
        Nome = nome;
        ValorAtual = valorInicial;
    }

    public void AdicionarOrdem(Ordem ordem)
    {
        if (ordem is null)
            throw new ArgumentNullException(nameof(ordem));

        _ordens.Add(ordem);
    }

    public void RemoverOrdem(Ordem ordem) => _ordens.Remove(ordem);

    public IReadOnlyList<Ordem> ObterOrdens() => _ordens.AsReadOnly();

    public void RegistrarMatch(decimal novoValor)
    {
        ValorAtual = novoValor;
        Notificar();
    }

    public void Inscrever(IAssinante assinante)
    {
        if (assinante is null)
            throw new ArgumentNullException(nameof(assinante));

        if (!_assinantes.Contains(assinante))
            _assinantes.Add(assinante);
    }

    public void Desinscrever(IAssinante assinante)
    {
        if (assinante is null)
            throw new ArgumentNullException(nameof(assinante));

        _assinantes.Remove(assinante);
    }

    public void Notificar()
    {
        foreach (var assinante in _assinantes)
            assinante.Atualizar(Nome, ValorAtual);
    }
}