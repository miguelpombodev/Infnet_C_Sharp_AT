using System.Globalization;

namespace AT;

public class Funcionario
{
    public Funcionario(string nome, string cargo, decimal salarioBase)
    {
        Nome = nome;
        Cargo = cargo;
        SalarioBase = salarioBase;
    }

    private string Nome;
    private string Cargo;
    private decimal SalarioBase;

    public void GetNome()
    {
        Console.WriteLine($"Nome: {Nome}");
    }

    public void GetCargo()
    {
        Console.WriteLine($"Cargo: {Cargo}");
    }

    public void GetSalario()
    {
        var brasilCultureInfo = new CultureInfo("pt-BR"); 

        Console.WriteLine($"Salario: {SalarioBase.ToString("C", brasilCultureInfo)}");
    }
}