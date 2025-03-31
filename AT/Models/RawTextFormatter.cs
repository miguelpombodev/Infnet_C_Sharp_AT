namespace AT;

class RawTextFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        foreach (var contato in contatos)
        {
            Console.WriteLine($"**Nome: {contato.GetNome()} | Telefone: {contato.GetTelefone()} | Email: {contato.GetEmail()}**");
        }
    }
}