using KPO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab3
{
    public partial class AnimalForm : Window
    {

        /// <summary>
        /// Животное, для которого открыта форма
        /// </summary>
        public Animal CurrentAnimal { get; set; }

        /// <summary>
        /// Режим работы формы
        /// </summary>
        public AnimalFormRegime Regime { get; set; }


        /// <summary>
        /// Конструктор формы
        /// </summary>
        /// <param name="parAnimal">Животное, которое будет отображено</param>
        /// <param name="parRegime">Режим, в котором работает форма</param>
        public AnimalForm(Animal parAnimal, AnimalFormRegime parRegime)
        {
            InitializeComponent();
            CurrentAnimal = parAnimal;
            Regime = parRegime;
            DataContext = this;
            UpdateComponent();
        }


        /// <summary>
        /// Настройка элементов формы под заданный режим работы и класс животного
        /// </summary>
        private void UpdateComponent()
        {
            switch (CurrentAnimal.GetType())
            {
                case Type t when t == typeof(Cow): cowElements.Visibility = Visibility.Visible; break;
                case Type t when t == typeof(Horse): horseElements.Visibility = Visibility.Visible; break;
                case Type t when t == typeof(Wolf): wolfElements.Visibility = Visibility.Visible; break;
                case Type t when t == typeof(Dolphin): dolphinElements.Visibility = Visibility.Visible; break;
            }
            switch (Regime) 
            {
                case AnimalFormRegime.Add: acceptButton.Content = "Создать"; Title = "Создание"; break;
                case AnimalFormRegime.Edit: acceptButton.Content = "Изменить"; Title = "Изменение"; break;
                case AnimalFormRegime.Delete:
                    {
                        baseElements.IsEnabled = false;
                        additionalElements.IsEnabled = false;
                        acceptButton.Content = "Удалить";
                        Title = "Удаление";
                        break;
                    }   
            }
        }

        /// <summary>
        /// Контроль ввода для полей с координатами
        /// </summary>
        /// <param name="sender">Объект, инициировавший событие</param>
        /// <param name="e">Аргументы события, содержащие информацию о вводимом тексте</param>
        private void Coordinates_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Проверяем, является ли введенный символ цифрой, запятой или backspace
            if (!char.IsDigit(e.Text, 0) && e.Text != "," && e.Text != "-" && e.Text != "\b")
            {
                // Если символ не прошел проверку, отменяем его ввод
                e.Handled = true;
            }
        }

        /// <summary>
        /// Контроль ввода для полей с целыми положительными значениями
        /// </summary>
        /// <param name="sender">Объект, инициировавший событие</param>
        /// <param name="e">Аргументы события, содержащие информацию о вводимом тексте</param>
        private void PosInteger_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0) && e.Text != "\b")
            {
                // Если символ не прошел проверку, отменяем его ввод
                e.Handled = true;
            }
        }

        /// <summary>
        /// Отмена действия формы
        /// </summary>
        /// <param name="sender">Объект, инициировавший событие</param>
        /// <param name="e">Данные события, связанные с кликом</param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        /// <summary>
        /// Подтверждение действия формыф
        /// </summary>
        /// <param name="sender">Объект, инициировавший событие</param>
        /// <param name="e">Данные события, связанные с кликом</param>
        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            var byteConv = new ByteConverter();
            var pointConv = new PointConverter();

            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
                MessageBox.Show($"Имя - какой-то набор символов, а не пустая строка или пробелы", "У вас ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (byteConv.ConvertBack(healthTextBox.Text, typeof(byte), null, CultureInfo.InvariantCulture) == DependencyProperty.UnsetValue)
                MessageBox.Show($"Здоровье - это целое положительное число до {Animal.MAX_HEALTH}", "У вас ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (pointConv.ConvertBack(coordinatesTextBox.Text, typeof(Point), null, CultureInfo.InvariantCulture) == DependencyProperty.UnsetValue)
                MessageBox.Show("Координаты - это два целых числа, записанных через запятую (например, '100,-100')", "У вас ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                switch (CurrentAnimal.GetType())
                {
                    case Type t when t == typeof(Cow):
                        {
                            if (byteConv.ConvertBack(happinessTextBox.Text, typeof(byte), null, CultureInfo.InvariantCulture) == DependencyProperty.UnsetValue)
                                MessageBox.Show($"Счастье - это целое положительное число до 255", "У вас ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                            else if (byteConv.ConvertBack(milkTextBox.Text, typeof(byte), null, CultureInfo.InvariantCulture) == DependencyProperty.UnsetValue)
                                MessageBox.Show($"Молоко - это целое положительное число до {Cow.MAX_MILK_LITERS}", "У вас ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                            else {
                                this.DialogResult = true;
                                this.Close();
                            }
                            break;
                        }
                    case Type t when t == typeof(Horse):
                        {
                            if (byteConv.ConvertBack(happynessTextBox.Text, typeof(byte), null, CultureInfo.InvariantCulture) == DependencyProperty.UnsetValue)
                                MessageBox.Show($"Счастье - это целое положительное число до 255", "У вас ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                            else
                            {
                                this.DialogResult = true;
                                this.Close();
                            }
                            break; 
                        }
                    case Type t when t == typeof(Wolf):
                        {
                            if (string.IsNullOrWhiteSpace(ownerNameTextBox.Text))
                                MessageBox.Show($"Имя хозина - какой-то набор символов, а не пустая строка или пробелы", "У вас ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                            else if (byteConv.ConvertBack(biteDamageTextBox.Text, typeof(byte), null, CultureInfo.InvariantCulture) == DependencyProperty.UnsetValue)
                                MessageBox.Show($"Сила укуса - это целое положительное число до {NeutralAnimal.MAX_BITE_DAMAGE}", "У вас ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                            else
                            {
                                this.DialogResult = true;
                                this.Close();
                            }
                            break;
                        }
                    case Type t when t == typeof(Dolphin):
                        {
                            if (pointConv.ConvertBack(treasureCoordinatesTextBox.Text, typeof(Point), null, CultureInfo.InvariantCulture) == DependencyProperty.UnsetValue)
                                MessageBox.Show("Координаты - это два целых числа, записанных через запятую (например, '100,-100')", "У вас ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                            else if (byteConv.ConvertBack(byteDamageTextBox.Text, typeof(byte), null, CultureInfo.InvariantCulture) == DependencyProperty.UnsetValue)
                                MessageBox.Show($"Сила укуса - это целое положительное число до {NeutralAnimal.MAX_BITE_DAMAGE}", "У вас ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                            else
                            {
                                this.DialogResult = true;
                                this.Close();
                            }
                            break;
                        }
                }
            }
        }

    }
}
