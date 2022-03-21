using System;
namespace ClubeLeitura
{
    public class SubMenu
    {
        //array
        public Notificador notificador;
        public Categoria[] arrayCategoria = new Categoria[100];
        public Revista[] arrayRevista = new Revista[100];
        public Caixa[] arrayCaixa = new Caixa[100];
        public Amigo[] arrayAmigo = new Amigo[100];
        public Emprestimo[] arrayEmprestimo = new Emprestimo[100];
        public Reserva[] arrayReserva = new Reserva[100];
        public Multa[] arrayMulta = new Multa[100];
        //indice do array
        public int indiceCategoria = 0, indiceRevista = 0, indiceCaixa = 0, indiceAmigo = 0,
        indiceEmprestimo = 0, indiceReserva = 0, indiceMulta;
        //id (é incrementado +1 sempre que uma nova posição do array é preenchida)
        public int controlaIdCategoria = 1, controlaIdRevista = 1, controlaNumeroCaixa = 1,
        controleIdAmigo = 1, controlaIdEmprestimo = 1, controlaIdReserva = 1, controlaIdMulta;

        //categoria
        public void TelaCategoria()
        {
            Console.Clear();
            Categoria categoria = new Categoria();
            Notificador.ApresentarTitulo("Gerenciamento de Categorias");
            Console.WriteLine("| 1 - Cadastrar Categoria \n| 2 - Visualizar Categorias \n| 3 - Visualizar Revistas por Categoria \n| 4 - Retornar ao Menu Principal ");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1":
                    categoria.CadastrarCategoria(arrayCategoria, ref indiceCategoria, ref controlaIdCategoria);
                    break;
                case "2":

                    categoria.ExibirCategorias(arrayCategoria);
                    break;
                case "3":
                    categoria.ExibirRevistasPorCategoria(arrayCategoria, arrayRevista);
                    break;
                case "4":
                    Console.Clear();
                    MenuPrincipal.ExibeMenuPrincipal();
                    break;
                default:
                    Notificador.ApresentarMensagem("\nOpção inválida\n", ConsoleColor.DarkRed);
                    TelaCategoria();
                    break;

            }
        }

