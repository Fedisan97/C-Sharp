using System;

class Program
{
    static void Main(string[] args)
    {
        string password = Console.ReadLine();
        if (IsValidPassword(password))
        {
            Console.WriteLine("YES");
        }
        else
        {
            Console.WriteLine("NO");
        }
    }

    private static bool IsValidPassword(string password)
    {
        if (password.Length < 8 || password.Length > 14)
        {
            return false;
        }

        int upperCaseCount = 0;
        int lowerCaseCount = 0;
        int digitCount = 0;
        int specialCharacterCount = 0;

        foreach (char c in password)
        {
            if (c >= 'A' && c <= 'Z')
            {
                upperCaseCount++;
            }
            else if (c >= 'a' && c <= 'z')
            {
                lowerCaseCount++;
            }
            else if (c >= '0' && c <= '9')
            {
                digitCount++;
            }
            else if ((c >= 33 && c <= 47) || (c >= 58 && c <= 64) || (c >= 91 && c <= 96) || (c >= 123 && c <= 126))
            {
                specialCharacterCount++;
            }
            else
            {
                return false;
            }
        }

        int criteriaMet = (upperCaseCount > 0 ? 1 : 0)
                        + (lowerCaseCount > 0 ? 1 : 0)
                        + (digitCount > 0 ? 1 : 0)
                        + (specialCharacterCount > 0 ? 1 : 0);

        return criteriaMet >= 3;
    }
}
