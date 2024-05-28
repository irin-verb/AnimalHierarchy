using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab4.EntitiesCreation;

namespace Lab4.FactoriesCreation
{
    public abstract class AnimalFactoryMethod
    {
        public abstract IAnimalFactory CreateAnimalFactory();
    }
}
