using System;

namespace ClubeLeitura
{
    internal partial class Program
    {
        static void Main(string[] args)
        {

            Caixa[] arrayCaixa = new Caixa[100];
            int indiceCaixa = 0;
            int controlaNumeroCaixa = 1;

            Revista[] arrayRevista = new Revista[100];
            int indiceRevista = 0;
            int controlaIdRevista = 1;

            Amigo[] arrayAmigo = new Amigo[100];
            int indiceAmigo = 0;
            int controleIdAmigo = 1;

            Emprestimo[] arrayEmprestimo = new Emprestimo[100];
            int indiceEmprestimo = 0;
            int controlaIdEmprestimo = 1;

            Reserva[] arrayReserva = new Reserva[100];
            int indiceReserva = 0;
            int controlaIdReserva = 1;

            //menu
            do
            {

                string opcaoMenu = ApresentaMenu();

                switch (opcaoMenu)
                {

                    case "1":
                        CadastrarRevista(arrayRevista, arrayCaixa, ref indiceRevista, ref controlaIdRevista);
                        break;
                    case "2":
                        ExibirRevistasCadastradas(arrayRevista);
                        break;
                    case "3":
                        CadastrarCaixa(arrayCaixa, ref indiceCaixa, ref controlaNumeroCaixa);
                        break;
                    case "4":
                        ExibirCaixasCadastradas(arrayCaixa);
                        break;
                    case "5":
                        CadastrarAmigo(arrayAmigo, ref indiceAmigo, ref controleIdAmigo);
                        break;
                    case "6":
                        ExibirAmigosCadastrados(arrayAmigo);
                        break;
                    case "7":
                        CadastrarEmprestimo(arrayEmprestimo, arrayRevista, arrayAmigo, ref indiceEmprestimo, ref controlaIdEmprestimo);
                        break;

                    case "8":
                        ExibirEmprestimo(arrayEmprestimo);
                        break;

                    case "9":
                        EditarEmprestimo(arrayEmprestimo, arrayAmigo);
                        break;


                    case "10":
                        string opcaoMenuReserva = menuReserva();
                        if (opcaoMenuReserva == "1")
                        {
                            CadastrarReserva(arrayReserva, arrayEmprestimo, arrayAmigo, arrayRevista, ref indiceReserva, ref controlaIdReserva);

                        }
                        else if (opcaoMenuReserva == "2")
                        {
                            ExibirReservas(arrayReserva);
                        } else if (opcaoMenuReserva == "3"){
                            EmprestimoReserva(arrayReserva, arrayEmprestimo, ref indiceEmprestimo, ref controlaIdEmprestimo);

                        }

                        break;

                    default:
                        Console.Clear();

                        break;
                };
            } while (true);
        }

        //metodos
        static string ApresentaMenu()
        {
            ApresentaMensagem("Clube da Leitura", ConsoleColor.Blue);
            string opcaoMenu;
            Console.WriteLine("" +
                "\n1 - Cadastrar Revista" +
                "\n2 - Visualizar as Revistas Cadastradas" +
                "\n3 - Cadastrar Caixa" +
                "\n4 - Visualizar as Caixas Cadastradas" +
                "\n5 - Cadastrar Amigo" +
                "\n6 - Visualizar os Amigos Cadastrados" +
                "\n7 - Cadastrar Emprestimo" +
                "\n8 - Visualizar os Emprestimentos Cadastrados" +
                "\n9 - Editar Emprestimo" +
                "\n10 - RESERVA");

            ApresentaMensagem("Escolha uma opção: ", ConsoleColor.Blue);
            opcaoMenu = Console.ReadLine();
            return opcaoMenu;
        }

        static void CadastrarCaixa(Caixa[] arrayCaixa, ref int indiceCaixa, ref int controlaNumeroCaixa)
        {
            ApresentaMensagem("\n\t3 - Cadastrar Caixa", ConsoleColor.Cyan);

            string corCaixa, etiquetaCaixa;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Número da Caixa: " + controlaNumeroCaixa);
            Console.ResetColor();

            Console.Write("Digite a Cor: ");
            corCaixa = Console.ReadLine();
            Console.Write("Digite a Etiqueta: ");
            etiquetaCaixa = Console.ReadLine();

            Caixa caixa = new Caixa();
            caixa.cor = corCaixa;
            caixa.etiqueta = etiquetaCaixa;
            caixa.numero = controlaNumeroCaixa;
            arrayCaixa[indiceCaixa] = caixa;

            indiceCaixa++;
            controlaNumeroCaixa++;

            ApresentaMensagem("Caixa cadastrada com sucesso!", ConsoleColor.Green);
            Console.ReadLine();
            Console.Clear();

        }

