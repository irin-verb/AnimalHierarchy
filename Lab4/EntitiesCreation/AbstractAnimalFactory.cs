using KPO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.EntitiesCreation
{
    /// <summary>
    /// Абстрактная фабрика для создания животных
    /// </summary>
    public abstract class AbstractAnimalFactory : IAnimalFactory
    {
        /// <summary>
        /// Создать дружелюбное животнное
        /// </summary>
        /// <returns>Созданное животное</returns>
        public abstract FriendlyAnimal CreateFriendlyAnimal();

        /// <summary>
        /// Создать нейтральное дивотное
        /// </summary>
        /// <returns>Созданное животное</returns>
        public abstract NeutralAnimal CreateNeutralAnimal();
    }
}
