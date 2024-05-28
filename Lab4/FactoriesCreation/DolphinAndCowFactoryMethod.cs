using Lab4.EntitiesCreation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.FactoriesCreation
{
    /// <summary>
    /// Фабричный метод для создания абстрактной фабрики, создающей дельфинов и коров
    /// </summary>
    public class DolphinAndCowFactoryMethod : AnimalFactoryMethod
    {
        /// <summary>
        /// Создать фабрику
        /// </summary>
        /// <returns>Созданная фабрика</returns>
        public override IAnimalFactory CreateAnimalFactory()
        {
            return new DolphinAndCowFactory();
        }
    }
}
