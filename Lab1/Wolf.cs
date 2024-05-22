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
        /// Имя владельца волка
        /// </summary>
        public string OwnerName { get; set; } = "";


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parName">Имя животного</param>
        /// <param name="parHealth">Здоровье животного</param>
        /// <param name="parLocation">Координаты животного</param>
        /// <param name="parDrop">Предмет, который животное несет во рту</param>
        /// <param name="parOwnerName">Имя владельца животного</param>
        /// <param name="parBiteDamage">Сала укуса животного</param>
        public Wolf(string parName, 
            string parOwnerName,
            Point parLocation,
            byte parHealth = MAX_HEALTH,
            Drop parDrop = Drop.None,
            byte parBiteDamage = MAX_BITE_DAMAGE)
            : base(parName, parLocation, parHealth, parDrop, parBiteDamage) 
        {
            OwnerName = parOwnerName;
        }

        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public Wolf() : base() { }

        /// <summary>
        /// Конструктор копирования
        /// </summary>
        /// <param name="parAnimal">Животное, которое копируется</param>
        public Wolf(Wolf parAnimal) : base(parAnimal)
        {
            Copy(parAnimal);
        }


        /// <summary>
        /// Копировать параметры животного
        /// </summary>
        /// <param name="parAnimal">Животного, параметры которого копируются</param>
        public override void Copy(Animal parAnimal)
        {
            base.Copy(parAnimal);
            OwnerName = ((Wolf)parAnimal).OwnerName;
        }

        /// <summary>
        /// Охотиться
        /// </summary>
        /// <param name="parAnimals">Список животных для охоты</param>
        /// <returns>Предмет, который жертва могла нести во рту</returns>
        public Drop ToHunt( Animal[] parAnimals )
        {
            double[] distances = parAnimals.Select(elAnimal => (Location - elAnimal.Location).Length).ToArray();
            Animal victim = parAnimals[Array.IndexOf(parAnimals, distances.Max())];
            return ToAttack(victim);
        }

    }
}
