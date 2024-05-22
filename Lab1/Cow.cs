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
        /// Максимальное количество молока в корове
        /// </summary>
        public const byte MAX_MILK_LITERS = 4;

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
            set => _litersOfMilk = value < 0 ? (byte)0 : value > MAX_MILK_LITERS ? MAX_MILK_LITERS : value;
        }


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parName">Имя животного</param>
        /// <param name="parLocation">Координаты животного</param>
        /// <param name="parHealth">Здоровье животного</param>
        /// <param name="parDrop">Предмет, который животное несет во рту</param>
        /// <param name="parAbleToSit">Возможность сидеть на животном</param>
        /// <param name="parMilkLiters">Наполненность коровы молоком</param>
        public Cow(string parName,
            Point parLocation,
            byte parHealth = MAX_HEALTH,
            Drop parDrop = Drop.None,
            bool parAbleToSit = IS_ABLE_TO_SIT,
            byte parMilkLiters = MAX_MILK_LITERS)
            : base(parName, parLocation, parHealth, parDrop, parAbleToSit)
        { 
            LitersOfMilk = parMilkLiters;
        }

        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public Cow() : base() { }

        /// <summary>
        /// Конструктор копирования
        /// </summary>
        /// <param name="parAnimal">Животное, которое копируется</param>
        public Cow(Cow parAnimal) : base(parAnimal)
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
            LitersOfMilk = ((Cow)parAnimal).LitersOfMilk;
        }

        /// <summary>
        /// Покормить корову
        /// </summary>
        /// <param name="parSatiety">Сытность еды</param>
        public override sealed void ToEat( byte parSatiety ) 
        { 
            base.ToEat(parSatiety);
            LitersOfMilk += parSatiety;
        }

        /// <summary>
        /// Подоить корову
        /// </summary>
        /// <returns>Количество литров молока</returns>
        public byte ToMilk()
        {
            if (LitersOfMilk > 0)
            {
                byte milking = LitersOfMilk;
                LitersOfMilk = 0;
                return milking;
            }
            return 0;
        }
    }
}
