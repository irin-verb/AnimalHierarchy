
using System.ComponentModel;

namespace KPO
{
    /// <summary>
    /// Виды предметов
    /// </summary>
    public enum Drop
    {
        /// <summary>
        /// Ничего
        /// </summary>
        [Description("Ничего")] None,
        /// <summary>
        /// Пшеница
        /// </summary>
        [Description("Пшеница")] Wheat,
        /// <summary>
        /// Треска
        /// </summary>
        [Description("Треска")] Codfish,
        /// <summary>
        /// Трава
        /// </summary>
        [Description("Трава")] Herb,
        /// <summary>
        /// Сено
        /// </summary>
        [Description("Сено")] Hay,
        /// <summary>
        /// Листья
        /// </summary>
        [Description("Листья")] Leaves,
        /// <summary>
        /// Водоросли
        /// </summary>
        [Description("Водоросли")] Seaweed,
        /// <summary>
        /// Мясо
        /// </summary>
        [Description("Мясо")] Meat,
        /// <summary>
        /// Кость
        /// </summary>
        [Description("Кость")] Bone
    }
}
