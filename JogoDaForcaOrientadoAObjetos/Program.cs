using System.Diagnostics;

namespace JogoDaForcaOrientadoAObjetos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int op = 1;
            while (op == 1)
            {
                Interface.Cabecalho();

                string frase = Engine.Dados();
                int tamanhodafrase, conterro, cont;
                char[] frasevetorizada, resultado;
                string cabeca = "", bracoe = "", bracod = "", corpo = "", perna = "";
                Interface.Escopo(frase, out tamanhodafrase, out frasevetorizada, out conterro, out cont, out resultado);

                while (true)
                {

                    char chute = Engine.Chute();
                    chute = Engine.ConverteEmMaiuscula(chute);
                    Interface.Cabecalho();
                    Engine.Equacao(frasevetorizada, ref conterro, ref cont, resultado, chute, cabeca, bracoe, bracod, corpo, perna);

                    if (cont == tamanhodafrase)
                    {
                        Interface.Win();
                        break;
                    }
                    if (conterro == 0)
                    {
                        Interface.GameOver();
                        break;
                    }
                }
                Interface.Cabecalho();
                op = Interface.Rexit();
            }
        }
    }

    public class Interface
    {
        public static void Cabecalho()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Clear();
            Console.WriteLine("######################################################################################");
            Console.WriteLine("###                                                                                ###");
            Console.WriteLine("###                          Academia do programador 2024                          ###");
            Console.WriteLine("###                                                                                ###");
            Console.WriteLine("###                              Jogo da adivinhação                               ###");
            Console.WriteLine("###                                                                                ###");
            Console.WriteLine("######################################################################################\n\n");
        }
        public static void Escopo(string frase, out int tamanhodafrase, out char[] frasevetorizada, out int conterro, out int cont, out char[] resultado)
        {
            tamanhodafrase = frase.Length;
            string traco = new string('_', tamanhodafrase);

            Console.WriteLine(" ___________");
            Console.WriteLine(" |/        |");
            Console.WriteLine(" |");
            Console.WriteLine(" |");
            Console.WriteLine(" |");
            Console.WriteLine(" |");
            Console.WriteLine(" |");
            Console.WriteLine(" |");
            Console.WriteLine("_|____\n\n");
            Console.WriteLine(traco);


            frasevetorizada = frase.ToCharArray();
            conterro = 5;
            cont = 0;
            resultado = traco.ToCharArray();
        }
        public static int Rexit() //Rexit = Restart or Exit
        {
            int opm;
            while (true)
            {
                opm = Engine.LerInt("Escolha sua opção.\n\n1. Jogar novamente\n2. Sair\n\nDigite sua opção: ");
                if (opm != 1 && opm != 2)
                {
                    Console.Write("\nPor favor escolha uma opção valida do menu.\n\nPrecione qualquer tecla para continuar.");
                    Console.ReadKey();
                    continue;
                }
                break;
            }
            return opm;
        }
        public (int, string, string, string, string, string) Erro(char[] frasevetorizada, int conterro, char chute, int auxerro, string cabeca , string bracoe, string bracod, string corpo, string perna)
        {
            for (int i = 0; i < frasevetorizada.Length; i++)
            {
                if (frasevetorizada[i] != chute)
                {
                    auxerro++;
                }
            }
            if (auxerro == frasevetorizada.Length)
            {
                conterro--;
            }
            if (conterro == 5)
            {
                Console.WriteLine(" ___________");
                Console.WriteLine(" |/        |");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine("_|____\n");
            }
            else
            {
                
                if (conterro == 4)
                {
                    cabeca = "o";
                }

                if (conterro == 3)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    corpo = "x";
                }

                if (conterro == 2)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    bracoe = "/";
                }

                if (conterro == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    bracod = "\\";
                }

                if (conterro == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    perna = "/ \\";
                }
                Console.WriteLine(" ___________");
                Console.WriteLine(" |/        |");
                Console.WriteLine($" |         {cabeca}");
                Console.WriteLine($" |        {bracoe}{corpo}{bracod}");
                Console.WriteLine($" |         {perna}");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine("_|____\n");
            }
            
            return (conterro, cabeca, bracoe, corpo, bracod, perna);
        }
        public static void Win()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n\n######################################################################################");
            Console.WriteLine("###                                                                                ###");
            Console.WriteLine("###                                 Você venceu!!!                                 ###");
            Console.WriteLine("###                                                                                ###");
            Console.WriteLine("###                     Precione qualquer tecla para continuar.                    ###");
            Console.WriteLine("###                                                                                ###");
            Console.WriteLine("######################################################################################");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.ReadKey();
        }
        public static void GameOver()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n\n######################################################################################");
            Console.WriteLine("###                                                                                ###");
            Console.WriteLine("###                                   Game Over!                                   ###");
            Console.WriteLine("###                                                                                ###");
            Console.WriteLine("###           Que pena, suas chances acabaram. mais sorte da proxima vez.          ###");
            Console.WriteLine("###                     Precione qualquer tecla para continuar.                    ###");
            Console.WriteLine("###                                                                                ###");
            Console.WriteLine("######################################################################################");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.ReadKey();
        }
    }

    public class Engine
    {
        public static int LerInt(string texto)
        {
            while (true)
            {
                Console.Write(texto);
                var digitouNumero = int.TryParse(Console.ReadLine(), out var numero);

                if (digitouNumero)
                {
                    return numero;
                }

                Console.Write("\nPor favor digite um numero.\n\nPrecione qualquer tecla para continuar.");
                Console.ReadLine();
                Interface.Cabecalho();
            }
        }
        public static string Dados()
        {
            Random escolhefrase = new Random();
            int numeroaleatorio = escolhefrase.Next(1, 29);
            string frase = "";
            switch (numeroaleatorio)
            {
                case 1:
                    frase = "ABACATE";
                    break;

                case 2:
                    frase = "ABACAXI";
                    break;

                case 3:
                    frase = "ACEROLA";
                    break;

                case 4:
                    frase = "AÇAÍ";
                    break;

                case 5:
                    frase = "ARAÇA";
                    break;

                case 6:
                    frase = "BACABA";
                    break;

                case 7:
                    frase = "BACURI";
                    break;

                case 8:
                    frase = "BANANA";
                    break;

                case 9:
                    frase = "CAJÁ";
                    break;

                case 10:
                    frase = "CAJÚ";
                    break;

                case 11:
                    frase = "CARAMBOLA";
                    break;

                case 12:
                    frase = "CUPUAÇU";
                    break;

                case 13:
                    frase = "GRAVIOLA";
                    break;

                case 14:
                    frase = "GOIABA";
                    break;

                case 15:
                    frase = "JABUTICABA";
                    break;

                case 16:
                    frase = "JENIPAPO";
                    break;

                case 17:
                    frase = "MAÇÃ";
                    break;

                case 18:
                    frase = "MANGABA";
                    break;

                case 19:
                    frase = "MANGA";
                    break;

                case 20:
                    frase = "MARACUJÁ";
                    break;

                case 21:
                    frase = "MURICI";
                    break;

                case 22:
                    frase = "PEQUI";
                    break;

                case 23:
                    frase = "PITANGA";
                    break;

                case 24:
                    frase = "PITAYA";
                    break;

                case 25:
                    frase = "SAPOTI";
                    break;

                case 26:
                    frase = "TANGERINA";
                    break;

                case 27:
                    frase = "UMBU";
                    break;

                case 28:
                    frase = "UVA";
                    break;

                case 29:
                    frase = "UVAIA";
                    break;
            }
            return frase;
        }
        public static char Chute()
        {
            string check;
            while (true)
            {
                Console.Write("\n\n Qual seu chute? ");
                check = Console.ReadLine();
                if (check != "a" && check != "A" && check != "á" && check != "Á" && check != "à" && check != "À" && check != "â" && check != "Â" && check != "ã" && check != "Ã" && check != "b" && check != "B" && check != "c" && check != "C" && check != "d" && check != "D" && check != "E" && check != "e" && check != "É" && check != "é" && check != "Ê" && check != "ê" && check != "F" && check != "f" && check != "G" && check != "g" && check != "H" && check != "h" && check != "I" && check != "i" && check != "Í" && check != "í" && check != "J" && check != "j" && check != "K" && check != "k" && check != "L" && check != "l" && check != "M" && check != "m" && check != "N" && check != "n" && check != "O" && check != "o" && check != "Ó" && check != "ó" && check != "Ô" && check != "ô" && check != "P" && check != "p" && check != "Q" && check != "q" && check != "R" && check != "r" && check != "S" && check != "s" && check != "T" && check != "t" && check != "U" && check != "u" && check != "Ú" && check != "ú" && check != "V" && check != "v" && check != "W" && check != "w" && check != "X" && check != "x" && check != "Y" && check != "y" && check != "Z" && check != "z")
                {
                    Console.Write("\n\nCaractere digitado inválido, verifique o caractere digitado. Precione qualquer tecla para continuar.");
                    Console.ReadKey();
                    continue;
                }
                break;
            }
            char chute = Convert.ToChar(check);
            return chute;
        }
        public static char ConverteEmMaiuscula(char chute)
        {
            if (char.IsLower(chute)) //troque chute por sua variavel char em letra minuscula
            {
                chute = char.ToUpper(chute);
            }
            return chute;
        }
        public static void Equacao(char[] frasevetorizada, ref int conterro, ref int cont, char[] resultado, char chute, string cabeca, string bracoe, string bracod, string corpo, string perna)
        {
            int auxerro = 0;
            (conterro, cabeca, bracoe, corpo, bracod, perna) = Interface.Erro(frasevetorizada, conterro, chute, auxerro, cabeca, bracoe, bracod, corpo, perna);

            for (int i = 0; i < frasevetorizada.Length; i++)
            {
                if (frasevetorizada[i] == chute)
                {
                    if (resultado[i] == '_')
                    {
                        resultado[i] = frasevetorizada[i];
                        cont++;
                    }
                }
                Console.Write(resultado[i]);
            }
        }
       
    }
}
