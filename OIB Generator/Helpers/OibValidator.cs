using System;

namespace OIB_Generator.Helpers
{
    public static class OibValidator
    {
        /// <summary>
        /// Checks if OIB is compliant with ISO 7064 standard
        /// </summary>
        /// <param name="oib">OIB (Osobni Identifikacijski Broj)</param>
        /// <returns>true if OIB is valid, else false</returns>
        public static bool IsValidOib(string oib)
        {
            if (oib.Length != 11)
                return false;

            if (!long.TryParse(oib, out _))
                return false;

            int checkSum = 10;
            for (int i = 0; i < 10; i++)
            {
                checkSum += Convert.ToInt32(oib.Substring(i, 1));
                checkSum %= 10;

                if (checkSum == 0)
                    checkSum = 10;

                checkSum *= 2;
                checkSum %= 11;
            }

            int controlNum = 11 - checkSum;
            if (controlNum == 10) controlNum = 0;

            return controlNum == Convert.ToInt32(oib.Substring(10, 1));
        }
    }
}
