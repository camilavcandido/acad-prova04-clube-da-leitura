using System;
namespace ClubeLeitura
{
    public class MenuPrincipal
    {

        public static void Main(string[] args)
        {
            ExibeMenuPrincipal();
        }

        public static void ExibeMenuPrincipal()
        {

            SubMenu subMenu = new SubMenu();


            do
            {

                string opcaoMenu = OpcoesDoMenu();

                switch (opcaoMenu)
                {
                    case "1":
                        Console.Clear();
                        subMenu.TelaRevista();
                        break;
                    case "2":
                        Console.Clear();
                        subMenu.TelaCaixa();
                        break;
                    case "3":
                        Console.Clear();
                        subMenu.TelaAmigo();
                        break;
                    case "4":
                        Console.Clear();
                        subMenu.TelaEmprestimo();
                        break;
                    case "5":
                        Console.Clear();
                        subMenu.TelaReserva();
                        break;
                    case "6":
                        Console.Clear();
                        subMenu.TelaCategoria();
                        break;
                    case "7":
                        Console.Clear();
                        subMenu.TelaMulta();
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            } while (true);
        }

        public static string OpcoesDoMenu()
        {
            Notificador.ApresentarMensagem("\tClube da Leitura", ConsoleColor.Cyan);
            string opcaoMenu;
            Console.WriteLine("" +
                "\n1 - REVISTAS" +
                "\n2 - CAIXAS" +
                "\n3 - AMIGOS" +
                "\n4 - EMPRESTIMOS" +
                "\n5 - RESERVAS" +
                "\n6 - CATEGORIAS" +
                "\n7 - MULTAS");

            Notificador.ApresentarMensagem("Escolha uma opção: ", ConsoleColor.Blue);
            opcaoMenu = Console.ReadLine();
            return opcaoMenu;
        }

    }
}
