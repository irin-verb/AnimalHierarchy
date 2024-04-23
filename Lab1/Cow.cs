using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KPO
{
    /// <summary>
    /// Корова
    /// </summary>
    public class Cow : FriendlyAnimal
    {
        /// <summary>
        /// Максимальное значение шкалы здоровья коровы
        /// </summary>
        private const byte MAX_HEALTH = 10;

        /// <summary>
        /// Возможность сидеть на корове
        /// </summary>
        private const bool IS_ABLE_TO_SIT = false;

        /// <summary>
        /// Максимальное количество молока в корове
        /// </summary>
        private const byte MAX_MILK_LITERS = 4;

        /// <summary>
        /// Словарь предметов, выпадающих с коровы, и соответствующих им вероятностей выпадения
        /// </summary>
        private static readonly Dictionary<Drop, byte> DefaultDrops
            = new Dictionary<Drop, byte>()
            {
                { Drop.Skin, 20 },
                { Drop.BeefMeat, 90 }
            };


        /// <summary>
        /// Шкала молока коровы
        /// </summary>
        private byte _litersOfMilk = 0;


        /// <summary>
        /// Шкала молока коровы от 0 до MAX_MILK_LITERS
        /// </summary>
        public byte LitersOfMilk
        {
            get => _litersOfMilk;
            private set => _litersOfMilk = value < 0 ? (byte)0 : value > MAX_MILK_LITERS ? MAX_MILK_LITERS : value;
        }


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parName">Имя животного</param>
        /// <param name="parLocation">Координаты животного</param>
        /// <param name="parMaxHealth">Максимальное здоровье животного</param>
        /// <param name="parDrops">Словарь выпадающих с животного предметов</param>
        /// <param name="parAbleToSit">Возможность сидеть на животном</param>
        /// <param name="parMilkLiters">Наполненность коровы молоком</param>
        public Cow(string parName,
            Point parLocation,
            byte parMaxHealth = MAX_HEALTH,
            Dictionary<Drop, byte> parDrops = null,
            bool parAbleToSit = IS_ABLE_TO_SIT,
            byte parMilkLiters = MAX_MILK_LITERS)
            : base(parName, parLocation, parMaxHealth, parDrops ?? DefaultDrops, parAbleToSit)
        { 
            LitersOfMilk = parMilkLiters;
        }


        /// <summary>
        /// Покормить корову
        /// </summary>
        /// <param name="parSatiety">Сытность еды</param>
        public override sealed void ToEat( byte parSatiety ) 
        { 
            base.ToEat(parSatiety);
            if (Health == MaxHealth) LitersOfMilk += parSatiety;
        }

        /// <summary>
        /// Подоить корову
        /// </summary>
        /// <returns>Количество литров молока</returns>
        public Tuple<Drop, byte>? ToMilk()
        {
            if (LitersOfMilk > 0)
            {
                Tuple<Drop, byte> milking = new(Drop.Skin, LitersOfMilk);
                LitersOfMilk = 0;
                return milking;
            }
            return null;
        }
    }
}