        static void ExibirCaixasCadastradas(Caixa[] arrayCaixa)
        {
            ApresentaMensagem("\n\t4 - Visualizar as Caixas Cadastradas", ConsoleColor.Cyan);

            if (arrayCaixa[0] == null)
            {
                ApresentaMensagem("Não há caixas cadastradas", ConsoleColor.Yellow);
            }
            else
            {
                Console.WriteLine("{0,-10} | {1,-10} | {2,-10}", "Numero", "Cor", "Etiqueta");
                Console.WriteLine("------------------------------------------------");

                for (int i = 0; i < arrayCaixa.Length; i++)
                {

                    if (arrayCaixa[i] == null)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("{0,-10} | {1,-10} | {2,-10}", arrayCaixa[i].numero, arrayCaixa[i].cor, arrayCaixa[i].etiqueta);
                    }
                }
            }
            Console.ReadLine();
            Console.Clear();
        }

        static void CadastrarRevista(Revista[] arrayRevista, Caixa[] arrayCaixa, ref int indiceRevista, ref int controlaIdRevista)
        {
            #region variaveis
            string tipoColecaoRevista, anoRevista;
            int numeroEdicaoRevista;
            int numeroCaixa;
            bool caixaExiste = false;
            #endregion

            ApresentaMensagem("\n\t1 - Cadastrar Revista", ConsoleColor.Cyan);



            Console.Write("Coleção: ");
            tipoColecaoRevista = Console.ReadLine();
            Console.Write("Edição Número:  ");
            numeroEdicaoRevista = int.Parse(Console.ReadLine());
            Console.Write("Ano: ");
            anoRevista = Console.ReadLine();

            Revista revista = new Revista();
            revista.idRevista = controlaIdRevista;
            revista.tipoColecaoRevista = tipoColecaoRevista;
            revista.numeroEdicaoRevista = numeroEdicaoRevista;
            revista.anoRevista = anoRevista;


            while (caixaExiste == false)
            {
                Console.WriteLine("Número da Caixa: ");
                numeroCaixa = int.Parse(Console.ReadLine());

                for (int i = 0; i < arrayCaixa.Length; i++)
                {
                    if (arrayCaixa[i] != null && numeroCaixa == arrayCaixa[i].numero)
                    {
                        revista.caixaRevista = arrayCaixa[i];
                        caixaExiste = true;
                        break;

                    }

                }
            }

            arrayRevista[indiceRevista] = revista;
            controlaIdRevista++;
            indiceRevista++;

            ApresentaMensagem("Revista cadastrada com sucesso!", ConsoleColor.Green);

            Console.ReadLine();
            Console.Clear();
        }

        static void ExibirRevistasCadastradas(Revista[] arrayRevista)
        {
            ApresentaMensagem("\n\t2 - Visualizar as Revistas Cadastradas", ConsoleColor.Cyan);

            if (arrayRevista[0] == null)
            {
                ApresentaMensagem("Não há revistas cadastradas", ConsoleColor.Yellow);
            }
            else
            {

                Console.WriteLine("{0,-5} | {1,-20} | {2,-10} | {3,-10} | {4,-10}", "ID", "Coleção", "Edição", "Ano", "Caixa");

                Console.WriteLine("-----------------------------------------------------------------");

                for (int i = 0; i < arrayRevista.Length; i++)
                {
                    if (arrayRevista[i] == null)
                    {
                        break;
                    }
                    else
                    {

                        Console.WriteLine("{0,-5} | {1,-20} | {2,-10} | {3,-10} | {4,-10}", arrayRevista[i].idRevista, arrayRevista[i].tipoColecaoRevista, arrayRevista[i].numeroEdicaoRevista, arrayRevista[i].anoRevista, arrayRevista[i].caixaRevista.cor);

                    }
                }
            }

            Console.ReadLine();
            Console.Clear();
        }

