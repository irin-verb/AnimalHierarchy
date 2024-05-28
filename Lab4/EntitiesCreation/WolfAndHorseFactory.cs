using KPO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.EntitiesCreation
{
    /// <summary>
    /// Абстрактная фабрика для создания волков и лошадей
    /// </summary>
    public class WolfAndHorseFactory : AbstractAnimalFactory
    {
        /// <summary>
        /// Создать лошадь
        /// </summary>
        /// <returns>Созданное животное</returns>
        public override FriendlyAnimal CreateFriendlyAnimal()
        {
            return new Horse();
        }

        /// <summary>
        /// Создать волка
        /// </summary>
        /// <returns>Созданное животное</returns>
        public override NeutralAnimal CreateNeutralAnimal()
        {
            return new Wolf();
        }

        /// <summary>
        /// Получить строковое представление фабрики
        /// </summary>
        /// <returns>Название фабрики</returns>
        public override string ToString()
        {
            return "Волк и лошадь";
        }
    }
}
