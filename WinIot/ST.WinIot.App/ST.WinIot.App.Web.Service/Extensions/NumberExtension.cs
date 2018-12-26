
namespace System
{
    public static class NumberExtension
    {

        public static bool IsEven(this int number)
        {
            if (number % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static bool IsEven(this double number)
        {
            if (number % 2 == 0.0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
