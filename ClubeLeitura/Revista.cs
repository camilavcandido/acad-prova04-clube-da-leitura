using System;
namespace ClubeLeitura
{
    public class Revista
    {
        public int idRevista;
        public string tipoColecaoRevista;
        public int numeroEdicaoRevista;
        public string anoRevista;
        public Caixa caixaRevista;
        public Categoria categoriaRevista;

        public void CadastrarRevista(Revista[] arrayRevista, Caixa[] arrayCaixa, Categoria[] arrayCategoria, ref int indiceRevista, ref int controlaIdRevista)
        {
            #region variaveis
            string tipoColecaoRevista, anoRevista;
            int numeroEdicaoRevista;
            int numeroCaixa;
            int idCategoria = 0;
            bool caixaExiste = false;
            bool categoriaExiste = false;
            #endregion

            Notificador.ApresentarTitulo("\n1 - Cadastrar Revista");

            Console.Write("Coleção: ");
            tipoColecaoRevista = Console.ReadLine();
            Console.Write("Edição Número:  ");
            numeroEdicaoRevista = int.Parse(Console.ReadLine());
            Console.Write("Ano: ");
            anoRevista = Console.ReadLine();

            Revista revista = new Revista();
            revista.idRevista = controlaIdRevista;
            revista.tipoColecaoRevista = tipoColecaoRevista;
            revista.numeroEdicaoRevista = numeroEdicaoRevista;
            revista.anoRevista = anoRevista;

            while (caixaExiste == false)
            {
                Console.Write("Número da Caixa: ");
                numeroCaixa = int.Parse(Console.ReadLine());

                for (int i = 0; i < arrayCaixa.Length; i++)
                {
                    if (arrayCaixa[i] != null && numeroCaixa == arrayCaixa[i].numero)
                    {
                        revista.caixaRevista = arrayCaixa[i];
                        caixaExiste = true;
                        break;

                    }

                }
            }

            while (categoriaExiste == false)
            {
                Console.Write("ID da categoria: ");
                idCategoria = int.Parse(Console.ReadLine());

                for (int i = 0; i < arrayCategoria.Length; i++)
                {
                    if (arrayCategoria[i] != null && idCategoria == arrayCategoria[i].idCategoria)
                    {
                        revista.categoriaRevista = arrayCategoria[i];

                        categoriaExiste = true;
                        break;

                    }

                }

            }

            arrayRevista[indiceRevista] = revista;


            controlaIdRevista++;
            indiceRevista++;

            Notificador.ApresentarMensagem ("Revista cadastrada com sucesso!", ConsoleColor.Green);

            Console.ReadLine();
            Console.Clear();
        }

        public void ExibirRevistasCadastradas(Revista[] arrayRevista)
        {
            Notificador.ApresentarTitulo("\n2 - Visualizar as Revistas Cadastradas");

            if (arrayRevista[0] == null)
            {
                Notificador. ApresentarMensagem("Não há revistas cadastradas", ConsoleColor.Yellow);
            }
            else
            {

                Console.WriteLine("{0,-5} | {1,-20} | {2,-10} | {3,-10} | {4,-10} | {5,-10}", "ID", "Coleção", "Edição", "Ano", "Caixa", "Categoria");

                Console.WriteLine("--------------------------------------------------------------------------------------------");

                for (int i = 0; i < arrayRevista.Length; i++)
                {
                    if (arrayRevista[i] == null)
                    {
                        break;
                    }
                    else
                    {

                        Console.WriteLine("{0,-5} | {1,-20} | {2,-10} | {3,-10} | {4,-10} | {5,-10}", arrayRevista[i].idRevista, arrayRevista[i].tipoColecaoRevista, arrayRevista[i].numeroEdicaoRevista, arrayRevista[i].anoRevista, arrayRevista[i].caixaRevista.cor, arrayRevista[i].categoriaRevista.nomeCategoria);

                    }
                }
            }

            Console.ReadLine();
            Console.Clear();
          
        }

    }
}
