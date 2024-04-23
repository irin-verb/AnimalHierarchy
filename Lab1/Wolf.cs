using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace KPO
{
    /// <summary>
    /// Волк
    /// </summary>
    public class Wolf: NeutralAnimal
    {
        /// <summary>
        /// Сила укуса волка
        /// </summary>
        private const byte BITE_DAMAGE = 2;

        /// <summary>
        /// Максимальное значение шкалы здоровья волка
        /// </summary>
        private const byte MAX_HEALTH = 12;

        /// <summary>
        /// Словарь предметов, выпадающих с волка, и соответствующих им вероятностей выпадения
        /// </summary>
        private static readonly Dictionary<Drop, byte> DefaultDrops
            = new Dictionary<Drop, byte>() 
            { { Drop.Bone, 120 } };

        
        /// <summary>
        /// Имя владельца волка
        /// </summary>
        public string OwnerName { get; set; }


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parName">Имя животного</param>
        /// <param name="parMaxHealth">Максимальное здоровье животного</param>
        /// <param name="parOwnerName">Имя владельца животного</param>
        /// <param name="parLocation">Координаты животного</param>
        /// <param name="parBiteDamage">Сала укуса животного</param>
        /// <param name="parDrops">Словарь выпадающих с животного предметов</param>
        public Wolf(string parName, 
            string parOwnerName,
            Point parLocation,
            byte parMaxHealth = MAX_HEALTH,
            Dictionary<Drop, byte> parDrops = null,
            byte parBiteDamage = BITE_DAMAGE)
            : base(parName, parLocation, parMaxHealth, parDrops ?? DefaultDrops, parBiteDamage) 
        {
            OwnerName = parOwnerName;
        }


        /// <summary>
        /// Охотиться
        /// </summary>
        /// <param name="parAnimals">Список животных для охоты</param>
        /// <returns>Случайный выпадаемый с жертвы предмет</returns>
        public Drop? ToHunt( Animal[] parAnimals )
        {
            double[] distances = parAnimals.Select(elAnimal => (Location - elAnimal.Location).Length).ToArray();
            Animal victim = parAnimals[Array.IndexOf(parAnimals, distances.Max())];
            return ToAttack(victim);
        }

    }
}
