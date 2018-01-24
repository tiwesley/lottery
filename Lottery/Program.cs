using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery
{
    class Program
    {
        // ----------------------------------------------------------------------------------------
        // Main methods
        // ----------------------------------------------------------------------------------------

        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Local variables
            int option;
            Lottery lottery = new Lottery();

            // Configurations with properties
            // lottery.Max = 10;

            do
            {
                Console.WriteLine("");

                // Options menu
                Console.WriteLine("Selecione a opção");
                Console.WriteLine("\t 1 - Inserir novo jogo (manual)");
                Console.WriteLine("\t 2 - Inserir novo jogo (automático)");
                Console.WriteLine("\t 3 - Jogos realizados");
                Console.WriteLine("\t 4 - Sortear");
                Console.WriteLine("\t 5 - Sair");

                option = Util.ConsoleReadNumber();

                showOptionSelected(option, lottery);

            } while (option != 5);

        }

        // ----------------------------------------------------------------------------------------
        // Private methods
        // ----------------------------------------------------------------------------------------

        /// <summary>
        /// Show options selected

        private static void showOptionSelected(int option, Lottery lottery)
        {
            Console.Clear();

            switch (option)
            {
                case 1:
                    lottery.AddManualBet();
                    break;
                case 2:
                    lottery.AddAutoBet();
                    break;
                case 3:
                    lottery.ShowMap();
                    break;
                case 4:
                    lottery.ValidateLottery();
                    break;
                case 5:
                    // Does nothing.
                    break;
                default:
                    Console.WriteLine("Selecione uma opção válida! \n");
                    break;
            }
        }

    }
}
