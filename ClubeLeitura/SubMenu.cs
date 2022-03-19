using System;
namespace ClubeLeitura
{
    public class SubMenu
    {

        //arrays
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
            Console.Clear();
            Console.WriteLine("Gerenciamento de Revistas");
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
                emprestimo.EditarEmprestimo(arrayEmprestimo, arrayAmigo, arrayMulta,ref indiceMulta, ref  controlaIdMulta);
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

        //MULTA

        public void menuMulta()
        {
            Console.WriteLine("Multa");
            Console.WriteLine("1 - Visualizar Multas | 2 - Quitar Multa");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();
            RedirecionaMulta(opcao);
        }
        public void RedirecionaMulta(string opcao)
        {
            Multa multa = new Multa();
            if (opcao == "1")
            {
                multa.ExibirMultas(arrayMulta, arrayEmprestimo, arrayAmigo);

            }
            else if (opcao == "2")
            {
                multa.QuitarMulta(arrayMulta, arrayAmigo, arrayEmprestimo);
            }

        }

   
        public void ApresentaMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            Console.ResetColor();

        }

    }

}


