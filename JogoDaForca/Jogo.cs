using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaForca
{
    class Jogo
    {
        private string[] palavrasSecretas = new string[]
        {
            "ABACATE", "ABACAXI", "ACEROLA", "AÇAÍ", "ARAÇA", "BACABA", "BACURI", "BANANA",
            "CARÁCAJÚ", "CARAMBOLA", "CUPUAÇU", "GRAVIOLA", "GOIABA", "JABUTICABA", "JENIPAPO",
            "MAÇÃ","MANGABA", "MANGA", "MARACUJÁ", "MURICI", "PEQUI", "PITANGA", "PITAYA",
            "SAPOTI", "TANGERINA", "UMBU", "UVA", "UVAIA"
        };

        public void Iniciar()
        {
            while (true)
            {
                string palavra = palavrasSecretas[new Random().Next(palavrasSecretas.Length)].ToUpper();
                PalavraSecreta palavraSecreta = new PalavraSecreta(palavra);
                List<string> tentativas = new List<string>();
                int erros = 0;

                while (!palavraSecreta.FoiDescoberta() && erros < 5)
                {
                    Console.Clear();
                    ExibirStatus(palavraSecreta, tentativas, erros);
                    Console.Write("Digite uma letra ou palavra: ");
                    string tentativa = Console.ReadLine().ToUpper();

                    if (tentativas.Contains(tentativa))
                    {
                        Console.WriteLine("Você já tentou isso. Pressione qualquer tecla para continuar.");
                        Console.ReadKey();
                        continue;
                    }

                    tentativas.Add(tentativa);

                    if (tentativa.Length > 1)
                    {
                        if (tentativa == palavra)
                        {
                            palavraSecreta.RevelarTudo();
                            break;
                        }
                        else
                        {
                            erros++;
                        }
                    }
                    else
                    {
                        if (!palavraSecreta.TentarLetra(tentativa[0]))
                        {
                            erros++;
                        }
                    }
                }

                Console.Clear();
                if (palavraSecreta.FoiDescoberta())
                {
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine($"Parabéns, você acertou a palavra {palavra}!");
                    Console.WriteLine("----------------------------------------------");
                }
                else
                {
                    Boneco.Desenhar(erros);
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine("Que azar, tente novamente! A palavra era: " + palavra);
                    Console.WriteLine("----------------------------------------------");
                }

                Console.Write("Deseja Continuar Jogando? (S/N) ");
                char continuar = Console.ReadLine()[0];
                if (continuar == 'N' || continuar == 'n') break;
            }
        }
        private void ExibirStatus(PalavraSecreta palavraSecreta, List<string> tentativas, int erros)
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Jogo da Forca");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Tema: Frutas");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Palavra Secreta: " + palavraSecreta.ObterDica());
            Console.WriteLine("Tentativas anteriores: " + string.Join(", ", tentativas));
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Erros: " + erros + " de 5");
            Boneco.Desenhar(erros);
            Console.WriteLine("----------------------------------------------");
        }

    }
}
