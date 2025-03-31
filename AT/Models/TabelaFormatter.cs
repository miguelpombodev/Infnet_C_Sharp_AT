namespace AT;

class TabelaFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("| Nome | Telefone | Email |");
        Console.WriteLine("----------------------------------------");
        
        foreach (var contato in contatos)
        {
            Console.WriteLine($"| {contato.GetNome()} | {contato.GetTelefone()} | {contato.GetEmail()} |");
        }
        
        Console.WriteLine("----------------------------------------");
    }
}