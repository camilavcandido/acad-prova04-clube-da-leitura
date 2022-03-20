using System;

namespace ClubeLeitura
{
    public class Multa
    {
        public int idMulta;
        public Emprestimo emprestimo;
        public bool statusMulta;

        public void ExibirMultas(Multa[] arrayMulta, Emprestimo[] arrayEmprestimo, Amigo[] arrayAmigo)
        {
            if (arrayMulta[0] == null)
            {
                Console.Write("nao ha multas");
            }
            else
            {
                for (int i = 0; i < arrayMulta.Length; i++)
                {
                    if (arrayMulta[i] != null)
                    {

                        Console.Write(arrayMulta[i].idMulta + "" + arrayMulta[i].emprestimo.nome.nomeAmigo + "" + arrayMulta[i].statusMulta);
                    }
                }
            }
        }

        public void QuitarMulta(Multa[] arrayMulta, Amigo[] arrayAmigo, Emprestimo[] arrayEmprestimo)
        {
            Console.WriteLine("ID DA MULTA: ");
            int idMulta = int.Parse(Console.ReadLine());

            //array multa
            for (int i = 0; i < arrayMulta.Length; i++)
            {
                if (arrayMulta[i] == null)
                {
                    break;
                }
                else
                {
                    for (int j = 0; j < arrayEmprestimo.Length; j++)
                    {
                        if (arrayEmprestimo[j] == null)
                        {
                            break;
                        }
                        else if (arrayMulta[i] != null && arrayMulta[i].idMulta == idMulta)
                        {
                            arrayMulta[i].idMulta = 0;
                            arrayMulta[i].statusMulta = false;
                            for(int a = 0; a < arrayAmigo.Length; a++)
                            {
                                if (arrayAmigo[a] == null)
                                    break;
                                else if(arrayAmigo[a]!=null && arrayAmigo[a].idAmigo == arrayMulta[i].emprestimo.nome.idAmigo)
                                {
                                    arrayAmigo[a].possuiMulta = false;
                                }
                            }
                        }
                    }

                }

            }


        }

        public void ExibirAmigosComMulta(Amigo[] arrayAmigo)
        {
            bool ExisteAmigoComMulta = false;
            Console.WriteLine("{0,-10} | {1,-10} | {2,-15} | {3,-10} | {4,-10} | {5,-10}", "ID", "Nome", "Responsavel", "Telefone", "Endereço", "Multa");
            Console.WriteLine("---------------------------------------------------------------------------------");
            for (int i = 0; i < arrayAmigo.Length; i++)
            {
                if (arrayAmigo[i] == null)
                {
                    break;
                }
                else if (arrayAmigo[i] != null & arrayAmigo[i].possuiMulta == true)
                {
                    ExisteAmigoComMulta = true;
                    Console.WriteLine("{0,-10} | {1,-10} | {2,-15} | {3,-10} | {4,-10} | {5,-10}", arrayAmigo[i].idAmigo,
                        arrayAmigo[i].nomeAmigo, arrayAmigo[i].nomeResponsavel, arrayAmigo[i].telefone, arrayAmigo[i].endereco, arrayAmigo[i].possuiMulta);

                }
            }
            if (ExisteAmigoComMulta == false)
            {
                Notificador.ApresentarMensagem("Não há amigo com multa em aberto", ConsoleColor.Green);
            }

        }

    }
}
