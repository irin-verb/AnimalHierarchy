using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace KPO
{
    /// <summary>
    /// Лошадь
    /// </summary>
    public class Horse : FriendlyAnimal
    {
        /// <summary>
        /// Максимальное значение шкалы здоровья лошади
        /// </summary>
        private const byte MAX_HEALTH = 16;

        /// <summary>
        /// Возможность сидеть на лошади
        /// </summary>
        private const bool IS_ABLE_TO_SIT = true;

        /// <summary>
        /// Словарь предметов, выпадающих с лошади, и соответствующих им вероятностей выпадения
        /// </summary>
        private static readonly Dictionary<Drop, byte> DefaultDrops
            = new Dictionary<Drop, byte>()
            { { Drop.Skin, 20 }  };


        /// <summary>
        /// Седельная сумка для вещей
        /// </summary>
        public List<Drop> SaddleBag { get; private set; } = new List<Drop>();


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parName">Имя животного</param>
        /// <param name="parLocation">Координаты животного</param>
        /// <param name="parMaxHealth">Максимальное здоровье животного</param>
        /// <param name="parDrops">Словарь выпадающих с животного предметов</param>
        /// <param name="parAbleToSit">Возможность сидеть на животном</param>
        /// <param name="parThingsInSaddleBag">Вещи в седельной сумке</param>
        public Horse(string parName,
            Point parLocation,
            byte parMaxHealth = MAX_HEALTH,
            Dictionary<Drop, byte> parDrops = null,
            bool parAbleToSit = IS_ABLE_TO_SIT,
            List<Drop> parThingsInSaddleBag = null)
            : base(parName, parLocation, parMaxHealth, parDrops ?? DefaultDrops, parAbleToSit)
        {
            SaddleBag = parThingsInSaddleBag ?? new List<Drop>();
        }


        /// <summary>
        /// Положить предмет в седельную сумку
        /// </summary>
        /// <param name="parThing">Предмет</param>
        public void PutThingOnTheSaddleBag( Drop parThing )
        {
            SaddleBag.Append(parThing);
        }

        /// <summary>
        /// Достать предмет из седельной сумки
        /// </summary>
        /// <param name="parThing">Искомый предмет</param>
        /// <returns>Предмет, который искали, если нашли</returns>
        public Drop? GetThingFromTheSaddleBag( Drop parThing )
        {
            if (SaddleBag.Contains(parThing))
            {
                SaddleBag.Remove(parThing);
                return parThing;
            }
            return null;
        }

    }
}
