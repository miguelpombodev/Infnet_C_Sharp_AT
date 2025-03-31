using System.Globalization;

namespace AT;

class Program
{
    static void Main(string[] args)
    {
        Exercicio9();
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

    private static void Exercicio3()
    {
        try
        {
            double resultado = 0;

            Console.WriteLine("Digite o primeiro número:");
            var n1 = double.Parse(Console.ReadLine().Replace(",", "."));

            Console.WriteLine("Digite o segundo número:");
            var n2 = double.Parse(Console.ReadLine().Replace(",", "."));

            Console.Clear();
            Console.WriteLine("Escolha a operação a ser feita");
            Console.WriteLine("1 - Soma");
            Console.WriteLine("2 - Subtração");
            Console.WriteLine("3 - Multiplicação");
            Console.WriteLine("4 - Divisão");
            var operacao = int.Parse(Console.ReadLine());

            if (operacao == 4 && n1 == 0 || n2 == 0)
            {
                throw new DivideByZeroException("[ERROR] Operação cancelada! Motivo: Divisão por zero!");
            }

            switch (operacao)
            {
                case 1: resultado = n1 + n2; break;
                case 2: resultado = n1 - n2; break;
                case 3: resultado = n1 * n2; break;
                case 4: resultado = n1 / n2; break;
                default:
                    Console.WriteLine("[ERROR] Operação não permitida");
                    Exercicio3();
                    break;
            }

            Console.WriteLine($"Resultado da Operação: {resultado}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Exercicio3();
            return;
        }
    }

    private static void Exercicio4()
    {
        var brasilCultureInfo = new CultureInfo("pt-BR");
        var formatoEsperadoData = "dd/MM/yyyy";
        var hoje = DateTime.Today;

        DateTime dataNascimento;

        Console.Write("Digite sua data de nascimento (dd/mm/aaaa): ");
        if (!DateTime.TryParseExact(Console.ReadLine(), formatoEsperadoData, brasilCultureInfo, DateTimeStyles.None,
                out dataNascimento))
        {
            Console.WriteLine("[ERROR] Data inválida! Por favor, digite no formato dd/mm/aaaa.");
            Console.Clear();
            Exercicio4();
            return;
        }

        var proximoAniversario = new DateTime(hoje.Year, dataNascimento.Month, dataNascimento.Day);

        if (proximoAniversario < hoje)
        {
            proximoAniversario = proximoAniversario.AddYears(1);
        }

        var diferencaDeDatas = proximoAniversario - hoje;
        var diasFaltantes = diferencaDeDatas.Days;

        switch (diasFaltantes)
        {
            case 0: Console.WriteLine("Parabéns! Hoje é seu aniversário!"); break;
            case < 7:
                Console.WriteLine($"Seu próximo aniversário é em {diasFaltantes} dias!");
                Console.WriteLine("Está quase chegando! Já está preparando a festa?");
                break;
            default:
                Console.WriteLine($"Faltam {diasFaltantes} dias para o seu próximo aniversário.");
                break;
        }

        Console.WriteLine(
            $"Seu próximo aniversário será em: {proximoAniversario:dd/MM/yyyy}");
    }

    private static void Exercicio5()
    {
        try
        {
            var brasilCultureInfo = new CultureInfo("pt-BR");
            var formatoEsperadoData = "dd/MM/yyyy";
            DateTime dataFormatura = new DateTime(2025, 12, 15);

            Console.WriteLine("Contagem Regressiva para a Formatura");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"DATA PREVISTA DA FORMATURA: {dataFormatura:dd/MM/yyyy}");

            DateTime dataAtual;

            Console.WriteLine("Digite a data atual (dd/MM/yyyy): ");

            var checarParse = DateTime.TryParseExact(
                Console.ReadLine(),
                formatoEsperadoData,
                brasilCultureInfo,
                DateTimeStyles.None,
                out dataAtual);

            if (!checarParse)
            {
                throw new Exception("[ERRO] Data ou formato de data inválido");
            }

            if (dataAtual > DateTime.Now)
            {
                throw new Exception("[ERRO] A data informada não pode ser no futuro!");
            }

            if (dataAtual > dataFormatura)
            {
                Console.WriteLine("Parabéns! Você já deveria estar formado!");
                return;
            }

            var tempoRestante = dataFormatura - dataAtual;

            var anos = (dataFormatura.Year - dataAtual.Year);
            var meses = dataFormatura.Month - dataAtual.Month;
            var dias = dataFormatura.Day - dataAtual.Day;

            if (dias < 0)
            {
                meses--;
                dias += DateTime.DaysInMonth(dataAtual.Year, dataAtual.Month);
            }

            if (meses < 0)
            {
                anos--;
                meses += 12;
            }

            if (tempoRestante.TotalDays <= 180)
            {
                Console.WriteLine($"Faltam {(meses > 0 ? $"{meses} meses e " : "")}{dias} dias para sua formatura!");
                Console.WriteLine("A reta final chegou! Prepare-se para a formatura!");
            }
            else
            {
                Console.WriteLine($"Faltam {anos} anos, {meses} meses e {dias} dias para sua formatura!");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Exercicio5();
            return;
        }
    }

    private static void Exercicio6()
    {
        var random = new Random();
        var aluno = new Aluno("Miguel", random.Next(1000, 10000).ToString(), "Análise e Desenvolvimento de Sistemas",
            8.0);

        aluno.ExibirDados();
        aluno.VerificarAprovacao();
    }

    private static void Exercicio7()
    {
        var conta = new ContaBancaria("João Silva");

        Console.WriteLine($"Titular: {conta.Titular}");
        conta.Depositar(500);
        conta.ExibirSaldo();
        Console.WriteLine("Tentativa de saque: R$ 700,00");
        conta.Sacar(700);
        conta.Sacar(200);
        conta.ExibirSaldo();
    }

    private static void Exercicio8()
    {
        var funcionario = new Funcionario("Miguel", "Analista", 2000);
        Console.WriteLine("------------ SALARIO FUNCIONARIO -------------");
        funcionario.GetSalario();

        var gerente = new Gerente("Carlos", 5000);
        Console.WriteLine("------------ SALARIO GERENTE -------------");
        gerente.GetSalario();
    }

    private static void Exercicio9()
    {
        var produtosLista = new List<Produto>();

        try
        {
            void InserirProduto()
            {
                var tamanhoListaProdutos = produtosLista.Count;

                for (var i = tamanhoListaProdutos; i <= 6; i++)
                {
                    if (i == 6)
                    {
                        Console.WriteLine("Limite de produtos atingido!");
                        Console.WriteLine("Voltando ao menu inicial...");
                        break;
                    }

                    Console.Write("Digite o nome do produto: ");
                    var nome = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(nome))
                    {
                        throw new ArgumentException("Nome do produto não pode ser vazio");
                    }

                    Console.Write("Digite a quantidade, caso não digitado o valor será 0 (zero): ");
                    var quantidade = int.TryParse(Console.ReadLine(), out var rawQuantidade) ? rawQuantidade : 0;

                    Console.Write("Digite o preço do produto: R$");
                    var precoRaw = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(precoRaw))
                    {
                        throw new ArgumentException("Preço não pode ser vazio");
                    }

                    if (!decimal.TryParse(precoRaw.Replace(",", "."), out var preco))
                    {
                        throw new ArgumentException("Por favor insira um valor de preço válido");
                    };

                    var produto = new Produto(nome.Trim(), preco, quantidade);
                    produtosLista.Add(produto);

                    Console.WriteLine("PRODUTO INSERIDO COM SUCESSO!");
                    Console.WriteLine("Gostaria de adicionar mais um produto? S (Sim) ou N (Não)");
                    var opcao = Console.ReadLine().ToUpper();

                    if (opcao == "N")
                    {
                        Console.WriteLine("Salvando produtos salvos...");
                        GravarProdutosEmArquivo(produtosLista);
                        Console.WriteLine("Voltando ao menu...");
                        return;
                    }

                    if (opcao != "S" && opcao != "N")
                    {
                        Console.WriteLine("Opção Inválida! Voltando ao menu...");
                        Console.WriteLine("Salvando produtos salvos...");
                        GravarProdutosEmArquivo(produtosLista);
                        Thread.Sleep(5);
                        return;
                    }
                }
            }

            void GravarProdutosEmArquivo(List<Produto> lista)
            {
                var caminhoProjeto = Environment.CurrentDirectory.Split("bin");
                var caminhoArquivo = Path.Combine(caminhoProjeto[0], "estoque.txt");

                var produtosExistentes = GetProdutosDeArquivo();

                try
                {
                    using (var streamWriter = new StreamWriter(caminhoArquivo, true))
                    {
                        foreach (var produto in lista)
                        {
                            if (!produtosExistentes.Exists(p => p.Nome == produto.Nome))
                            {
                                streamWriter.WriteLine(
                                    $"{produto.GetNome()},{produto.GetQuantidade()},{produto.GetPreco(true):F2}");
                            }
                        }

                        streamWriter.Flush();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Menu();
                    throw;
                }
            }

            List<Produto> GetProdutosDeArquivo()
            {
                var caminhoProjeto = Environment.CurrentDirectory.Split("bin");
                var caminhoArquivo = Path.Combine(caminhoProjeto[0], "estoque.txt");

                var produtosListaVindosDoArquivo = new List<Produto>();
                using (var streamReader = new StreamReader(caminhoArquivo))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        var dadosProduto = line.Split(',');
                        var produto = new Produto(dadosProduto[0], Convert.ToDecimal(dadosProduto[2]),
                            int.Parse(dadosProduto[1]));
                        produtosListaVindosDoArquivo.Add(produto);
                    }
                }

                return produtosListaVindosDoArquivo;
            }

            void ListarProdutos()
            {
                var caminhoProjeto = Environment.CurrentDirectory.Split("bin");
                var caminhoArquivo = Path.Combine(caminhoProjeto[0], "estoque.txt");

                var checarArquivo = File.Exists(caminhoArquivo);

                if (!checarArquivo)
                {
                    using (File.Create(caminhoArquivo)) {}
                }

                var produtosListaVindosDoArquivo = new List<Produto>();
                using (var streamReader = new StreamReader(caminhoArquivo))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        var dadosProduto = line.Split(',');
                        var produto = new Produto(dadosProduto[0], Convert.ToDecimal(dadosProduto[2]),
                            int.Parse(dadosProduto[1]));
                        produtosListaVindosDoArquivo.Add(produto);
                    }
                }

