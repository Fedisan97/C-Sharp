using System;

class Program
{
    static void Main()
    {
 
        int[] nums = { 1, 2, 1, 3, 2, 5 };


        int[] result = SingleNumber(nums);


        Console.WriteLine("Уникальные числа: [" + string.Join(", ", result) + "]");
    }

    public static int[] SingleNumber(int[] nums)
    {
  
        int xorResult = 0;
        foreach (int num in nums)
        {
            xorResult ^= num;
        }

        int diffBit = 1;
        while ((xorResult & diffBit) == 0)
        {
            diffBit <<= 1;
        }

   
        int a = 0, b = 0;
        foreach (int num in nums)
        {
            if ((num & diffBit) != 0)
            {
                a ^= num;
            }
            else
            {
                b ^= num;
            }
        }

        return new int[] { a, b };
    }
}
