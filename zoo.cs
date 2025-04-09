

// переделать, ошибки есть 

using System;
using System.Collections.Generic;


public class Animal
{

    public int Id { get; set; }          // идентификатор
    public string Name { get; set; }     // Имя животного
    public string Species { get; set; }  // Вид животного
    public int Age { get; set; }         // Возраст
    public bool IsFed { get; set; }  

    
    public Animal(int id, string name, string species, int age, bool isFed)
    {
        Id = id;
        Name = name;
        Species = species;
        Age = age;
        IsFed = isFed;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Имя: {Name}");
        Console.WriteLine($"Вид: {Species}");
        Console.WriteLine($"Возраст: {Age} лет");
        Console.WriteLine($"Статус кормления: {(IsFed ? "Сытое" : "Голодное")}");
        Console.WriteLine("---------------------");
    }
}

public class Zoo
{
    // cписок животных в зоопарке
    public List<Animal> Animals { get; private set; }

    public Zoo()
    {
        Animals = new List<Animal>();
    }

    //  для добавления нового животного
    public void AddAnimal(Animal animal)
    {
        Animals.Add(animal);
        Console.WriteLine($"Животное {animal.Name} добавлено в зоопарк!");
    }

    //  для кормления животного по ID
    public void FeedAnimal(int animalId)
    {
        Animal animal = Animals.Find(a => a.Id == animalId);

        if (animal != null)
        {
            animal.IsFed = true;
            Console.WriteLine($"Животное {animal.Name} накормлено!");
        }
        else
        {
            Console.WriteLine($"Ошибка: Животное с ID {animalId} не найдено.");
        }
    }

    // для обновления данных животного
    public void UpdateAnimal(int animalId, Animal updatedAnimal)
    {
        Animal animal = Animals.Find(a => a.Id == animalId);

        if (animal != null)
        {
            animal.Name = updatedAnimal.Name;
            animal.Species = updatedAnimal.Species;
            animal.Age = updatedAnimal.Age;
            animal.IsFed = updatedAnimal.IsFed;
            Console.WriteLine($"Данные животного с ID {animalId} обновлены!");
        }
        else
        {
            Console.WriteLine($"Ошибка: Животное с ID {animalId} не найдено.");
        }
    }

    // для вывода списка всех животных
    public void ListAllAnimals()
    {
        if (Animals.Count == 0)
        {
            Console.WriteLine("В зоопарке пока нет животных.");
            return;
        }

        Console.WriteLine("Список всех животных в зоопарке:");
        Console.WriteLine("=====================");

        foreach (var animal in Animals)
        {
            animal.DisplayInfo();
        }
    }

    // получения животного по ID
    public Animal GetAnimalById(int animalId)
    {
        Animal animal = Animals.Find(a => a.Id == animalId);

        if (animal != null)
        {
            return animal;
        }
        else
        {
            Console.WriteLine($"Ошибка: Животное с ID {animalId} не найдено.");
            return null;
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
      
        Zoo myZoo = new Zoo();

        //                               животные
        myZoo.AddAnimal(new Animal(1, "Барсик", "Лев", 5, false));
        myZoo.AddAnimal(new Animal(2, "Мур", "Тигр", 3, true));
        myZoo.AddAnimal(new Animal(3, "Рекс", "Медведь", 7, false));

   
        myZoo.ListAllAnimals();
        myZoo.FeedAnimal(1);
        myZoo.FeedAnimal(99);
        myZoo.UpdateAnimal(2, new Animal(2, "Мурзик", "Тигр", 4, false));




     
        Animal animal = myZoo.GetAnimalById(3);
        if (animal != null)
        {
            Console.WriteLine("Информация о животном с ID 3:");
            animal.DisplayInfo();
        }

        myZoo.GetAnimalById(100);
    }
}
