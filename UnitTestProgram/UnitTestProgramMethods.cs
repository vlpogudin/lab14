using GameLib;
using lab14;
using MyCollectionAVLTree;

namespace UnitTestProgram { }

/// <summary>
/// Класс тестов методов класса Program.
/// </summary>
[TestClass]
public class UnitTestProgramMethods

{
    #region Тесты первой части
    #region Тесты формирования коллекции
    /// <summary>
    /// Тест корректного заполнения коллекции и списков внутри.
    /// </summary>
    [TestMethod]
    public void TestCollection_CorrectCountFill()
    {
        SortedDictionary<string, List<Game>> gameStore = Program.FillStore(); // Создание и заполнение коллекции коллекций
        Assert.AreEqual(4, gameStore.Count); // Проверка, что коллекция заполнена корректным числом списков
        Assert.AreEqual(5, gameStore["Игры"].Count); // Проверка, что список заполнен корректным числом элементов
        Assert.AreEqual(3, gameStore["Настольные игры"].Count); // Проверка, что список заполнен корректным числом элементов
        Assert.AreEqual(6, gameStore["Видео-игры"].Count); // Проверка, что список заполнен корректным числом элементов
        Assert.AreEqual(4, gameStore["VR-игры"].Count); // Проверка, что список заполнен корректным числом элементов
    }

    /// <summary>
    /// Тест корректного заполнения коллекции и сохранения ключей.
    /// </summary>
    [TestMethod]
    public void TestCollection_CorrectKeyFill()
    {
        SortedDictionary<string, List<Game>> gameStore = Program.FillStore(); // Создание и заполнение коллекции коллекций
        Assert.IsTrue(gameStore.ContainsKey("Игры")); // Проверка, что содержится корректный ключ
        Assert.IsTrue(gameStore.ContainsKey("Настольные игры")); // Проверка, что содержится корректный ключ
        Assert.IsTrue(gameStore.ContainsKey("Видео-игры")); // Проверка, что содержится корректный ключ
        Assert.IsTrue(gameStore.ContainsKey("VR-игры")); // Проверка, что содержится корректный ключ
    }
    #endregion

