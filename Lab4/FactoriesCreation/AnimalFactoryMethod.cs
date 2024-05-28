using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab4.EntitiesCreation;

namespace Lab4.FactoriesCreation
{
    /// <summary>
    /// Фабричный метод для создания фабрик
    /// </summary>
    public abstract class AnimalFactoryMethod
    {
        /// <summary>
        /// Создать фабрику
        /// </summary>
        /// <returns>Созданная фабрика</returns>
        public abstract IAnimalFactory CreateAnimalFactory();
    }
}
