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
                        subMenu.TelaRevista();
                        break;
                    case "2":
                        subMenu.TelaCaixa();
                        break;
                    case "3":
                        subMenu.TelaAmigo();
                        break;
                    case "4":
                        subMenu.TelaEmprestimo();
                        break;
                    case "5":
                        subMenu.TelaReserva();
                        break;
                    case "6":
                        subMenu.TelaCategoria();
                        break;
                    case "7":
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
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Notificador.ApresentarMensagem("Clube da Leitura", ConsoleColor.White);
            Console.ResetColor();
            string opcaoMenu;
            Console.WriteLine("Gerenciamento: " +
                "\n| 1 - Revistas" +
                "\n| 2 - Caixas" +
                "\n| 3 - Amigos" +
                "\n| 4 - Emprestimos" +
                "\n| 5 - Reservas" +
                "\n| 6 - Categorias" +
                "\n| 7 - Multas");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Escolha uma opção: ");
            Console.ResetColor();
            opcaoMenu = Console.ReadLine();
            return opcaoMenu;
        }

    }
}
