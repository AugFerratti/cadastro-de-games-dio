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

                        break;
                    case 4:

                        break;
                    case 5:

                        break;
                    case 6:
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
                Console.WriteLine("-> [2]. LISTAS GAMES");
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
                    Console.WriteLine("#ID {0}: - {1}", game.retornaId(), game.retornaTitulo());
                }
                Console.WriteLine();
                Console.WriteLine("Pressione [enter] para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
