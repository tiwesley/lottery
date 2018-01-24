using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Lottery
{
    class Lottery
    {

        // ----------------------------------------------------------------------------------------
        // Instance attributes
        // ----------------------------------------------------------------------------------------

        /// <summary>
        /// Map bet numbers
        /// </summary>
        private Dictionary<string, List<int>> mBetMap = new Dictionary<string, List<int>>();

        /// <summary>
        /// 
        /// </summary>
        private static int mSeqNumber = 0;

        /// <summary>
        /// Number quantity to bet.
        /// </summary>
        private int mNumberQuantityToBet = 6;

        /// <summary>
        /// Min value to bet.
        /// </summary>
        private int mMin = 1;

        /// <summary>
        /// Max value to bet.
        /// </summary>
        private int mMax = 60;

        /// <summary>
        /// Sequential length value.
        /// </summary>
        private int mSeqLength = 6;

        // ----------------------------------------------------------------------------------------
        // Constructor
        // ----------------------------------------------------------------------------------------

        /// <summary>
        /// Default contructor
        /// </summary>
        public Lottery()
        {
        }

        // ----------------------------------------------------------------------------------------
        // Private methods
        // ----------------------------------------------------------------------------------------

        /// <summary>
        /// Generate a sequential number.
        /// </summary>
        /// <returns></returns>
        private string Seq()
        {
            // Local variables
            string sequential;
            Interlocked.Increment(ref mSeqNumber);

            sequential = DateTime.Now.ToString("yyyyMMddHHmmss") + (mSeqNumber).ToString().PadLeft(mSeqLength, '0');

            return sequential;
        }

        /// <summary>
        /// Generate a lottery bet.
        /// </summary>
        /// <returns></returns>
        private List<int> GenerateLottery()
        {
            // Local variables
            List<int> lottery = new List<int>();
            Random numberRand = new Random();
            int count = 0;
            int number;

            while (count < mNumberQuantityToBet)
            {
                number = numberRand.Next(mMin, mMax);

                if (!lottery.Contains(number))
                {
                    lottery.Add(number);
                    count++;
                }
            }

            return lottery;
        }

        /// <summary>
        ///  Validete bet lottery.
        /// </summary>
        /// <param name="hitsNumber">Hits number reference.</param>
        private List<string> ValidateLottery(int hitsNumber, List<int> lottery)
        {
            // Local Variables
            List<string> winList = new List<string>();
            int hits;

            foreach (KeyValuePair<string, List<int>> entry in mBetMap)
            {
                hits = 0;
                foreach (int number in lottery)
                {

                    if (entry.Value.Contains(number))
                    {
                        hits++;
                    }
                }

                if (hits == hitsNumber)
                {
                    winList.Add(entry.Key);
                }

            }

            if (winList.Count > 0)
            {

                Console.WriteLine("\t Ganhadores: ");
                foreach (string win in winList)
                {
                    Console.WriteLine("\t" + win);
                }
            }
            else
            {
                Console.WriteLine("\t Não houve ganhadores!");
            }

            return winList;
        }

        /// <summary>
        /// Write bet.
        /// </summary>
        /// <param name="sequential"></param>
        /// <param name="list"></param>
        private void WriteBet(string sequential, List<int> list)
        {
            Console.WriteLine("\t Jogo número: " + sequential + "\t Números selecionados: " + String.Join(", ", list));
        }

        /// <summary>
        /// Show in console the lottery.
        /// </summary>
        /// <param name="lottery"></param>
        private void showGenerateedLottery(List<int> lottery)
        {
            Console.WriteLine("\t Números Sorteados: ");
            Console.WriteLine("\t " + String.Join(", ", lottery));
            Console.WriteLine("");
        }

        // ----------------------------------------------------------------------------------------
        // Public methods
        // ----------------------------------------------------------------------------------------

        /// <summary>
        /// Add a new bet
        /// </summary>
        public void AddManualBet()
        {
            // Local vaiables
            string betNumber;
            List<int> betList = new List<int>();
            int count = 1;
            int number;

            while (count <= mNumberQuantityToBet)
            {
                Console.WriteLine("Informe o " + count + "º número: ");
                number = Util.ConsoleReadNumber();

                if (betList.Contains(number))
                {
                    Console.WriteLine("Número já selecionado, escolha outro número entre " + mMin + " e " + mMax);
                }
                else if (number <= mMax && number >= mMin)
                {
                    betList.Add(number);
                    count++;
                }
                else
                {
                    Console.WriteLine("Número inválido, escolha outro número entre " + mMin + " e " + mMax);
                }
            }

            betNumber = Seq();
            mBetMap.Add(betNumber, betList);

            Console.Clear();
            WriteBet(betNumber, betList);
        }

        /// <summary>
        /// Add a new bet automatic
        /// </summary>
        public void AddAutoBet()
        {
            // Local variables
            int quantity;
            Dictionary<String, List<int>> map = new Dictionary<string, List<int>>();
            List<int> list;
            String sequential;

            Console.WriteLine("Informe a quantidade de jogos a serem gerados:");
            quantity = Util.ConsoleReadNumber();

            for (int count = 0; count < quantity; count++)
            {
                sequential = Seq();
                list = GenerateLottery();

                mBetMap.Add(sequential, list);
                WriteBet(sequential, list);
                System.Threading.Thread.Sleep(10);
            }
        }

        /// <summary>
        /// Validete bet lottery.
        /// </summary>
        public void ValidateLottery()
        {
            List<int> lottery = GenerateLottery();
            List<string> winList = new List<string>();

            showGenerateedLottery(lottery);

            Console.WriteLine("\n");
            Console.WriteLine("\t Resultado da Sena: ");
            ValidateLottery(6, lottery);
            Console.WriteLine("\n");
            Console.WriteLine("\t Resultado da Quina: ");
            ValidateLottery(5, lottery);
            Console.WriteLine("\n");
            Console.WriteLine("\t Resultado da Quadra: ");
            ValidateLottery(4, lottery);
            Console.WriteLine("\n");
        }

        /// <summary>
        /// Show Mapping bet.
        /// </summary>
        public void ShowMap()
        {
            foreach (KeyValuePair<string, List<int>> entry in mBetMap)
            {
                Console.WriteLine("Jogo: " + entry.Key + " Números: " + String.Join(", ", entry.Value));
            }

        }

        // ----------------------------------------------------------------------------------------
        // Properties
        // ----------------------------------------------------------------------------------------

        /// <summary>
        /// BetMap dictionary property.
        /// </summary>
        public Dictionary<string, List<int>> BetMap
        {
            get { return mBetMap; }
            set { mBetMap = value; }
        }

        /// <summary>
        /// Sequential number property
        /// </summary>
        public int SeqNumber
        {
            get { return mSeqNumber; }
            set { mSeqNumber = value; }
        }

        /// <summary>
        /// Number quantity to bet property.
        /// </summary>
        public int NumberQuantity
        {
            get { return mNumberQuantityToBet; }
            set { mNumberQuantityToBet = value; }
        }

        /// <summary>
        /// Min value to bet property.
        /// </summary>
        public int Min
        {
            get { return mMin; }
            set { mMin = value; }
        }

        /// <summary>
        /// Max value to bet property.
        /// </summary>
        public int Max
        {
            get { return mMax; }
            set { mMax = value; }
        }

        /// <summary>
        /// Sequential length property.
        /// </summary>
        public int SeqLength
        {
            get { return mSeqLength; }
            set { mSeqLength = value; }
        }
    }
}
