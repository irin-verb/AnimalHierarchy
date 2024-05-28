using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace KPO
{   
    /// <summary>
    /// Дельфин
    /// </summary>
    public class Dolphin: NeutralAnimal
    {
        /// <summary>
        /// Радиус плавания по кругу
        /// </summary>
        private const double CIRCULATION_RADIUS = 20;

        /// <summary>
        /// Расстояние, на которое переплывает дельфин за раз
        /// </summary>
        private const double CIRCULATION_STEP = 1;

        /// <summary>
        /// Вероятность случайно съесть рыбу при перемещении
        /// </summary>
        private const double CATCHING_FISH_PROBABILITY = 0.05;


        /// <summary>
        /// Координаты сокровища
        /// </summary>
        public Point TreasureLocation { get; set; } = new Point();


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parName">Имя животного</param>
        /// <param name="parHealth">Здоровье животного</param>
        /// <param name="parDrop">Предмет, который животное несет во рту</param>
        /// <param name="parLocation">Координаты животного</param>
        /// <param name="parBiteDamage">Сала укуса животного</param>
        /// <param name="parTreasureLocation">Координаты сокровища</param>
        public Dolphin(string parName,
            Point parLocation,
            Point parTreasureLocation,
            byte parHealth = MAX_HEALTH,
            Drop parDrop = Drop.None,
            byte parBiteDamage = MAX_BITE_DAMAGE)
            : base(parName, parLocation, parHealth, parDrop, parBiteDamage)
        {
            TreasureLocation = parTreasureLocation;
        }

        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public Dolphin() : base() { }

        /// <summary>
        /// Конструктор копирования
        /// </summary>
        /// <param name="parAnimal">Животное, которое копируется</param>
        public Dolphin(Dolphin parAnimal) : base(parAnimal)
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
            TreasureLocation = ((Dolphin)parAnimal).TreasureLocation;
        }

        /// <summary>
        /// Клонировать объект
        /// </summary>
        /// <returns>Клон объекта</returns>
        public override object Clone()
        {
            return new Dolphin(this);
        }

        /// <summary>
        /// Переплыть в место, ближайшее к окружности вокруг сокровища
        /// </summary>
        private void MoveToTheCircle()
        {
            // единичный вектор по направлению к сокровищу
            Vector vector = Location - TreasureLocation; 
            vector.Normalize();
            // ближайшая к окружности вокруг сокровища точка
            Point nearestPointOnCircle = TreasureLocation + vector * CIRCULATION_RADIUS;
            ToMove(nearestPointOnCircle);
        }

        /// <summary>
        /// Проплыть по окружности вокруг сокровища
        /// </summary>
        private void ToCirculate()
        {
            // единичный вектор по направлению к сокровищу
            Vector vector = Location - TreasureLocation;
            vector.Normalize();
            // угол между предыдущим вектором и осью X
            double angleAxisX = Vector.AngleBetween(new Vector(1, 0), vector);
            // угол, на который нужно проплыть дельфину по окружности,
            // чтобы преодолеть заданное расстояние CIRCULATION_STEP
            double clockwiseAngle 
                = angleAxisX - (CIRCULATION_STEP / CIRCULATION_RADIUS) * (180 / Math.PI);
            // точка на окружности, в которую нужно приплыть дельфину
            Point nextPointOnCircle = new(
                TreasureLocation.X + CIRCULATION_RADIUS * Math.Cos(clockwiseAngle * Math.PI / 180),
                TreasureLocation.Y + CIRCULATION_RADIUS * Math.Sin(clockwiseAngle * Math.PI / 180)
            );
            ToMove(nextPointOnCircle);
        }

        /// <summary>
        /// Кружить вокруг сокровища
        /// </summary>
        /// <returns>Случайно пойманный улов в ходе плавания</returns>
        public Drop? ToCirculateTreasure()
        {
            // если дельфин далеко от сокровища
            if ((Location - TreasureLocation).Length > CIRCULATION_RADIUS)
                MoveToTheCircle();
            else
                ToCirculate();
            // в пути дельфин мог наткнуться или не наткнуться на рыбу
            bool hasCatchedFish = new Random().NextDouble() <= CATCHING_FISH_PROBABILITY;
            if (hasCatchedFish) ToEat(BiteDamage);
            return hasCatchedFish ? Drop.Codfish : null;
        }

    }
}
