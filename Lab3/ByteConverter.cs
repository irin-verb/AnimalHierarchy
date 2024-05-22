using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace Lab3
{
    /// <summary>
    /// Конвертер типа byte в строковое представление и обратно
    /// </summary>
    public class ByteConverter : IValueConverter
    {
        /// <summary>
        /// Преобразует число в строковое представление
        /// </summary>
        /// <param name="value">Преобразуемое число</param>
        /// <param name="targetType">Тип данных, в который необходимо преобразовать число</param>
        /// <param name="parameter">Дополнительные параметры для преобразования</param>
        /// <param name="culture">Информация, которая используется для форматирования</param>
        /// <returns>Строковое представление числа при успешном преобразовании - иначе DependencyProperty.UnsetValue</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is byte health)
            {
                return health.ToString();
            }
            return DependencyProperty.UnsetValue;
        }

        /// <summary>
        /// Преобразует строковое представление числа в число byte
        /// </summary>
        /// <param name="value">Преобразуемая строка</param>
        /// <param name="targetType">Тип данных, к которому необходимо преобразовать строку</param>
        /// <param name="parameter">Дополнительные параметры для преобразования</param>
        /// <param name="culture">Информация, которая используется для форматирования</param>
        /// <returns>Полученное число byte при успешном преобразовании - иначе DependencyProperty.UnsetValue</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string stringValue && byte.TryParse(stringValue, out byte health))
            {
                return health;
            }
            return DependencyProperty.UnsetValue;
        }
    }

}