        static void CadastrarAmigo(Amigo[] arrayAmigo, ref int indiceAmigo, ref int controlaIdAmigo)
        {
            string nomeAmigo, nomeResponsavelAmigo, telefoneAmigo, enderecoAmigo;

            ApresentaMensagem("\n\t5 - Cadastrar Amigo", ConsoleColor.Cyan);


            Console.WriteLine("ID: " + controlaIdAmigo);

            Console.Write("Nome: ");
            nomeAmigo = Console.ReadLine();
            Console.Write("Responsável: ");
            nomeResponsavelAmigo = Console.ReadLine();
            Console.Write("Telefone: ");
            telefoneAmigo = Console.ReadLine();
            Console.Write("Endereço: ");
            enderecoAmigo = Console.ReadLine();

            Amigo amigo = new Amigo();
            amigo.idAmigo = controlaIdAmigo;
            amigo.nomeAmigo = nomeAmigo;
            amigo.nomeResponsavel = nomeResponsavelAmigo;
            amigo.telefone = telefoneAmigo;
            amigo.endereco = enderecoAmigo;
            arrayAmigo[indiceAmigo] = amigo;

            indiceAmigo++;
            controlaIdAmigo++;
            ApresentaMensagem("Amigo cadastrado com sucesso!", ConsoleColor.Green);
            Console.ReadLine();
            Console.Clear();

        }

        static void ExibirAmigosCadastrados(Amigo[] arrayAmigo)
        {
            ApresentaMensagem("\n\t 6 - Visualizar os Amigos Cadastrados", ConsoleColor.Cyan);


            if (arrayAmigo[0] == null)
            {
                ApresentaMensagem("Não há amigos cadastrados", ConsoleColor.Yellow);
            }
            else
            {
                Console.WriteLine("{0,-10} | {1,-10} | {2,-15} | {3,-10} | {4,-10}", "ID", "Nome", "Responsavel", "Telefone", "Endereço");
                Console.WriteLine("---------------------------------------------------------------------------------");
                for (int i = 0; i < arrayAmigo.Length; i++)
                {
                    if (arrayAmigo[i] == null)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("{0,-10} | {1,-10} | {2,-15} | {3,-10} | {4,-10}", arrayAmigo[i].idAmigo, arrayAmigo[i].nomeAmigo, arrayAmigo[i].nomeResponsavel, arrayAmigo[i].telefone, arrayAmigo[i].endereco);

                    }
                }
            }

