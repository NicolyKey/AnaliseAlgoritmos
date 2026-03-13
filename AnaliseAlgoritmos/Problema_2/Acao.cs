
using Problema_2.Core.Interfaces;

public class Acao : IPublicador
{
    private readonly List<IAssinante> _assinantes;

    public string Nome { get; }
    public decimal ValorAtual { get; private set; }
  
    public Acao(string nome, decimal valorInicial)
    {
        Nome = nome;
        ValorAtual = valorInicial;
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