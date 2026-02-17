using System.Numerics;

public static class NumberFormatter
{
    private static readonly string[] suffixes = 
    { 
        "", "K", "M", "B", "T", 
        "Qa", "Qi", "Sx", "Sp", "Oc", "No", "Dc" 
    };

    public static string Format(BigInteger number)
    {
        if (number < 1000)
            return number.ToString();

        int magnitude = 0;
        BigInteger temp = number;

        while (temp >= 1000 && magnitude < suffixes.Length - 1)
        {
            temp /= 1000;
            magnitude++;
        }

        double shortened = (double)number / System.Math.Pow(1000, magnitude);

        return shortened.ToString("F2") + suffixes[magnitude];
    }
    public static string Format(double number)
    {
        if (number < 1000)
        {
            return number.ToString("F2");
        }
        int magnitude = 0;
        while (number >= 1000 && magnitude < suffixes.Length - 1)
        {
            number /= 1000;
            magnitude++;
        }
        return number.ToString("F2") + suffixes[magnitude];
    }

}