using KPO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.EntitiesCreation
{
    /// <summary>
    /// Фабрика прототипов для создания животных
    /// </summary>
    public class PrototypeAnimalFactory : IAnimalFactory
    {
        /// <summary>
        /// Прототип нейтрального животного
        /// </summary>
        private NeutralAnimal _neutralAnimal;

        /// <summary>
        /// Прототип дружелюбного животнго
        /// </summary>
        private FriendlyAnimal _friendlyAnimal;


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parNeutralAnimal">Прототип нейтрального животного</param>
        /// <param name="parFriendlyAnimal">Прототип дружелюбного животнго</param>
        public PrototypeAnimalFactory(NeutralAnimal parNeutralAnimal, FriendlyAnimal parFriendlyAnimal)
        {
            _neutralAnimal = parNeutralAnimal;
            _friendlyAnimal = parFriendlyAnimal;
        }


        /// <summary>
        /// Создать дружелюбное животное
        /// </summary>
        /// <returns>Созданное животное</returns>
        public FriendlyAnimal CreateFriendlyAnimal()
        {
            return (FriendlyAnimal)_friendlyAnimal.Clone();
        }

        /// <summary>
        /// Создать нейтральное животное
        /// </summary>
        /// <returns>Созданное животное</returns>
        public NeutralAnimal CreateNeutralAnimal()
        {
            return (NeutralAnimal)_neutralAnimal.Clone();
        }

        /// <summary>
        /// Получить строковое представление фабрики
        /// </summary>
        /// <returns>Название фабрики</returns>
        public override string ToString() 
        {
            return "Прототип";
        }
    }
}
