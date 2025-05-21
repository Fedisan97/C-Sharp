using System;
using System.Collections.Generic;
using System.Linq;

public class Rarity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ConsoleColor Color { get; set; }
    public double Chance { get; set; }
    public List<Item> Items { get; set; } = new();
}

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Item> Items { get; set; } = new();
}

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int RarityId { get; set; }
    public int CategoryId { get; set; }
}

public class Lootbox
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int DropCount { get; set; }
    public List<int> ItemIds { get; set; } = new();
}

class Program
{
    static List<Rarity> rarities = new();
    static List<Category> categories = new();
    static List<Item> items = new();
    static List<Lootbox> lootboxes = new();

    static void Main()
    {
        SeedSampleData();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Главное меню ===");
            Console.WriteLine("1. Лутбоксы");
            Console.WriteLine("2. Редкости");
            Console.WriteLine("3. Категории");
            Console.WriteLine("4. Предметы");
            Console.WriteLine("0. Выход");
            Console.Write("Выбор: ");
            switch (Console.ReadLine())
            {
                case "1": LootboxMenu(); break;
                case "2": RarityMenu(); break;
                case "3": CategoryMenu(); break;
                case "4": ItemMenu(); break;
                case "0": return;
            }
        }
    }

    static void Pause() { Console.WriteLine("Нажмите Enter..."); Console.ReadLine(); }

    static void SeedSampleData()
    {
        rarities.Add(new Rarity { Id = 1, Name = "Обычная", Color = ConsoleColor.Green, Chance = 0.7 });
        rarities.Add(new Rarity { Id = 2, Name = "Редкая", Color = ConsoleColor.Blue, Chance = 0.25 });
        rarities.Add(new Rarity { Id = 3, Name = "Эпичная", Color = ConsoleColor.Magenta, Chance = 0.05 });

        categories.Add(new Category { Id = 1, Name = "Обычная"});
        categories.Add(new Category { Id = 2, Name = "Редкая" });
        categories.Add(new Category { Id = 3, Name = "Эпичная" });

        items.Add(new Item { Id = 1, Name = "ГАЗ-3110", Description = "150 000р", RarityId = 1, CategoryId = 1 });
        items.Add(new Item { Id = 2, Name = "Сайбер", Description = "1 000 000р", RarityId = 2, CategoryId = 1 });
        items.Add(new Item { Id = 3, Name = "Танк Т-72", Description = "16 000 000р", RarityId = 3, CategoryId = 1 });

        items.Add(new Item { Id = 4, Name = "BMW M5", Description = "14 000 000 р", RarityId = 1, CategoryId = 2 });
        items.Add(new Item { Id = 5, Name = "Tesla Cybertruck", Description = "17 900 000р", RarityId = 2, CategoryId = 2 });
        items.Add(new Item { Id = 6, Name = "Lamborghini Urus", Description = "20 500 000р", RarityId = 3, CategoryId = 2 });

        items.Add(new Item { Id = 7, Name = "Rolls-Royce", Description = "55 000 000р", RarityId = 1, CategoryId = 3 });
        items.Add(new Item { Id = 8, Name = "Bugatti Chiron", Description = "351 746 208р", RarityId = 2, CategoryId = 3 });
        items.Add(new Item { Id = 9, Name = "Пагани Utopia", Description = "550 000 000р", RarityId = 3, CategoryId = 3 });

        lootboxes.Add(new Lootbox { Id = 1, Name = "Отечественные", Description = "Содержит отечественные машина", DropCount = 1, ItemIds = new List<int> { 1, 2, 3 } });
        lootboxes.Add(new Lootbox { Id = 2, Name = "Иномарки", Description = "Содержит иномарки", DropCount = 1, ItemIds = new List<int> { 4, 5, 6 } });
        lootboxes.Add(new Lootbox { Id = 2, Name = "Люкс", Description = "Содержит Люкс качесвто", DropCount = 1, ItemIds = new List<int> { 7, 8, 9 } });
    }

    static void LootboxMenu()
    {
        Console.Clear();
        Console.WriteLine("-- Лутбоксы --");
        Console.WriteLine("1. Показать все");
        Console.WriteLine("2. Создать");
        Console.WriteLine("3. Добавить предмет");
        Console.WriteLine("4. Открыть");
        Console.WriteLine("5. Редактировать");
        Console.WriteLine("0. Назад"); Console.Write("=> ");
        switch (Console.ReadLine())
        {
            case "1": ShowLootboxes(); break;
            case "2": CreateLootbox(); break;
            case "3": AddItemToLootbox(); break;
            case "4": OpenLootbox(); break;
            case "5": EditLootbox(); break;
        }
        Pause();
    }

    static void ShowLootboxes()
    {
        foreach (var lb in lootboxes)
        {
            Console.WriteLine($"{lb.Id}. {lb.Name} - Выпадает предметов: {lb.DropCount}, Предметы: {lb.ItemIds.Count}");
            Console.WriteLine(lb.Description);
            foreach (var id in lb.ItemIds)
                Console.WriteLine(" - " + items.First(i => i.Id == id).Name);
        }
    }

    static void CreateLootbox()
    {
        Console.Write("Название: "); var name = Console.ReadLine();
        Console.Write("Описание: "); var desc = Console.ReadLine();
        Console.Write("Сколько выпадает: "); int dc = int.Parse(Console.ReadLine() ?? "1");
        int id = lootboxes.Count > 0 ? lootboxes.Max(lb => lb.Id) + 1 : 1;
        lootboxes.Add(new Lootbox { Id = id, Name = name, Description = desc, DropCount = dc });
        Console.WriteLine("Создано.");
    }

    static void AddItemToLootbox()
    {
        Console.Write("ID предмета: "); int iid = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("ID лутбокса: "); int lid = int.Parse(Console.ReadLine() ?? "0");
        var lb = lootboxes.FirstOrDefault(x => x.Id == lid);
        if (lb != null && items.Any(i => i.Id == iid)) lb.ItemIds.Add(iid);
        Console.WriteLine("Добавлено.");
    }

    static void OpenLootbox()
    {
        Console.Write("ID лутбокса: "); int lid = int.Parse(Console.ReadLine() ?? "0");
        var lb = lootboxes.FirstOrDefault(x => x.Id == lid);
        if (lb == null) { Console.WriteLine("Не найдено"); return; }
        var rnd = new Random();
        var pool = lb.ItemIds.Select(id => items.First(i => i.Id == id)).ToList();
        for (int i = 0; i < lb.DropCount; i++)
        {
            var item = pool[rnd.Next(pool.Count)];
            var rarity = rarities.First(r => r.Id == item.RarityId);
            var category = categories.First(c => c.Id == item.CategoryId);
            Console.BackgroundColor = rarity.Color;
            Console.WriteLine($"{item.Id}. {item.Name} ({category.Name})");
            Console.ResetColor();
            Console.WriteLine(item.Description);
            Console.WriteLine($"Редкость: {rarity.Name}, Шанс: {rarity.Chance}");
        }
    }

    static void EditLootbox()
    {
        Console.Write("ID: "); int id = int.Parse(Console.ReadLine() ?? "0");
        var lb = lootboxes.FirstOrDefault(x => x.Id == id);
        if (lb == null) { Console.WriteLine("Не найдено"); return; }
        Console.Write("Новое название (Enter чтобы пропустить): "); var n = Console.ReadLine(); if (!string.IsNullOrEmpty(n)) lb.Name = n;
        Console.Write("Новое описание: "); var d = Console.ReadLine(); if (!string.IsNullOrEmpty(d)) lb.Description = d;
        Console.WriteLine("Обновлено.");
    }

    static void RarityMenu()
    {
        Console.Clear(); Console.WriteLine("-- Редкости --");
        Console.WriteLine("1. Показать"); Console.WriteLine("2. Добавить");
        Console.WriteLine("3. Редактировать"); Console.WriteLine("4. Удалить");
        Console.WriteLine("0. Назад"); Console.Write("=> ");
        switch (Console.ReadLine())
        {
            case "1": ShowRarities(); break;
            case "2": CreateRarity(); break;
            case "3": EditRarity(); break;
            case "4": DeleteRarity(); break;
        }
        Pause();
    }

    static void ShowRarities() => rarities.ForEach(r => Console.WriteLine($"{r.Id}. {r.Name}, Цвет: {r.Color}, Предметы: {items.Count(i => i.RarityId == r.Id)}"));

    static void CreateRarity()
    {
        Console.Write("Имя: "); var name = Console.ReadLine();
        Console.Write("Шанс (<=1): "); var ch = double.Parse(Console.ReadLine() ?? "0");
        if (rarities.Sum(r => r.Chance) + ch > 1) { Console.WriteLine("Суммарная >1"); return; }
        Console.WriteLine("Доступные цвета: " + string.Join(",", Enum.GetNames(typeof(ConsoleColor))));
        Console.Write("Цвета: "); var col = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), Console.ReadLine() ?? "Белый");
        int id = rarities.Count > 0 ? rarities.Max(r => r.Id) + 1 : 1;
        rarities.Add(new Rarity { Id = id, Name = name, Chance = ch, Color = col });
        Console.WriteLine("Добавлено.");
    }

    static void EditRarity()
    {
        Console.Write("ID: "); int id = int.Parse(Console.ReadLine() ?? "0"); var r = rarities.FirstOrDefault(x => x.Id == id);
        if (r == null) { Console.WriteLine("Нет"); return; }
        Console.Write("Имя: "); var n = Console.ReadLine(); if (!string.IsNullOrEmpty(n)) r.Name = n;
        Console.Write("Цвет: "); var c = Console.ReadLine(); if (!string.IsNullOrEmpty(c)) r.Color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), c);
        Console.WriteLine("OK");
    }

    static void DeleteRarity()
    {
        Console.Write("ID: "); int id = int.Parse(Console.ReadLine() ?? "0");
        if (items.Any(i => i.RarityId == id)) { Console.WriteLine("Нельзя удалить"); return; }
        rarities.RemoveAll(x => x.Id == id);
        Console.WriteLine("Удалено");
    }

    static void CategoryMenu()
    {
        Console.Clear(); Console.WriteLine("-- Категории --");
        Console.WriteLine("1. Показать"); Console.WriteLine("2. Добавить");
        Console.WriteLine("3. Редактировать"); Console.WriteLine("4. Удалить");
        Console.WriteLine("0. Назад"); Console.Write("=> ");
        switch (Console.ReadLine())
        {
            case "1": ShowCategories(); break;
            case "2": CreateCategory(); break;
            case "3": EditCategory(); break;
            case "4": DeleteCategory(); break;
        }
        Pause();
    }

    static void ShowCategories() => categories.ForEach(c => Console.WriteLine($"{c.Id}. {c.Name}, Items: {items.Count(i => i.CategoryId == c.Id)}"));

    static void CreateCategory()
    {
        Console.Write("Имя: "); var n = Console.ReadLine();
        int id = categories.Count > 0 ? categories.Max(c => c.Id) + 1 : 1;
        categories.Add(new Category { Id = id, Name = n });
        Console.WriteLine("OK");
    }

    static void EditCategory()
    {
        Console.Write("ID: "); int id = int.Parse(Console.ReadLine() ?? "0"); var c = categories.FirstOrDefault(x => x.Id == id);
        if (c == null) { Console.WriteLine("Нет"); return; }
        Console.Write("Имя: "); var n = Console.ReadLine(); if (!string.IsNullOrEmpty(n)) c.Name = n;
        Console.WriteLine("OK");
    }

    static void DeleteCategory()
    {
        Console.Write("ID: "); int id = int.Parse(Console.ReadLine() ?? "0");
        if (items.Any(i => i.CategoryId == id)) { Console.WriteLine("No"); return; }
        categories.RemoveAll(x => x.Id == id);
        Console.WriteLine("OK");
    }


    static void ItemMenu()
    {
        Console.Clear(); Console.WriteLine("-- Предметы --");
        Console.WriteLine("1. Создать"); Console.WriteLine("2. Поменять редкость");
        Console.WriteLine("3. Удалить"); Console.WriteLine("4. Показать по лутбоксу");
        Console.WriteLine("0. Назад"); Console.Write("=> ");
        switch (Console.ReadLine())
        {
            case "1": CreateItem(); break;
            case "2": ChangeItemRarity(); break;
            case "3": DeleteItem(); break;
            case "4": ShowItemsByLootbox(); break;
        }
        Pause();
    }

    static void CreateItem()
    {
        Console.Write("Имя: "); var n = Console.ReadLine();
        Console.Write("Описание: "); var d = Console.ReadLine();
        Console.Write("Редкость Id: "); int rid = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("Категория Id: "); int cid = int.Parse(Console.ReadLine() ?? "0");
        int id = items.Count > 0 ? items.Max(i => i.Id) + 1 : 1;
        items.Add(new Item { Id = id, Name = n, Description = d, RarityId = rid, CategoryId = cid });
        Console.WriteLine("OK");
    }

    static void ChangeItemRarity()
    {
        Console.Write("ID: "); int id = int.Parse(Console.ReadLine() ?? "0"); var it = items.FirstOrDefault(x => x.Id == id);
        if (it == null) { Console.WriteLine("Нет"); return; }
        Console.Write("Новая редкость: "); it.RarityId = int.Parse(Console.ReadLine() ?? "0");
        Console.WriteLine("OK");
    }

    static void DeleteItem()
    {
        Console.Write("ID: "); int id = int.Parse(Console.ReadLine() ?? "0");
        if (lootboxes.Any(lb => lb.ItemIds.Contains(id))) { Console.WriteLine("No"); return; }
        items.RemoveAll(x => x.Id == id);
        Console.WriteLine("OK");
    }

    static void ShowItemsByLootbox()
    {
        Console.Write("LootboxId: "); int lid = int.Parse(Console.ReadLine() ?? "0");
        var lb = lootboxes.FirstOrDefault(x => x.Id == lid);
        if (lb == null) { Console.WriteLine("Не найдено"); return; }
        foreach (var iid in lb.ItemIds)
        {
            var it = items.First(i => i.Id == iid);
            var rarity = rarities.First(r => r.Id == it.RarityId);
            var cat = categories.First(c => c.Id == it.CategoryId);
            Console.BackgroundColor = rarity.Color;
            Console.WriteLine($"{it.Id}. {it.Name} ({cat.Name})");
            Console.ResetColor();
            Console.WriteLine(it.Description);
            Console.WriteLine($"Редкость: {rarity.Name}, Шанс: {rarity.Chance}");
            var lbs = lootboxes.Where(x => x.ItemIds.Contains(it.Id)).Select(x => x.Name);
            Console.WriteLine("В лутбоксах: " + string.Join(", ", lbs));
        }
    }
}
