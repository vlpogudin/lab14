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
                                    Request1(gameStore); // Первый запрос
                                    break;

                                case 4:
                                    Console.Clear();
                                    Request2(gameStore); // Второй запрос
                                    break;

                                case 5:
                                    Console.Clear();
                                    Request3(gameStore); // Третий запрос
                                    break;

                                case 6:
                                    Console.Clear();
                                    Request4(gameStore); // Четвертый запрос
                                    break;

                                case 7:
                                    Console.Clear();
                                    Request5(gameStore); // Пятый запрос
                                    break;

                                case 8:
                                    Console.Clear();
                                    Request6(gameStore); // Шестой запрос
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
                                    Request1(tree); // Первый запрос
                                    break;

                                case 4:
                                    Console.Clear();
                                    Request2(tree); // Второй запрос
                                    break;

                                case 5:
                                    Console.Clear();
                                    Request3(tree); // Третий запрос
                                    break;

                                case 6:
                                    Console.Clear();
                                    Request4(tree); // Четвертый запрос
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
        /// Первый запрос для коллекции. Используется оператор Where.
        /// </summary>
        /// <param name="gameStore">Коллекция коллекций.</param>
        public static void Request1(SortedDictionary<string, List<Game>> gameStore)
        {
            if (IsEmptyCollection(gameStore)) { return; } // Если в коллекции нет элементов, выход из метода
            // Запоминаем только элементы, являющиеся настольной игрой и требующие дополнительных атрибутов
            var res = from item in gameStore.Values
                      from game in item
                      where game is BoardGame && ((BoardGame)game).ReqSpecBoard == true
                      select game;
            PrintRequest1(res); // Вызов метода печати результата на экран
        }

        /// <summary>
        /// Печать результата первого запроса.
        /// </summary>
        /// <param name="res">Результат выполнения первого запроса.</param>
        public static void PrintRequest1(IEnumerable<Game> res)
        {
            if (!res.Any()) { Console.WriteLine("В коллекции нет таких игр.\n"); return; } // Если подходящих элементов не найдено, выход из метода
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
        /// Второй запрос для коллекции. Используется оператор Intersect.
        /// </summary>
        /// <param name="gameStore">Коллекция коллекций.</param>
        public static void Request2(SortedDictionary<string, List<Game>> gameStore)
        {
            if (IsEmptyCollection(gameStore)) { return; } // Если в коллекции нет элементов, выход из метода
            // Запоминаем только названия элементов, являющихся видео-игрой
            var boardGames = gameStore.SelectMany(games => games.Value)
                             .Where(game => game is BoardGame)
                             .Select(game => game.Name);

            // Запоминаем только названия элементов, являющихся VR-игрой
            var vrGames = gameStore.SelectMany(games => games.Value)
                                   .Where(game => game is VRGame)
                                   .Select(game => game.Name);

            var res = boardGames.Intersect(vrGames); // Находим пересечение множеств
            PrintRequest2(res); // Вызов метода печати результата на экран
        }

        /// <summary>
        /// Печать результата второго запроса.
        /// </summary>
        /// <param name="res">Результат выполнения второго запроса.</param>
        public static void PrintRequest2(IEnumerable<string> res)
        {
            if (!res.Any()) { Console.WriteLine("В коллекции нет таких названий.\n"); return; } // Если подходящих элементов не найдено, выход из метода
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
        /// Третий запрос для коллекции. Используется оператор Max.
        /// </summary>
        /// <param name="gameStore">Коллекция коллекций.</param>
        public static void Request3(SortedDictionary<string, List<Game>> gameStore)
        {
            if (IsEmptyCollection(gameStore)) { return; } // Если в коллекции нет элементов, выход из метода
            // Запоминаем максимальное количество игроков из всех игр
            var res = (from games in gameStore.Values
                       from game in games
                       select game.MaxCount).Max();

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
        /// Четвертый запрос для коллекции. Используется оператор Group by.
        /// </summary>
        /// <param name="gameStore">Коллекция коллекций.</param>
        public static void Request4(SortedDictionary<string, List<Game>> gameStore)
        {
            if (IsEmptyCollection(gameStore)) { return; } // Если в коллекции нет элементов, выход из метода
            // Группировка игр по названию
            var res = from games in gameStore.Values
                      from game in games
                      group game by game.Name;

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
        /// Пятый запрос для коллекции. Используется оператор Let.
        /// </summary>
        /// <param name="gameStore">Коллекция коллекций.</param>
        public static void Request5(SortedDictionary<string, List<Game>> gameStore)
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
        /// Шестой запрос для коллекции. Используется оператор Join.
        /// </summary>
        /// <param name="gameStore">Коллекция коллекций.</param>
        public static void Request6(SortedDictionary<string, List<Game>> gameStore)
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
        /// Первый запрос. Используется оператор Where.
        /// </summary>
        /// <param name="tree">АВЛ-дерево.</param>
        public static void Request1(MyAVLTree<Game> tree)
        {
            if (IsEmptyTree(tree)) { return; } // Если в коллекции нет элементов, выход из метода
            // Запоминаем только настольные игры, в которых разница в кол-ве игроков больше 10000
            var res = tree.Where(game => game.MaxCount - game.MinCount > 10000 && game is BoardGame);
            PrintTreeRequest1(res); // Вызов метода печати результата на экран
        }

        /// <summary>
        /// Печать результата первого запроса.
        /// </summary>
        /// <param name="res">Результат выполнения первого запроса.</param>
        public static void PrintTreeRequest1(IEnumerable<Game> res)
        {
            if (!res.Any()) { Console.WriteLine("В дереве нет таких игр.\n"); return; } // Если подходящих элементов не найдено, выход из метода
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
        /// Второй запрос. Используется оператор Count.
        /// </summary>
        /// <param name="tree">АВЛ-дерево.</param>
        public static void Request2(MyAVLTree<Game> tree)
        {
            if (IsEmptyTree(tree)) { return; } // Если в коллекции нет элементов, выход из метода
            // Запоминаем только видео-игры, в которых устройство для игры - PlayStation
            var res = (from item in tree
                      where item is VideoGame && ((VideoGame)item).Device == "PlayStation"
                      select item).Count();
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
        /// Третий запрос. Используется оператор Average.
        /// </summary>
        /// <param name="tree">АВЛ-дерево.</param>
        public static void Request3(MyAVLTree<Game> tree)
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
        /// Четвертый запрос. Используется оператор Group by.
        /// </summary>
        /// <param name="tree">АВЛ-дерево.</param>
        public static void Request4(MyAVLTree<Game> tree)
        {
            if (IsEmptyTree(tree)) { return; } // Если в коллекции нет элементов, выход из метода
            // Группировка игр по названию
            var res = tree.GroupBy(game => game.Name);
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
        #endregion
        #endregion
    }
}