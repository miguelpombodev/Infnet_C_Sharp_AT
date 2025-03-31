namespace AT;

public class Aluno
{
    public Aluno(string nome, string matricula, string curso, double mediaNotas)
    {
        Nome = nome;
        Matricula = matricula;
        Curso = curso;
        MediaNotas = mediaNotas;
    }

    public string Nome;
    public string Matricula;
    public string Curso;
    public double MediaNotas;

    public void ExibirDados()
    {
        Console.WriteLine($"Nome: {Nome} | Matricula: {Matricula} | Curso: {Curso} | MediaNotas: {MediaNotas}");
    }

    public void VerificarAprovacao()
    {
        var mensagemPadrao = "Status do Aluno:";
        if (MediaNotas >= 7)
        {
            Console.WriteLine($"{mensagemPadrao} Aprovado!");
        }
        
        Console.WriteLine($"{mensagemPadrao} Reprovado!");
    }
}
