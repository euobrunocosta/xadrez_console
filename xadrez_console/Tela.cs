using System;
using System.Collections.Generic;
using tabuleiro;
using xadrez;

namespace xadrez_console {
	
	class Tela {

		public static void imprimirTabuleiro(Tabuleiro tab) {

			Console.ForegroundColor = ConsoleColor.Yellow;

			Console.WriteLine();
			for (int i = 0; i < tab.linhas; i++) {

				Console.Write("   " + (8 - i) + " ");
				for (int j = 0; j < tab.colunas; j++) {
					imprimirPeca(tab.peca(i, j));
				}
				Console.WriteLine();
			}
			Console.WriteLine("     a b c d e f g h ");

		}

		public static void imprimirPartida(PartidaDeXadrez partida) {
			Console.WriteLine();
			imprimirTabuleiro(partida.tab);
			Console.WriteLine();
            imprimirPecasCapturadas(partida);
			Console.WriteLine("\n");
			Console.WriteLine("   Partida: " + partida.turno);
			if (!partida.terminada) {
				Console.Write("   Aguardando jogada: ");
				Console.ForegroundColor = (partida.jogadorAtual == Cor.Branca ? ConsoleColor.White : ConsoleColor.Black);
				Console.WriteLine(partida.jogadorAtual);
				if (partida.xeque) {
					Console.WriteLine();
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("   XEQUE!");
					Console.ForegroundColor = ConsoleColor.Yellow;
				}
			}
			else {
				Console.WriteLine();
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("   XEQUEMATE!");
				Console.WriteLine();
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.Write("   Vencedor: ");
				Console.ForegroundColor = (partida.jogadorAtual == Cor.Branca? ConsoleColor.White : ConsoleColor.Black);
				Console.WriteLine(partida.jogadorAtual);
				Console.ForegroundColor = ConsoleColor.Yellow;
			}
		}

		public static void imprimirPartida(PartidaDeXadrez partida, bool [,] posicoesPossiveis) {
			Console.WriteLine();
			imprimirTabuleiro(partida.tab, posicoesPossiveis);
			Console.WriteLine();
			imprimirPecasCapturadas(partida);
			Console.WriteLine("\n");
			Console.WriteLine("   Partida: " + partida.turno);
			Console.Write("   Aguardando jogada: ");
			Console.ForegroundColor = (partida.jogadorAtual == Cor.Branca ? ConsoleColor.White : ConsoleColor.Black);
			Console.WriteLine(partida.jogadorAtual);
			Console.ForegroundColor = ConsoleColor.Yellow;
			if (partida.xeque) {
				Console.WriteLine();
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("   XEQUE!");
				Console.ForegroundColor = ConsoleColor.Yellow;
			}
		}

		public static void imprimirPecasCapturadas(PartidaDeXadrez partida) {
			Console.WriteLine("   Peças capturadas:");
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write("   Brancas: ");
			imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.Black;
			Console.Write("   Pretas: ");
			imprimirConjunto(partida.pecasCapturadas(Cor.Preta));

			Console.ForegroundColor = ConsoleColor.Yellow;
		}

		public static void imprimirConjunto(HashSet<Peca> conjunto) {
			Console.Write("[ ");
			foreach (Peca x in conjunto) {
				Console.Write(x + " ");
			}
			Console.Write("]");
		}

		public static void imprimirTabuleiro(Tabuleiro tab, bool [,] posicoesPossiveis) {

			ConsoleColor fundoOriginal = Console.BackgroundColor;
			ConsoleColor fundoAlterado = ConsoleColor.Cyan;

			Console.ForegroundColor = ConsoleColor.Yellow;

			Console.WriteLine();
			for (int i = 0; i < tab.linhas; i++) {

				Console.Write("   " + (8 - i) + " ");
				for (int j = 0; j < tab.colunas; j++) {
					if (posicoesPossiveis[i, j]) {
						Console.BackgroundColor = fundoAlterado;
					}
					else {
						Console.BackgroundColor = fundoOriginal;
					}
					imprimirPeca(tab.peca(i, j));
					Console.BackgroundColor = fundoOriginal;
				}
				Console.WriteLine();
			}
			Console.WriteLine("     a b c d e f g h ");
			Console.BackgroundColor = fundoOriginal;
		}

		public static PosicaoXadrez lerPosicaoXadrez() {
			string s = Console.ReadLine();
			char coluna = s[0];
			int linha = int.Parse(s[1] + "");
			return new PosicaoXadrez(coluna, linha);
		}

		public static void imprimirPeca(Peca peca) {
			if (peca == null) {
				Console.Write("- ");
			}
			else {
				if (peca.cor == Cor.Preta) {
					Console.ForegroundColor = ConsoleColor.Black;
					Console.Write(peca);
					Console.ForegroundColor = ConsoleColor.Yellow;
				}
				else {
					Console.ForegroundColor = ConsoleColor.White;
					Console.Write(peca);
					Console.ForegroundColor = ConsoleColor.Yellow;
				}
				Console.Write(" ");
			}
				
		}

	}

}
