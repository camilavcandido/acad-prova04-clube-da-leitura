using System;

namespace ClubeLeitura
{
    internal partial class MenuPrincipal
    {
        static void Main(string[] args)
        {

            SubMenu subMenu = new SubMenu();

            do
            {
                string opcaoMenu = Menu();

                switch (opcaoMenu)
                {
                    case "1":
                        subMenu.menuRevista();
                        break;     
                    case "2":
                        subMenu.menuCaixa();
                        break;
                    case "3":
                        subMenu.menuAmigo();
                        break;
                    case "4":
                        subMenu.menuEmprestimo();
                        break;
                    case "5":
                        subMenu.menuReserva();
                        break;
                    case "6":
                        subMenu.menuCategoria();
                        break;
                    default:
                        Console.Clear();
                        break;
                };
            } while (true);
        }

        static string Menu()
        {
            ApresentaMensagem("\tClube da Leitura", ConsoleColor.Cyan);
            string opcaoMenu;
            Console.WriteLine("" +
                "\n1 - REVISTAS" +
                "\n2 - CAIXAS" +
                "\n3 - AMIGOS" +
                "\n4 - EMPRESTIMOS" +
                "\n5 - RESERVAS" +
                "\n6 - CATEGORIAS");

            ApresentaMensagem("Escolha uma opção: ", ConsoleColor.Blue);
            opcaoMenu = Console.ReadLine();
            return opcaoMenu;
        }

        static void ApresentaMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.Write(mensagem);
            Console.ResetColor();

        }

    }

}


