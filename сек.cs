using System;
using System.Timers;

class Program
{
    static void Main()
    {
        // Создаем таймер с интервалом 1 секунда (1000 миллисекунд)
        Timer timer = new Timer(1000);
        
        // Обработчик события "Tick" для вывода времени
        timer.Elapsed += OnTimedEvent;
        
        // Запускаем таймер
        timer.Start();
        
        Console.WriteLine("Секундомер запущен! Нажмите любую клавишу для остановки.");
        Console.ReadKey(); // Ожидаем нажатия клавиши

        // Останавливаем таймер
        timer.Stop();
        timer.Dispose();
    }
    
    private static int secondsElapsed = 0; // Счетчик секунд

    private static void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        secondsElapsed++;
        Console.SetCursorPosition(0, Console.CursorTop); // Возвращаемся к началу строки
        Console.Write($"Прошло {secondsElapsed} секунд");
    }
}
