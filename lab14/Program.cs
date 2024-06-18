using BalancedTree;
using GameLib;
using MyCollectionAVLTree;
using System.Diagnostics.CodeAnalysis;

namespace lab14
{
    /// <summary>
    /// Демонстрационная программа.
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // Создание коллекции коллекций
            MyAVLTree<Game> tree = new MyAVLTree<Game>(); // Создание коллекции

            int mainAnswer; /* Переменная, отвечающая за выбор
                               пользователем пункта главного меню */
            do
            {
                Console.Clear();
                UI.PrintMainMenu(); // Печать главного меню
                mainAnswer = UI.GetInt(); // Проверка корректного ввода пункта меню
                switch (mainAnswer)
                {
                    case 1:
                        Console.Clear();
                        int partOneAnswer; /* Переменная, отвечающая за выбор
                                              пользователем пункта меню первой части */
                        do
                        {
                            UI.PrintPartMenu(1); // Печать меню первой части
                            partOneAnswer = UI.GetInt(); // Проверка корректного ввода пункта меню
                            switch (partOneAnswer)
                            {
                                case 1:
                                    Console.Clear();
                                    gameStore = FillStore(); // Заполнение коллекции случайными элементами
                                    break;

                                case 2:
                                    Console.Clear();
                                    PrintCollection(gameStore); // Печать коллекции
                                    break;

                                case 3:
                                    Console.Clear();
                                    var res1LINQ = ActivateRequest(gameStore, Request1_LINQ); // Первый запрос через LINQ
                                    PrintRequest1(res1LINQ); // Печать результата первого запроса LINQ
                                    var res1ExMethod = ActivateRequest(gameStore, Request1_ExMethod); // Первый запрос через метод расширения
                                    PrintRequest1(res1ExMethod); // Печать результата первого запроса метода расширения
                                    break;

                                case 4:
                                    Console.Clear();
                                    var res2LINQ = ActivateRequest(gameStore, Request2_LINQ); // Второй запрос через LINQ
                                    PrintRequest2(res2LINQ); // Второй запрос через метод расширения
                                    var res2ExMethod = ActivateRequest(gameStore, Request2_ExMethod); // Второй запрос через метод расширения
                                    PrintRequest2(res2ExMethod); // Печать результата второго запроса метода расширения
                                    break;

                                case 5:
                                    Console.Clear();
                                    Request3_LINQ(gameStore); // Третий запрос через LINQ
                                    Request3_ExMethod(gameStore); // Третий запрос через метод расширения
                                    break;

                                case 6:
                                    Console.Clear();
                                    Request4_LINQ(gameStore); // Четвертый запрос через LINQ
                                    Request4_ExMethod(gameStore); // Четвертый запрос через метод расширения
                                    break;

                                case 7:
                                    Console.Clear();
                                    Request5_LINQ(gameStore); // Пятый запрос через LINQ
                                    Request5_ExMethod(gameStore); // Пятый запрос через метод расширения
                                    break;

                                case 8:
                                    Console.Clear();
                                    Request6_LINQ(gameStore); // Шестой запрос через LINQ
                                    Request6_ExMethod(gameStore); // Шестой запрос через метод расширения
                                    break;

                                case 9:
                                    Console.Clear();
                                    break;

                                default:
                                    Console.Clear();
                                    UI.ChangeColor("Некорректный пункт меню. \nПопробуйте снова.\n\n", ConsoleColor.Red); // Печать сообщения об ошибочном выборе пункта меню
                                    break;
                            }
                        } while (partOneAnswer != 9);
                        break;

                    case 2:
                        Console.Clear();
                        int partTwoAnswer; /* Переменная, отвечающая за выбор
                                              пользователем пункта меню второй части */
                        do
                        {
                            UI.PrintPartMenu(2); // Печать меню второй части
                            partTwoAnswer = UI.GetInt(); // Проверка корректного ввода пункта меню
                            switch (partTwoAnswer)
                            {
                                case 1:
                                    Console.Clear();
                                    tree = CreateTree(); // Заполнение дерева случайными элементами
                                    break;

                                case 2:
                                    Console.Clear();
                                    PrintTree(tree); // Печать дерева
                                    break;

                                case 3:
                                    Console.Clear();
                                    var res1LINQ = ActivateRequestTree(tree, Request1_LINQ); // Первый запрос через LINQ
                                    PrintTreeRequest1(res1LINQ); // Печать результата первого запроса LINQ
                                    var res1ExMethod = ActivateRequestTree(tree, Request1_ExMethod); // Первый запрос через метод расширения
                                    PrintTreeRequest1(res1ExMethod); // Печать результата первого запроса метод расширения
                                    break;

                                case 4:
                                    Console.Clear();
                                    Request2_ExMethod(tree); // Второй запрос метод расширения
                                    Request2_LINQ(tree); // Второй запрос LINQ
                                    break;

                                case 5:
                                    Console.Clear();
                                    Request3_ExMethod(tree); // Третий запрос метод расширения
                                    Request3_LINQ(tree); // Третий запрос LINQ
                                    break;

                                case 6:
                                    Console.Clear();
                                    Request4_ExMethod(tree); // Четвертый запрос метод расширения
                                    Request4_LINQ(tree); // Четвертый запрос LINQ
                                    break;

                                case 7:
                                    Console.Clear();
                                    break;

                                default:
                                    Console.Clear();
                                    UI.ChangeColor("Некорректный пункт меню. \nПопробуйте снова.\n\n", ConsoleColor.Red); // Печать сообщения об ошибочном выборе пункта меню
                                    break;
                            }
                        } while (partTwoAnswer != 7);
                        break;

                    case 3:
                        Console.Clear();
                        int exitAnswer; /* Переменная, отвечающая за выбор
                                           пользователем пункта выходного меню */
                        do
                        {
                            UI.PrintExitMenu(); // Печать выходного меню
                            exitAnswer = UI.GetInt(); // Проверка корректного ввода пункта меню
                            switch (exitAnswer)
                            {
                                case 1:
                                    Console.Clear();
                                    UI.ExitProgram(); // Печать сообщения о завершении программы
                                    System.Environment.Exit(0); // Принудительное завершение программы
                                    break;

                                case 2:
                                    Console.Clear();
                                    break;

                                default:
                                    Console.Clear();
                                    UI.ChangeColor("Некорректный пункт меню. \nПопробуйте снова.\n\n", ConsoleColor.Red); // Печать сообщения об ошибочном выборе пункта меню
                                    break;
                            }
                        } while (exitAnswer != 2);
                        break;

                    default:
                        Console.Clear();
                        UI.ChangeColor("Некорректный пункт меню. \nПопробуйте снова.\n\n", ConsoleColor.Red); // Печать сообщения об ошибочном выборе пункта меню
                        break;
                }

            } while (true);

        }

        #region Первая часть
        #region Формирование коллекции коллекций
        /// <summary>
        /// Заполнение коллекции случайными элементами.
        /// </summary>
        /// <returns>Новая заполненная коллекция.</returns>
        public static SortedDictionary<string, List<Game>> FillStore()
        {
            SortedDictionary<string, List<Game>> gameStore = new SortedDictionary<string, List<Game>>(); // Создание новой коллекции коллекций
            List<Game> games = GenerateGames<Game>(5); // Создание списка элементов типа Games (игры)
            gameStore.Add("Игры", games); // Добавление элементов в коллекцию

            List<Game> boardGames = GenerateGames<BoardGame>(3); // Создание списка элементов типа BoardGames (настольные игры)
            gameStore.Add("Настольные игры", boardGames); // Добавление элементов в коллекцию

            List<Game> videoGames = GenerateGames<VideoGame>(6); // Создание списка элементов типа VideoGames (видео-игры)
            gameStore.Add("Видео-игры", videoGames); // Добавление элементов в коллекцию

            List<Game> VRGames = GenerateGames<VRGame>(4); // Создание списка элементов типа VRGames (VR-игры)
            gameStore.Add("VR-игры", VRGames); // Добавление элементов в коллекцию

            Console.WriteLine("Коллекция заполнена случайными элементами.\n");
            return gameStore; // Возврат заполненной коллекции
        }

        /// <summary>
        /// Создание списка случайных элементов определенного типа.
        /// </summary>
        /// <typeparam name="T">Тип элементов списка из иерархии классов Game.</typeparam>
        /// <param name="size">Размерность создаваемого списка.</param>
        /// <returns>Список, заполненный случайными элементами определенного типа.</returns>
        public static List<Game> GenerateGames<T>(int size) where T : Game, new()
        {
            List<Game> games = new List<Game>(); // Создание нового списка
            for (int i = 0; i < size; i++)
            {
                T game = new T(); // Создание нового элемента определенного типа
                game.RandomInit(); // Заполнение элемента случайным информационным полем
                games.Add(game); // Добавление в список нового заполненного элемента
            }
            return games; // Возврат заполненного списка
        }
        #endregion

        #region Первый запрос (оператор where)
        /// <summary>
        /// Первый запрос для коллекции. Используется оператор Where. LINQ.
        /// </summary>
        /// <param name="gameStore">Коллекция коллекций.</param>
        public static IEnumerable<Game> Request1_LINQ(SortedDictionary<string, List<Game>> gameStore)
        {
            // Запоминаем только элементы, являющиеся настольной игрой и требующие дополнительных атрибутов
            var res = from item in gameStore.Values
                      from game in item
                      where game is BoardGame && ((BoardGame)game).ReqSpecBoard == true
                      select game;
            return res; // Вызов метода печати результата на экран
        }

        /// <summary>
        /// Первый запрос для коллекции. Используется оператор Where. Метод расширения.
        /// </summary>
        /// <param name="gameStore">Коллекция коллекций.</param>
        public static IEnumerable<Game> Request1_ExMethod(SortedDictionary<string, List<Game>> gameStore)
        {
            // Запоминаем только элементы, являющиеся настольной игрой и требующие дополнительных атрибутов
            var res = gameStore.Values
                      .SelectMany(item => item)
                      .Where(game => game is BoardGame && ((BoardGame)game).ReqSpecBoard == true);
            return res; // Вызов метода печати результата на экран
        }

        /// <summary>
        /// Печать результата первого запроса.
        /// </summary>
        /// <param name="res">Результат выполнения первого запроса.</param>
        public static void PrintRequest1(IEnumerable<Game>? res)
        {
            if (res == null) { return; } // Если результат пуст, выход из метода
            else if (!res.Any()) { Console.WriteLine("В коллекции нет таких игр.\n"); return; } // Если подходящих элементов не найдено, выход из метода
            UI.ChangeColor("Настольные игры, в которых требуются дополнительные атрибуты:", ConsoleColor.Green);
            foreach (var item in res) // Перебор всех элементов результата
            {
                Console.WriteLine(item); // Печать элемента на экран
            }
            Console.WriteLine();
        }
        #endregion

        #region Второй запрос (оператор intersect)
        /// <summary>
        /// Второй запрос для коллекции. Используется оператор Intersect. LINQ.
        /// </summary>
        /// <param name="gameStore">Коллекция коллекций.</param>
        public static IEnumerable<string> Request2_LINQ(SortedDictionary<string, List<Game>> gameStore)
        {
            // Запоминаем только названия элементов, являющихся видео-игрой
            var boardGames = from item in gameStore.Values
                             from game in item
                             where game is BoardGame
                             select game.Name;

            // Запоминаем только названия элементов, являющихся VR-игрой
            var vrGames = from item in gameStore.Values
                          from game in item
                          where game is VRGame
                          select game.Name;

            var res = boardGames.Intersect(vrGames); // Находим пересечение множеств
            return res; // Вызов метода печати результата на экран
        }

        /// <summary>
        /// Второй запрос для коллекции. Используется оператор Intersect. Метод расширения.
        /// </summary>
        /// <param name="gameStore">Коллекция коллекций.</param>
        public static IEnumerable<string> Request2_ExMethod(SortedDictionary<string, List<Game>> gameStore)
        {
            // Запоминаем только названия элементов, являющихся видео-игрой
            var boardGames = gameStore.SelectMany(games => games.Value)
                             .Where(game => game is BoardGame)
                             .Select(game => game.Name);

            // Запоминаем только названия элементов, являющихся VR-игрой
            var vrGames = gameStore.SelectMany(games => games.Value)
                          .Where(game => game is VRGame)
                          .Select(game => game.Name);

            var res = boardGames.Intersect(vrGames); // Находим пересечение множеств
            return res; // Вызов метода печати результата на экран
        }

        /// <summary>
        /// Печать результата второго запроса.
        /// </summary>
        /// <param name="res">Результат выполнения второго запроса.</param>
        public static void PrintRequest2(IEnumerable<string>? res)
        {
            if (res == null) { return; } // Если результат пуст, выход из метода
            else if (!res.Any()) { Console.WriteLine("В коллекции нет таких названий.\n"); return; } // Если подходящих элементов не найдено, выход из метода
            UI.ChangeColor("Одинаковые названия, которые есть в видео-играх и VR-играх:", ConsoleColor.Green);
            foreach (var item in res) // Перебор всех элементов результата
            {
                Console.WriteLine(item); // Печать элемента на экран
            }
            Console.WriteLine();
        }
        #endregion

        #region Третий запрос (оператор max)
        /// <summary>
        /// Третий запрос для коллекции. Используется оператор Max. LINQ.
        /// </summary>
        /// <param name="gameStore">Коллекция коллекций.</param>
        public static void Request3_LINQ(SortedDictionary<string, List<Game>> gameStore)
        {
            if (IsEmptyCollection(gameStore)) { return; } // Если в коллекции нет элементов, выход из метода
            // Запоминаем максимальное количество игроков из всех игр
            var res = (from games in gameStore.Values
                       from game in games
                       select game.MaxCount).Max();

            PrintRequest3(res); // Вызов метода печати результата на экран
        }

        /// <summary>
        /// Третий запрос для коллекции. Используется оператор Max. Метод расширения.
        /// </summary>
        /// <param name="gameStore">Коллекция коллекций.</param>
        public static void Request3_ExMethod(SortedDictionary<string, List<Game>> gameStore)
        {
            if (IsEmptyCollection(gameStore)) { return; } // Если в коллекции нет элементов, выход из метода
            // Запоминаем максимальное количество игроков из всех игр
            var res = gameStore.Values
                      .SelectMany(games => games)
                      .Select(game => game.MaxCount)
                      .Max();

            PrintRequest3(res); // Вызов метода печати результата на экран
        }

        /// <summary>
        /// Печать результата третьего запроса.
        /// </summary>
        /// <param name="res">Результат выполнения третьего запроса.</param>
        public static void PrintRequest3(int res)
        {
            UI.ChangeColor("Максимальное количество игроков из всех игр:", ConsoleColor.Green);
            Console.WriteLine($"{res}\n");
            
        }
        #endregion

        #region Четвертый запрос (оператор group by)
        /// <summary>
        /// Четвертый запрос для коллекции. Используется оператор Group by. LINQ.
        /// </summary>
        /// <param name="gameStore">Коллекция коллекций.</param>
        public static void Request4_LINQ(SortedDictionary<string, List<Game>> gameStore)
        {
            if (IsEmptyCollection(gameStore)) { return; } // Если в коллекции нет элементов, выход из метода
            // Группировка игр по названию
            var res = from games in gameStore.Values
                      from game in games
                      group game by game.Name;

            PrintRequest4(res); // Вызов метода печати результата на экран
        }

        /// <summary>
        /// Четвертый запрос для коллекции. Используется оператор Group by. Метод расширения.
        /// </summary>
        /// <param name="gameStore">Коллекция коллекций.</param>
        public static void Request4_ExMethod(SortedDictionary<string, List<Game>> gameStore)
        {
            if (IsEmptyCollection(gameStore)) { return; } // Если в коллекции нет элементов, выход из метода
            // Группировка игр по названию
            var res = gameStore.Values
                      .SelectMany(games => games)
                      .GroupBy(game => game.Name);

            PrintRequest4(res); // Вызов метода печати результата на экран
        }

        /// <summary>
        /// Печать результата четвертого запроса.
        /// </summary>
        /// <param name="res">Результат выполнения четвертого запроса.</param>
        public static void PrintRequest4(IEnumerable<IGrouping<string, Game>> res)
        {
            UI.ChangeColor("Группировка игр по названию:", ConsoleColor.Blue);
            foreach (var group in res) // Перебор всех элементов результата
            {
                UI.ChangeColor($"{group.Key} (количество элементов: {group.Count()}):", ConsoleColor.Green); // Печать названия группируемой коллекции (название игры)
                foreach (var game in group) // Перебор всех элементов в группе
                {
                    Console.WriteLine($"{game} - {game.GetType().Name}"); // Печать элемента и его типа
                }
                Console.WriteLine();
            }
        }
        #endregion

        #region Пятый запрос (оператор let)
        /// <summary>
        /// Пятый запрос для коллекции. Используется оператор Let. LINQ.
        /// </summary>
        /// <param name="gameStore">Коллекция коллекций.</param>
        public static void Request5_LINQ(SortedDictionary<string, List<Game>> gameStore)
        {
            if (IsEmptyCollection(gameStore)) { return; } // Если в коллекции нет элементов, выход из метода
            // Дополнительные вычисления разницы между количеством игроков
            var res = from games in gameStore.Values
                      from game in games
                      let countDifference = game.MaxCount - game.MinCount
                      select new
                      {
                          Name = game.Name,
                          CountDifference = countDifference
                      };

            PrintRequest5(res); // Вызов метода печати результата на экран
        }

        /// <summary>
        /// Пятый запрос для коллекции. Используется оператор Let. Метод расширения.
        /// </summary>
        /// <param name="gameStore">Коллекция коллекций.</param>
        public static void Request5_ExMethod(SortedDictionary<string, List<Game>> gameStore)
        {
            if (IsEmptyCollection(gameStore)) { return; } // Если в коллекции нет элементов, выход из метода
            // Дополнительные вычисления разницы между количеством игроков
            var res = gameStore.Values
                      .SelectMany(games => games)
                      .Select(game =>
                      {
                          int countDifference = game.MaxCount - game.MinCount;
                          return new { Name = game.Name, CountDifference = countDifference };
                      });

            PrintRequest5(res); // Вызов метода печати результата на экран
        }

        /// <summary>
        /// Печать результата пятого запроса.
        /// </summary>
        /// <param name="res">Результат выполнения пятого запроса.</param>
        public static void PrintRequest5(IEnumerable<dynamic> res)
        {
            UI.ChangeColor("Печать игр с разницей в количестве игроков:", ConsoleColor.Green);
            foreach (var game in res) // Перебор всех элементов результата
            {
                Console.WriteLine($"Игра: {game.Name}. Разница в количестве игроков: {game.CountDifference}");
            }
            Console.WriteLine();
        }
        #endregion

        #region Шестой запрос (оператор join)
        /// <summary>
        /// Шестой запрос для коллекции. Используется оператор Join. LINQ.
        /// </summary>
        /// <param name="gameStore">Коллекция коллекций.</param>
        public static void Request6_LINQ(SortedDictionary<string, List<Game>> gameStore)
        {
            if (IsEmptyCollection(gameStore)) { return; } // Если в коллекции нет элементов, выход из метода

            // Массив подарков
            Gift[] gifts =
            {
                new Gift("Minecraft", "Джойстик, брелок"), new Gift("CS VR", "VR-джойстики"),
                new Gift("Салки", "Перчатки, кепка"), new Gift("Шахматы", "Поле для шахмат, часы"),
                new Gift("Монополия", "Фишки, кубик, карты"), new Gift("Уно", "Брелок, маска")
            };

            // Соединение коллекций
            var res = gameStore.SelectMany(kv => kv.Value)
                .Join(gifts,
                game => game.Name,
                gifts => gifts.Name,
                (game, gifts) => new { Id = game.id, Name = game.Name, Gifts = gifts.Gifts });

            PrintRequest6(res); // Вызов метода печати результата на экран
        }

        /// <summary>
        /// Шестой запрос для коллекции. Используется оператор Join. Метод расширения.
        /// </summary>
        /// <param name="gameStore">Коллекция коллекций.</param>
        public static void Request6_ExMethod(SortedDictionary<string, List<Game>> gameStore)
        {
            if (IsEmptyCollection(gameStore)) { return; } // Если в коллекции нет элементов, выход из метода

            // Массив подарков
            Gift[] gifts =
            {
                new Gift("Minecraft", "Джойстик, брелок"), new Gift("CS VR", "VR-джойстики"),
                new Gift("Салки", "Перчатки, кепка"), new Gift("Шахматы", "Поле для шахмат, часы"),
                new Gift("Монополия", "Фишки, кубик, карты"), new Gift("Уно", "Брелок, маска")
            };

            // Соединение коллекций
            var res = from kv in gameStore
                      from game in kv.Value
                      join gift in gifts on game.Name equals gift.Name
                      select new { Id = game.id, Name = game.Name, Gifts = gift.Gifts };

            PrintRequest6(res); // Вызов метода печати результата на экран
        }

        /// <summary>
        /// Печать результата шестого запроса.
        /// </summary>
        /// <param name="res">Результат выполнения шестого запроса.</param>
        public static void PrintRequest6(IEnumerable<dynamic> res)
        {
            if (!res.Any()) { Console.WriteLine("Результат запроса пуст.\n"); return; } // Если подходящих элементов не найдено, выход из метода
            UI.ChangeColor("Соединение коллекций (игра + подарки):", ConsoleColor.Green);
            foreach (var game in res) // Перебор всех элементов результата
            {
                Console.WriteLine($"ID: {game.Id}, Игра: {game.Name}, В подарок: {game.Gifts}.");
            }
            Console.WriteLine();
        }
        #endregion

        #region Вспомогательные методы
        /// <summary>
        /// Проверка коллекции на пустоту.
        /// </summary>
        /// <param name="gameStore">Коллекция коллекций для проверки на пустоту.</param>
        /// <returns>true, если коллекция пуста, иначе - false.</returns>
        static bool IsEmptyCollection(SortedDictionary<string, List<Game>> gameStore)
        {
            if (gameStore.Count == 0) // Если в коллекции нет элементов
            {
                Console.WriteLine("Коллекция не заполнена элементами.\n"); // Информируем пользователя
                return true; // Возврат true, т.к. в коллекции нет элементов
            }
            return false; // Возврат false, т.к. в коллекции есть элементы
        }

        [ExcludeFromCodeCoverage]
        /// <summary>
        /// Печать коллекции на экран.
        /// </summary>
        /// <param name="gameStore">Коллекция коллекций для печати.</param>
        static void PrintCollection(SortedDictionary<string, List<Game>> gameStore)
        {
            if (IsEmptyCollection(gameStore)) { return; }; // Если в коллекции нет элементов, выход из метода
            foreach (var games in gameStore) // Перебор списков коллекции
            {
                UI.ChangeColor($"{games.Key}:", ConsoleColor.Green); // Печать названия списка
                foreach (var game in games.Value) // Перебор элементов списка
                {
                    Console.WriteLine(game); // Печать элемента
                }
                Console.WriteLine();
            }
                
        }

        // Делегат для хранения ссылок на запросы
        public delegate dynamic RequestHandler(SortedDictionary<string, List<Game>> gameStore);

        /// <summary>
        /// Метод обработки переданного запроса (метода) с коллекцией.
        /// </summary>
        /// <param name="gameStore">Коллекция коллекций.</param>
        /// <param name="method">Метод для выполнения.</param>
        /// <returns>Результат выполнения метода.</returns>
        public static dynamic ActivateRequest(SortedDictionary<string, List<Game>> gameStore, RequestHandler method)
        {
            if (IsEmptyCollection(gameStore)) { return null; } // Если коллекция пуста, возврат null
            return method(gameStore); // Возврат выполнения запроса
        }
        #endregion
        #endregion

        #region Вторая часть
        #region Формирование дерева
        /// <summary>
        /// Создание дерева.
        /// </summary>
        /// <returns>Созданное АВЛ-дерево.</returns>
        public static MyAVLTree<Game> CreateTree()
        {
            MyAVLTree<Game> tree = new MyAVLTree<Game>(); // Создаем новое дерево
            int size = 15; // Задает размерность для дерева
            tree = FillTree(tree, size); // Заполнение дерева случайными элементами
            Console.WriteLine("Дерево заполнено случайными элементами.\n");
            return tree; // Возврат заполненного дерева
        }

        /// <summary>
        /// Заполнение дерева случайными элементами.
        /// </summary>
        /// <param name="tree">АВЛ-дерево для заполнения.</param>
        /// <param name="size">Размерность заполняемого дерева.</param>
        /// <returns></returns>
        public static MyAVLTree<Game> FillTree(MyAVLTree<Game> tree, int size)
        {
            for (int i = 0; i < size; i++)
            {
                switch (i % 4)
                {
                    case 0:
                        Game game = new Game(); // Создание нового элемента типа Game
                        game.RandomInit(); // Заполнение элемента случайными данными
                        tree.Add(game); // Добавление элемента в дерево
                        break;
                    case 1:
                        BoardGame boardGame = new BoardGame(); // Создание нового элемента типа BoardGame
                        boardGame.RandomInit(); // Заполнение элемента случайными данными
                        tree.Add(boardGame); // Добавление элемента в дерево
                        break;
                    case 2:
                        VideoGame videoGame = new VideoGame(); // Создание нового элемента типа VideoGame
                        videoGame.RandomInit(); // Заполнение элемента случайными данными
                        tree.Add(videoGame); // Добавление элемента в дерево
                        break;
                    case 3:
                        VRGame VRGame = new VRGame(); // Создание нового элемента типа VRGame
                        VRGame.RandomInit(); // Заполнение элемента случайными данными
                        tree.Add(VRGame); // Добавление элемента в дерево
                        break;
                }
            }
            return tree; // Возврат заполненного дерева
        }
        #endregion

        #region Первый запрос (оператор where)
        /// <summary>
        /// Первый запрос. Используется оператор Where. Метод расширения.
        /// </summary>
        /// <param name="tree">АВЛ-дерево.</param>
        public static IEnumerable<Game> Request1_ExMethod(MyAVLTree<Game> tree)
        {
            // Запоминаем только настольные игры, в которых разница в кол-ве игроков больше 10000
            var res = tree.Where(game => game.MaxCount - game.MinCount > 10000 && game is BoardGame);
            return res; // Вызов метода печати результата на экран
        }

        /// <summary>
        /// Первый запрос. Используется оператор Where. LINQ.
        /// </summary>
        /// <param name="tree">АВЛ-дерево.</param>
        public static IEnumerable<Game> Request1_LINQ(MyAVLTree<Game> tree)
        {
            // Запоминаем только настольные игры, в которых разница в кол-ве игроков больше 10000
            var res = from item in tree
                      where item is BoardGame && item.MaxCount - item.MinCount > 10000
                      select item;
            return res; // Вызов метода печати результата на экран
        }

        /// <summary>
        /// Печать результата первого запроса.
        /// </summary>
        /// <param name="res">Результат выполнения первого запроса.</param>
        public static void PrintTreeRequest1(IEnumerable<Game>? res)
        {
            if (res == null) { return; } // Если результат пуст, выходим из метода
            else if (!res.Any()) { Console.WriteLine("В дереве нет таких игр.\n"); return; } // Если подходящих элементов не найдено, выход из метода
            UI.ChangeColor("Настольные игры, в которых разница в кол-ве игроков больше 10000:", ConsoleColor.Green);
            foreach (var item in res) // Перебор всех элементов результата
            {
                Console.WriteLine(item); // Печать элемента на экран
            }
            Console.WriteLine();
        }
        #endregion

        #region Второй запрос (оператор сount)
        /// <summary>
        /// Второй запрос. Используется оператор Count. LINQ.
        /// </summary>
        /// <param name="tree">АВЛ-дерево.</param>
        public static void Request2_LINQ(MyAVLTree<Game> tree)
        {
            if (IsEmptyTree(tree)) { return; } // Если в коллекции нет элементов, выход из метода
            // Запоминаем только видео-игры, в которых устройство для игры - PlayStation
            var res = (from item in tree
                      where item is VideoGame && ((VideoGame)item).Device == "PlayStation"
                      select item).Count();
            PrintTreeRequest2(res); // Вызов метода печати результата на экран
        }

        /// <summary>
        /// Второй запрос. Используется оператор Count. Метод расширения.
        /// </summary>
        /// <param name="tree">АВЛ-дерево.</param>
        public static void Request2_ExMethod(MyAVLTree<Game> tree)
        {
            if (IsEmptyTree(tree)) { return; } // Если в коллекции нет элементов, выход из метода
            // Запоминаем только видео-игры, в которых устройство для игры - PlayStation
            var res = tree
                      .Where(item => item is VideoGame && ((VideoGame)item).Device == "PlayStation")
                      .Count();
            PrintTreeRequest2(res); // Вызов метода печати результата на экран
        }

        /// <summary>
        /// Печать результата второго запроса.
        /// </summary>
        /// <param name="res">Результат выполнения второго запроса.</param>
        public static void PrintTreeRequest2(int res)
        {
            if (res == 0) { Console.WriteLine("В дереве нет таких игр.\n"); return; } // Если подходящих элементов не найдено, выход из метода
            UI.ChangeColor("Количество видео-игр, в которых устройство для игры - PlayStation:", ConsoleColor.Green);
            Console.WriteLine(res); // Печать результата на экран
            Console.WriteLine();
        }
        #endregion

        #region Третий запрос (оператор average)
        /// <summary>
        /// Третий запрос. Используется оператор Average. LINQ.
        /// </summary>
        /// <param name="tree">АВЛ-дерево.</param>
        public static void Request3_LINQ(MyAVLTree<Game> tree)
        {
            try
            {
                if (IsEmptyTree(tree)) { return; } // Если в коллекции нет элементов, выход из метода
                                                   // Подсчет среднего значения минимального количества элементов у настольных игр
                var res = (from item in tree
                           where item is BoardGame
                           select item.MinCount).Average();
                PrintTreeRequest3(res); // Вызов метода печати результата на экран
            }
            catch (InvalidOperationException ex) 
            {
                Console.WriteLine($"Ошибка! {ex.Message}.\n");
            }
        }

        /// <summary>
        /// Третий запрос. Используется оператор Average. Метод расширения.
        /// </summary>
        /// <param name="tree">АВЛ-дерево.</param>
        public static void Request3_ExMethod(MyAVLTree<Game> tree)
        {
            try
            {
                if (IsEmptyTree(tree)) { return; } // Если в коллекции нет элементов, выход из метода
                                                   // Подсчет среднего значения минимального количества элементов у настольных игр
                var res = tree
                          .Where(item => item is BoardGame)
                          .Select(item => item.MinCount)
                          .Average();
                PrintTreeRequest3(res); // Вызов метода печати результата на экран
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Ошибка! {ex.Message}.\n");
            }
        }

        /// <summary>
        /// Печать результата третьего запроса.
        /// </summary>
        /// <param name="res">Результат выполнения третьего запроса.</param>
        public static void PrintTreeRequest3(double res)
        {

            UI.ChangeColor("Среднее значение мин. кол-ва игроков у настольных игр:", ConsoleColor.Green);
            Console.WriteLine(res); // Печать результата на экран
            Console.WriteLine();
        }
        #endregion

        #region Четвертый запрос (оператор group by)
        /// <summary>
        /// Четвертый запрос. Используется оператор Group by. Метод расширения.
        /// </summary>
        /// <param name="tree">АВЛ-дерево.</param>
        public static void Request4_ExMethod(MyAVLTree<Game> tree)
        {
            if (IsEmptyTree(tree)) { return; } // Если в коллекции нет элементов, выход из метода
            // Группировка игр по названию
            var res = tree.GroupBy(game => game.Name);
            PrintTreeRequest4(res); // Вызов метода печати результата на экран
        }

        /// <summary>
        /// Четвертый запрос. Используется оператор Group by. LINQ.
        /// </summary>
        /// <param name="tree">АВЛ-дерево.</param>
        public static void Request4_LINQ(MyAVLTree<Game> tree)
        {
            if (IsEmptyTree(tree)) { return; } // Если в коллекции нет элементов, выход из метода
            // Группировка игр по названию
            var res = from game in tree
                      group game by game.Name into gameGroup
                      select gameGroup;
            PrintTreeRequest4(res); // Вызов метода печати результата на экран
        }

        /// <summary>
        /// Печать результата четвертого запроса.
        /// </summary>
        /// <param name="res">Результат выполнения четвертого запроса.</param>
        public static void PrintTreeRequest4(IEnumerable<IGrouping<string, Game>> res)
        {
            UI.ChangeColor("Группировка игр по названию:", ConsoleColor.Blue);
            foreach (var group in res) // Перебор всех элементов результата
            {
                UI.ChangeColor($"{group.Key} (количество элементов: {group.Count()}):", ConsoleColor.Green); // Печать названия группируемой коллекции (название игры)
                foreach (var game in group) // Перебор всех элементов в группе
                {
                    Console.WriteLine(game); // Печать элемента
                }
                Console.WriteLine();
            }
        }
        #endregion

        #region Вспомогательные методы
        /// <summary>
        /// Проверка дерева на пустоту.
        /// </summary>
        /// <param name="tree">Дерево для проверки на пустоту.</param>
        /// <returns>true, если дерево пусто, иначе - false.</returns>
        static bool IsEmptyTree(MyAVLTree<Game> tree)
        {
            if (tree.Count == 0) // Если в коллекции нет элементов
            {
                Console.WriteLine("Дерево не заполнено элементами.\n"); // Информируем пользователя
                return true; // Возврат true, т.к. в коллекции нет элементов
            }
            return false; // Возврат false, т.к. в коллекции есть элементы
        }

        [ExcludeFromCodeCoverage]
        /// <summary>
        /// Печать дерева.
        /// </summary>
        /// <param name="tree">АВЛ-дерево для печати.</param>
        static void PrintTree(AVLTree<Game>? tree)
        {
            if (tree.Root == null) { tree.Print(); Console.WriteLine(); return; }
            UI.ChangeColor("Печать авл-дерева по уровням:\n", ConsoleColor.Green);
            tree.Print(); // Печать авл-дерева
            Console.WriteLine();
        }

        // Делегат для хранения ссылок на запросы для дерева
        public delegate dynamic RequestHandlerTree(MyAVLTree<Game> tree);

        /// <summary>
        /// Метод обработки переданного запроса (метода) с деревом.
        /// </summary>
        /// <param name="tree">АВЛ-дерево.</param>
        /// <param name="method">Метод для выполнения.</param>
        /// <returns>Результат выполнения метода.</returns>
        public static dynamic ActivateRequestTree(MyAVLTree<Game> tree, RequestHandlerTree method)
        {
            if (IsEmptyTree(tree)) { return null; } // Если коллекция пуста, возврат null
            return method(tree); // Возврат выполнения запроса
        }
        #endregion
        #endregion
    }
}