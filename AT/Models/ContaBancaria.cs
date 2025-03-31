using System.Globalization;

namespace AT;

public class ContaBancaria
{
    public ContaBancaria(string titular, decimal saldo = 0)
    {
        Titular = titular;
        Saldo = saldo;
    }

    public string Titular;
    private decimal Saldo;

    public void Depositar(decimal valor)
    {
        var brasilCultureInfo = new CultureInfo("pt-BR");
        if (valor < 0)
        {
            Console.WriteLine("O valor do depósito deve ser positivo!");
        }
        
        Saldo += valor;
        Console.WriteLine($"Depósito de {valor.ToString("C",brasilCultureInfo)} realizado com sucesso!");
    }

    public void Sacar(decimal valor)
    {
        var brasilCultureInfo = new CultureInfo("pt-BR"); 
        if (valor > Saldo)
        {
            Console.WriteLine("Saldo insuficiente para realizar o saque!");
            return;
        }
        
        Saldo -= valor;
        Console.WriteLine($"Saque de {valor.ToString("C",brasilCultureInfo)} realizado com sucesso!");
    }

    public void ExibirSaldo()
    {
        var brasilCultureInfo = new CultureInfo("pt-BR");
        Console.WriteLine($"Saldo Atual: {Saldo.ToString("C", brasilCultureInfo)}");
    }
}