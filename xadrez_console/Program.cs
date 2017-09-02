using System;
using tabuleiro;
using xadrez;

namespace xadrez_console {
	
	class MainClass {
		
		public static void Main(string[] args) {

			Console.BackgroundColor = ConsoleColor.DarkRed;

			try {
				Tabuleiro tab = new Tabuleiro(8, 8);

				tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
				tab.colocarPeca(new Torre(tab, Cor.Branca), new Posicao(1, 3));
				tab.colocarPeca(new Rei(tab, Cor.Preta), new Posicao(0, 2));

				tab.colocarPeca(new Rei(tab, Cor.Branca), new Posicao(0, 6));

				Tela.imprimirTabuleiro(tab);
			}
			catch (TabuleiroException e) {
				Console.WriteLine(e.Message);
			}

			Console.ReadKey();


		}

	}

}