            Console.ReadLine();
            Console.Clear();
        }

        static void CadastrarEmprestimo(Emprestimo[] arrayEmprestimo, Revista[] arrayRevista, Amigo[] arrayAmigo, ref int indiceEmprestimo, ref int controlaIdEmprestimo)
        {
            int idAmigo, idRevista;
            bool amigoExiste = false;
            bool revistaExiste = false;

            ApresentaMensagem("\n\t7 - Cadastrar Emprestimo", ConsoleColor.Cyan);


            Emprestimo emprestimo = new Emprestimo();
            emprestimo.idEmprestimo = controlaIdEmprestimo;

            while (amigoExiste == false)
            {
                Console.Write("ID do Amigo: ");
                idAmigo = int.Parse(Console.ReadLine());

                for (int i = 0; i < arrayAmigo.Length; i++)
                {
                    if (arrayAmigo[i] != null && arrayAmigo[i].idAmigo == idAmigo)
                    {
                        emprestimo.nome = arrayAmigo[i];
                        amigoExiste = true;
                        break;
                    }

                }
            }

            while (revistaExiste == false)
            {
                Console.Write("ID da Revista: ");
                idRevista = int.Parse(Console.ReadLine());

                for (int y = 0; y < arrayRevista.Length; y++)
                {
                    if (arrayRevista[y] != null && idRevista == arrayRevista[y].idRevista)
                    {
                        emprestimo.revista = arrayRevista[y];
                        revistaExiste = true;
                        break;
                    }

                }
            }


            #region data emprestimo
            int dia, mes, ano;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Data do Emprestimo");
            Console.ResetColor();
            Console.Write("Dia (DD): ");
            dia = int.Parse(Console.ReadLine());
            Console.Write("Mês (MM): ");
            mes = int.Parse(Console.ReadLine());
            Console.Write("Ano (AAAA): ");
            ano = int.Parse(Console.ReadLine());

            DateTime date = new DateTime(ano, mes, dia);

            emprestimo.dataEmprestimo = Convert.ToString(date);
            #endregion

            #region data devolucao
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Data de Devolução");
            Console.ResetColor();
            Console.Write("Dia (DD): ");
            dia = int.Parse(Console.ReadLine());
            Console.Write("Mês (MM): ");
            mes = int.Parse(Console.ReadLine());
            Console.Write("Ano (AAAA): ");
            ano = int.Parse(Console.ReadLine());

            DateTime devolucao = new DateTime(ano, mes, dia);

            emprestimo.dataDevolucao = Convert.ToString(devolucao);


            #endregion

            arrayEmprestimo[indiceEmprestimo] = emprestimo;

            indiceEmprestimo++;
            controlaIdEmprestimo++;

            ApresentaMensagem("Emprestimo cadastrado com sucesso", ConsoleColor.Green);
            Console.ReadLine();
        }

        static void ExibirEmprestimo(Emprestimo[] arrayEmprestimo)
        {
            string opcao;
            ApresentaMensagem("\n\t8 - Visualizar os Emprestimentos Cadastrados", ConsoleColor.Cyan);
            Console.WriteLine("Filtros: 1 - Emprestimos em Aberto; 2 - Filtrar por Mês");

            if (arrayEmprestimo[0] == null)
            {
                ApresentaMensagem("\nNão há emprestimos", ConsoleColor.Yellow);
            }
            else
            {
                #region TODOS OS EMPRESTIMOS 
                Console.WriteLine("\n\t # Exibindo todos os emprestimos cadastrados\n");
                Console.WriteLine("{0,-5} | {1,-10} | {2,-8} | {3,-20} | {4,-20} | {5,-10}", "ID", "Amigo", "Revista", "Data Emprestimo", "Data Devolução", "Status Devolução");
                Console.WriteLine("---------------------------------------------------------------------------------");

                for (int i = 0; i < arrayEmprestimo.Length; i++)
                {
                    if (arrayEmprestimo[i] == null)
                    {
                        break;
                    }
                    string status;
                    if (arrayEmprestimo[i] != null && arrayEmprestimo[i].statusDevolucao == false)
                    {
                        status = "Pendente";
                    }
                    else
                    {
                        status = "Devolvido";
                    }
                    Console.WriteLine("{0,-5} | {1,-10} | {2,-8} | {3,-20} | {4,-20} | {5,-10}", arrayEmprestimo[i].idEmprestimo, arrayEmprestimo[i].nome.nomeAmigo, arrayEmprestimo[i].revista.tipoColecaoRevista, arrayEmprestimo[i].dataEmprestimo, arrayEmprestimo[i].dataDevolucao, status);

                }
                #endregion

                Console.Write("\nEscolher filtro: ");
                opcao = Console.ReadLine();

                #region EMPRESTIMOS EM ABERTO

                if (opcao == "1")
                {
                    Console.WriteLine("\n\t # Empréstimos em Aberto\n");
                    Console.WriteLine("{0,-5} | {1,-10} | {2,-8} | {3,-20} | {4,-20} | {5,-10}", "ID", "Amigo", "Revista", "Data Emprestimo", "Data Devolução", "Status Devolução");
                    Console.WriteLine("---------------------------------------------------------------------------------");

                    for (int y = 0; y < arrayEmprestimo.Length; y++)
                    {
                        if (arrayEmprestimo[y] == null)
                        {
                            break;
                        }
                        else
                        {

                            if (arrayEmprestimo[y] != null && arrayEmprestimo[y].statusDevolucao == false)
                            {

                                Console.WriteLine("{0,-5} | {1,-10} | {2,-8} | {3,-20} | {4,-20} | {5,-10}",
                                    arrayEmprestimo[y].idEmprestimo, arrayEmprestimo[y].nome.nomeAmigo,
                                    arrayEmprestimo[y].revista.tipoColecaoRevista, arrayEmprestimo[y].dataEmprestimo,
                                    arrayEmprestimo[y].dataDevolucao, "Pendente");

                            }

                        }


                    }
                }
                #endregion


                //filtro mes
                //to do
            }
            Console.ReadLine();
            Console.Clear();
        }

        static void EditarEmprestimo(Emprestimo[] arrayEmprestimo, Amigo[] arrayAmigo)
        {
            Console.WriteLine("Registrar Devolução");

            int id;
            string data;

            Console.WriteLine("Digite o ID do emprestimo");
            id = int.Parse(Console.ReadLine());

            for (int i = 0; i < arrayEmprestimo.Length; i++)
            {

                if (arrayEmprestimo[i] != null && arrayEmprestimo[i].idEmprestimo == id)
                {
                    int opcao;
                    Console.WriteLine("Digite 1 para confirmar a Devolução da Revista ou 0 para sair ");
                    opcao = int.Parse(Console.ReadLine());
                    if (opcao == 1)
                    {
                        arrayEmprestimo[i].statusDevolucao = true;

                    }
                    else
                    {
                        break;
                    }
                }

            }

            ApresentaMensagem("Devolução registrada!", ConsoleColor.Green);
            Console.ReadLine();
            Console.Clear();
        }

        static string menuReserva()
        {
            Console.WriteLine("RESERVA");
            Console.WriteLine("1 - Cadastrar Reserva | 2 - Visualizar Reservas | 3 - Efetuar Empréstimo");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();
            return opcao;
        }

        static void CadastrarReserva(Reserva[] arrayReserva, Emprestimo[] arrayEmprestimo,
            Amigo[] arrayAmigo, Revista[] arrayRevista,
            ref int indiceReserva, ref int controlaIdReserva)
        {
            Console.WriteLine("Cadastrar Reserva");
            bool amigoExiste = false;
            bool revistaExiste = false;
            int idAmigo;
            int idRevista;

            Reserva reserva = new Reserva();
            reserva.idReserva = controlaIdReserva;

            //amigo
            while (amigoExiste == false)
            {
                Console.Write("ID do Amigo: ");
                idAmigo = int.Parse(Console.ReadLine());

                for (int i = 0; i < arrayAmigo.Length; i++)
                {
                    if (arrayAmigo[i] != null && arrayAmigo[i].idAmigo == idAmigo)
                    {
                        reserva.nome = arrayAmigo[i];
                        amigoExiste = true;
                        break;
                    }

                }
            }
            //reserva
            while (revistaExiste == false)
            {
                Console.Write("ID da Revista: ");
                idRevista = int.Parse(Console.ReadLine());

                for (int y = 0; y < arrayRevista.Length; y++)
                {
                    if (arrayRevista[y] != null && idRevista == arrayRevista[y].idRevista)
                    {
                        reserva.revista = arrayRevista[y];
                        revistaExiste = true;
                        break;
                    }

                }
            }

            reserva.dataReserva = DateTime.Now;
            //prazo
            DateTime prazoReserva = DateTime.Now;

            reserva.prazoReserva = prazoReserva.AddDays(2);

            reserva.statusReserva = "Válida";

            arrayReserva[indiceReserva] = reserva;

            controlaIdReserva++;
            indiceReserva++;

        }

        static void ExibirReservas(Reserva[] arrayReserva)
        {
            Console.WriteLine("EXIBIR Reserva");

            for (int i = 0; i < arrayReserva.Length; i++)
            {
                if (arrayReserva[i] == null)
                {
                    break;
                }
                else
                {
                    //verifique se já passou 2 dias e atualiza status da reserva

                    DateTime hoje = new DateTime();
                    hoje = DateTime.Now;

                    if(arrayReserva[i].statusReserva == "Válida" && hoje.Day  > arrayReserva[i].dataReserva.Day)
                    {
                        arrayReserva[i].statusReserva = "Expirada";
                    }

                    Console.WriteLine("ID: " + arrayReserva[i].idReserva + "AMIGO: " + arrayReserva[i].nome.nomeAmigo +
                        "REVISTA: " + arrayReserva[i].revista.idRevista +
                        "DATA RESERVA: " + arrayReserva[i].dataReserva + "PRAZO RESERVA "+arrayReserva[i].prazoReserva+"STATUS RESERVA " + arrayReserva[i].statusReserva);
                }
            }
            Console.ReadLine();
        }

        static void EmprestimoReserva(Reserva[] arrayReserva, Emprestimo[] arrayEmprestimo, ref int indiceEmprestimo, ref int controlaIdEmprestimo)
        {
            Console.WriteLine("Digite o ID da Reserva: ");
            int idReserva = int.Parse(Console.ReadLine());

            for (int i = 0; i < arrayReserva.Length; i++)
            {

                if (arrayReserva[i] != null && arrayReserva[i].idReserva == idReserva && arrayReserva[i].statusReserva == "Válida")
                {
                    Emprestimo emprestimo = new Emprestimo();
                    emprestimo.idEmprestimo = controlaIdEmprestimo;
                    emprestimo.nome = arrayReserva[i].nome;
                    emprestimo.revista = arrayReserva[i].revista;

                    Console.WriteLine("Digite a data do emprestimo: ");
                    string dataEmprestimo = Console.ReadLine();
                    Console.WriteLine("Digite a data de devolução: ");
                    string dataDevolucao = Console.ReadLine();

                    emprestimo.dataEmprestimo = dataEmprestimo;
                    emprestimo.dataDevolucao = dataDevolucao;

                    arrayEmprestimo[indiceEmprestimo] = emprestimo;

                    arrayReserva[i].statusReserva = "Finalizada";
                    indiceEmprestimo++;
                    controlaIdEmprestimo++;
                }

            }
        }

        //style



        static void ApresentaMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            Console.ResetColor();
        }
    }


}


