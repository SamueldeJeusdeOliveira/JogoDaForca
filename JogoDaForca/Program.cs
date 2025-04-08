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
                while (true)
                {
                    string[] palavrasSecretas = new string[]
                    {
                        "ABACATE", "ABACAXI", "ACEROLA", "AÇAÍ", "ARAÇA", "BACABA", "BACURI", "BANANA",
                        "CARÁCAJÚ", "CARAMBOLA", "CUPUAÇU", "GRAVIOLA", "GOIABA", "JABUTICABA", "JENIPAPO",
                        "MAÇÃ","MANGABA", "MANGA", "MARACUJÁ", "MURICI", "PEQUI", "PITANGA", "PITAYA",
                        "SAPOTI", "TANGERINA", "UMBU", "UVA", "UVAIA"
                    };

                    string palavraSecreta = palavrasSecretas[new Random().Next(0, palavrasSecretas.Length)].ToUpper();
                    char[] letrasDescobertas = new char[palavraSecreta.Length];
                    List<string> tentativas = new List<string>();

                    for (int i = 0; i < letrasDescobertas.Length; i++)
                    {
                        letrasDescobertas[i] = '_';
                    }

                    int quantidadeErros = 0;
                    bool jogadorEnforcou = false;
                    bool jogadorAcertou = false;

                    do
                    {
                        string dicaDaPalavra = String.Join(" ", letrasDescobertas);

                        Console.Clear();
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine("Jogo da Forca");
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine("Tema: Frutas");
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine("Palavra Secreta: " + dicaDaPalavra);
                        Console.WriteLine("Tentativas anteriores: " + string.Join(", ", tentativas));
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine("Erros: " + quantidadeErros + " de 5");
                        DesenharBoneco(quantidadeErros);
                        Console.WriteLine("----------------------------------------------");

                        Console.Write("Digite uma letra ou palavra: ");
                        string tentativa = Console.ReadLine().ToUpper();

                        if (tentativas.Contains(tentativa))
                        {
                            Console.WriteLine("Você já tentou isso. Pressione qualquer tecla para continuar.");
                            Console.ReadKey();
                            continue;
                        }

                        tentativas.Add(tentativa);
                        bool letraFoiEncontrada = false;

                        if (tentativa.Length > 1)
                        {
                            if (tentativa == palavraSecreta)
                            {
                                letrasDescobertas = palavraSecreta.ToCharArray();
                                jogadorAcertou = true;
                                break;
                            }
                            else
                            {
                                quantidadeErros++;
                            }
                        }
                        else
                        {
                            char letra = tentativa[0];
                            for (int i = 0; i < palavraSecreta.Length; i++)
                            {
                                if (palavraSecreta[i] == letra)
                                {
                                    letrasDescobertas[i] = letra;
                                    letraFoiEncontrada = true;
                                }
                            }

                            if (!letraFoiEncontrada)
                            {
                                quantidadeErros++;
                            }
                        }

                        jogadorAcertou = new string(letrasDescobertas) == palavraSecreta;
                        jogadorEnforcou = quantidadeErros >= 5;

                    } while (!jogadorAcertou && !jogadorEnforcou);

                    Console.Clear();
                    if (jogadorAcertou)
                    {
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine($"Parabéns, você acertou a palavra {palavraSecreta}!");
                        Console.WriteLine("----------------------------------------------");
                    }
                    else
                    {
                        DesenharBoneco(quantidadeErros);
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine("Que azar, tente novamente! A palavra era: " + palavraSecreta);
                        Console.WriteLine("----------------------------------------------");
                    }

                    Console.Write("Deseja Continuar Jogando? (S/N) ");
                    char continuar = Console.ReadLine()[0];
                    if (continuar == 'N' || continuar == 'n') { break; }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Um erro aconteceu! O jogo será reiniciado");
            }
        }

        static void DesenharBoneco(int erros)
        {
            Console.WriteLine(" +---+");
            Console.WriteLine(" |   |");

            if (erros >= 1)
                Console.WriteLine(" O   |");
            else
                Console.WriteLine("     |");

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
