using KPO;
using Lab4.EntitiesCreation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.FactoriesCreation
{
    public class PrototypeAnimalFactoryMethod : AnimalFactoryMethod
    {
        private NeutralAnimal _neutralAnimal;
        private FriendlyAnimal _friendlyAnimal;

        public PrototypeAnimalFactoryMethod(NeutralAnimal parNeutralAnimal, FriendlyAnimal parFriendlyAnimal)
        {
            _neutralAnimal = parNeutralAnimal;
            _friendlyAnimal = parFriendlyAnimal;
        }

        public override IAnimalFactory CreateAnimalFactory()
        {
            return new PrototypeAnimalFactory(_neutralAnimal, _friendlyAnimal);
        }
    }
}
