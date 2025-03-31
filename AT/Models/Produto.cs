using System.Globalization;

namespace AT;

public class Produto
{
    public Produto(string nome, decimal preco, int quantidade = 0)
    {
        Nome = nome;
        Quantidade = quantidade;
        Preco = preco;
    }

    public string Nome;
    public int Quantidade;
    public decimal Preco;
    
    public string GetNome()
    {
        return Nome;
    }

    public int GetQuantidade()
    {
        return Quantidade;
    }

    public string GetPreco()
    {
        var brasilCultureInfo = new CultureInfo("pt-BR"); 

        return Preco.ToString("C", brasilCultureInfo);
    }
    
    public string GetPreco(bool notFormatted)
    {
        if (notFormatted)
        {
            return Preco.ToString("F2");

        }
        return GetPreco();
    }
    
    public override string ToString()
    {
        return $"Produto: {GetNome()} | Quantidade: {GetQuantidade()} | Preço: {GetPreco()}";
    }
}