namespace AT;

public class Contato
{
    public Contato(string nome, string telefone, string email)
    {
        Nome = nome;
        Telefone = telefone;
        Email = email;
    }

    public string Nome;
    public string Telefone;
    public string Email;


    public string GetNome()
    {
        return Nome;
    }

    public string GetTelefone()
    {
        return Telefone;
    }

    public string GetEmail()
    {
        return Email;
    }


    public override string ToString()
    {
        return $"Nome: {GetNome()} | Telefone: {GetTelefone()} | Email: {GetEmail()}";
    }
}