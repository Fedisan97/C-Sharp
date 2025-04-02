using System;

class Program
{
    static void Main()
    {
        // Пример входного массива
        int[] nums = { 1, 2, 1, 3, 2, 5 };

        // Находим два уникальных числа
        int[] result = SingleNumber(nums);

        // Выводим результат
        Console.WriteLine("Уникальные числа: [" + string.Join(", ", result) + "]");
    }

    public static int[] SingleNumber(int[] nums)
    {
        // Получаем XOR всех элементов (это будет a ^ b)
        int xorResult = 0;
        foreach (int num in nums)
        {
            xorResult ^= num;
        }

        // Находим любой установленный бит в xorResult (возьмём самый младший)
        int diffBit = 1;
        while ((xorResult & diffBit) == 0)
        {
            diffBit <<= 1;
        }

        // Разделяем числа на две группы и находим a и b
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