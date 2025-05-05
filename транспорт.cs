using System;





abstract class Transport
{
    public string Model { get; set; }
    public int Speed { get; protected set; }
    public int MaxSpeed { get; protected set; }
    public Transport(string model, int maxSpeed)
    {
        Model = model;
        
        MaxSpeed = maxSpeed;
        
        Speed = 0;
    }
    public abstract void Move();

    public virtual void Stop()
    {
        Speed = 0;
        Console.WriteLine(Model + " остановился");
    }
}
class Car : Transport
{
    public int Seats { get; set; } 
    public Car(string model, int maxSpeed, int seats) : base(model, maxSpeed)
    {
        Seats = seats;
    }
    public override void Move()
    {
        Speed += 20;
        if (Speed > MaxSpeed) Speed = MaxSpeed;
        Console.WriteLine($"{Model} едет со скоростью {Speed} км/ч. Мест: {Seats}");
    }
    public override void Stop()
    {
        base.Stop();
        Console.WriteLine("Скрип! Машина остановилась");
    }
}
class Truck : Transport
{
   public double LoadCapacity { get; set; }
   private double currentLoad = 0;

    public Truck(string model, int maxSpeed, double capacity) : base(model, maxSpeed)
    {
        LoadCapacity = capacity;
    }

    public override void Move()
    {
        Speed += 10;
        if (Speed > MaxSpeed) Speed = MaxSpeed;
        Console.WriteLine($"{Model} едет со скоростью {Speed} км/ч. Груз: {currentLoad}/{LoadCapacity}т");
    }

    public void Load(double weight)
    {
        currentLoad += weight;
        Console.WriteLine($"Загружено {weight}т. Всего груза: {currentLoad}т");
    }
}
class Bicycle : Transport
{
    public bool HasBell { get; set; }

    public Bicycle(string model, bool hasBell) : base(model, 30) //скорость 30 км/ч
    {
        HasBell = hasBell;
    }

    public override void Move()
    {
        Speed += 5; // разгоняется медленно
        if (Speed > MaxSpeed) Speed = MaxSpeed;
        Console.WriteLine($"{Model} едет со скоростью {Speed} км/ч. Звонок: {(HasBell ? "есть" : "нет")}");
    }

    public void RingBell()
    {
        if (HasBell)
            Console.WriteLine("Дзинь-дзинь!");
        else
            Console.WriteLine("Нет звонка!");
    }
}
class Program
{
    static void Main()
    {
        Transport[] transports = {
            new Car("Лада", 200, 5),
            new Truck("КАМАЗ", 120, 10),
            new Bicycle("Велик", true)
        };
        foreach (var t in transports)
        {
            Console.WriteLine("\nТестируем " + t.Model);
            t.Move();
            t.Move();
            t.Move();
            t.Stop();
            if (t is Car car)
            {   Console.WriteLine("Это машина на " + car.Seats + " мест"); }
            else if (t is Truck truck)
            {
                truck.Load(3);
                truck.Load(5);
            }
            else if (t is Bicycle bike)
            {
                bike.RingBell();
            }
        }
    }
}
