namespace lab14
{
    /// <summary>
    /// Пользовательскиий интерфейс.
    /// </summary>
    internal class UI
    {
        #region Списки для меню
        /// <summary>
        /// Список для главного меню.
        /// </summary>
        static List<string> MainMenu = new List<string>() {
            "=== ГЛАВНОЕ МЕНЮ ===",
            "1. Первая часть.\n",
            "2. Вторая часть.\n",
            "3. Выход.\n",
            "\nВыберите пункт меню: " };

        /// <summary>
        /// Список для меню первой части.
        /// </summary>
        static List<string> PartOneMenu = new List<string>(){
            "=== ПЕРВАЯ ЧАСТЬ ===",
            "1. Заполнение коллекции случайными элементами.\n",
            "2. Печать коллекции.\n",
            "3. Печать всех настольных игр, требующих дополнительные атрибуты (where).\n",
            "4. Печать названий игр, которые есть в видео-играх и VR-играх (intersect).\n",
            "5. Печать максимального количества игроков из всех игр (max).\n",
            "6. Группировка игр по названию (group by).\n",
            "7. Печать игр с доп. вычислением - разницей в кол-ве игроков (let).\n",
            "8. Соединение коллекций (join).\n",
            "9. Вернуться назад.\n",
            "\nВыберите пункт меню: " };

        /// <summary>
        /// Список для меню второй части.
        /// </summary>
        static List<string> PartTwoMenu = new List<string>(){
            "=== ВТОРАЯ ЧАСТЬ ===",
            "1. Заполнение дерева случайными элементами.\n",
            "2. Печать дерева.\n",
            "3. Печать всех настольных игр, разница в количестве игроков у которых больше 10000 (where).\n",
            "4. Печать количества видео-игр, в которых устройство для игры - PlayStation (count).\n",
            "5. Печать среднего значения мин. кол-ва игроков у настольных игр (average).\n",
            "6. Группировка игр по названию (group by).\n",
            "7. Вернуться назад.\n",
            "\nВыберите пункт меню: " };

        /// <summary>
        /// Список для выходного меню.
        /// </summary>
        static List<string> ExitMenu = new List<string>() {
            "Вы уверены, что хотите завершить работу?",
            "1. Да.\n",
            "2. Нет.\n",
            "\nВыберите пункт меню: " };
        #endregion

        #region Методы работы с цветом
        /// <summary>
        /// Изменение цвета переданной строки.
        /// </summary>
        /// <param name="str">Строка для печати.</param>
        /// <param name="color">Цвет консоли.</param>
        public static void ChangeColor(string str, ConsoleColor color)
        {
            Console.ForegroundColor = color; // Изменение цвета консоли
            Console.WriteLine(str); // Печать строки
            Console.ResetColor(); // Сброс цвета консоли
        }
        #endregion

        #region Методы печати меню
        /// <summary>
        /// Печать главного меню.
        /// </summary>
        static public void PrintMainMenu()
        {
            ChangeColor(MainMenu[0], ConsoleColor.Blue); // Печать заголовка
            for (int i = 1; i < MainMenu.Count; i++) // Перебор пунктов меню
            {
                Console.Write(MainMenu[i]); // Печать пункта меню
            }
        }

        /// <summary>
        /// Печать меню частей.
        /// </summary>
        static public void PrintPartMenu(int part)
        {
            if (part == 1)
            {
                ChangeColor(PartOneMenu[0], ConsoleColor.Blue); // Печать заголовка
                for (int i = 1; i < PartOneMenu.Count; i++) // Перебор пунктов меню
                {
                    Console.Write(PartOneMenu[i]); // Печать пункта меню
                }
            }
            else if (part == 2)
            {
                ChangeColor(PartTwoMenu[0], ConsoleColor.Blue); // Печать заголовка
                for (int i = 1; i < PartTwoMenu.Count; i++) // Перебор пунктов меню
                {
                    Console.Write(PartTwoMenu[i]); // Печать пункта меню
                }
            }
        }

        /// <summary>
        /// Печать меню выхода.
        /// </summary>
        static public void PrintExitMenu()
        {
            ChangeColor(ExitMenu[0], ConsoleColor.Blue); // Печать заголовка
            for (int i = 1; i < ExitMenu.Count; i++) // Перебор пунктов меню
            {
                Console.Write(ExitMenu[i]); // Печать пункта меню
            }
        }

        /// <summary>
        /// Печать сообщения о завершении программы.
        /// </summary>
        static public void ExitProgram()
        {
            ChangeColor("Программа завершена!", ConsoleColor.Red);
        }
        #endregion

        #region Вспомогательные методы для пользователя
        /// <summary>
        /// Получение целого числа от пользователя.
        /// </summary>
        /// <returns>Корректное введеное целое число.</returns>
        public static int GetInt()
        {
            bool isConvert; // Результат конвертирования
            int result; // Результат преобразования строки
            do // Пока не будет введено корректное значение
            {
                isConvert = int.TryParse(Console.ReadLine(), out result); // Проверка конвертирования
                if (!isConvert) // Если введено некорректное число
                {
                    ChangeColor("\nНекорректный ввод или число выходит за пределы. \nПовторите ввод: ", ConsoleColor.Red); // Вывод ошибки
                }
            }
            while (!isConvert);
            return result; // Возврат корректного числа
        }
        #endregion
    }
}
