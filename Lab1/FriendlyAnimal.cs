using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KPO
{
    /// <summary>
    /// Дружелюбное животное
    /// </summary>
    public class FriendlyAnimal : Animal
    {
        /// <summary>
        /// Возможность сидеть по умолчанию
        /// </summary>
        public const bool IS_ABLE_TO_SIT = true;


        /// <summary>
        /// Шкала счастья животного
        /// </summary>
        private byte _happiness = 0;


        /// <summary>
        /// Шкала счастья животного
        /// </summary>
        public byte Happyness 
        { 
            get => _happiness; 
            set => _happiness = value < 0 ? (byte)0: value > 255 ? (byte)255 : value; 
        }

        /// <summary>
        /// Возможность сидеть на животном
        /// </summary>
        public bool IsAbleToSit { get; set; }


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parName">Имя животного</param>
        /// <param name="parLocation">Координаты животного</param>
        /// <param name="parHealth">Здоровье животного</param>
        /// <param name="parDrop">Предмет, который животное несет во рту</param>
        /// <param name="parAbleToSit">Возможность сидеть на животном</param>
        public FriendlyAnimal(string parName, Point parLocation, byte parHealth = MAX_HEALTH, Drop parDrop = Drop.None, bool parAbleToSit = IS_ABLE_TO_SIT)
            : base(parName, parLocation, parHealth, parDrop)
        {
            IsAbleToSit = parAbleToSit;
        }

        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public FriendlyAnimal() : base() { }

        /// <summary>
        /// Конструктор копирования
        /// </summary>
        /// <param name="parAnimal">Животное, которое копируется</param>
        public FriendlyAnimal(FriendlyAnimal parAnimal) : base(parAnimal)
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
            Happyness = ((FriendlyAnimal)parAnimal).Happyness;
            IsAbleToSit = ((FriendlyAnimal)parAnimal).IsAbleToSit;
        }

        /// <summary>
        /// Погладить животное
        /// </summary>
        /// <returns>Количество сердечек (уровень счастья животного)</returns>
        public byte ToPet()
        {
            ++Happyness;
            return Happyness;
        }

        /// <summary>
        /// Клонировать объект
        /// </summary>
        /// <returns>Клон объекта</returns>
        public override object Clone()
        {
            return new FriendlyAnimal(this);
        }
    }
}
