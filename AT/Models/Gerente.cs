namespace AT;

public class Gerente : Funcionario
{
    public Gerente(string Nome, decimal Salario) : base(Nome, "Gerente", (Salario * 1.2m))
    { }
    
}