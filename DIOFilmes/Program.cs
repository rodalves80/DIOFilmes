using System;

namespace DIOFilmes
{
    class Program
    {

        static FilmeRepositorio repositorio = new FilmeRepositorio();
        static void Main(string[] args)
        {

            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarFilmes();
                        break;
                    case "2":
                        InserirFilmes();
                        break;
                    case "3":
                       AtualizarFilmes();
                        break;
                    case "4":
                        ExcluirFilmes();
                        break;
                    case "5":
                       VisualizarFilmes();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado Por Utilizar Nossos Serviços!");
            Console.ReadLine();
        }   

             private static void ListarFilmes()
             {
               Console.WriteLine("Listar Filmes");
             
               var lista = repositorio.Lista();
                
               if (lista.Count == 0)
               {

                Console.WriteLine("Nenhum Filme Cadastrado!");
                return;

               }
               foreach (var filme in lista)
               {

                var excluido = filme.RetornaExcluido();
                Console.WriteLine("#ID {0}:-{1} {2}", filme.RetornaId(), filme.RetornaTitulo(), (excluido ? "Excluido*" : "") );
               }

             }


               private static void InserirFilmes()
               {

                 Console.WriteLine("Inserir Novo Filme");
                  
                 foreach (int i in Enum.GetValues(typeof(Genero)))
                 {
                Console.WriteLine("{0}:-{1}", i, Enum.GetName(typeof(Genero), i));
                 }
                 Console.WriteLine("Digite o Gênero Entre as Opções Acima: ");
                 int entraGenero = int.Parse(Console.ReadLine());

                 Console.WriteLine("Digite O Título do Filme: ");
                 string entraTitulo = Console.ReadLine();

                 Console.WriteLine("Digite o Ano de Lançamento do Filme: ");
                 int entradaAno = int.Parse(Console.ReadLine());

                 Console.WriteLine("Pertence a Uma Trilogia? ");
                 string entraTrilogia = Console.ReadLine();


                 Console.Write("Digite a Descrição do Filme: ");
                 string entraDescricao = Console.ReadLine();

                 Filmes novoFilme = new Filmes(id: repositorio.ProximoId(),
                                          genero: (Genero)entraGenero,
                                          titulo: entraTitulo, ano: entradaAno, 
                                          trilogia: entraTrilogia,descricao: entraDescricao) ;

                 repositorio.Insere(novoFilme);
               }

                public static void AtualizarFilmes()
                {

                 Console.WriteLine("Digite o id do Filme: ");
                 int indiceFilme = int.Parse(Console.ReadLine());

                 foreach (int i in Enum.GetValues(typeof(Genero)))
                 {
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
                 }
                 Console.Write("Digite o Gênero Entre as Opções Acima: ");
                 int entraGenero = int.Parse(Console.ReadLine());

                 Console.Write("Digite o Título do Filme: ");
                 string entraTitulo = Console.ReadLine();

                 Console.Write("Digite o Ano de Lançamento do Filme: ");
                 int entradaAno = int.Parse(Console.ReadLine());

                 Console.Write("Pertence a Uma Trilogia: ");
                 string entraTrilogia = Console.ReadLine();

                 Console.Write("Digite a Descrição do Filme: ");
                 string entraDescricao = Console.ReadLine();

                 Filmes atualizaFilme = new Filmes(id: indiceFilme,
                                             genero: (Genero)entraGenero,
                                             titulo: entraTitulo, ano: entradaAno, 
                                             trilogia: entraTrilogia,
                                             descricao: entraDescricao);

                 repositorio.Atualiza(indiceFilme, atualizaFilme);
                 
                }

               private static void ExcluirFilmes()
               {

                Console.Write("Digite o id do Filme: ");
                int indiceFilme = int.Parse(Console.ReadLine());

                repositorio.Exclui(indiceFilme);
             
               }

               private static void VisualizarFilmes()
               {
                Console.Write("Digite o id do Filme: ");
                int indiceFilme = int.Parse(Console.ReadLine());

                var filme = repositorio.RetornaPorId(indiceFilme);

                Console.WriteLine(filme);

               }
               
           private static string ObterOpcaoUsuario()
           {
                Console.WriteLine();
                Console.WriteLine("DIO Filmes a Seu Dispor!!");
                Console.WriteLine("Informe a Opção Desejada: ");

                Console.WriteLine("1- Listar Filmes");
                Console.WriteLine("2- Inserir Novo Filme");
                Console.WriteLine("3- Atualizar Filme");
                Console.WriteLine("4- Excluir Filme");
                Console.WriteLine("5- Visualizar Filme");
                Console.WriteLine("C- Limpar Tela");
                Console.WriteLine("X- Sair");
                Console.WriteLine();

                string opcaoUsuario = Console.ReadLine().ToUpper();
                Console.WriteLine();
                return opcaoUsuario;

           }
           
  
    }
}
