using System;
namespace ClubeLeitura
{
    public class Amigo
    {
        public int idAmigo;
        public string nomeAmigo;
        public string nomeResponsavel;
        public string telefone;
        public string endereco;
        public bool possuiMulta;

        public void CadastrarAmigo(Amigo[] arrayAmigo, ref int indiceAmigo, ref int controlaIdAmigo)
        {
            string nomeAmigo, nomeResponsavelAmigo, telefoneAmigo, enderecoAmigo;

            Notificador.ApresentarTitulo("\n1 - Cadastrar Amigo");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("ID: " + controlaIdAmigo);
            Console.ResetColor();

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

            Notificador.ApresentarMensagem("Amigo cadastrado com sucesso!", ConsoleColor.Green);
            Console.ReadLine();
            Console.Clear();

        }

        public void ExibirAmigosCadastrados(Amigo[] arrayAmigo)
        {
            Notificador.ApresentarTitulo("\n2 - Visualizar os Amigos Cadastrados");
            if (arrayAmigo[0] == null)
            {
                Notificador.ApresentarMensagem("Não há amigos cadastrados", ConsoleColor.Yellow);
            }
            else
            {
                Console.WriteLine("| 1 - Visualizar Todos os Amigos Cadastrados \n| 2 - Visualizar os Amigos com Multas em Aberto");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1":
                        ExibirAmigos(arrayAmigo);
                        break;
                    case "2":
                        ExibirAmigosComMulta(arrayAmigo);
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
            Console.ReadLine();

        }

        public void ExibirAmigos(Amigo[] arrayAmigo)
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\n#1 Todos os Amigos Cadastrados:\n");
            Console.ResetColor();
            Console.WriteLine("{0,-10} | {1,-10} | {2,-15} | {3,-10} | {4,-10} | {5,-10}", "ID", "Nome", "Responsavel", "Telefone", "Endereço", "Multa");
            Console.WriteLine("---------------------------------------------------------------------------------");
            for (int i = 0; i < arrayAmigo.Length; i++)
            {
                if (arrayAmigo[i] == null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("{0,-10} | {1,-10} | {2,-15} | {3,-10} | {4,-10} | {5,-10}", arrayAmigo[i].idAmigo,
                        arrayAmigo[i].nomeAmigo, arrayAmigo[i].nomeResponsavel, arrayAmigo[i].telefone, arrayAmigo[i].endereco, arrayAmigo[i].possuiMulta);

                }
            }
            Console.WriteLine("\nDigite qualquer tecla para retornar ao Menu");
        }

        public void ExibirAmigosComMulta(Amigo[] arrayAmigo)
        {
            bool ExisteAmigoComMulta = false;
            Console.WriteLine("\n#2 Amigos com Multa em Aberto:\n");

            Console.WriteLine("{0,-10} | {1,-10} | {2,-15} | {3,-10} | {4,-10} | {5,-10}", "ID", "Nome", "Responsavel", "Telefone", "Endereço", "Multa");
            Console.WriteLine("---------------------------------------------------------------------------------");
            for (int i = 0; i < arrayAmigo.Length; i++)
            {
                if (arrayAmigo[i] == null)
                {
                    break;
                }
                else if(arrayAmigo[i]!= null & arrayAmigo[i].possuiMulta == true)
                {
                    ExisteAmigoComMulta = true;
                    Console.WriteLine("{0,-10} | {1,-10} | {2,-15} | {3,-10} | {4,-10} | {5,-10}", arrayAmigo[i].idAmigo,
                        arrayAmigo[i].nomeAmigo, arrayAmigo[i].nomeResponsavel, arrayAmigo[i].telefone, arrayAmigo[i].endereco, arrayAmigo[i].possuiMulta);
                    break;
                }
            }
            if(ExisteAmigoComMulta == false)
            {
                Notificador.ApresentarMensagem("Não há amigo com multa em aberto", ConsoleColor.Green);
            }

            Console.ReadLine();
            Console.Clear();

        }
    }
}
