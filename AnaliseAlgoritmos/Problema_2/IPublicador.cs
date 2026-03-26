namespace Problema_2.Core.Interfaces;

public interface IPublicador
{
    void Inscrever(IAssinante assinante);
    void Desinscrever(IAssinante assinante);
}