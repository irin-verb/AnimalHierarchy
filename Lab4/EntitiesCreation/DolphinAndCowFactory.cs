using KPO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.EntitiesCreation
{
    /// <summary>
    /// Абстрактная фабрика для создания дельфинов и коров
    /// </summary>
    public class DolphinAndCowFactory : AbstractAnimalFactory
    {
        /// <summary>
        /// Создать корову
        /// </summary>
        /// <returns>Созданное животное</returns>
        public override FriendlyAnimal CreateFriendlyAnimal()
        {
            return new Cow();
        }

        /// <summary>
        /// Создать дельфина
        /// </summary>
        /// <returns>Созданное животное</returns>
        public override NeutralAnimal CreateNeutralAnimal()
        {
            return new Dolphin();
        }

        /// <summary>
        /// Получить строковое представление фабрики
        /// </summary>
        /// <returns>Название фабрики</returns>
        public override string ToString()
        {
            return "Дельфин и корова";
        }
    }
}
