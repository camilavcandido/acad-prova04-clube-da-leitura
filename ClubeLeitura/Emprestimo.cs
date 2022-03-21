using System;
namespace ClubeLeitura
{
    public class Emprestimo
    {
        public int idEmprestimo;
        public Amigo nome;
        public Revista revista;
        public DateTime dataEmprestimo;
        public DateTime dataDevolucao;
        public DateTime dataDevolucaoRealizada;
        public string statusDevolucao;

        public void CadastrarEmprestimo(Emprestimo[] arrayEmprestimo, Revista[] arrayRevista, Amigo[] arrayAmigo, ref int indiceEmprestimo, ref int controlaIdEmprestimo)
        {
            int idAmigo, idRevista;
            bool amigoExiste = false;
            bool revistaExiste = false;
            bool amigoPossuiMulta = false;
            Notificador.ApresentarTitulo("\n\t1 - Cadastrar Emprestimo");

            Emprestimo emprestimo = new Emprestimo();
            emprestimo.idEmprestimo = controlaIdEmprestimo;

            Console.Write("ID do Amigo: ");
            idAmigo = int.Parse(Console.ReadLine());

            for (int i = 0; i < arrayAmigo.Length; i++)
            {
                if (arrayAmigo[i] != null && arrayAmigo[i].idAmigo == idAmigo && arrayAmigo[i].possuiMulta == true)
                {
                    amigoPossuiMulta = true;

                    if (amigoPossuiMulta)
                    {
                        Notificador.ApresentarMensagem("Amigo possuí multa em aberto", ConsoleColor.Red);
                        break;
                    }
                }
                else if (arrayAmigo[i] != null && arrayAmigo[i].idAmigo == idAmigo)
                {
                    emprestimo.nome = arrayAmigo[i];
                    amigoExiste = true;
                    break;
                }
            }

            if (amigoExiste)
            {

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

                DateTime dataEmprestimo = new DateTime();
                Console.Write("Data do Emprestimo (DD/MM/AAAA): ");
                dataEmprestimo = Convert.ToDateTime(Console.ReadLine());
                emprestimo.dataEmprestimo = dataEmprestimo;

                DateTime dataDevolucao = new DateTime();


                int dias;
                for (int i = 0; i < arrayRevista.Length; i++)
                {
                    if (arrayRevista[i] != null)
                    {
                        dias = arrayRevista[i].categoriaRevista.quantidadeDiasEmprestimo;
                        dataDevolucao = dataEmprestimo.AddDays(dias);
                        emprestimo.dataDevolucao = dataDevolucao;

                    }
                }

                Console.Write("Data de Devolução (DD/MM/AAAA): {0}", dataDevolucao);
                emprestimo.statusDevolucao = "Pendente";

                arrayEmprestimo[indiceEmprestimo] = emprestimo;

                indiceEmprestimo++;
                controlaIdEmprestimo++;

                Notificador.ApresentarMensagem("\nEmprestimo cadastrado com sucesso", ConsoleColor.Green);
            }
            Console.ReadLine();
            Console.Clear();
        }
        public void ExibirEmprestimo(Emprestimo[] arrayEmprestimo)
        {
            string opcao;
            Notificador.ApresentarTitulo("\n1 - Visualizar os Emprestimentos Cadastrados");

            if (arrayEmprestimo[0] == null)
            {
                Notificador.ApresentarMensagem("\nNão há emprestimos", ConsoleColor.Yellow);
            }
            else
            {
                Console.WriteLine("| 1 - Todos os Emprestimos \n| 2 - Emprestimos com devolução pendente \n| 3 - Filtrar por Mês");

                Console.Write("Escolha uma opção: ");
                opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1":
                        ExibirTodosEmprestimos(arrayEmprestimo);
                        break;
                    case "2":
                        ExibirEmprestimosPendentes(arrayEmprestimo);
                        break;
                    case "3":
                    ExibirEmprestimosMes(arrayEmprestimo);
                    break;
            }
        }
        Console.ReadLine();
            Console.Clear();
        }
        public void RegistrarDevolucao(Emprestimo[] arrayEmprestimo, Amigo[] arrayAmigo, Multa[] arrayMulta, ref int indiceMulta, ref int controlaIdMulta)
        {
            bool emprestimoExiste = false;
            int id;

            Notificador.ApresentarTitulo("\n3 - Registrar Devolução");


            Console.Write("Digite o ID do emprestimo: ");
            id = int.Parse(Console.ReadLine());

            for (int a = 0; a < arrayEmprestimo.Length; a++)
            {
                if (arrayEmprestimo[a] != null && arrayEmprestimo[a].idEmprestimo == id)
                {
                    emprestimoExiste = true;
                    break;
                }

            }

            if (emprestimoExiste)
            {
                for (int i = 0; i < arrayEmprestimo.Length; i++)
                {

                    if (arrayEmprestimo[i] != null && arrayEmprestimo[i].idEmprestimo == id)
                    {
                        int opcao;
                        DateTime devolucaoRealizada = new DateTime();
                        Console.WriteLine("Devolução realizada em (DD/MM/AAAA): ");
                        devolucaoRealizada = Convert.ToDateTime(Console.ReadLine());

                        Console.WriteLine("Digite 1 para confirmar a Devolução da Revista ou 0 para sair ");
                        opcao = int.Parse(Console.ReadLine());
                        if (opcao == 1)
                        {
                            arrayEmprestimo[i].dataDevolucaoRealizada = devolucaoRealizada;

                            if (arrayEmprestimo[i].dataDevolucao < devolucaoRealizada)
                            {
                                arrayEmprestimo[i].statusDevolucao = "Atrasada";

                                //adiciona Multa no arrayMulta
                                Multa multa = new Multa();
                                multa.idMulta = controlaIdMulta;
                                multa.emprestimo = arrayEmprestimo[i];
                                multa.statusMulta = true;
                                arrayMulta[indiceMulta] = multa;
                                //adiciona Multa no array Amigo;
                                for (int x = 0; x < arrayAmigo.Length; x++)
                                {
                                    if (arrayAmigo[x] == null)
                                    {
                                        break;
                                    }
                                    else if (arrayAmigo[x].idAmigo == arrayEmprestimo[i].nome.idAmigo)
                                    {
                                        arrayAmigo[x].possuiMulta = true;
                                    }

                                }
                            }
                            else if (devolucaoRealizada <= arrayEmprestimo[i].dataDevolucao)
                            {
                                arrayEmprestimo[i].statusDevolucao = "No Prazo";

                            }
                            break;
                        }


                    }


                }
                Notificador.ApresentarMensagem("Devolução registrada!", ConsoleColor.Green);

            }

            if (emprestimoExiste == false)
            {
                Notificador.ApresentarMensagem("ID inválido", ConsoleColor.Red);
            }
            Console.ReadLine();
            Console.Clear();
        }
        public void ExibirTodosEmprestimos(Emprestimo[] arrayEmprestimo)
        {

           Notificador.ApresentarTitulo("\n\t #1  Todos os empréstimos cadastrados\n");
            Console.WriteLine("{0,-5} | {1,-10} | {2,-8} | {3,-20} | {4,-20} | {5,-10}",
                "ID", "Amigo", "Revista", "Data Emprestimo", "Data Devolução", "Status");
            Console.WriteLine("-------------------------------------------------------------------------------------------");

            for (int i = 0; i < arrayEmprestimo.Length; i++)
            {
                if (arrayEmprestimo[i] == null)
                {
                    break;
                }

                Console.WriteLine("{0,-5} | {1,-10} | {2,-8} | {3,-20} | {4,-20} | {5,-10}",
                    arrayEmprestimo[i].idEmprestimo, arrayEmprestimo[i].nome.nomeAmigo,
                    arrayEmprestimo[i].revista.idRevista, arrayEmprestimo[i].dataEmprestimo,
                    arrayEmprestimo[i].dataDevolucao, arrayEmprestimo[i].statusDevolucao);

            }
        }
        public void ExibirEmprestimosPendentes(Emprestimo[] arrayEmprestimo)
        {
            Notificador.ApresentarTitulo("\n\t #2 Empréstimos com devolução Pendente\n");
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

                    if (arrayEmprestimo[y] != null && arrayEmprestimo[y].statusDevolucao == "Pendente")
                    {


                        Console.WriteLine("{0,-5} | {1,-10} | {2,-8} | {3,-20} | {4,-20} | {5,-10}",
                            arrayEmprestimo[y].idEmprestimo, arrayEmprestimo[y].nome.nomeAmigo,
                            arrayEmprestimo[y].revista.idRevista, arrayEmprestimo[y].dataEmprestimo,
                            arrayEmprestimo[y].dataDevolucao, arrayEmprestimo[y].statusDevolucao);


                    }

                }


            }
        }
        public void ExibirEmprestimosMes(Emprestimo[] arrayEmprestimo)
        {
            Notificador.ApresentarTitulo("\n\t #3 Filtrar Empréstimos por Mês\n");

            string[] meses = new string[] { "Janeiro", "Fevereiro", "Março", "Abril", 
                "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"};

            bool emprestimoExiste = false;
            int mes;
            Console.Write("Digite o Mês [exemplo: 3]: ");
            mes = int.Parse(Console.ReadLine());
            
            while(mes > 12)
            {
                Console.Write("Digite o Mês [exemplo: 3]: ");
                mes = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Mês Selecionado: " + meses[mes-1] +"\n");

            for (int i = 0; i < arrayEmprestimo.Length; i++)
            {
                if (arrayEmprestimo[i] != null && arrayEmprestimo[i].dataEmprestimo.Month == mes)
                {
                    emprestimoExiste = true;
                    Console.WriteLine("{0,-5} | {1,-10} | {2,-8} | {3,-20} | {4,-20} | {5,-10}", "ID", "Amigo", "Revista", "Data Emprestimo", "Data Devolução", "Status");
                    Console.WriteLine("---------------------------------------------------------------------------------");

                        Console.WriteLine("{0,-5} | {1,-10} | {2,-8} | {3,-20} | {4,-20} | {5,-10}",
                            arrayEmprestimo[i].idEmprestimo, arrayEmprestimo[i].nome.nomeAmigo,
                            arrayEmprestimo[i].revista.idRevista, arrayEmprestimo[i].dataEmprestimo,
                            arrayEmprestimo[i].dataDevolucao, arrayEmprestimo[i].statusDevolucao);

                }
            }

            if(emprestimoExiste == false)
            {
                Notificador.ApresentarMensagem("Não existem emprestimos no mês selecionado", ConsoleColor.Yellow);
            }
        }

    }


}
