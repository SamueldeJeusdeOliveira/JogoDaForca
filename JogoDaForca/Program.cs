using System;
using System.Collections.Generic;

namespace JogoDaForca
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Jogo jogo = new Jogo();
                jogo.Iniciar();
            }
            catch (Exception)
            {
                Console.WriteLine("Um erro aconteceu! O jogo será reiniciado.");
            }
        }
    }
}