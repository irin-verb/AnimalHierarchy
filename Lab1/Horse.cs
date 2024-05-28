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
        /// Седло
        /// </summary>
        public Saddle Saddle { get; set; }


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parName">Имя животного</param>
        /// <param name="parHealth">Здоровье животного</param>
        /// <param name="parLocation">Координаты животного</param>
        /// <param name="parDrop">Предмет, который животное несет во рту</param>
        /// <param name="parAbleToSit">Возможность сидеть на животном</param>
        /// <param name="parSaddle">Вид седла на лошади</param>
        public Horse(string parName,
            Point parLocation,
            byte parHealth = MAX_HEALTH,
            Drop parDrop = Drop.None,
            bool parAbleToSit = IS_ABLE_TO_SIT,
            Saddle parSaddle = Saddle.None)
            : base(parName, parLocation, parHealth, parDrop, parAbleToSit)
        {
            Saddle = parSaddle;
        }

        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public Horse() : base() { }

        /// <summary>
        /// Конструктор копирования
        /// </summary>
        /// <param name="parAnimal">Животное, которое копируется</param>
        public Horse(Horse parAnimal) : base(parAnimal)
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
            Saddle = ((Horse)parAnimal).Saddle;
        }

        /// <summary>
        /// Клонировать объект
        /// </summary>
        /// <returns>Клон объекта</returns>
        public override object Clone()
        {
            return new Horse(this);
        }

        /// <summary>
        /// Попытка оседлать лошадь
        /// </summary>
        /// <returns>Успешность попытки</returns>
        public bool TryToRide()
        {
            switch (Saddle)
            {
                case Saddle.None: return false;
                case Saddle.Soft: return true;
                case Saddle.Hard: return (new Random()).Next(2) == 0;
                default: return true;
            }
        }

    }
}
