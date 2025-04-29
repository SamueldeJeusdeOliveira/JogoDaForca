using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaForca
{
    class PalavraSecreta
    {
        private string palavra;
        private char[] letrasDescobertas;

        public PalavraSecreta(string palavra)
        {
            this.palavra = palavra;
            letrasDescobertas = new char[palavra.Length];
            for (int i = 0; i < letrasDescobertas.Length; i++)
            {
                letrasDescobertas[i] = '_';
            }
        }

        public bool TentarLetra(char letra)
        {
            bool encontrada = false;
            for (int i = 0; i < palavra.Length; i++)
            {
                if (palavra[i] == letra)
                {
                    letrasDescobertas[i] = letra;
                    encontrada = true;
                }
            }
            return encontrada;
        }

        public bool FoiDescoberta()
        {
            return new string(letrasDescobertas) == palavra;
        }

        public void RevelarTudo()
        {
            letrasDescobertas = palavra.ToCharArray();
        }

        public string ObterDica()
        {
            return string.Join(" ", letrasDescobertas);
        }
    }
}
