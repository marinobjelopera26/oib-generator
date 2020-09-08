using System;

namespace OIB_Generator
{
    public static class OibGenerator
    {
        private static readonly Random _random = new Random();

        /// <summary>
        /// Generates the first 10 digits of OIB (Osobni Identifikacijski Broj) randomly
        /// and adds the 11th, check sum digit to the OIB
        /// </summary>
        /// <returns>Fully generated, valid OIB with 11 digits</returns>
        public static string GenerateOib()
        {
            string oib = "";

            for (int i = 0; i < 10; i++)
            {
                oib += $"{_random.Next(1, 9)}";
            }

            return AddCheckSumDigit(oib);
        }

        /// <summary>
        /// Generates the last digit of OIB(Osobni Identifikacijski Broj)
        /// depending on the previous 10 numbers
        /// </summary>
        /// <param name="oib">OIB (Osobni Identifikacijsi Broj)</param>
        /// <returns>Fully generated, valid OIB with 11 digits</returns>
        private static string AddCheckSumDigit(string oib)
        {
            int remainder = 0;

            for (int i = 0; i <= oib.Length; i++)
            {
                if (i == oib.Length)
                {
                    if (remainder == 1)
                        oib += "0";
                    else
                        oib += $"{11 - remainder}";

                    break;
                }

                int digit = Convert.ToInt32(oib.Substring(i, 1));

                if (i == 0)
                    digit += 10;
                else
                    digit += remainder;

                var d = digit % 10;
                if (d == 0)
                    d = 10;

                var e = d * 2;

                remainder = e % 11;
            }

            return oib;
        }
    }
}