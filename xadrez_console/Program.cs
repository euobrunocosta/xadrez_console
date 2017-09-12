using System;
using tabuleiro;
using xadrez;

namespace xadrez_console {
	
	class MainClass {
		
		public static void Main(string[] args) {

			Console.BackgroundColor = ConsoleColor.DarkCyan;

			try {
				PartidaDeXadrez partida = new PartidaDeXadrez();

				while (!partida.terminada) {

					try {
						Console.Clear();
						Tela.imprimirTabuleiro(partida.tab);

						Console.WriteLine();
						Console.WriteLine("   Partida: " + partida.turno);
						Console.WriteLine("   Aguardando jogada: " + partida.jogadorAtual);

						Console.WriteLine();
						Console.Write("   Origem: ");
						Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
						partida.validarPosicaoDeOrigem(origem);

						bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();

						Console.Clear();
						Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

						Console.WriteLine();
						Console.Write("   Destino: ");
						Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
						partida.validarPosicaoDeDestino(origem, destino);

						partida.realizaJogada(origem, destino);
					}
					catch (TabuleiroException e) {
						
						Console.Write("   " + e.Message + "...");
						Console.ReadKey();

					}


				}


			}
			catch (TabuleiroException e) {
				Console.WriteLine(e.Message);
			}

			Console.ReadKey();


		}

	}

}
