using System.Text.RegularExpressions;

namespace lab14
{
    /// <summary>
    /// Класс атрибутов, идущих в подарок к игре.
    /// </summary>
    internal class Gift
    {
        #region Поля
        /// <summary>
        /// Название игры.
        /// </summary>
        protected string? name;

        /// <summary>
        /// Атрибуты, идущие в подарок к игре.
        /// </summary>
        protected string? gifts;
        #endregion

        #region Свойства
        /// <summary>
        /// Название игры.
        /// </summary>
        public string? Name
        {
            get => name;
            set
            {
                Regex latinLetters = new Regex("^[a-zA-Zа-яА-Я\\s]+$");
                if (latinLetters.IsMatch(value))
                    name = value;
                else
                    name = "Названия нет";
            }
        }

        /// <summary>
        /// Атрибуты, идущие в подарок к игре.
        /// </summary>
        public string? Gifts 
        {
            get => gifts;
            set => gifts = value;
        }
        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор без параметров формирования элемента класса.
        /// </summary>
        public Gift()
        {
            Name = "Игра";
            Gifts = "Подарки";
        }

        /// <summary>
        /// Конструктор с параметрами для формирования элемента класса.
        /// </summary>
        /// <param name="name">Название игры.</param>
        /// <param name="gifts">Атрибуты, идущие в подарок к игре.</param>
        public Gift(string name, string gifts)
        {
            Name = name;
            Gifts = gifts;
        }
        #endregion

        #region Методы
        /// <summary>
        /// Преобразование элемента в строку.
        /// </summary>
        /// <returns>Преобразованная строка.</returns>
        public override string? ToString()
        {
            return $"{Name}. {Gifts}";
        }
        #endregion
    }
}