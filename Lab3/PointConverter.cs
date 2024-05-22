using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Data;
using System.Windows;

namespace Lab3
{
    /// <summary>
    /// Конвертер типа Point в строковое представление и обратно
    /// </summary>
    public class PointConverter : IValueConverter
    {
        /// <summary>
        /// Преобразует координаты в строковое представление
        /// </summary>
        /// <param name="value">Преобразуемые координаты</param>
        /// <param name="targetType">Тип данных, в который необходимо преобразовать координаты</param>
        /// <param name="parameter">Дополнительные параметры для преобразования</param>
        /// <param name="culture">Информация, которая используется для форматирования</param>
        /// <returns>Строковое представление координат при успешном преобразовании - иначе DependencyProperty.UnsetValue</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Point point)
            {
                return $"{point.X},{point.Y}";
            }
            return DependencyProperty.UnsetValue;
        }

        /// <summary>
        /// Преобразует строковое представление координат в координаты
        /// </summary>
        /// <param name="value">Преобразуемая строка</param>
        /// <param name="targetType">Тип данных, к которому необходимо преобразовать строку</param>
        /// <param name="parameter">Дополнительные параметры для преобразования</param>
        /// <param name="culture">Информация, которая используется для форматирования</param>
        /// <returns>Полученные координаты Point при успешном преобразовании - иначе DependencyProperty.UnsetValue</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string stringValue)
            {
                string[] parts = stringValue.Split(',');
                if (parts.Length == 2 && int.TryParse(parts[0], out int x) && int.TryParse(parts[1], out int y))
                {
                    return new Point(x, y);
                }
            }
            return DependencyProperty.UnsetValue;
        }
    }
}