    #region Тесты первого запроса
    /// <summary>
    /// Тест первого запроса к пустой коллекции. LINQ.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest1_EmptyCollection_LINQ()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // Создание коллекции коллекций
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request1_LINQ(gameStore); // Первый запрос к коллекции
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("Коллекция не заполнена элементами.")); // Проверка, что выведено корректное сообщение
    }
    
    /// <summary>
    /// Тест первого запроса к коллекции, не содержащей корректных элементов. LINQ.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest1_NoExistCorrectItems_LINQ()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // Создание коллекции коллекций
        List<Game> games = new List<Game> // Создаем новый список с элементами
        {
            new Game("Игра А", 1, 5, 1), new Game("Игра Б", 2, 7, 2),
            new Game("Игра В", 3, 4, 3), new Game("Игра Г", 6, 9, 5)
        };
        gameStore.Add("Игры", games); // Добавляем список в коллекцию
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request1_LINQ(gameStore); // Первый запрос к коллекции
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("В коллекции нет таких игр.")); // Проверка, что выведено корректное сообщение
    }

    /// <summary>
    /// Тест первого запроса к коллекции, содержащей корректные элементы. LINQ.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest1_ExistCorrectItems_LINQ()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // Создание коллекции коллекций
        List<Game> games = new List<Game> // Создаем новый список с элементами
        {
            new BoardGame("Игра А", 1, 5, 1, true, "Атрибуты"), new Game("Игра Б", 2, 7, 2),
            new Game("Игра В", 3, 4, 3), new BoardGame("Игра Г", 6, 9, 5, false, "Атрибуты")
        };
        gameStore.Add("Игры", games); // Добавляем список в коллекцию
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request1_LINQ(gameStore); // Первый запрос к коллекции
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains(new BoardGame("Игра А", 1, 5, 1, true, "Атрибуты").ToString())); // Проверка, что выведено корректное сообщение
    }

    /// <summary>
    /// Тест первого запроса к пустой коллекции. Метод расширения.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest1_EmptyCollection_ExMethod()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // Создание коллекции коллекций
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request1_ExMethod(gameStore); // Первый запрос к коллекции
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("Коллекция не заполнена элементами.")); // Проверка, что выведено корректное сообщение
    }

    /// <summary>
    /// Тест первого запроса к коллекции, не содержащей корректных элементов. Метод расширения.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest1_NoExistCorrectItems_ExMethod()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // Создание коллекции коллекций
        List<Game> games = new List<Game> // Создаем новый список с элементами
        {
            new Game("Игра А", 1, 5, 1), new Game("Игра Б", 2, 7, 2),
            new Game("Игра В", 3, 4, 3), new Game("Игра Г", 6, 9, 5)
        };
        gameStore.Add("Игры", games); // Добавляем список в коллекцию
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request1_ExMethod(gameStore); // Первый запрос к коллекции
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("В коллекции нет таких игр.")); // Проверка, что выведено корректное сообщение
    }

    /// <summary>
    /// Тест первого запроса к коллекции, содержащей корректные элементы. Метод расширения.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest1_ExistCorrectItems_ExMethod()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // Создание коллекции коллекций
        List<Game> games = new List<Game> // Создаем новый список с элементами
        {
            new BoardGame("Игра А", 1, 5, 1, true, "Атрибуты"), new Game("Игра Б", 2, 7, 2),
            new Game("Игра В", 3, 4, 3), new BoardGame("Игра Г", 6, 9, 5, false, "Атрибуты")
        };
        gameStore.Add("Игры", games); // Добавляем список в коллекцию
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request1_ExMethod(gameStore); // Первый запрос к коллекции
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains(new BoardGame("Игра А", 1, 5, 1, true, "Атрибуты").ToString())); // Проверка, что выведено корректное сообщение
    }
    #endregion

    #region Тесты второго запроса
    /// <summary>
    /// Тест второго запроса к пустой коллекции. LINQ.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest2_EmptyCollection_LINQ()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // Создание коллекции коллекций
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request2_LINQ(gameStore); // Запрос к коллекции
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("Коллекция не заполнена элементами.")); // Проверка, что выведено корректное сообщение
    }

    /// <summary>
    /// Тест второго запроса к коллекции, не содержащей корректных элементов. LINQ.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest2_NoExistCorrectItems_LINQ()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // Создание коллекции коллекций
        List<Game> games = new List<Game> // Создаем новый список с элементами
        {
            new Game("Игра А", 1, 5, 1), new Game("Игра Б", 2, 7, 2),
            new Game("Игра В", 3, 4, 3), new Game("Игра Г", 6, 9, 5)
        };
        gameStore.Add("Игры", games); // Добавляем список в коллекцию
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request2_LINQ(gameStore); // Запрос к коллекции
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("В коллекции нет таких названий.")); // Проверка, что выведено корректное сообщение
    }

    /// <summary>
    /// Тест второго запроса к коллекции, содержащей корректные элементы. LINQ.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest2_ExistCorrectItems_LINQ()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // Создание коллекции коллекций
        List<Game> games = new List<Game> // Создаем новый список с элементами
        {
            new BoardGame("Игра А", 1, 5, 1, true, "Атрибуты"), new Game("Игра Б", 2, 7, 2),
            new Game("Игра В", 3, 4, 3), new VRGame("Игра А", 6, 9, 5, "Часы", 6, true, true)
        };
        gameStore.Add("Игры", games); // Добавляем список в коллекцию
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request2_LINQ(gameStore); // Запрос к коллекции
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("Игра А")); // Проверка, что выведено корректное сообщение
    }

    /// <summary>
    /// Тест второго запроса к пустой коллекции. Метод расширения.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest2_EmptyCollection_ExMethod()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // Создание коллекции коллекций
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request2_ExMethod(gameStore); // Запрос к коллекции
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("Коллекция не заполнена элементами.")); // Проверка, что выведено корректное сообщение
    }

    /// <summary>
    /// Тест второго запроса к коллекции, не содержащей корректных элементов. Метод расширения.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest2_NoExistCorrectItems_ExMethod()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // Создание коллекции коллекций
        List<Game> games = new List<Game> // Создаем новый список с элементами
        {
            new Game("Игра А", 1, 5, 1), new Game("Игра Б", 2, 7, 2),
            new Game("Игра В", 3, 4, 3), new Game("Игра Г", 6, 9, 5)
        };
        gameStore.Add("Игры", games); // Добавляем список в коллекцию
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request2_ExMethod(gameStore); // Запрос к коллекции
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("В коллекции нет таких названий.")); // Проверка, что выведено корректное сообщение
    }

    /// <summary>
    /// Тест второго запроса к коллекции, содержащей корректные элементы. Метод расширения.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest2_ExistCorrectItems_ExMethod()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // Создание коллекции коллекций
        List<Game> games = new List<Game> // Создаем новый список с элементами
        {
            new BoardGame("Игра А", 1, 5, 1, true, "Атрибуты"), new Game("Игра Б", 2, 7, 2),
            new Game("Игра В", 3, 4, 3), new VRGame("Игра А", 6, 9, 5, "Часы", 6, true, true)
        };
        gameStore.Add("Игры", games); // Добавляем список в коллекцию
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request2_ExMethod(gameStore); // Запрос к коллекции
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("Игра А")); // Проверка, что выведено корректное сообщение
    }
    #endregion

    #region Тесты третьего запроса
    /// <summary>
    /// Тест третьего запроса к пустой коллекции. LINQ.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest3_EmptyCollection_LINQ()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // Создание коллекции коллекций
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request3_LINQ(gameStore); // Запрос к коллекции
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("Коллекция не заполнена элементами.")); // Проверка, что выведено корректное сообщение
    }

    /// <summary>
    /// Тест третьего запроса к коллекции, содержащей корректные элементы. LINQ.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest3_ExistCorrectItems_LINQ()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // Создание коллекции коллекций
        List<Game> games = new List<Game> // Создаем новый список с элементами
        {
            new BoardGame("Игра А", 1, 5, 1, true, "Атрибуты"), new Game("Игра Б", 2, 7, 2),
            new Game("Игра В", 3, 4, 3), new VRGame("Игра А", 6, 9, 5, "Часы", 6, true, true)
        };
        gameStore.Add("Игры", games); // Добавляем список в коллекцию
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request3_LINQ(gameStore); // Запрос к коллекции
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("9")); // Проверка, что выведено корректное сообщение
    }

    /// <summary>
    /// Тест третьего запроса к пустой коллекции. Метод расширения.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest3_EmptyCollection_ExMethod()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // Создание коллекции коллекций
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request3_ExMethod(gameStore); // Запрос к коллекции
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("Коллекция не заполнена элементами.")); // Проверка, что выведено корректное сообщение
    }

    /// <summary>
    /// Тест третьего запроса к коллекции, содержащей корректные элементы. Метод расширения.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest3_ExistCorrectItems_ExMethod()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // Создание коллекции коллекций
        List<Game> games = new List<Game> // Создаем новый список с элементами
        {
            new BoardGame("Игра А", 1, 5, 1, true, "Атрибуты"), new Game("Игра Б", 2, 7, 2),
            new Game("Игра В", 3, 4, 3), new VRGame("Игра А", 6, 9, 5, "Часы", 6, true, true)
        };
        gameStore.Add("Игры", games); // Добавляем список в коллекцию
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request3_ExMethod(gameStore); // Запрос к коллекции
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("9")); // Проверка, что выведено корректное сообщение
    }
    #endregion

    #region Тесты четвертого запроса
    /// <summary>
    /// Тест четвертого запроса к пустой коллекции. LINQ.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest4_EmptyCollection_LINQ()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // Создание коллекции коллекций
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request4_LINQ(gameStore); // Запрос к коллекции
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("Коллекция не заполнена элементами.")); // Проверка, что выведено корректное сообщение
    }

    /// <summary>
    /// Тест четвертого запроса к коллекции, содержащей корректные элементы. LINQ.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest4_ExistCorrectItems_LINQ()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // Создание коллекции коллекций
        List<Game> games = new List<Game> // Создаем новый список с элементами
        {
            new BoardGame("Игра А", 1, 5, 1, true, "Атрибуты"), new Game("Игра Б", 2, 7, 2),
            new Game("Игра В", 3, 4, 3), new VRGame("Игра А", 6, 9, 5, "Часы", 6, true, true)
        };
        gameStore.Add("Игры", games); // Добавляем список в коллекцию
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request4_LINQ(gameStore); // Запрос к коллекции
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("Игра А")); // Проверка, что выведено корректное сообщение
        Assert.IsTrue(consoleOutput.Contains("Игра Б")); // Проверка, что выведено корректное сообщение
        Assert.IsTrue(consoleOutput.Contains("Игра В")); // Проверка, что выведено корректное сообщение
        Assert.IsFalse(consoleOutput.Contains("Игра Г")); // Проверка, что не выведено некорректное сообщение
    }

    /// <summary>
    /// Тест четвертого запроса к пустой коллекции. Метод расширения.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest4_EmptyCollection_ExMethod()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // Создание коллекции коллекций
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request4_ExMethod(gameStore); // Запрос к коллекции
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("Коллекция не заполнена элементами.")); // Проверка, что выведено корректное сообщение
    }

    /// <summary>
    /// Тест четвертого запроса к коллекции, содержащей корректные элементы. Метод расширения.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest4_ExistCorrectItems_ExMethod()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // Создание коллекции коллекций
        List<Game> games = new List<Game> // Создаем новый список с элементами
        {
            new BoardGame("Игра А", 1, 5, 1, true, "Атрибуты"), new Game("Игра Б", 2, 7, 2),
            new Game("Игра В", 3, 4, 3), new VRGame("Игра А", 6, 9, 5, "Часы", 6, true, true)
        };
        gameStore.Add("Игры", games); // Добавляем список в коллекцию
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request4_ExMethod(gameStore); // Запрос к коллекции
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("Игра А")); // Проверка, что выведено корректное сообщение
        Assert.IsTrue(consoleOutput.Contains("Игра Б")); // Проверка, что выведено корректное сообщение
        Assert.IsTrue(consoleOutput.Contains("Игра В")); // Проверка, что выведено корректное сообщение
        Assert.IsFalse(consoleOutput.Contains("Игра Г")); // Проверка, что не выведено некорректное сообщение
    }
    #endregion

    #region Тесты пятого запроса
    /// <summary>
    /// Тест пятого запроса к пустой коллекции. LINQ.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest5_EmptyCollection_LINQ()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // Создание коллекции коллекций
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request5_LINQ(gameStore); // Запрос к коллекции
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("Коллекция не заполнена элементами.")); // Проверка, что выведено корректное сообщение
    }

    /// <summary>
    /// Тест пятого запроса к коллекции, содержащей корректные элементы. LINQ.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest5_ExistCorrectItems_LINQ()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // Создание коллекции коллекций
        List<Game> games = new List<Game> // Создаем новый список с элементами
        {
            new BoardGame("Игра А", 1, 5, 1, true, "Атрибуты"), new Game("Игра Б", 2, 7, 2),
            new Game("Игра В", 3, 4, 3), new VRGame("Игра А", 6, 9, 5, "Часы", 6, true, true)
        };
        gameStore.Add("Игры", games); // Добавляем список в коллекцию
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request5_LINQ(gameStore); // Запрос к коллекции
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("Разница в количестве игроков: 4")); // Проверка, что выведено корректное сообщение
        Assert.IsTrue(consoleOutput.Contains("Разница в количестве игроков: 5")); // Проверка, что выведено корректное сообщение
        Assert.IsTrue(consoleOutput.Contains("Разница в количестве игроков: 1")); // Проверка, что выведено корректное сообщение
        Assert.IsTrue(consoleOutput.Contains("Разница в количестве игроков: 3")); // Проверка, что не выведено некорректное сообщение
    }

    /// <summary>
    /// Тест пятого запроса к пустой коллекции. Метод расширения.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest5_EmptyCollection_ExMethod()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // Создание коллекции коллекций
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request5_ExMethod(gameStore); // Запрос к коллекции
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("Коллекция не заполнена элементами.")); // Проверка, что выведено корректное сообщение
    }

    /// <summary>
    /// Тест пятого запроса к коллекции, содержащей корректные элементы. Метод расширения.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest5_ExistCorrectItems_ExMethod()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // Создание коллекции коллекций
        List<Game> games = new List<Game> // Создаем новый список с элементами
        {
            new BoardGame("Игра А", 1, 5, 1, true, "Атрибуты"), new Game("Игра Б", 2, 7, 2),
            new Game("Игра В", 3, 4, 3), new VRGame("Игра А", 6, 9, 5, "Часы", 6, true, true)
        };
        gameStore.Add("Игры", games); // Добавляем список в коллекцию
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request5_ExMethod(gameStore); // Запрос к коллекции
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("Разница в количестве игроков: 4")); // Проверка, что выведено корректное сообщение
        Assert.IsTrue(consoleOutput.Contains("Разница в количестве игроков: 5")); // Проверка, что выведено корректное сообщение
        Assert.IsTrue(consoleOutput.Contains("Разница в количестве игроков: 1")); // Проверка, что выведено корректное сообщение
        Assert.IsTrue(consoleOutput.Contains("Разница в количестве игроков: 3")); // Проверка, что не выведено некорректное сообщение
    }
    #endregion

    #region Тесты шестого запроса
    /// <summary>
    /// Тест шестого запроса к пустой коллекции. LINQ.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest6_EmptyCollection_LINQ()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // Создание коллекции коллекций
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request6_LINQ(gameStore); // Запрос к коллекции
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("Коллекция не заполнена элементами.")); // Проверка, что выведено корректное сообщение
    }

    /// <summary>
    /// Тест шестого запроса к коллекции, не содержащей корректных элементов. LINQ.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest6_NoExistCorrectItems_LINQ()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // Создание коллекции коллекций
        List<Game> games = new List<Game> // Создаем новый список с элементами
        {
            new Game("Игра А", 1, 5, 1), new Game("Игра Б", 2, 7, 2),
            new Game("Игра В", 3, 4, 3), new Game("Игра Г", 6, 9, 5)
        };
        gameStore.Add("Игры", games); // Добавляем список в коллекцию
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request6_LINQ(gameStore); // Запрос к коллекции
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("Результат запроса пуст.")); // Проверка, что выведено корректное сообщение
    }

    /// <summary>
    /// Тест шестого запроса к коллекции, содержащей корректные элементы. LINQ.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest6_ExistCorrectItems_LINQ()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // Создание коллекции коллекций
        List<Game> games = new List<Game> // Создаем новый список с элементами
        {
            new BoardGame("Шахматы", 1, 5, 1, true, "Атрибуты"), new Game("Игра Б", 2, 7, 2),
            new Game("Игра В", 3, 4, 3), new VRGame("Игра А", 6, 9, 5, "Часы", 6, true, true)
        };
        gameStore.Add("Игры", games); // Добавляем список в коллекцию
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request6_LINQ(gameStore); // Запрос к коллекции
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("ID: 1, Игра: Шахматы, В подарок: Поле для шахмат, часы")); // Проверка, что выведено корректное сообщение
    }

    /// <summary>
    /// Тест шестого запроса к пустой коллекции. Метод расширения.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest6_EmptyCollection_ExMethod()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // Создание коллекции коллекций
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request6_ExMethod(gameStore); // Запрос к коллекции
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("Коллекция не заполнена элементами.")); // Проверка, что выведено корректное сообщение
    }

    /// <summary>
    /// Тест шестого запроса к коллекции, не содержащей корректных элементов. Метод расширения.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest6_NoExistCorrectItems_ExMethod()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // Создание коллекции коллекций
        List<Game> games = new List<Game> // Создаем новый список с элементами
        {
            new Game("Игра А", 1, 5, 1), new Game("Игра Б", 2, 7, 2),
            new Game("Игра В", 3, 4, 3), new Game("Игра Г", 6, 9, 5)
        };
        gameStore.Add("Игры", games); // Добавляем список в коллекцию
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request6_ExMethod(gameStore); // Запрос к коллекции
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("Результат запроса пуст.")); // Проверка, что выведено корректное сообщение
    }

    /// <summary>
    /// Тест шестого запроса к коллекции, содержащей корректные элементы. Метод расширения.
    /// </summary>
    [TestMethod]
    public void TestCollectionRequest6_ExistCorrectItems_ExMethod()
    {
        SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // Создание коллекции коллекций
        List<Game> games = new List<Game> // Создаем новый список с элементами
        {
            new BoardGame("Шахматы", 1, 5, 1, true, "Атрибуты"), new Game("Игра Б", 2, 7, 2),
            new Game("Игра В", 3, 4, 3), new VRGame("Игра А", 6, 9, 5, "Часы", 6, true, true)
        };
        gameStore.Add("Игры", games); // Добавляем список в коллекцию
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request6_ExMethod(gameStore); // Запрос к коллекции
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("ID: 1, Игра: Шахматы, В подарок: Поле для шахмат, часы")); // Проверка, что выведено корректное сообщение
    }
    #endregion
    #endregion

    #region Тесты второй части
    #region Тесты формирования дерева
    /// <summary>
    /// Тест корректного заполнения дерева
    /// </summary>
    [TestMethod]
    public void TestTree_CorrectFill()
    {
        MyAVLTree<Game> tree = Program.CreateTree(); // Создание и заполнение дерева
        Assert.IsNotNull(tree.Root); // Проверка, что корень дерева не пуст
        Assert.AreEqual(15, tree.Count); // Проверка, что заполнено корректное количество элементов
    }
    #endregion

    #region Тесты первого запроса
    /// <summary>
    /// Тест первого запроса к пустому дереву.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest1_EmptyTree_ExMethod()
    {
        MyAVLTree<Game> tree = new MyAVLTree<Game>(); // Создание дерева
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request1_ExMethod(tree); // Запрос к дереву
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("Дерево не заполнено элементами.")); // Проверка, что выведено корректное сообщение
    }

    /// <summary>
    /// Тест первого запроса к дереву, не содержащего корректных элементов.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest1_NoExistCorrectItems_ExMethod()
    {
        MyAVLTree<Game> tree = new MyAVLTree<Game>(); // Создание дерева
        List<Game> games = new List<Game> // Создаем новый список с элементами
        {
            new Game("Игра А", 1, 5, 1), new Game("Игра Б", 2, 7, 2),
            new Game("Игра В", 3, 4, 3), new Game("Игра Г", 6, 9, 5)
        };
        foreach (Game game in games)
            tree.Add(game); // Добавляем элементы списка в дерево
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request1_ExMethod(tree); // Запрос к дереву
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("В дереве нет таких игр.")); // Проверка, что выведено корректное сообщение
    }

    /// <summary>
    /// Тест первого запроса к дереву, содержащему корректные элементы.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest1_ExistCorrectItems_ExMethod()
    {
        MyAVLTree<Game> tree = new MyAVLTree<Game>(); // Создание дерева
        List<Game> games = new List<Game> // Создаем новый список с элементами
        {
            new BoardGame("Игра А", 1, 50000, 1, true, "Атрибуты"), new Game("Игра Б", 2, 7, 2),
            new Game("Игра В", 3, 4, 3), new Game("Игра Г", 6, 9, 5)
        };
        foreach (Game game in games)
            tree.Add(game); // Добавляем элементы списка в дерево
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request1_ExMethod(tree); // Запрос к дереву
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains(new BoardGame("Игра А", 1, 50000, 1, true, "Атрибуты").ToString())); // Проверка, что выведено корректное сообщение
    }

    /// <summary>
    /// Тест первого запроса к пустому дереву.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest1_EmptyTree_LINQ()
    {
        MyAVLTree<Game> tree = new MyAVLTree<Game>(); // Создание дерева
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request1_LINQ(tree); // Запрос к дереву
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("Дерево не заполнено элементами.")); // Проверка, что выведено корректное сообщение
    }

    /// <summary>
    /// Тест первого запроса к дереву, не содержащего корректных элементов.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest1_NoExistCorrectItems_LINQ()
    {
        MyAVLTree<Game> tree = new MyAVLTree<Game>(); // Создание дерева
        List<Game> games = new List<Game> // Создаем новый список с элементами
        {
            new Game("Игра А", 1, 5, 1), new Game("Игра Б", 2, 7, 2),
            new Game("Игра В", 3, 4, 3), new Game("Игра Г", 6, 9, 5)
        };
        foreach (Game game in games)
            tree.Add(game); // Добавляем элементы списка в дерево
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request1_LINQ(tree); // Запрос к дереву
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("В дереве нет таких игр.")); // Проверка, что выведено корректное сообщение
    }

    /// <summary>
    /// Тест первого запроса к дереву, содержащему корректные элементы.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest1_ExistCorrectItems_LINQ()
    {
        MyAVLTree<Game> tree = new MyAVLTree<Game>(); // Создание дерева
        List<Game> games = new List<Game> // Создаем новый список с элементами
        {
            new BoardGame("Игра А", 1, 50000, 1, true, "Атрибуты"), new Game("Игра Б", 2, 7, 2),
            new Game("Игра В", 3, 4, 3), new Game("Игра Г", 6, 9, 5)
        };
        foreach (Game game in games)
            tree.Add(game); // Добавляем элементы списка в дерево
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request1_LINQ(tree); // Запрос к дереву
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains(new BoardGame("Игра А", 1, 50000, 1, true, "Атрибуты").ToString())); // Проверка, что выведено корректное сообщение
    }
    #endregion

    #region Тесты второго запроса
    /// <summary>
    /// Тест второго запроса к пустому дереву.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest2_EmptyTree_ExMethod()
    {
        MyAVLTree<Game> tree = new MyAVLTree<Game>(); // Создание дерева
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request2_ExMethod(tree); // Запрос к дереву
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("Дерево не заполнено элементами.")); // Проверка, что выведено корректное сообщение
    }

    /// <summary>
    /// Тест второго запроса к дереву, не содержащего корректных элементов.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest2_NoExistCorrectItems_ExMethod()
    {
        MyAVLTree<Game> tree = new MyAVLTree<Game>(); // Создание дерева
        List<Game> games = new List<Game> // Создаем новый список с элементами
        {
            new Game("Игра А", 1, 5, 1), new Game("Игра Б", 2, 7, 2),
            new Game("Игра В", 3, 4, 3), new Game("Игра Г", 6, 9, 5)
        };
        foreach (Game game in games)
            tree.Add(game); // Добавляем элементы списка в дерево
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request2_ExMethod(tree); // Запрос к дереву
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("В дереве нет таких игр.")); // Проверка, что выведено корректное сообщение
    }

    /// <summary>
    /// Тест второго запроса к дереву, содержащему корректные элементы.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest2_ExistCorrectItems_ExMethod()
    {
        MyAVLTree<Game> tree = new MyAVLTree<Game>(); // Создание дерева
        List<Game> games = new List<Game> // Создаем новый список с элементами
        {
            new VideoGame("Игра А", 1, 50000, 1, "PlayStation", 5), new Game("Игра Б", 2, 7, 2),
            new Game("Игра В", 3, 4, 3), new Game("Игра Г", 6, 9, 5)
        };
        foreach (Game game in games)
            tree.Add(game); // Добавляем элементы списка в дерево
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request2_ExMethod(tree); // Запрос к дереву
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("1")); // Проверка, что выведено корректное сообщение
    }

    /// <summary>
    /// Тест второго запроса к пустому дереву.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest2_EmptyTree_LINQ()
    {
        MyAVLTree<Game> tree = new MyAVLTree<Game>(); // Создание дерева
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request2_LINQ(tree); // Запрос к дереву
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("Дерево не заполнено элементами.")); // Проверка, что выведено корректное сообщение
    }

    /// <summary>
    /// Тест второго запроса к дереву, не содержащего корректных элементов.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest2_NoExistCorrectItems_LINQ()
    {
        MyAVLTree<Game> tree = new MyAVLTree<Game>(); // Создание дерева
        List<Game> games = new List<Game> // Создаем новый список с элементами
        {
            new Game("Игра А", 1, 5, 1), new Game("Игра Б", 2, 7, 2),
            new Game("Игра В", 3, 4, 3), new Game("Игра Г", 6, 9, 5)
        };
        foreach (Game game in games)
            tree.Add(game); // Добавляем элементы списка в дерево
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request2_LINQ(tree); // Запрос к дереву
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("В дереве нет таких игр.")); // Проверка, что выведено корректное сообщение
    }

    /// <summary>
    /// Тест второго запроса к дереву, содержащему корректные элементы.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest2_ExistCorrectItems_LINQ()
    {
        MyAVLTree<Game> tree = new MyAVLTree<Game>(); // Создание дерева
        List<Game> games = new List<Game> // Создаем новый список с элементами
        {
            new VideoGame("Игра А", 1, 50000, 1, "PlayStation", 5), new Game("Игра Б", 2, 7, 2),
            new Game("Игра В", 3, 4, 3), new Game("Игра Г", 6, 9, 5)
        };
        foreach (Game game in games)
            tree.Add(game); // Добавляем элементы списка в дерево
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request2_LINQ(tree); // Запрос к дереву
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("1")); // Проверка, что выведено корректное сообщение
    }
    #endregion

    #region Тесты третьего запроса
    /// <summary>
    /// Тест третьего запроса к пустому дереву.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest3_EmptyTree_ExMethod()
    {
        MyAVLTree<Game> tree = new MyAVLTree<Game>(); // Создание дерева
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request3_ExMethod(tree); // Запрос к дереву
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("Дерево не заполнено элементами.")); // Проверка, что выведено корректное сообщение
    }

    /// <summary>
    /// Тест третьего запроса к дереву, не содержащего корректных элементов.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest3_NoExistCorrectItems_ExMethod()
    {
        MyAVLTree<Game> tree =
        [
            new Game("Игра", 0, 0, 1),
        ]; // Создание дерева
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request3_ExMethod(tree); // Запрос к дереву
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("Ошибка")); // Проверка, что выведено корректное сообщение
    }

    /// <summary>
    /// Тест третьего запроса к дереву, содержащему корректные элементы.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest3_ExistCorrectItems_ExMethod()
    {
        MyAVLTree<Game> tree = new MyAVLTree<Game>(); // Создание дерева
        List<Game> games = new List<Game> // Создаем новый список с элементами
        {
            new BoardGame("Игра А", 1, 50000, 1, true, "Атрибуты"),
            new Game("Игра Б", 2, 7, 2),
        };
        foreach (Game game in games)
            tree.Add(game); // Добавляем элементы списка в дерево
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request3_ExMethod(tree); // Запрос к дереву
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("1")); // Проверка, что выведено корректное сообщение
    }

    /// <summary>
    /// Тест третьего запроса к пустому дереву.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest3_EmptyTree_LINQ()
    {
        MyAVLTree<Game> tree = new MyAVLTree<Game>(); // Создание дерева
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request3_LINQ(tree); // Запрос к дереву
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("Дерево не заполнено элементами.")); // Проверка, что выведено корректное сообщение
    }

    /// <summary>
    /// Тест третьего запроса к дереву, не содержащего корректных элементов.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest3_NoExistCorrectItems_LINQ()
    {
        MyAVLTree<Game> tree =
        [
            new Game("Игра", 0, 0, 1),
        ]; // Создание дерева
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request3_LINQ(tree); // Запрос к дереву
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("Ошибка")); // Проверка, что выведено корректное сообщение
    }

    /// <summary>
    /// Тест третьего запроса к дереву, содержащему корректные элементы.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest3_ExistCorrectItems_LINQ()
    {
        MyAVLTree<Game> tree = new MyAVLTree<Game>(); // Создание дерева
        List<Game> games = new List<Game> // Создаем новый список с элементами
        {
            new BoardGame("Игра А", 1, 50000, 1, true, "Атрибуты"),
            new Game("Игра Б", 2, 7, 2),
        };
        foreach (Game game in games)
            tree.Add(game); // Добавляем элементы списка в дерево
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request3_LINQ(tree); // Запрос к дереву
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("1")); // Проверка, что выведено корректное сообщение
    }
    #endregion

    #region Тесты четвертого запроса
    /// <summary>
    /// Тест четвертого запроса к пустому дереву.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest4_EmptyTree_ExMethod()
    {
        MyAVLTree<Game> tree = new MyAVLTree<Game>(); // Создание дерева
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request4_ExMethod(tree); // Запрос к дереву
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("Дерево не заполнено элементами.")); // Проверка, что выведено корректное сообщение
    }

    /// <summary>
    /// Тест четвертого запроса к дереву, содержащему корректные элементы.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest4_ExistCorrectItems_ExMethod()
    {
        MyAVLTree<Game> tree =
        [
            new Game("Игра", 0, 0, 1),
            new Game("Игра", 1, 2, 5),
            new Game("ЕщеИгра", 2, 4, 6)
        ]; // Создание дерева
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request4_ExMethod(tree); // Запрос к дереву
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("Игра (количество элементов: 2)")); // Проверка, что выведено корректное сообщение
        Assert.IsTrue(consoleOutput.Contains("ЕщеИгра (количество элементов: 1)")); // Проверка, что выведено корректное сообщение
    }

    /// <summary>
    /// Тест четвертого запроса к пустому дереву.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest4_EmptyTree_LINQ()
    {
        MyAVLTree<Game> tree = new MyAVLTree<Game>(); // Создание дерева
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request4_LINQ(tree); // Запрос к дереву
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("Дерево не заполнено элементами.")); // Проверка, что выведено корректное сообщение
    }

    /// <summary>
    /// Тест четвертого запроса к дереву, содержащему корректные элементы.
    /// </summary>
    [TestMethod]
    public void TestTreeRequest4_ExistCorrectItems_LINQ()
    {
        MyAVLTree<Game> tree =
        [
            new Game("Игра", 0, 0, 1),
            new Game("Игра", 1, 2, 5),
            new Game("ЕщеИгра", 2, 4, 6)
        ]; // Создание дерева
        StringWriter sw = new StringWriter();
        Console.SetOut(sw); // Перенаправляем стандартный вывод в StringWriter
        Program.Request4_LINQ(tree); // Запрос к дереву
        string consoleOutput = sw.ToString(); // Сохраняем вывод консоли в строку
        Console.SetOut(Console.Out); // Восстанавливаем стандартный вывод
        Assert.IsTrue(consoleOutput.Contains("Игра (количество элементов: 2)")); // Проверка, что выведено корректное сообщение
        Assert.IsTrue(consoleOutput.Contains("ЕщеИгра (количество элементов: 1)")); // Проверка, что выведено корректное сообщение
    }
    #endregion
    #endregion
}