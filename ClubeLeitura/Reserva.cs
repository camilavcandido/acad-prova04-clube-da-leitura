using System;
namespace ClubeLeitura
{
    public class Reserva
    {
        public int idReserva;
        public Amigo nome;
        public Revista revista;
        public DateTime dataReserva;
        public DateTime prazoReserva;
        public string statusReserva;

        public void CadastrarReserva(Reserva[] arrayReserva, Emprestimo[] arrayEmprestimo,
         Amigo[] arrayAmigo, Revista[] arrayRevista,
         ref int indiceReserva, ref int controlaIdReserva)
        {
            Console.WriteLine("Cadastrar Reserva");
            bool amigoExiste = false;
            bool revistaExiste = false;
            int idAmigo;
            int idRevista;

            Reserva reserva = new Reserva();
            reserva.idReserva = controlaIdReserva;

            //amigo
            while (amigoExiste == false)
            {
                Console.Write("ID do Amigo: ");
                idAmigo = int.Parse(Console.ReadLine());

                for (int i = 0; i < arrayAmigo.Length; i++)
                {
                    if (arrayAmigo[i] != null && arrayAmigo[i].idAmigo == idAmigo)
                    {
                        reserva.nome = arrayAmigo[i];
                        amigoExiste = true;
                        break;
                    }

                }
            }
            //reserva
            while (revistaExiste == false)
            {
                Console.Write("ID da Revista: ");
                idRevista = int.Parse(Console.ReadLine());

                for (int y = 0; y < arrayRevista.Length; y++)
                {
                    if (arrayRevista[y] != null && idRevista == arrayRevista[y].idRevista)
                    {
                        reserva.revista = arrayRevista[y];
                        revistaExiste = true;
                        break;
                    }

                }
            }

            reserva.dataReserva = DateTime.Now;
            //prazo
            DateTime prazoReserva = DateTime.Now;

            reserva.prazoReserva = prazoReserva.AddDays(2);

            reserva.statusReserva = "Válida";

            arrayReserva[indiceReserva] = reserva;

            controlaIdReserva++;
            indiceReserva++;

        }

        public void ExibirReservas(Reserva[] arrayReserva)
        {
            Console.WriteLine("EXIBIR Reserva");

            if (arrayReserva[0] == null)
            {
                ApresentaMensagem("Não há reservas", ConsoleColor.Yellow);
            }
            else
            {
                Console.WriteLine("{0,-5} | {1,-10} | {2,-8} | {3,-20} | {4,-20} | {5,-10}", "ID", "Amigo", "Revista", "Data Reserva", "Prazo", "Status");
                Console.WriteLine("---------------------------------------------------------------------------------");
                for (int i = 0; i < arrayReserva.Length; i++)
                {
                    if (arrayReserva[i] == null)
                    {
                        break;
                    }
                    else
                    {


                        //verifique se já passou 2 dias e atualiza status da reserva

                        DateTime hoje = new DateTime();
                        hoje = DateTime.Now;

                        if (arrayReserva[i].statusReserva == "Válida" && hoje.Day > arrayReserva[i].prazoReserva.Day)
                        {
                            arrayReserva[i].statusReserva = "Expirada";
                        }

                        Console.WriteLine("{0,-5} | {1,-10} | {2,-8} | {3,-20} | {4,-20} | {5,-10}", arrayReserva[i].idReserva, arrayReserva[i].nome.nomeAmigo, arrayReserva[i].revista.idRevista, arrayReserva[i].dataReserva, arrayReserva[i].prazoReserva, arrayReserva[i].statusReserva);
                    }
                }
            }
            Console.ReadLine();
        }

        public void EmprestimoReserva(Reserva[] arrayReserva, Emprestimo[] arrayEmprestimo, Revista[] arrayRevista, ref int indiceEmprestimo, ref int controlaIdEmprestimo)
        {
            Console.WriteLine("Digite o ID da Reserva: ");
            int idReserva = int.Parse(Console.ReadLine());
            bool reservaEhValida = false;

            for (int i = 0; i < arrayReserva.Length; i++)
            {

                if (arrayReserva[i] != null && arrayReserva[i].idReserva == idReserva && arrayReserva[i].statusReserva == "Válida")
                {
                    reservaEhValida = true;
                    Emprestimo emprestimo = new Emprestimo();
                    emprestimo.idEmprestimo = controlaIdEmprestimo;
                    emprestimo.nome = arrayReserva[i].nome;
                    emprestimo.revista = arrayReserva[i].revista;

                    DateTime dataEmprestimo = new DateTime();
                    Console.Write("Data do Emprestimo (DD/MM/AAAA): ");
                    dataEmprestimo = Convert.ToDateTime(Console.ReadLine());
                    emprestimo.dataEmprestimo = dataEmprestimo;

                    DateTime dataDevolucao = new DateTime();


                    int dias;
                    for (int j = 0; j < arrayRevista.Length; j++)
                    {
                        if (arrayRevista[j] != null)
                        {
                            dias = arrayRevista[j].categoriaRevista.quantidadeDiasEmprestimo;
                            dataDevolucao = dataEmprestimo.AddDays(dias);
                            emprestimo.dataDevolucao = dataDevolucao;

                        }
                    }

                    Console.Write("Data de Devolução (DD/MM/AAAA): {0}", dataDevolucao);

                    arrayEmprestimo[indiceEmprestimo] = emprestimo;

                    arrayReserva[i].statusReserva = "Finalizada";
                    indiceEmprestimo++;
                    controlaIdEmprestimo++;
                }

            }
            if (reservaEhValida == false)
            {

                ApresentaMensagem("Reserva inválida", ConsoleColor.Red);
            }

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


