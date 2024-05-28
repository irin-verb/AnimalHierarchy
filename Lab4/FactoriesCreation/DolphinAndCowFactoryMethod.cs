using Lab4.EntitiesCreation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.FactoriesCreation
{
    public class DolphinAndCowFactoryMethod : AnimalFactoryMethod
    {
        public override IAnimalFactory CreateAnimalFactory()
        {
            return new DolphinAndCowFactory();
        }
    }
}
