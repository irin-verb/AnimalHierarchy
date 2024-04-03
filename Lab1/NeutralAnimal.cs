using System;
using System.Collections.Generic;
using System.Windows;

namespace KPO
{
    /// <summary>
    /// Нейтральное животное
    /// </summary>
    public class NeutralAnimal: Animal
    {
        /// <summary>
        /// Сила укуса по умолчанию
        /// </summary>
        private const byte BITE_DAMAGE = 1;


        /// <summary>
        /// Сила укуса животного
        /// </summary>
        public byte BiteDamage { get; private set; }


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parName">Имя животного</param>
        /// <param name="parMaxHealth">Максимальное здоровье животного</param>
        /// <param name="parLocation">Координаты животного</param>
        /// <param name="parBiteDamage">Сила укуса животного</param>
        /// <param name="parDrops">Словарь выпадающих с животного предметов</param>
        public NeutralAnimal( string parName, Point parLocation, byte parMaxHealth, Dictionary<Drop, byte> parDrops = null, byte parBiteDamage = BITE_DAMAGE)
            : base(parName, parLocation, parDrops ?? new Dictionary<Drop, byte>(), parMaxHealth) 
        {
            BiteDamage = (byte)Math.Abs(parBiteDamage);
        }


        /// <summary>
        /// Напасть животным
        /// </summary>
        /// <param name="parVictim">Животное-жертва, на которое нападают</param>
        /// <returns>Случайный выпадаемый с жертвы предмет</returns>
        public Drop? ToAttack( Animal parVictim )
        {
            ToMove(parVictim.Location);
            ToEat(BiteDamage);
            return parVictim.ToDamage(BiteDamage);
        }


    }
}
