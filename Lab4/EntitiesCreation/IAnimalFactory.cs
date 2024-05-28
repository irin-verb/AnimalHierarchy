using KPO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.EntitiesCreation
{
    public interface IAnimalFactory
    {
        NeutralAnimal CreateNeutralAnimal();
        FriendlyAnimal CreateFriendlyAnimal();
    }
}
