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

            Console.WriteLine("Nome:");
            nomeCategoria = Console.ReadLine();
            Console.WriteLine("Dias:");
            quantidadeDiasEmprestimo = int.Parse(Console.ReadLine());

            Categoria categoria = new Categoria();
            categoria.idCategoria = controlaIdCategoria;
            categoria.nomeCategoria = nomeCategoria;
            categoria.quantidadeDiasEmprestimo = quantidadeDiasEmprestimo;


            arrayCategoria[indiceCategoria] = categoria;

            indiceCategoria++;
            controlaIdCategoria++;

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

        public void ExibirListaRevistas(Categoria[] arrayCategoria, Revista[] arrayRevista)
        {
            int id;
            Console.WriteLine("Digite o id da categoria");
            id = int.Parse(Console.ReadLine());
            Console.WriteLine("{0,-5} | {1,-20} | {2,-10} | {3,-10} | {4,-10} | {5,-10}", "ID", "Coleção", "Edição", "Ano", "Caixa", "Catteogira");

            
                for (int y = 0; y < arrayRevista.Length; y++)
                {
                    if (arrayRevista[y] != null && arrayRevista[y].categoriaRevista.idCategoria == id )
                    {
                        Console.WriteLine("{0,-5} | {1,-20} | {2,-10} | {3,-10} | {4,-10} | {5,-10}", arrayRevista[y].idRevista, arrayRevista[y].tipoColecaoRevista,
                            arrayRevista[y].numeroEdicaoRevista,
                            arrayRevista[y].anoRevista, arrayRevista[y].caixaRevista.cor, arrayRevista[y].categoriaRevista.nomeCategoria);
                        break;
                    }
                }
            }
        


    }

}






//for (int i = 0; i < arrayCategoria.Length; i++)
//{
//    if (arrayCategoria == null)
//    {
//        break;
//    }
//    else if (arrayCategoria[i] != null && arrayCategoria[i].idCategoria == idCategoria)
//    {
//        for (int y = 0; y < listaRevistas.Length; y++)
//        {
//            if (listaRevistas[y] == null)
//            {
//                break;
//            }
//            else
//            if (listaRevistas[y] != null)
//            {
//                Console.WriteLine("{0,-5} | {1,-20} | {2,-10} | {3,-10} | {4,-10} | {5,-10}", listaRevistas[y].idRevista, listaRevistas[y].tipoColecaoRevista, listaRevistas[y].numeroEdicaoRevista, listaRevistas[y].anoRevista, listaRevistas[y].caixaRevista.cor, listaRevistas[y].categoriaRevista.nomeCategoria);
//                break;
//            }
//        }
//    }
//}