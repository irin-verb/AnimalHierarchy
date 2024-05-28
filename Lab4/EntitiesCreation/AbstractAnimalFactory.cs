using KPO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.EntitiesCreation
{
    public abstract class AbstractAnimalFactory : IAnimalFactory
    {
        public abstract FriendlyAnimal CreateFriendlyAnimal();
        public abstract NeutralAnimal CreateNeutralAnimal();
    }
}
