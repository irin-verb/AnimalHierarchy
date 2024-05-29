using KPO;
using Lab4.EntitiesCreation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.FactoriesCreation
{
    /// <summary>
    /// Фабричный метод для создания фабрики прототипов, создающей нейтральных и дружелююных животных
    /// </summary>
    public class PrototypeAnimalFactoryMethod : AnimalFactoryMethod
    {
        /// <summary>
        /// Прототип нейтрального животного
        /// </summary>
        private NeutralAnimal _neutralAnimal;
        /// <summary>
        /// Прототип дружелюбного животного
        /// </summary>
        private FriendlyAnimal _friendlyAnimal;


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parNeutralAnimal">Прототип нейтрального животного</param>
        /// <param name="parFriendlyAnimal">Прототип дружелюбного животного</param>
        public PrototypeAnimalFactoryMethod(NeutralAnimal parNeutralAnimal, FriendlyAnimal parFriendlyAnimal)
        {
            _neutralAnimal = parNeutralAnimal;
            _friendlyAnimal = parFriendlyAnimal;
        }


        /// <summary>
        /// Создать фабрику
        /// </summary>
        /// <returns>Созданная фабрика</returns>
        public override IAnimalFactory CreateAnimalFactory()
        {
            return new PrototypeAnimalFactory(_neutralAnimal, _friendlyAnimal);
        }
    }
}
