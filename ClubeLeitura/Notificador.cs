using System;
namespace ClubeLeitura
{
    public class Notificador
    {
        public static void ApresentarMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            Console.ResetColor();

        }

        public static void ApresentarTitulo(string titulo)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\t"+titulo);
            Console.ResetColor();
        }
    }
}
