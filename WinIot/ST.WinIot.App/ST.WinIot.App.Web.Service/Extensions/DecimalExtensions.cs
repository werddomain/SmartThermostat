using ST.WinIot.App.Web.Service;
using System;
namespace System.Web
{
    public enum MidpointRounding
    {
        ToEven,
        AwayFromZero
    }

    public static class DecimalExtensions
    {
        public static decimal Round(this decimal d, MidpointRounding mode)
        {
            return d.Round(0, mode);
        }

        /// <summary>
        /// Rounds using arithmetic (5 rounds up) symmetrical (up is away from zero) rounding
        /// </summary>
        /// <param name="d">A Decimal number to be rounded.</param>
        /// <param name="decimals">The number of significant fractional digits (precision) in the return value.</param>
        /// <returns>The number nearest d with precision equal to decimals. If d is halfway between two numbers, then the nearest whole number away from zero is returned.</returns>
        public static decimal Round(this decimal d, int decimals, MidpointRounding mode)
        {
            if (mode == MidpointRounding.ToEven)
            {
                return Math.Round(d, decimals, System.MidpointRounding.ToEven);
            }
            else
            {
                decimal factor = Convert.ToDecimal(Math.Pow(10, decimals));
                int sign = Math.Sign(d);
                return Decimal.Truncate(d * factor + 0.5m * sign) / factor;
            }
        }
        
        
        public static string ToPrice(this double value)
        {
            return string.Format("{0:N2}", Math.Round(value, 2, System.MidpointRounding.AwayFromZero));
        }
        public static string ToPrice(this decimal value)
        {
            return string.Format("{0:N2}", Math.Round(value, 2, System.MidpointRounding.AwayFromZero));
        }
    }
}
