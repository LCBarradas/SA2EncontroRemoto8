//See https://aka.ms/new-console-template for more information

using BE5.Classes;

Console.WriteLine(@$"
=================================================================================================================
|                                   Bem Vindo ao sistema de cadastro de                                         |
|                                       Pessoas Fisicas e Jurídicas                                             |
=================================================================================================================
");

BarraCarregamento("Carregando", 500);

List<PessoaFisica> listaPf = new List<PessoaFisica>();
List<PessoaJuridica> listaPj = new List<PessoaJuridica>();


string? opcao;
do
{
    Console.Clear();
    Console.WriteLine(@$"
    
=================================================================================================================
|                                   Escolha uma das Opções abaixo                                               |
|---------------------------------------------------------------------------------------------------------------|
|                                         1- Pessoa Física                                                      |
|                                         2- Pessoa Jurídica                                                    |
|                                                                                                               |
|                                         0- Sair                                                               |
=================================================================================================================

");

    opcao = Console.ReadLine();

    switch (opcao)
    {
        case "0":
            Console.Clear();
            Console.WriteLine($"Obrigado por utilizar nosso sistema!!!");
            BarraCarregamento("Finalizando", 400);
            break;

        case "1":
            PessoaFisica metodoPf = new PessoaFisica();

            string? opcaoPf;
            do
            {
                Console.Clear();
                Console.WriteLine(@$"
=================================================================================================================
|                                   Escolha uma das Opções abaixo                                               |
|---------------------------------------------------------------------------------------------------------------|
|                                         1- Cadastrar Pessoa Física                                            |
|                                         2- Mostrar Pessoa Física                                              |
|                                                                                                               |
|                                         0- Voltar para menu anterior                                          |
=================================================================================================================

");
                opcaoPf = Console.ReadLine();

                switch (opcaoPf)
                {
                    case "1":

                        PessoaFisica novaPf = new PessoaFisica();
                        Endereco novoEnd = new Endereco();

                        Console.WriteLine($"Digite o nome da pessoa física de deseja cadastrar.");
                        novaPf.nome = Console.ReadLine();
                        
                        bool dataValida;
                        do
                        {
                            Console.WriteLine($"Digite a data de nascimento. EX .:DD/MM/AAAA");
                            string dataNasc = Console.ReadLine();


                            dataValida = metodoPf.ValidarDataNascimento(dataNasc);
                            if (dataValida)
                            {
                                novaPf.dataNascimento = dataNasc;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine($"Data digitada inválida por favor digite uma data válida");
                                Console.ResetColor();
                            }
                        } while (dataValida == false);

                        Console.WriteLine($"Digite o número do CPF");
                        novaPf.cpf = Console.ReadLine();

                        Console.WriteLine($"Digite o rendimento mensal (digite apenas números)");
                        novaPf.rendimento = float.Parse(Console.ReadLine());

                        Console.WriteLine($"dite o logradouro");
                        novoEnd.logadouro = Console.ReadLine();

                        Console.WriteLine($"Digite o número");
                        novoEnd.numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o complemento (Aperte ENTER para vazio)");
                        novoEnd.complemento = Console.ReadLine();

                        Console.WriteLine($"Este endereço é comercial? S/N");
                        string endCom = Console.ReadLine().ToUpper();
                        if (endCom == "S")
                        {
                            novoEnd.endComercial = true;
                        }
                        else
                        {
                            novoEnd.endComercial = false;
                        }
                        novaPf.endereco = novoEnd;
                        listaPf.Add(novaPf);
                        //StreamWriter sw = new StreamWriter($"{novaPf.nome}.txt");
                        //sw.WriteLine(novaPf.nome);
                        //sw.Close();
                        

                        using (StreamWriter sw = new StreamWriter($"{novaPf.nome}.txt"))
                        {
                            sw.WriteLine(novaPf.nome);
                        }




                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"Cadastro Realizado com sucesso!!!");
                        Thread.Sleep(3000);
                        Console.ResetColor();
                        break;

                    case "2":
                        Console.Clear();

                        
                        if (listaPf.Count > 0)
                        {
                            foreach (PessoaFisica cadaPessoa in listaPf)
                            {
                                Console.Clear();
                                Console.WriteLine(@$"
                                Nome: {cadaPessoa.nome}
                                Endereco: {cadaPessoa.endereco.logadouro},{cadaPessoa.endereco.numero}
                                Data de nascimento: {cadaPessoa.dataNascimento}
                                Taxa De Imposto a ser paga é: {metodoPf.PagarImposto(cadaPessoa.rendimento).ToString("C")}
                                ");
                                Console.WriteLine($"Aperte Enter para continuar...");
                                Console.ReadLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Lista Vazia!!!");
                            Thread.Sleep(3000);

                        }
                        
                         using (StreamReader sr = new StreamReader("Luiz Carlos Barradas.txt"))
                        {
                            string linha;
                            while ((linha = sr.ReadLine()) != null)
                            {
                                Console.WriteLine($"{linha}");
                            }
                        }
                        Console.WriteLine($"Aperte ENTER para continuar....");
                        Console.ReadLine();
                        

                        break;
                    case "0":
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine($"Opção Inválida, por favor digite outra opçao.");
                        Thread.Sleep(2000);
                        break;
                }


            } while (opcaoPf != "0");

            break;

        case "2":

            PessoaJuridica metodoPj = new PessoaJuridica();

            string? opcaoPj;
            do
            {
                Console.Clear();
                Console.WriteLine(@$"
=================================================================================================================
|                                      Escolha uma das Opções abaixo                                            |
|---------------------------------------------------------------------------------------------------------------|
|                                        1- Cadastrar Pessoa Jurídica                                           |
|                                        2- Mostrar Pessoa Jurídica                                             |
|                                                                                                               |
|                                        0- Voltar para menu anterior                                           |
=================================================================================================================

");

                opcaoPj = Console.ReadLine();

                switch (opcaoPj)
                {
                    case "1":

                        PessoaJuridica novaPJ = new PessoaJuridica();
                        Endereco novoEndpj = new Endereco();


                        Console.WriteLine($"Digite o nome da pessoa Jurídica que deseja cadastrar.");
                        novaPJ.nome = Console.ReadLine();

                        bool cnpjValido;
                        do
                        {
                            Console.WriteLine($"Digite o CNPJ");
                            string numCnpj = Console.ReadLine();

                            cnpjValido = metodoPj.ValidarCnpj(numCnpj);
                            if (cnpjValido)
                            {
                                novaPJ.cnpj = numCnpj;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine($"CNPJ inválido por favor digite um CNPJ válido");
                                Console.ResetColor();
                            }

                        } while (cnpjValido == false);

                        Console.WriteLine($"Digite a Razão Social.");
                        novaPJ.razao = Console.ReadLine();


                        Console.WriteLine($"Digite o Rendimento.");
                        novaPJ.rendimento = float.Parse(Console.ReadLine());

                        Console.WriteLine($"dite o logradouro");
                        novoEndpj.logadouro = Console.ReadLine();

                        Console.WriteLine($"Digite o número");
                        novoEndpj.numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o complemento (Aperte ENTER para vazio)");
                        novoEndpj.complemento = Console.ReadLine();

                        Console.WriteLine($"Este endereço é comercial? S/N");
                        string endCom = Console.ReadLine().ToUpper();
                        if (endCom == "S")
                        {
                            novoEndpj.endComercial = true;
                        }
                        else
                        {
                            novoEndpj.endComercial = false;
                        }

                        novaPJ.endereco = novoEndpj;

                        metodoPj.Inserir(novaPJ);

                        List<PessoaJuridica> ListaPj = metodoPj.Ler();

                        foreach (PessoaJuridica cadaItem in listaPj)
                        {
                        listaPj.Add(novaPJ);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"Cadastro Realizado com sucesso!!!");
                        Thread.Sleep(3000);
                        Console.ResetColor();
                        }

                       
                        break;

                    case "2":
                    
                        Console.Clear();
                        if (listaPj.Count > 0)
                        {
                            foreach (PessoaJuridica cadaPessoapj in listaPj)
                            {
                                Console.Clear();
                                Console.WriteLine(@$"
                                    Nome: {cadaPessoapj.nome}
                                    Endereco: {cadaPessoapj.endereco.logadouro},{cadaPessoapj.endereco.numero}
                                    CNPJ: {cadaPessoapj.cnpj}
                                    Taxa De Imposto a ser paga é: {metodoPj.PagarImposto(cadaPessoapj.rendimento).ToString("C")}
                                    ");
                                Console.WriteLine($"Aperte Enter para continuar...");
                                Console.ReadLine();
                            }

                        }
                        else
                        {
                            Console.WriteLine($"Lista Vazia!!!");
                            Thread.Sleep(3000);
                        }
                        break;

                    case "0":
                    
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine($"Opção Inválida, por favor digite outra opçao.");
                        Thread.Sleep(2000);
                        break;
                }
            } while (opcaoPj != "0");
            break;
    }
} while (opcao != "0");





static void BarraCarregamento(string texto, int tempo)
{
    Console.BackgroundColor = ConsoleColor.DarkCyan;
    Console.ForegroundColor = ConsoleColor.Red;

    Console.Write($"{texto} ");

    for (var contador = 0; contador < 10; contador++)
    {
        Console.Write(". ");
        Thread.Sleep(tempo);
    }

    Console.ResetColor();
}









