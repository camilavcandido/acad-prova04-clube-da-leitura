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


            arrayEmprestimo[indiceEmprestimo] = emprestimo;

            indiceEmprestimo++;
            controlaIdEmprestimo++;

            ApresentaMensagem("\nEmprestimo cadastrado com sucesso", ConsoleColor.Green);
            Console.ReadLine();
        }

        public void ExibirEmprestimo(Emprestimo[] arrayEmprestimo)
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
                Console.WriteLine("{0,-5} | {1,-10} | {2,-8} | {3,-20} | {4,-20} | {5,-10}",
                    "ID", "Amigo", "Revista", "Data Emprestimo", "Data Devolução", "Status");
                Console.WriteLine("---------------------------------------------------------------------------------");

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

                            if (arrayEmprestimo[y] != null && arrayEmprestimo[y].dataDevolucaoRealizada == null)
                            {


                                Console.WriteLine("{0,-5} | {1,-10} | {2,-8} | {3,-20} | {4,-20} | {5,-10}",
                                    arrayEmprestimo[y].idEmprestimo, arrayEmprestimo[y].nome.nomeAmigo,
                                    arrayEmprestimo[y].revista.idRevista, arrayEmprestimo[y].dataEmprestimo,
                                    arrayEmprestimo[y].dataDevolucao, arrayEmprestimo[y].statusDevolucao);


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

        public void EditarEmprestimo(Emprestimo[] arrayEmprestimo, Amigo[] arrayAmigo)
        {
            Console.WriteLine("Registrar Devolução");

            int id;


            Console.WriteLine("Digite o ID do emprestimo");
            id = int.Parse(Console.ReadLine());

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

                        if(devolucaoRealizada > arrayEmprestimo[i].dataDevolucao)
                        {
                            arrayEmprestimo[i].statusDevolucao = "Atrasada";
                        } 
                        else if (devolucaoRealizada <= arrayEmprestimo[i].dataDevolucao)
                        {
                            arrayEmprestimo[i].statusDevolucao = "No Prazo";

                        } else
                        {
                            arrayEmprestimo[i].statusDevolucao = "Pendente";

                        }


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

        public void ApresentaMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            Console.ResetColor();

        }

    }


}
