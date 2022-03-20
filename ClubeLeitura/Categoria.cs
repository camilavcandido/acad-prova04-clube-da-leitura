using System;
namespace ClubeLeitura
{

    public class Categoria
    {
        public int idCategoria;
        public string nomeCategoria;
        public int quantidadeDiasEmprestimo;

        public void CadastrarCategoria(Categoria[] arrayCategoria, ref int indiceCategoria, ref int controlaIdCategoria)
        {
            string nomeCategoria;
            int quantidadeDiasEmprestimo;

            Console.WriteLine("Cadastrar Categoria");

            Console.Write("Nome: ");
            nomeCategoria = Console.ReadLine();
            Console.Write("Quantidade de Dias de Emprestimo: ");
            quantidadeDiasEmprestimo = int.Parse(Console.ReadLine());

            Categoria categoria = new Categoria();
            categoria.idCategoria = controlaIdCategoria;
            categoria.nomeCategoria = nomeCategoria;
            categoria.quantidadeDiasEmprestimo = quantidadeDiasEmprestimo;


            arrayCategoria[indiceCategoria] = categoria;

            indiceCategoria++;
            controlaIdCategoria++;
            Notificador.ApresentarMensagem("Categoria Cadastrada!", ConsoleColor.Green);
            Console.ReadLine();
            Console.Clear();
        }

        public void ExibirCategorias(Categoria[] arrayCategoria)
        {

            Console.WriteLine("Exibir Categoria");
            if (arrayCategoria[0] == null)
            {
                Console.WriteLine("Não há categorias");
            }
            for (int i = 0; i < arrayCategoria.Length; i++)
            {
                if (arrayCategoria[i] == null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine(arrayCategoria[i].idCategoria + " " + arrayCategoria[i].nomeCategoria + " " + arrayCategoria[i].quantidadeDiasEmprestimo);
                }
            }
        }

        public void ExibirRevistasPorCategoria(Categoria[] arrayCategoria, Revista[] arrayRevista)
        {
            bool categoriaExiste = false;
            int id;
            Console.WriteLine("Digite o id da categoria");
            id = int.Parse(Console.ReadLine());

            if (arrayCategoria[0] == null)
            {
                Console.WriteLine("Não há categorias");
            }
            else
            {
                //verifica pelo id se a categoria existe
                for (int j = 0; j < arrayCategoria.Length; j++)
                {
                    if (arrayCategoria[j] != null && arrayCategoria[j].idCategoria == id)
                    {
                        categoriaExiste = true;
                    }
                }

                if (categoriaExiste)
                {
                    Console.WriteLine("{0,-5} | {1,-20} | {2,-10} | {3,-10} | {4,-10} | {5,-10}", "ID", "Coleção", "Edição", "Ano", "Caixa", "Categoria");

                    for (int y = 0; y < arrayRevista.Length; y++)
                    {
                        if (arrayRevista[y] != null && arrayRevista[y].categoriaRevista.idCategoria == id)
                        {
                            Console.WriteLine("{0,-5} | {1,-20} | {2,-10} | {3,-10} | {4,-10} | {5,-10}", arrayRevista[y].idRevista, arrayRevista[y].tipoColecaoRevista,
                                arrayRevista[y].numeroEdicaoRevista,
                                arrayRevista[y].anoRevista, arrayRevista[y].caixaRevista.cor, arrayRevista[y].categoriaRevista.nomeCategoria);
                            break;
                        }
                    }
                }

            }


            if(categoriaExiste == false)
            {
                Notificador.ApresentarMensagem("Categoria não existe", ConsoleColor.Red);
            }
            Console.ReadLine();
            Console.Clear();

        }

    }

}
