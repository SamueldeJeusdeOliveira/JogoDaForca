using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaForca
{
    static class Boneco
    {
        public static void Desenhar(int erros)
        {
            Console.WriteLine(" +---+");
            Console.WriteLine(" |   |");

            Console.WriteLine(erros >= 1 ? " O   |" : "     |");

            if (erros == 2)
                Console.WriteLine(" |   |");
            else if (erros == 3)
                Console.WriteLine("/|   |");
            else if (erros >= 4)
                Console.WriteLine("/|\\  |");
            else
                Console.WriteLine("     |");

            if (erros == 5)
                Console.WriteLine("/ \\  |");
            else if (erros == 4)
                Console.WriteLine("/    |");
            else
                Console.WriteLine("     |");

            Console.WriteLine("     |");
            Console.WriteLine("=========");
        }
    }
}
