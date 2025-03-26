namespace JogoDaForca
{
    class Program
    {
        //Versão 1: Estrutura básica e entrada do usuário
        static void Main(string[] args)
        {
            while (true)
            {
                
                string palavraSecreta = "CIA";

                char[] letrasDescobertas = new char[palavraSecreta.Length];

                for (int caractere = 0; caractere < letrasDescobertas.Length; caractere++)
                {
                    // acessar o array no indice 0
                    letrasDescobertas[caractere] = '_';
                }
                

                int quantidadeErros = 0;
                bool jogadorEnforcou = false;
                bool jogadorAcertou = false;
                do
                {
                    
                    string dicaDaPalavra = String.Join(" ", letrasDescobertas);
                    
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine("Jogo da Forca");
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine("Palavra Secreta: " + dicaDaPalavra);
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine("Quantidade de Erros: " + quantidadeErros);
                    Console.WriteLine("----------------------------------------------");

                    Console.Write("Digite uma letra: ");
                    char letra = Console.ReadLine()[0]; // obtém apenas um caractere do que o usuário digita

                    bool letraFoiEncontrada = false;
                    for (int contador = 0; contador < palavraSecreta.Length; contador++)
                    {
                        char letraAtual = palavraSecreta[contador];

                        if (letra == letraAtual)
                        {
                            letrasDescobertas[contador] = letraAtual;
                            letraFoiEncontrada = true;
                        }
                        
                    }
                    if (!letraFoiEncontrada)
                    {
                        quantidadeErros++;
                    }
                    string dicadaPalavra = String.Join(" ", letrasDescobertas);

                    jogadorAcertou = dicadaPalavra == palavraSecreta;

                    jogadorEnforcou = quantidadeErros > 5;
                    jogadorAcertou = new string(letrasDescobertas) == palavraSecreta;
                    Console.Clear();
                    if (jogadorAcertou)
                    {
                        Console.Clear();
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine($"Parabéns, você acertou a palavra {palavraSecreta}!");
                        Console.WriteLine("----------------------------------------------");
                        break;
 
                    }
                    else if (jogadorEnforcou)
                    {
                        Console.Clear();
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine("Que azar, tente novamente! A palavra era: " + palavraSecreta);
                        Console.WriteLine("----------------------------------------------");
                        break;
                    }

                } while (jogadorAcertou == false || jogadorEnforcou == false);
                Console.Write("Deseja Continuar Jogando?(S/N) ");
                char continuar = Console.ReadLine()[0];
                if (continuar == 'N') { break; }
            }
        }
    }
}