        //revista
        public void TelaRevista()
        {
            Console.Clear();
            Revista revista = new Revista();
            Notificador.ApresentarTitulo("Gerenciamento de Revistas");
            Console.WriteLine("| 1 - Cadastrar Revista \n| 2 - Visualizar Revistas \n| 3 - Retornar para o Menu Principal");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1":
                    revista.CadastrarRevista(arrayRevista, arrayCaixa, arrayCategoria, ref indiceRevista, ref controlaIdRevista);
                    break;
                case "2":
                    revista.ExibirRevistasCadastradas(arrayRevista);
                    break;
                case "3":
                    Console.Clear();
                    MenuPrincipal.ExibeMenuPrincipal();
                    break;
                default:
                    Notificador.ApresentarMensagem("\nOpção inválida\n", ConsoleColor.DarkRed);
                    TelaRevista();
                    break;

            }

        }

        //caixa
        public void TelaCaixa()
        {
            Console.Clear();
            Caixa caixa = new Caixa();
            Notificador.ApresentarTitulo("Gerenciamento de Caixas");
            Console.WriteLine("| 1 - Cadastrar Caixa \n| 2 - Visualizar Caixas \n| 3 - Retornar ao Menu Principal ");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1":
                    caixa.CadastrarCaixa(arrayCaixa, ref indiceCaixa, ref controlaNumeroCaixa);
                    break;
                case "2":
                    caixa.ExibirCaixas(arrayCaixa);
                    break;
                case "3":
                    Console.Clear();
                    MenuPrincipal.ExibeMenuPrincipal();
                    break;
                default:
                    Notificador.ApresentarMensagem("\nOpção inválida\n", ConsoleColor.DarkRed);
                    TelaCaixa();
                    break;

            }
        }

        //amigo
        public void TelaAmigo()
        {
            Console.Clear();
            Amigo amigo = new Amigo();

            Notificador.ApresentarTitulo("Gerenciamento de Amigos");
            Console.WriteLine("| 1 - Cadastrar Amigo \n| 2 - Visualizar Amigos \n| 3 - Retornar ao Menu Principal");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1":
                    amigo.CadastrarAmigo(arrayAmigo, ref indiceAmigo, ref controleIdAmigo);
                    break;
                case "2":
                    amigo.ExibirAmigosCadastrados(arrayAmigo);
                    break;
                case "3":
                    Console.Clear();
                    MenuPrincipal.ExibeMenuPrincipal();
                    break;
                default:
                    Notificador.ApresentarMensagem("\nOpção inválida\n", ConsoleColor.DarkRed);
                    TelaAmigo();
                    break;
            }
        }

        //emprestimo
        public void TelaEmprestimo()
        {
            Console.Clear();
            Emprestimo emprestimo = new Emprestimo();
           
            Notificador.ApresentarTitulo("Gerenciamento de Emprestimos");
            Console.WriteLine("| 1 - Cadastrar Emprestimo \n| 2 - Visualizar Emprestimos \n| 3 - Registrar Devolução \n| 4 - Retornar para o Menu Principal");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1":
                    emprestimo.CadastrarEmprestimo(arrayEmprestimo, arrayRevista, arrayAmigo, ref indiceEmprestimo, ref controlaIdEmprestimo);
                    break;
                case "2":
                    emprestimo.ExibirEmprestimo(arrayEmprestimo);
                    break;
                case "3":
                    emprestimo.RegistrarDevolucao(arrayEmprestimo, arrayAmigo, arrayMulta, ref indiceMulta, ref controlaIdMulta);
                    break;
                case "4":
                    Console.Clear();
                    MenuPrincipal.ExibeMenuPrincipal();
                    break;
                default:
                    Console.WriteLine("Opção inválida\n");
                    TelaEmprestimo();
                    break;
            }
        }

        //reserva 
        public void TelaReserva()
        {
            Console.Clear();

            Reserva reserva = new Reserva();
            Notificador.ApresentarTitulo("Gerenciamento de Reservas");
            Console.WriteLine("| 1 - Cadastrar Reserva \n| 2 - Visualizar Reservas \n| 3 - Realizar Emprestimo \n| 4 - Retornar para o Menu Principal");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1":
                    reserva.CadastrarReserva(arrayReserva, arrayAmigo, arrayRevista, ref indiceReserva, ref controlaIdReserva);
                    break;
                case "2":
                    reserva.ExibirReservas(arrayReserva);
                    break;
                case "3":
                    reserva.EmprestimoReserva(arrayReserva, arrayEmprestimo, arrayRevista, ref indiceEmprestimo, ref controlaIdEmprestimo);
                    break;
                case "4":
                    Console.Clear();
                    MenuPrincipal.ExibeMenuPrincipal();
                    break;
                default:
                    Console.WriteLine("Opção inválida\n");
                    TelaReserva();
                    break;
            }
        }

        //multa
        public void TelaMulta()
        {
            Console.Clear();
            Notificador.ApresentarTitulo("Gerenciamento de Multas");
            Multa multa = new Multa();
           
            Console.WriteLine("| 1 - Visualizar Todas as Multas \n| 2 - Visualizar Amigos com Multas em Aberto \n| 3 - Quitar Multa \n| 4 - Retornar para o Menu Principal");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1":
                    multa.ExibirMultas(arrayMulta, arrayEmprestimo, arrayAmigo);
                    break;
                case "2":
                    multa.ExibirAmigosComMulta(arrayAmigo);
                    break;
                case "3":
                    multa.QuitarMulta(arrayMulta, arrayAmigo, arrayEmprestimo);
                    break;
                case "4":
                    Console.Clear();
                    MenuPrincipal.ExibeMenuPrincipal();
                    break;
                default:
                    Console.WriteLine("Opção inválida\n");
                    TelaMulta();
                    break;
            }
        }

    }

}