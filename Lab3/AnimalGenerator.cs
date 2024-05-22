using KPO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Xml.Linq;

namespace Lab3
{
    /// <summary>
    /// Класс-генератор случайных животных
    /// </summary>
    public static class AnimalGenerator
    {
        /// <summary>
        /// Список случайных имен животных
        /// </summary>
        private static readonly string[] animalNames = ["Bunbo", "Ro", "Lolly", "Jingles", "Daisy", "Tutu", "Kessie", "BoBo", "Smoochy", "Chico"];
        /// <summary>
        /// Список случайных имен хозяев животных
        /// </summary>
        private static readonly string[] ownerNames = ["Sophia", "Lily", "Olivia", "Isla", "Noah", "Oliver", "George", "Arthur"];

        /// <summary>
        /// Нижний порог генерации координат
        /// </summary>
        private const int MIN_COORDINATE = -100;
        /// <summary>
        /// Верхний порог генерации координат
        /// </summary>
        private const int MAX_COORDINATE = 100;

        /// <summary>
        /// Список элементов перечисления Drop
        /// </summary>
        private static readonly Array dropValues = Enum.GetValues(typeof(Drop));
        /// <summary>
        /// Список элементов перечисления Saddle
        /// </summary>
        private static readonly Array saddleValues = Enum.GetValues(typeof(Saddle));

        /// <summary>
        /// Переменная случацной генерации
        /// </summary>
        private static readonly Random random = new Random();


        /// <summary>
        /// Имя животного
        /// </summary>
        private static string Name { get; set; }
        /// <summary>
        /// Координаты животного
        /// </summary>
        private static Point Point { get; set; }
        /// <summary>
        /// Здоровье животного
        /// </summary>
        private static byte Health { get; set; }
        /// <summary>
        /// Предмет, который несет животное
        /// </summary>
        private static Drop Drop { get; set; }
        /// <summary>
        /// Возможность сидеть на животном
        /// </summary>
        private static bool IsAbleToSit {  get; set; }
        /// <summary>
        /// Сила укуса животного
        /// </summary>
        private static byte BiteDamage {  get; set; }
        /// <summary>
        /// Количество литров молока в животном
        /// </summary>
        private static byte MilkLiters { get; set; }
        /// <summary>
        /// Вид седла на животном
        /// </summary>
        private static Saddle Saddle { get; set; }
        /// <summary>
        /// Имя владельца животного
        /// </summary>
        private static string OwnerName {  get; set; }
        /// <summary>
        /// Координатфы сокровища животного
        /// </summary>
        private static Point TreasureLocation { get; set; }


        /// <summary>
        /// Обновление полей класса случайными значениями
        /// </summary>
        private static void Update()
        {
            Name = animalNames[random.Next(animalNames.Length)];
            Point = new Point(random.Next(MIN_COORDINATE, MAX_COORDINATE + 1), random.Next(MIN_COORDINATE, MAX_COORDINATE + 1));
            Health = (byte)random.Next(1, Animal.MAX_HEALTH);
            Drop = random.Next(2) == 0 ? (Drop)dropValues.GetValue(random.Next(dropValues.Length)) : Drop.None;
            IsAbleToSit = random.Next(2) == 0;
            BiteDamage = (byte)random.Next(1, NeutralAnimal.MAX_BITE_DAMAGE);
            MilkLiters = (byte)random.Next(Cow.MAX_MILK_LITERS + 1);
            Saddle = (Saddle)saddleValues.GetValue(random.Next(saddleValues.Length));
            OwnerName = ownerNames[random.Next(ownerNames.Length)];
            TreasureLocation = new Point(random.Next(MIN_COORDINATE, MAX_COORDINATE + 1), random.Next(MIN_COORDINATE, MAX_COORDINATE + 1));
        }

        /// <summary>
        /// Сгенерировать случайное животное
        /// </summary>
        /// <returns>Случайное животное</returns>
        public static Animal GenerateAnimal()
        {
            Update();
            return new Animal(Name, Point, Health, Drop);
        }

        /// <summary>
        /// Сгенерировать случайное дружелюбное животное
        /// </summary>
        /// <returns>Случайное дружелюбное животное</returns>
        public static FriendlyAnimal GenerateFriendlyAnimal()
        {
            Update();
            return new FriendlyAnimal(Name, Point, Health, Drop, IsAbleToSit);
        }

        /// <summary>
        /// Сгенерировать случайное нейтральное животное
        /// </summary>
        /// <returns>Случайное нейтральное жиыотное</returns>
        public static NeutralAnimal GenerateNeutralAnimal()
        {
            Update();
            return new NeutralAnimal(Name, Point, Health, Drop, BiteDamage);
        }

        /// <summary>
        /// Сгенерировать случайную корову
        /// </summary>
        /// <returns>Случайная корова</returns>
        public static Cow GenerateCow()
        {
            Update();
            return new Cow(Name, Point, Health, Drop, IsAbleToSit, MilkLiters);
        }

        /// <summary>
        /// Сгенерировать случайную лошадь
        /// </summary>
        /// <returns>Случайная лошадь</returns>
        public static Horse GenerateHorse()
        {
            Update();
            return new Horse(Name, Point, Health, Drop, IsAbleToSit, Saddle);
        }

        /// <summary>
        /// Сгенерировать случайного волка
        /// </summary>
        /// <returns>Случайный волк</returns>
        public static Wolf GenerateWolf()
        {
            Update();
            return new Wolf(Name, OwnerName, Point, Health, Drop, BiteDamage);
        }

        /// <summary>
        /// Сгенерировать случайного дельфина
        /// </summary>
        /// <returns>Случайный дельфин</returns>
        public static Dolphin GenerateDolphin() 
        { 
            Update();
            return new Dolphin(Name, Point, TreasureLocation, Health, Drop, BiteDamage);
        }
    }
}
