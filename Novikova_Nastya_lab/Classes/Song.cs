using System;

namespace Novikova_Nastya_lab
{
    class Song
    {
        /// <summary>
        /// Название песни
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Автор песни
        /// </summary>
        public string Author { get; private set; }
        /// <summary>
        /// Связь с предыдущей песней в списке
        /// </summary>
        public Song Prev { get; private set; }

        /// <summary>
        /// Метод для заполнения поля Name
        /// </summary>
        /// <param name="name"></param>
        public void SetName(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Метод для заполнения поля Author
        /// </summary>
        /// <param name="author"></param>
        public void SetAuthor(string author)
        {
            Author = author;
        }

        /// <summary>
        /// Метод для заполнения поля Prev
        /// </summary>
        /// <param name="prev"></param>
        public void SetPrev(Song prev)
        {
            Prev = prev;
        }

        /// <summary>
        /// Метод для печати названия песни и ее исполнителя
        /// </summary>
        public void PrintInfo()
        {
            Console.WriteLine($"Название: {Name}, Исполнитель: {Author}");
        }

        /// <summary>
        /// Метод, который возвращает название и исполнителя
        /// </summary>
        /// <returns></returns>
        public string Title()
        {
            return $"{Name} - {Author}";
        }

        /// <summary>
        /// Переопределение метода Equals для сравнения двух объектов-песен
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Song other = (Song)obj;
            return Name == other.Name && Author == other.Author;
        }

        /// <summary>
        /// Переопределение метода GetHashCode для корректного сравнения
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (Name, Author).GetHashCode();
        }
    }
}
