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
        /// Максимальная сила укуса животного
        /// </summary>
        public const byte MAX_BITE_DAMAGE = Animal.MAX_HEALTH;

        /// <summary>
        /// Сила укуса животного
        /// </summary>
        private byte _biteDamage = 0;

        /// <summary>
        /// Сила укуса животного
        /// </summary>
        public byte BiteDamage { 
            get => _biteDamage; 
            set => _biteDamage = value < 0 ? (byte)0 : value > MAX_BITE_DAMAGE ? MAX_BITE_DAMAGE : value;
        }


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parName">Имя животного</param>
        /// <param name="parLocation">Координаты животного</param>
        /// <param name="parBiteDamage">Сила укуса животного</param>
        /// <param name="parHealth">Здоровье животного</param>
        /// <param name="parDrop">Предмет, который животное несет во рту</param>
        public NeutralAnimal( string parName, Point parLocation, byte parHealth = MAX_HEALTH, Drop parDrop = Drop.None, byte parBiteDamage = MAX_BITE_DAMAGE)
            : base(parName, parLocation, parHealth, parDrop) 
        {
            BiteDamage = parBiteDamage;
        }

        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public NeutralAnimal() : base() { }

        /// <summary>
        /// Конструктор копирования
        /// </summary>
        /// <param name="parAnimal">Животное, которое копируется</param>
        public NeutralAnimal(NeutralAnimal parAnimal) : base(parAnimal)
        {
            Copy(parAnimal);
        }


        /// <summary>
        /// Копировать параметры животного
        /// </summary>
        /// <param name="parAnimal">Животного, параметры которого копируются</param>
        public override void Copy(Animal parAnimal)
        {
            base.Copy(parAnimal);
            BiteDamage = ((NeutralAnimal)parAnimal).BiteDamage;
        }

        /// <summary>
        /// Напасть животным
        /// </summary>
        /// <param name="parVictim">Животное-жертва, на которое нападают</param>
        /// <returns>Предмет, который жертва могла нести во рту</returns>
        public Drop ToAttack( Animal parVictim )
        {
            ToMove(parVictim.Location);
            ToEat(BiteDamage);
            return parVictim.ToDamage(BiteDamage);
        }

        /// <summary>
        /// Клонировать объект
        /// </summary>
        /// <returns>Клон объекта</returns>
        public override object Clone()
        {
            return new NeutralAnimal(this);
        }
    }
}