                var tamanhoListaProdutos = produtosListaVindosDoArquivo.Count();

                Console.WriteLine("------------ LISTA DE PRODUTOS ------------");
                if (tamanhoListaProdutos == 0)
                {
                    Console.WriteLine("Nenhum produto cadastrado.");
                    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                    Console.ReadLine();
                    return;
                }

                foreach (var produto in produtosListaVindosDoArquivo)
                {
                    Console.WriteLine($"{produto.ToString()}");
                }


                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                Console.ReadLine();
            }

            void Menu()
            {
                var sistemaLigado = true;

                while (sistemaLigado)
                {
                    Console.Clear();
                    Console.WriteLine("------------ MENU DE PRODUTOS -------------");
                    Console.WriteLine("1 - Inserir Produto");
                    Console.WriteLine("2 - Listar Produtos");
                    Console.WriteLine("3 - Sair");

                    var opcao = int.Parse(Console.ReadLine());

                    switch (opcao)
                    {
                        case 1: InserirProduto(); break;
                        case 2: ListarProdutos(); break;
                        case 3:
                            Console.WriteLine("Saindo...");
                            sistemaLigado = false;
                            return;
                        default:
                            Console.WriteLine("Opção inválida! Voltando ao menu");
                            break;
                    }
                }
            }

            Menu();
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadLine();
            Exercicio9();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadLine();
            Exercicio9();
        }
    }
}