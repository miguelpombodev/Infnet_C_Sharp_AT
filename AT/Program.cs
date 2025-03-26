namespace AT;

class Program
{
    static void Main(string[] args)
    {
        Exercicio2();
    }

    private static void Exercicio1()
    {
        var userName = "Miguel";
        var dataNascimento = new DateTime(1996, 5, 24).ToString();
        
        Console.WriteLine($"Nome: {userName}, Data de Nascimento: {dataNascimento}");
    }

    private static void Exercicio2()
    {
        try
        {
            var alphabet = Enumerable.Range('a', 26).Select(x => (char)x).ToList();
            var encryptedName = ""; 
            
            Console.WriteLine("Digite o seu nome");
            var userName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new NullReferenceException("[ERROR] Por favor tente novamente.");
            }
            
            var splitedUserName = userName.Trim().ToLower().Split(" ");

            foreach (var name in splitedUserName)
            {
                var aux = "";
                foreach (var letter in name)
                {
                    var letterIndex = alphabet.IndexOf(letter);
                    var mixedLetter = alphabet[letterIndex + 2];
                    
                    aux += mixedLetter;
                }

                encryptedName += $"{char.ToUpper(aux[0])}{aux[1..]}" + " ";
            }
            
            Console.WriteLine($"Entrada: {userName}");
            Console.WriteLine($"Saída: {encryptedName}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Exercicio2();
        }
    }
}