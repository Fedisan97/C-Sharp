using System;
 
class MainClass
{
    public static void Main(string[] args)
    {
        // Вход данных
        Console.WriteLine("Номер строки:");
        int x1 = GetValidInput(1, 8);

        Console.WriteLine("Номер столбца:");
        int y1 = GetValidInput(1, 8);

        Console.WriteLine("Укажите номер строки, куда хотите походить:");
        int x2 = GetValidInput(1, 8);

        Console.WriteLine("Укажите номер столбца, куда хотите походить:");
        int y2 = GetValidInput(1, 8);

        if ((x1 == x2) || 
            (y1 == y2) || 
            (Math.Abs(x1 - x2) == Math.Abs(y1 - y2)))
        {
            Console.WriteLine("Да");
        }
        else
        {
            Console.WriteLine("Нет");
        }
    }

    private static int GetValidInput(int minValue, int maxValue)
    {
        int value;
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out value) &&
                value >= minValue && value <= maxValue)
            {
                break;
            }
            Console.WriteLine("Вы ввели неверное значение. Попробуйте еще раз.");
            Console.Write($"Введите число от {minValue} до {maxValue}: ");
        }
        return value;
    }
}
