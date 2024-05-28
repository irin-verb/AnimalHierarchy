using KPO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.EntitiesCreation
{
    public class WolfAndHorseFactory : AbstractAnimalFactory
    {
        public override FriendlyAnimal CreateFriendlyAnimal()
        {
            return new Horse();
        }

        public override NeutralAnimal CreateNeutralAnimal()
        {
            return new Wolf();
        }

        public override string ToString()
        {
            return "Волк и лошадь";
        }
    }
}
