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
        private const bool IS_ABLE_TO_SIT = false;


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
            private set => _happiness = value < 0 ? (byte)0: value > 255 ? (byte)255 : value; 
        }

        /// <summary>
        /// Возможность сидеть на животном
        /// </summary>
        public bool IsAbleToSit { get; private set; }


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parName">Имя животного</param>
        /// <param name="parLocation">Координаты животного</param>
        /// <param name="parMaxHealth">Максимальное здоровье животного</param>
        /// <param name="parDrops">Словарь выпадающих с животного предметов</param>
        /// <param name="parAbleToSit">Возможность сидеть на животном</param>
        public FriendlyAnimal(string parName, Point parLocation, byte parMaxHealth, Dictionary<Drop, byte> parDrops = null, bool parAbleToSit = IS_ABLE_TO_SIT)
            : base(parName, parLocation, parDrops ?? new Dictionary<Drop, byte>(), parMaxHealth)
        {
            IsAbleToSit = parAbleToSit;
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
    }
}
