using System;
using tabuleiro;

namespace xadrez_console {
	
	class MainClass {
		
		public static void Main(string[] args) {

			Tabuleiro tab = new Tabuleiro(8, 8);

			Tela.imprimirTabuleiro(tab);

			Console.ReadKey();

		}

	}

}
