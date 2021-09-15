using System;

namespace DIO.Games
{
    class Program
    {
        static GameRepositorio repositorio = new GameRepositorio();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine("| CRUD DE GAMES DA DIO v1.0 |");
                Console.WriteLine("-----------------------------");
                Console.WriteLine();
                Console.WriteLine("[1]. INSERIR GAME");
                Console.WriteLine("[2]. LISTAR GAMES");
                Console.WriteLine("[3]. VISUALIZAR GAME");
                Console.WriteLine("[4]. ATUALIZAR GAME");
                Console.WriteLine("[5]. EXCLUIR GAME");
                Console.WriteLine("[6]. SAIR");
                Console.WriteLine();
                Console.Write("Escolha: ");
                string opcaousuario = Console.ReadLine();
                switch (Convert.ToInt32(opcaousuario))
                {
                    case 1:
                        InserirGame();
                        break;
                    case 2:
                        ListarGames();
                        break;
                    case 3:
                        VisualizarGame();
                        break;
                    case 4:
                        AtualizarGame();
                        break;
                    case 5:
                        ExcluirGame();
                        break;
                    case 6:
                        Console.WriteLine("Obrigado por utilizar!");
                        Console.WriteLine("Saindo...");
                        return;
                    default:

                        break;
                }
            }

            static void InserirGame()
            {
                Console.Clear();
                Console.WriteLine("-> [1]. INSERIR GAME");
                Console.WriteLine();

                foreach (int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
                }
                Console.WriteLine();
                Console.Write("-> Digite o gênero entre as opções acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.Write("- Digite o nome do Game: ");
                string entradaTitulo = Console.ReadLine();

                Console.Write("- Digite a data de lançamento do Game: ");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.Write("- Digite a descrição do Game: ");
                string entradaDescricao = Console.ReadLine();

                Game novoGame = new Game(id: repositorio.ProximoId(), genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);

                repositorio.Insere(novoGame);
                Console.WriteLine();
                Console.WriteLine("Game inserido com sucesso!");
                Console.WriteLine();
                Console.WriteLine("Pressione [enter] para continuar...");
                Console.ReadKey();
                Console.Clear();
            }

            static void ListarGames()
            {
                Console.Clear();
                Console.WriteLine("-> [2]. LISTAR GAMES");
                Console.WriteLine();
                var lista = repositorio.Lista();

                if (lista.Count == 0)
                {
                    Console.WriteLine("Nenhum game cadastrado");
                    Console.WriteLine("Pressione [enter] para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                    return;
                }

                foreach (var game in lista)
                {
                    var excluido = game.retornaExcluido();
                        Console.WriteLine("#ID {0}: - {1}{2}", game.retornaId(), game.retornaTitulo(), (excluido ? " **Excluído" : ""));
                }
                Console.WriteLine();
                Console.WriteLine("Pressione [enter] para continuar...");
                Console.ReadKey();
                Console.Clear();
            }

            static void VisualizarGame()
            {
                Console.Clear();
                Console.WriteLine("-> [3]. VISUALIZAR GAME");
                Console.WriteLine();
                Console.Write("Digite o ID do game: ");
                int indiceGame = int.Parse(Console.ReadLine());
                Console.WriteLine();

                var game = repositorio.RetornaPorId(indiceGame);

                Console.WriteLine("Visualizando...");
                Console.WriteLine(game);
                Console.WriteLine();
                Console.WriteLine("Pressione [enter] para continuar...");
                Console.ReadKey();
                Console.Clear();
            }

            static void AtualizarGame()
            {
                Console.Clear();
                Console.WriteLine("-> [4]. ATUALIZAR GAME");
                Console.WriteLine();
                Console.Write("Digite o ID do game: ");
                int indiceGame = int.Parse(Console.ReadLine());

                foreach (int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
                }
                Console.WriteLine();
                Console.Write("-> Digite o gênero entre as opções acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.Write("- Digite o nome do Game: ");
                string entradaTitulo = Console.ReadLine();

                Console.Write("- Digite a data de lançamento do Game: ");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.Write("- Digite a descrição do Game: ");
                string entradaDescricao = Console.ReadLine();

                Game atualizaGame = new Game(id:indiceGame, genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);

                repositorio.Atualiza(indiceGame, atualizaGame);
                Console.WriteLine();
                Console.WriteLine("Game atualizado com sucesso!");
                Console.WriteLine();
                Console.WriteLine("Pressione [enter] para continuar...");
                Console.ReadKey();
                Console.Clear();
            }

            static void ExcluirGame()
            {
                Console.Clear();
                Console.WriteLine("-> [5]. EXCLUIR GAME");
                Console.WriteLine();
                Console.Write("Digite o ID do game: ");
                int indiceGame = int.Parse(Console.ReadLine());

                repositorio.Exclui(indiceGame);

                Console.WriteLine();
                Console.WriteLine("Game excluído com sucesso!");
                Console.WriteLine();
                Console.WriteLine("Pressione [enter] para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
