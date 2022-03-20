﻿using System;
namespace ClubeLeitura
{
    public class Caixa
    {
        public string cor;
        public string etiqueta;
        public int numero;
        public void CadastrarCaixa(Caixa[] arrayCaixa, ref int indiceCaixa, ref int controlaNumeroCaixa)
        {
            Notificador.ApresentarMensagem("\n\t1 - Cadastrar Caixa", ConsoleColor.Cyan);

            string corCaixa, etiquetaCaixa;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Número da Caixa: " + controlaNumeroCaixa);
            Console.ResetColor();

            Console.Write("Digite a Cor: ");
            corCaixa = Console.ReadLine();
            Console.Write("Digite a Etiqueta: ");
            etiquetaCaixa = Console.ReadLine();

            Caixa caixa = new Caixa();
            caixa.cor = corCaixa.ToUpper();
            caixa.etiqueta = etiquetaCaixa.ToUpper();
            caixa.numero = controlaNumeroCaixa;
            arrayCaixa[indiceCaixa] = caixa;

            indiceCaixa++;
            controlaNumeroCaixa++;
           
            Notificador.ApresentarMensagem("Caixa cadastrada com sucesso!", ConsoleColor.Green);
            Console.ReadLine();
            Console.Clear();

        }

        public void ExibirCaixasCadastradas(Caixa[] arrayCaixa)
        {
          
            Notificador.ApresentarMensagem("\n\t2 - Visualizar as Caixas Cadastradas", ConsoleColor.Cyan);

            if (arrayCaixa[0] == null)
            {
                Notificador.ApresentarMensagem("Não há caixas cadastradas", ConsoleColor.Yellow);
            }
            else
            {
                Console.WriteLine("{0,-10} | {1,-10} | {2,-10}", "Numero", "Cor", "Etiqueta");
                Console.WriteLine("------------------------------------------------");

                for (int i = 0; i < arrayCaixa.Length; i++)
                {

                    if (arrayCaixa[i] == null)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("{0,-10} | {1,-10} | {2,-10}", arrayCaixa[i].numero, arrayCaixa[i].cor, arrayCaixa[i].etiqueta);
                    }
                }
            }
            Console.ReadLine();
            Console.Clear();
        }

    }


}
