using Lab12;
using static System.Console;
using MyClassLibrary;
using System;

internal class Program
{
    enum Colors
    {
        Green,
        Red,
        Blue,
        Yellow,
        White,
        Cyan,
        DarkYellow,
        DarkGreen,
        Magenta,
        DarkBlue
    }

    static void ShowText(string text, Colors color = Colors.White)
    {
        switch (color)
        {
            case Colors.Green:
                ForegroundColor = ConsoleColor.Green;
                break;
            case Colors.Red:
                ForegroundColor = ConsoleColor.Red;
                break;
            case Colors.Blue:
                ForegroundColor = ConsoleColor.Blue;
                break;
            case Colors.Yellow:
                ForegroundColor = ConsoleColor.Yellow;
                break;
            case Colors.White:
                ForegroundColor = ConsoleColor.White;
                break;
            case Colors.Cyan:
                ForegroundColor = ConsoleColor.Cyan;
                break;
            case Colors.DarkYellow:
                ForegroundColor = ConsoleColor.DarkYellow;
                break;
            case Colors.DarkGreen:
                ForegroundColor = ConsoleColor.DarkGreen;
                break;
            case Colors.Magenta:
                ForegroundColor = ConsoleColor.Magenta;
                break;
            case Colors.DarkBlue:
                ForegroundColor = ConsoleColor.DarkBlue;
                break;
        }
        WriteLine(text);
        ResetColor();
    }

