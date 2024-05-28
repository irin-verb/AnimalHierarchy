using KPO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.EntitiesCreation
{
    /// <summary>
    /// Интерфейс фабрики для создания животных
    /// </summary>
    public interface IAnimalFactory
    {
        /// <summary>
        /// Создать нейтральное животное
        /// </summary>
        /// <returns>Созданное животное</returns>
        NeutralAnimal CreateNeutralAnimal();

        /// <summary>
        /// Создать дружелюбное животное
        /// </summary>
        /// <returns>Созданное животное</returns>
        FriendlyAnimal CreateFriendlyAnimal();
    }
}
