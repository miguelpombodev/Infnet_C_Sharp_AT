namespace AT;

class MarkdownFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        Console.WriteLine("## Lista de Contatos");
        foreach (var contato in contatos)
        {
            Console.WriteLine($"- **Nome:** {contato.GetNome()}");
            Console.WriteLine($"- 📞 Telefone: {contato.GetTelefone()}");
            Console.WriteLine($"- 📧 Email: {contato.GetEmail()}");
        }
    }
}