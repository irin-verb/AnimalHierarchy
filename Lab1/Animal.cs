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
        public BigInteger ID { get; } = _currentId;

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Координаты
        /// </summary>
        public Point Location { get; private set; }

        /// <summary>
        /// Максимальное значение шкалы здоровья животного
        /// </summary>
        public byte MaxHealth { get; private set; }

        /// <summary>
        /// Шкала здоровья животного от 0 до MaxHealth
        /// </summary>
        public byte Health
        {
            get => _health;
            private set => _health = value < 0 ? (byte)0 : value > MaxHealth ? MaxHealth : value;
        }

        /// <summary>
        /// Словарь предметов, выпадающих с животного, и соответствующих им вероятностей выпадения
        /// </summary>
        public Dictionary<Drop,byte> Drops { get; private set; }


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parName">Имя животного</param>
        /// <param name="parMaxHealth">Максимальное здоровье животного</param>
        /// <param name="parLocation">Координаты животного</param>
        /// <param name="parDrops">Словарь выпадающих с животного предметов</param>
        public Animal( string parName, Point parLocation, Dictionary<Drop, byte> parDrops, byte parMaxHealth)
        {
            _currentId++;
            Name = parName;
            MaxHealth = (byte)Math.Abs(parMaxHealth);
            Health = MaxHealth;
            Location = parLocation;
            Drops = parDrops;
        }

    
        /// <summary>
        /// Смерть животного
        /// </summary>
        /// <returns>Случайный выпадающий предмет</returns>
        private Drop? ToDie() 
        {
            int probability = new Random().Next(Drops.Values.Max());
            int totalProbability = 0;
            foreach (var elIDrop in Drops)
            {
                totalProbability += elIDrop.Value;
                if (probability < totalProbability)
                {
                    return elIDrop.Key;
                }
            }
            return null;
        }

        /// <summary>
        /// Поранить животное
        /// </summary>
        /// <param name="parDamage">Урон</param>
        /// <returns>Случайный выпадаемый предмет в случае смерти</returns>
        public Drop? ToDamage( byte parDamage ) 
        {
            Health -= parDamage;
            return Health > 0 ? null : ToDie();
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
