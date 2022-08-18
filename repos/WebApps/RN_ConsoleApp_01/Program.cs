using System;

class Program
{
    /// <summary>
    /// Determines whether the string is a palindrome.
    /// My Comments: I found an example on Google and changed just builded Try/Catch around to make sure that errors are caught. 
    /// The method compares only letters and digits and ignores casing
    /// The method handles both int's and strings
    /// </summary>
    public static bool IsPalindrome(string value)
    {
        int min = 0;
        int max = value.Length - 1;
        while (true)
        {
            if (min > max)
            {
                return true;
            }
            char a = value[min];
            char b = value[max];

            // Scan forward for a while invalid.
            while (!char.IsLetterOrDigit(a))
            {
                min++;
                if (min > max)
                {
                    return true;
                }
                a = value[min];
            }

            // Scan backward for b while invalid.
            while (!char.IsLetterOrDigit(b))
            {
                max--;
                if (min > max)
                {
                    return true;
                }
                b = value[max];
            }

            if (char.ToLower(a) != char.ToLower(b))
            {
                return false;
            }
            min++;
            max--;
        }
    }

    static void Main()
    {
        string[] array =
        {
                "123@321",
                "123456789098765432",
                "A man, a plan, a canal: Panama.",
                "A Toyota. Race fast, safe car. A Toyota.",
                "Cigar? Toss it in a can. It is so tragic.",
                "Was it a car @£$ or a cat I saw?",
                "...",
                "...Test"
            };
        try
        {
            foreach (string value in array)
            {
                Console.WriteLine("{0} = {1}", value, IsPalindrome(value));
            }
        }
        catch (Exception ex)
        {
            string error = "Unexpected error: " + ex.Message;
            Console.WriteLine(error);
        }
    }
}
