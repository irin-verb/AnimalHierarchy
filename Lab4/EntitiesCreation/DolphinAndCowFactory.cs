using KPO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.EntitiesCreation
{
    public class DolphinAndCowFactory : AbstractAnimalFactory
    {
        public override FriendlyAnimal CreateFriendlyAnimal()
        {
            return new Cow();
        }

        public override NeutralAnimal CreateNeutralAnimal()
        {
            return new Dolphin();
        }

        public override string ToString()
        {
            return "Дельфин и корова";
        }
    }
}
