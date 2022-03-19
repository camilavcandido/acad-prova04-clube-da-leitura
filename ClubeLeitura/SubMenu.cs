using System;
namespace ClubeLeitura
{
    public class SubMenu
    {
        public Categoria[] arrayCategoria = new Categoria[100];
        public int indiceCategoria = 0;
        public int controlaIdCategoria = 1;

        public Revista[] arrayRevista = new Revista[100];
        public int indiceRevista = 0;
        public int controlaIdRevista = 1;

        public Caixa[] arrayCaixa = new Caixa[100];
        public int indiceCaixa = 0;
        public int controlaNumeroCaixa = 1;


        public Amigo[] arrayAmigo = new Amigo[100];
        public int indiceAmigo = 0;
        public int controleIdAmigo = 1;


        public Emprestimo[] arrayEmprestimo = new Emprestimo[100];
        public int indiceEmprestimo = 0;
        public int controlaIdEmprestimo = 1;

        public Reserva[] arrayReserva = new Reserva[100];
        public int indiceReserva = 0;
        public int controlaIdReserva = 1;


        #region CATEGORIA
        public void menuCategoria()
        {
            Console.WriteLine("Categoria");
            Console.WriteLine("1 - Cadastrar Categoria | 2 - Visualizar Categorias | 3 - Visualizar Revistas da Categoria");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();
            RedirecionaCategoria(opcao);

        }
        public void RedirecionaCategoria(string opcao)
        {
            Categoria categoria = new Categoria();
            if (opcao == "1")
            {
                categoria.CadastrarCategoria(arrayCategoria, ref indiceCategoria, ref controlaIdCategoria);
            }
            else if (opcao == "2")
            {
                categoria.ExibirCategorias(arrayCategoria);
            }
            else if (opcao == "3")
            {
                categoria.ExibirListaRevistas(arrayCategoria, arrayRevista);
            }
        }
        #endregion

        #region REVISTA
        public void menuRevista()
        {
            Console.WriteLine("Revista");
            Console.WriteLine("1 - Cadastrar Revista | 2 - Visualizar Revistas ");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();
            RedirecionaRevista(opcao);

        }

        public void RedirecionaRevista(string opcao)
        {
            Revista revista = new Revista();
            if (opcao == "1")
            {
                revista.CadastrarRevista(arrayRevista, arrayCaixa, arrayCategoria, ref indiceRevista, ref controlaIdRevista);
            }
            else if (opcao == "2")
            {
                revista.ExibirRevistasCadastradas(arrayRevista);
            }
        }
        #endregion


        #region CAIXA
        public void menuCaixa()
        {
            Console.WriteLine("Caixa");
            Console.WriteLine("1 - Cadastrar Caixa | 2 - Visualizar Caixas ");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();
            RedirecionaCaixa(opcao);
        }
        public void RedirecionaCaixa(string opcao)
        {
            Caixa caixa = new Caixa();
            if (opcao == "1")
            {
                caixa.CadastrarCaixa(arrayCaixa, ref indiceCaixa, ref controlaNumeroCaixa);

            }
            else if (opcao == "2")
            {
                caixa.ExibirCaixasCadastradas(arrayCaixa);
            }
            else if (opcao == "3")
            {
                //  categoria.ExibirListaRevistas(arrayCategoria, arrayRevista);
            }
        }

        #endregion

        #region AMIGO
        public void menuAmigo()
        {
            Console.WriteLine("AMIGO");
            Console.WriteLine("1 - Cadastrar Amigo | 2 - Visualizar Amigos ");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();
            RedirecionaAmigo(opcao);
        }
        public void RedirecionaAmigo(string opcao)
        {
            Amigo amigo = new Amigo();
            if (opcao == "1")
            {
                amigo.CadastrarAmigo(arrayAmigo, ref indiceAmigo, ref controleIdAmigo);

            }
            else if (opcao == "2")
            {
                amigo.ExibirAmigosCadastrados(arrayAmigo);
            }

        }
        #endregion

        #region EMPRESTIMO
        public void menuEmprestimo()
        {
            Console.WriteLine("Emprestimo");
            Console.WriteLine("1 - Cadastrar Emprestimo | 2 - Visualizar Emprestimos | 3 - Editar");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();
            RedirecionaEmprestimo(opcao);
        }

        public void RedirecionaEmprestimo(string opcao)
        {
            Emprestimo emprestimo = new Emprestimo();
            if (opcao == "1")
            {
                emprestimo.CadastrarEmprestimo(arrayEmprestimo, arrayRevista, arrayAmigo, ref indiceEmprestimo, ref controlaIdEmprestimo);

            }
            else if (opcao == "2")
            {
                emprestimo.ExibirEmprestimo(arrayEmprestimo);
            } else if(opcao == "3")
            {
                emprestimo.EditarEmprestimo(arrayEmprestimo, arrayAmigo);
            }

        }

        #endregion

        #region RESERVA
        public void menuReserva()
        {
            Console.WriteLine("Reserva");
            Console.WriteLine("1 - Cadastrar Reserva | 2 - Visualizar Reservas | 3 - Realizar Emprestimo ");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();
            RedirecionaReserva(opcao);
        }

        public void RedirecionaReserva(string opcao)
        {
            Reserva reserva = new Reserva();
            if (opcao == "1")
            {
                reserva.CadastrarReserva(arrayReserva, arrayEmprestimo, arrayAmigo, arrayRevista, ref indiceReserva, ref controlaIdReserva);
            }
            else if (opcao == "2")
            {
                reserva.ExibirReservas(arrayReserva);
            }
            else if (opcao == "3")
            {
                reserva.EmprestimoReserva(arrayReserva, arrayEmprestimo, arrayRevista, ref indiceEmprestimo, ref controlaIdEmprestimo);
            }

        }

        #endregion;

        public void ApresentaMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            Console.ResetColor();

        }

    }

}


