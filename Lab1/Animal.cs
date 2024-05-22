using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Windows;
using Vector = System.Windows.Vector;

namespace KPO
{
    /// <summary>
    /// Животное, вдохновленное Майнкрафтом :)
    /// </summary>
    public class Animal
    {
        /// <summary>
        /// Максимальное здоровье животного
        /// </summary>
        public const byte MAX_HEALTH = 20;


        /// <summary>
        /// Текущий свободный идентификатор для следующего создаваемого животного
        /// </summary>
        private static BigInteger _currentId = 0;

        /// <summary>
        /// Шкала здоровья животного
        /// </summary>
        private byte _health;


        /// <summary>
        /// Идентификатор
        /// </summary>
        public BigInteger ID { get; private set; } = _currentId;

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// Координаты
        /// </summary>
        public Point Location { get; set; }

        /// <summary>
        /// Шкала здоровья животного от 0
        /// </summary>
        public byte Health
        {
            get => _health;
            set => _health = value < 0 ? (byte)0 : value > MAX_HEALTH ? MAX_HEALTH : value;
        }

        /// <summary>
        /// Предмет, который животное несет во рту
        /// </summary>
        public Drop Drop { get; set; }


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parName">Имя животного</param>
        /// <param name="parHealth">Здоровье животного</param>
        /// <param name="parLocation">Координаты животного</param>
        /// <param name="parDrop">Предмет, который животное несет во рту</param>
        public Animal( string parName, Point parLocation, byte parHealth = MAX_HEALTH, Drop parDrop = Drop.None)
        {
            _currentId++;
            Name = parName;
            Health = parHealth;
            Location = parLocation;
            Drop = parDrop;
        }

        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public Animal()
        {
            _currentId++;
        }

        /// <summary>
        /// Конструктор копирования
        /// </summary>
        /// <param name="parAnimal">Животное, которое копируется</param>
        public Animal(Animal parAnimal)
        {
            Copy(parAnimal);
        }


        /// <summary>
        /// Копировать параметры животного
        /// </summary>
        /// <param name="parAnimal">Животного, параметры которого копируются</param>
        public virtual void Copy(Animal parAnimal)
        {
            ID = parAnimal.ID;
            Name = parAnimal.Name;
            Location = parAnimal.Location;
            Health = parAnimal.Health;
            Drop = parAnimal.Drop;
        }
    
        /// <summary>
        /// Смерть животного
        /// </summary>
        /// <returns>Предмет, которое животное несло во рту</returns>
        private Drop ToDie() 
        {
            return (new Random()).Next(2) == 0 ? Drop.None : Drop;
        }

        /// <summary>
        /// Поранить животное
        /// </summary>
        /// <param name="parDamage">Урон</param>
        /// <returns>Предмет, которое животное несло во рту (в случае смерти)</returns>
        public Drop ToDamage( byte parDamage ) 
        {
            Health -= parDamage;
            return Health > 0 ? Drop.None : ToDie();
        }

        /// <summary>
        /// Покормить животное
        /// </summary>
        /// <param name="parSatiety">Сытность еды</param>
        public virtual void ToEat( byte parSatiety ) 
        {
            Health += parSatiety;
        }
        
        /// <summary>
        /// Переместить животное
        /// </summary>
        /// <param name="parVector">Вектор перемещения</param>
        public void ToMove( Vector parVector )
        {
            Location += parVector;
        }
        
        /// <summary>
        /// Переместить животное
        /// </summary>
        /// <param name="point">Конечная точка, в которую перемещаем</param>
        public void ToMove( Point point )
        {
            ToMove(Location - point);
        }

    }
}
