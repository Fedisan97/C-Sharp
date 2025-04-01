using System;

public class Program
{
    public static void Main()
    {
        int[] nums1 = {1, 2, 1, 3, 2, 5};
        int[] result1 = SingleNumber(nums1);
        Console.WriteLine($"[{result1[0]}, {result1[1]}]"); // [3, 5]

        int[] nums2 = {-1, 0};
        int[] result2 = SingleNumber(nums2);
        Console.WriteLine($"[{result2[0]}, {result2[1]}]"); // [-1, 0]

        int[] nums3 = {0, 1};
        int[] result3 = SingleNumber(nums3);
        Console.WriteLine($"[{result3[0]}, {result3[1]}]"); // [0, 1]
    }

    public static int[] SingleNumber(int[] nums)
    {
        // XOR всех чисел
        int xor = 0;
        foreach (int num in nums)
        {
            xor ^= num;
        }
 установленный бит
        int diffBit = xor & -xor;

        int num1 = 0, num2 = 0;
        
        foreach (int num in nums)
        {
            if ((num & diffBit) != 0)
            {
                num1 ^= num;
            }
            else
            {
                num2 ^= num;
            }
        }

        return new[] {num1, num2};
    }
}