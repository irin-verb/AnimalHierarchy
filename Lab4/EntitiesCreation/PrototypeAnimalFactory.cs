using KPO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.EntitiesCreation
{
    public class PrototypeAnimalFactory : IAnimalFactory
    {
        private NeutralAnimal _neutralAnimal;
        private FriendlyAnimal _friendlyAnimal;
        public PrototypeAnimalFactory(NeutralAnimal parNeutralAnimal, FriendlyAnimal parFriendlyAnimal)
        {
            _neutralAnimal = parNeutralAnimal;
            _friendlyAnimal = parFriendlyAnimal;
        }

        public FriendlyAnimal CreateFriendlyAnimal()
        {
            return (FriendlyAnimal)_neutralAnimal.Clone();
        }

        public NeutralAnimal CreateNeutralAnimal()
        {
            return (NeutralAnimal)_friendlyAnimal.Clone();
        }
    }
}