    static void Continue()
    {
        ShowText("\nДля продолжения нажмите на любую клавишу", Colors.Yellow);
        ReadKey();
    }
    private static void Main(string[] args)
    {

        //Lab12

        // PART 1

        // 1.1
        ShowText("Добавляем случайные объекты иерархии в список и выводим его", Colors.Magenta);
        DoublyLinkedList<Person> people = new DoublyLinkedList<Person>();
        Person person1 = new Person();
        Enginer person2 = new Enginer();
        Worker person3 = new Worker();
        Administartion person4 = new Administartion();

        person1.RandomInit();
        person2.RandomInit();
        person3.RandomInit();
        person4.RandomInit();

        people.Add(person1);
        people.Add(person2);
        people.Add(person3);
        people.Add(person4);

        // 1.2
        foreach (var item in people) ShowText(item.ToString(), Colors.Green);

        Continue();

        // 1.3
        ShowText("Добавляем в список элемент на 4 место и выводим его", Colors.Magenta);
        Person person5 = new Person();
        person5.RandomInit();
        people.Insert(person5, 3);
        foreach (var item in people) ShowText(item.ToString(), Colors.Green);
        Continue();

        // 1.4
        ShowText("Клонируем список и выводим его", Colors.Magenta);

        // 1.5
        DoublyLinkedList<Person> clonedList = new DoublyLinkedList<Person>();
        foreach (Item<Person> item in people)
        {
            Person clonePerson = (Person)item.Data.Clone();
            clonedList.Add(clonePerson);
        }
        foreach (var item in clonedList) ShowText(item.ToString(), Colors.Green);
        if (people == clonedList)
            ShowText("Списки находятся в одной области памяти", Colors.Red);
        else
            ShowText("Списки находятся в разных областях памяти", Colors.Red);
        Continue();

        // 1.6
        ShowText("Очищаем список", Colors.Magenta);
        people.Clear();
        GC.Collect();

        foreach (var item in people) ShowText(item.ToString(), Colors.Red);
        if (people.Count == 0) ShowText("Список пустой", Colors.Green);
        Continue();

        // PART 2

        // 2.1
        ShowText("Генерируем идеально сбалансированное бинарное дерево.", Colors.Magenta);
        ShowText("Добавляем случайные объекты бинарное дерево и выводим его.", Colors.Magenta);
        ShowText("Cколько элементов нужно добавить в бинарное дерево?", Colors.Red);
        int size = Convert.ToInt32(ReadLine());
        BinaryTree<Person> binaryTree = new BinaryTree<Person>(size);

        // 2.2
        binaryTree.ShowIdealBalancedTree();
        Continue();

        //2.3
        ShowText(binaryTree.MinAge(), Colors.Yellow);
        Continue();

        // 2.4
        ShowText("Создаем дерево поиска", Colors.Magenta);
        BinaryTree<int> ages = new BinaryTree<int>(binaryTree.Count, binaryTree.Ages);

        // 2.5
        ages.ShowSearchTree();
        Continue();

        // 2.6
        ShowText("Очищаем бинарное дерево", Colors.Magenta);
        binaryTree.Erase();
        binaryTree.ShowIdealBalancedTree();
        Continue();

        // PART 3

        // 3.1
        ShowText("Генерируем идеально HashTable с ёмкостью 30 и 10 случайными элементами.", Colors.Magenta);
        HashTable<Person> people = new HashTable<Person>(30);
        for (int i = 0; i < 10; i++)
        {
            Person person = new Person();
            person.RandomInit();
            people.Add(person);
        }
        foreach (var item in people) ShowText(item.ToString(), Colors.White);
        Continue();

        // 3.2
        Person[] peopleArray = people.ToArray();
        ShowText($"Какого человека нужно найти? Введите номер от 1 до {peopleArray.Length}.", Colors.Magenta);
        int number = Convert.ToInt32(ReadLine());
        var isFound = people.Contains(peopleArray[number - 1]);
        if (isFound) ShowText($"Человек {peopleArray[number - 1]} найден.", Colors.Magenta);
        else ShowText($"Человека {peopleArray[number - 1]} нет в таблице.", Colors.Magenta);
        Continue();

        // 3.3
        ShowText($"Удаляем человека {peopleArray[number - 1]}.", Colors.Magenta);
        people.Remove(peopleArray[number - 1]);
        foreach (var item in people) ShowText(item.ToString(), Colors.White);
        Continue();

        // 3.4
        ShowText($"Пытаемся найти человека {peopleArray[number - 1]} в таблице заново.", Colors.Magenta);
        isFound = people.Contains(peopleArray[number - 1]);
        if (isFound) ShowText($"Человек {peopleArray[number - 1]} найден.", Colors.Magenta);
        else ShowText($"Человека {peopleArray[number - 1]} нет в таблице.", Colors.Magenta);
        Continue();

        // 3.5
        ShowText($"Добавляем 50 случайных инженеров.", Colors.Magenta);
        for (int i = 0; i < 50; i++)
        {
            Enginer person = new Enginer();
            person.RandomInit();
            people.Add(person);
        }
        foreach (var item in people) ShowText(item.ToString(), Colors.White);

        //PART 4

        // 4.1
        ShowText("Генерируем дерево поиска мощностью из 20 элементов.", Colors.Magenta);
        SearchTree<Enginer> searchTree = new SearchTree<Enginer>();
        for (int i = 0; i < 20; i++)
        {
            Enginer person = new Enginer();
            person.RandomInit();
            searchTree.Add(person);
        }
        searchTree.ShowByLevels();
        Continue();

        // 4.2
        ShowText("Выводим все элементы с индексами.", Colors.Magenta);
        int j = 0;
        foreach (var item in searchTree)
        {
            ShowText($"[{j}] {item}", Colors.Magenta);
            j++;
        }
        Continue();

        // 4.3
        ShowText("Ищем индекс элемента.", Colors.Magenta);
        ShowText("Человека с какой зарплатой нужно найти?.", Colors.Green);
        bool isParsed = int.TryParse(ReadLine(), out int wage);
        while (!isParsed)
        {
            WriteLine("Введите число");
            isParsed = int.TryParse(ReadLine(), out wage);
        }
        Enginer enginer1 = new Enginer(0, "", wage, 0);
        int index = searchTree.IntContains(enginer1);
        if (index >= 0) WriteLine($"Человек с зарплатой {wage} находится под индексом {index}");
        else WriteLine($"Человек с зарплатой {wage} не найден");
        Continue();

        // 4.4
        ShowText($"Удаляем инженера под индексом {index}.", Colors.Magenta);
        searchTree.Remove(searchTree[index]);
        searchTree.ShowByLevels();
        j = 0;
        foreach (var item in searchTree)
        {
            ShowText($"[{j}] {item}", Colors.Magenta);
            j++;
        }
        Continue();

        //Lab13

        Continue();
        ShowText("Создаем 2 коллекции и применяем методы.", Colors.Magenta);
        NewSearchTree<Person> tree1 = new NewSearchTree<Person>("Дерево 1");
        NewSearchTree<Person> tree2 = new NewSearchTree<Person>("Дерево 2");

        Journal journal1 = new Journal();
        Journal journal2 = new Journal();

        tree1.CollectionCountChanged += journal1.Add; // subscribe 
        tree1.CollectionReferenceChanged += journal1.Add;
        tree1.CollectionReferenceChanged += journal2.Add;
        tree2.CollectionReferenceChanged += journal2.Add;

        for (int i = 0; i < 10; i++)
        {
            if (i < 5) // add to tree1
            {
                Enginer person = new Enginer();
                person.RandomInit();
                tree1.Add(person);
            }
            else // add to tree2
            {
                Enginer person = new Enginer();
                person.RandomInit();
                tree2.Add(person);
            }
        }

        tree1.Remove(tree1[3]);
        tree2.Remove(tree2[3]);

        tree1[0] = new Person();
        tree2[0] = new Person(100, "Ivan Ivanov");

        ShowText("Journal 1: ", Colors.Green);
        foreach (var item in journal1.list) ShowText(item.ToString(), Colors.Blue);

        ShowText("Journal 2: ", Colors.Green);
        foreach (var item in journal2.list) ShowText(item.ToString(), Colors.Yellow);


        // Lab 14

        // PART 1

        // 1.1
        Continue();
        ShowText($"Часть 1.", Colors.Magenta);
        Queue<List<Person>> factory = new Queue<List<Person>>();
        List<Person> workshop1 = new List<Person>();
        List<Person> workshop2 = new List<Person>();

        // 1.2
        for (int i = 0; i < 5; i++)
        {
            Enginer enginer = new Enginer();
            enginer.RandomInit();
            workshop1.Add(enginer);
            enginer.RandomInit();
            workshop2.Add(enginer);
        }
        for (int i = 0; i < 5; i++)
        {
            Administartion administartion = new Administartion();
            administartion.RandomInit();
            workshop1.Add(administartion);
            administartion.RandomInit();
            workshop2.Add(administartion);
        }

        factory.Enqueue(workshop1);
        factory.Enqueue(workshop2);

        // (a - На выборку данных, LINQ) 
        var factories1 = from sections in factory
                        from item in sections
                        where item is Enginer
                        select item; // LINQ query (like SQL)
        ShowText("Ищем все элементы с типом Enginer (LINQ)", Colors.Yellow);
        foreach (var item in factories1) ShowText(item.ToString(), Colors.Green);

        // (a - На выборку данных, Методом расширения) 
        var factories2 = factory.SelectMany(x => x).Where(x => x is Enginer); // Методом расширения (like NoSQL)
        ShowText("Ищем все элементы с типом Enginer (Методом расширения)", Colors.Yellow);
        foreach (var item in factories2) ShowText(item.ToString(), Colors.Green);

        // (b - Получение счетчика, LINQ)
        var enginiersCount1 = (from sections in factory
                             from item in sections
                             where item is Enginer
                             select item).Count();
        ShowText($"Всего инженеров: {enginiersCount1} (LINQ)", Colors.Yellow);

        // (b - Получение счетчика, Методом расширения)
        var enginiersCount2 = factory.SelectMany(x => x).Where(x => x is Enginer).Count();
        ShowText($"Всего инженеров: {enginiersCount2} (Методом расширения)", Colors.Yellow);

        // (c - Использование операций над множествами (пересечение), LINQ)
        var intersection1 = (from item in workshop1 select item).Intersect(from item in workshop2 select item);
        ShowText($"Пересечения (LINQ)", Colors.Yellow);
        foreach (var item in intersection1) ShowText(item.ToString(), Colors.Green);

        // (c - Использование операций над множествами (пересечение), Методом расширения)
        var intersection2 = workshop1.Intersect(workshop2);
        ShowText($"Пересечения (Методом расширения)", Colors.Yellow);
        foreach (var item in intersection2) ShowText(item.ToString(), Colors.Green);

        // (c - Использование операций над множествами (объединение), LINQ)
        var union1 = (from item in workshop1 select item).Union(from item in workshop2 select item);
        ShowText($"Объеденения (LINQ)", Colors.Yellow);
        foreach (var item in union1) ShowText(item.ToString(), Colors.Green);

        // (c - Использование операций над множествами (объединение), Методом расширения)
        var union2 = workshop1.Union(workshop2);
        ShowText($"Объеденения (Методом расширения)", Colors.Yellow);
        foreach (var item in union2) ShowText(item.ToString(), Colors.Green);

        // (c - Использование операций над множествами (разность), LINQ)
        var distinct1 = (from item in workshop1 select item).Distinct();
        ShowText($"Разность (Методом расширения)", Colors.Yellow);
        foreach (var item in distinct1) ShowText(item.ToString(), Colors.Green);

        // (c - Использование операций над множествами (разность), Методом расширения)
        var distinct2 = workshop1.Distinct();
        ShowText($"Разность (Методом расширения)", Colors.Yellow);
        foreach (var item in distinct2) ShowText(item.ToString(), Colors.Green);

        // (d - Агрегирование данных, LINQ)
        var averageAge1 = (from section in factory
                          from item in section
                          select item).Average(x => x.Age);
        ShowText($"Средний возраст: {averageAge1} (LINQ)", Colors.Yellow);

        // (d - Агрегирование данных, Методом расширения)
        var averageAge2 = factory.SelectMany(x => x).Average(x => x.Age);
        ShowText($"Средний возраст: {averageAge2} (Методом расширения)", Colors.Yellow);

        // (e - Группировка данных, Методом расширения)
        var sortByAge1 = from section in factory
                        from item in section
                        group item by item.Age;
        ShowText($"Сортируем по возрасту: (LINQ)", Colors.Yellow);
        foreach (var item in sortByAge1) ShowText(item.ToString(), Colors.Green);

        // (e - Группировка данных, LINQ)
        var sortByAge2 = factory.SelectMany(x => x).GroupBy(x => x.Age);
        ShowText($"Сортируем по возрасту: (Методом расширения)", Colors.Yellow);
        foreach (var item in sortByAge2) ShowText(item.ToString(), Colors.Green);


        // PART 2

        // 1
        ShowText($"Часть 2.", Colors.Magenta);
        SearchTree<Person> plant1 = new SearchTree<Person>();
        SearchTree<Person> plant2 = new SearchTree<Person>();
        for (int i = 0; i < 5; i++)
        {
            Enginer enginer2 = new Enginer();
            enginer2.RandomInit();
            plant1.Add(enginer2);
            enginer2.RandomInit();
            plant2.Add(enginer2);
        }
        for (int i = 0; i < 5; i++)
        {
            Administartion administartion = new Administartion();
            administartion.RandomInit();
            plant1.Add(administartion);
            administartion.RandomInit();
            plant2.Add(administartion);
        }

        // (a - На выборку данных, LINQ) 
        var plants1 = from item in plant1
                      where item is Enginer
                      select item;
        ShowText("Ищем все элементы с типом Enginer (LINQ)", Colors.Yellow);
        foreach (var item in plants1) ShowText(item.ToString(), Colors.Green);

        // (a - На выборку данных, Методом расширения) 
        var plants2 = plant2.Select(x => x).Where(x => x is Enginer);
        ShowText("Ищем все элементы с типом Enginer (Методом расширения)", Colors.Yellow);
        foreach (var item in plants2) ShowText(item.ToString(), Colors.Green);

        // (b - Получение счетчика, LINQ)
        var enginiersCount3 = (from item in plant1
                              where item is Enginer
                              select item).Count();
        ShowText($"Всего инженеров: {enginiersCount3} (LINQ)", Colors.Yellow);

        // (b - Получение счетчика, Методом расширения)
        var enginiersCount4 = plant2.Select(x => x).Where(x => x is Enginer).Count();
        ShowText($"Всего инженеров: {enginiersCount4} (Методом расширения)", Colors.Yellow);

        // (c - Использование операций над множествами (пересечение), LINQ)
        var intersection3 = (from item in plant1 select item).Intersect(from item in plant2 select item);
        ShowText($"Пересечения (LINQ)", Colors.Yellow);
        foreach (var item in intersection3) ShowText(item.ToString(), Colors.Green);

        // (c - Использование операций над множествами (пересечение), Методом расширения)
        var intersection4 = plant1.Intersect(plant2);
        ShowText($"Пересечения (Методом расширения)", Colors.Yellow);
        foreach (var item in intersection4) ShowText(item.ToString(), Colors.Green);

        // (c - Использование операций над множествами (объединение), LINQ)
        var union3 = (from item in plant1 select item).Union(from item in plant2 select item);
        ShowText($"Объеденения (LINQ)", Colors.Yellow);
        foreach (var item in union3) ShowText(item.ToString(), Colors.Green);

        // (c - Использование операций над множествами (объединение), Методом расширения)
        var union4 = plant1.Union(plant2);
        ShowText($"Объеденения (Методом расширения)", Colors.Yellow);
        foreach (var item in union4) ShowText(item.ToString(), Colors.Green);

        // (c - Использование операций над множествами (разность), LINQ)
        var distinct3 = (from item in plant1 select item).Distinct();
        ShowText($"Разность (Методом расширения)", Colors.Yellow);
        foreach (var item in distinct3) ShowText(item.ToString(), Colors.Green);

        // (c - Использование операций над множествами (разность), Методом расширения)
        var distinct4 = plant2.Distinct();
        ShowText($"Разность (Методом расширения)", Colors.Yellow);
        foreach (var item in distinct2) ShowText(item.ToString(), Colors.Green);

        // (d - Агрегирование данных, LINQ)
        var averageAge3 = (from item in plant1 select item).Average(x => x.Age);
        ShowText($"Средний возраст: {averageAge3} (LINQ)", Colors.Yellow);

        // (d - Агрегирование данных, Методом расширения)
        var averageAge4 = plant1.Select(x => x).Average(x => x.Age);
        ShowText($"Средний возраст: {averageAge4} (Методом расширения)", Colors.Yellow);

        // (e - Группировка данных, LINQ)
        var sortByAge3 = from item in plant1
                         group item by item.Age;
        ShowText($"Сортируем по возрасту: (LINQ)", Colors.Yellow);
        //foreach (var item in sortByAge3) ShowText(item.ToString(), Colors.Green);
        foreach (var group in sortByAge3) foreach (var item in group) ShowText(item.ToString(), Colors.Green);

        // (e - Группировка данных, Методом расширения)
        var sortByAge4 = plant1.Select(x => x).GroupBy(x => x.Age);
        ShowText($"Сортируем по возрасту: (Методом расширения)", Colors.Yellow);
        foreach (var group in sortByAge4) foreach (var item in group) ShowText(item.ToString(), Colors.Green);

        ReadKey();
    }
}
