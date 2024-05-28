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
    /// <summary>
    /// Окно работы с животным
    /// </summary>
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
            switch (CurrentAnimal)
            { 
                case NeutralAnimal _:
                    {
                        GridNeutralAnimalProperties.Visibility = Visibility.Visible;
                        if (CurrentAnimal is Wolf) GridWolfProperties.Visibility = Visibility.Visible;
                        if (CurrentAnimal is Dolphin) GridDolphinProperties.Visibility = Visibility.Visible;
                        break;
                    }
                    
                case FriendlyAnimal _:
                    {
                        GridFriendlyAnimalProperties.Visibility = Visibility.Visible;
                        if (CurrentAnimal is Cow) GridCowProperties.Visibility = Visibility.Visible;
                        if (CurrentAnimal is Horse) GridHorseProperties.Visibility = Visibility.Visible;
                        break;
                    }
            }
            switch (Regime) 
            {
                case AnimalFormRegime.Add: ButtonAccept.Content = "Создать"; Title = "Создание"; break;
                case AnimalFormRegime.Edit: ButtonAccept.Content = "Изменить"; Title = "Изменение"; break;
                case AnimalFormRegime.Delete:
                    {
                        GridAnimalProperties.IsEnabled = false;
                        GridNeutralAndFriendAnimalProperties.IsEnabled = false;
                        GridCowWolfHorseDolphinProperties.IsEnabled = false;
                        ButtonAccept.Content = "Удалить";
                        Title = "Удаление";
                        break;
                    }
                case AnimalFormRegime.PrototypeCreating:
                    {
                        ButtonCancel.IsEnabled = false;
                        ButtonAccept.Content = "Добавить прототип";
                        Title = "Создание прототипа";
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

            if (string.IsNullOrWhiteSpace(TextBoxName.Text))
                MessageBox.Show($"Имя - какой-то набор символов, а не пустая строка или пробелы", "У вас ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (byteConv.ConvertBack(TextBoxHealth.Text, typeof(byte), null, CultureInfo.InvariantCulture) == DependencyProperty.UnsetValue)
                MessageBox.Show($"Здоровье - это целое положительное число до {Animal.MAX_HEALTH}", "У вас ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (pointConv.ConvertBack(TextBoxCoordinates.Text, typeof(Point), null, CultureInfo.InvariantCulture) == DependencyProperty.UnsetValue)
                MessageBox.Show("Координаты - это два целых числа, записанных через запятую (например, '100,-100')", "У вас ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                switch (CurrentAnimal)
                {
                    case NeutralAnimal _:
                        {
                            if (byteConv.ConvertBack(TextBoxBiteDamage.Text, typeof(byte), null, CultureInfo.InvariantCulture) == DependencyProperty.UnsetValue)
                                MessageBox.Show($"Сила укуса - это целое положительное число до {NeutralAnimal.MAX_BITE_DAMAGE}", "У вас ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                            else if (CurrentAnimal is Wolf && string.IsNullOrWhiteSpace(TextBoxOwnerName.Text))
                                MessageBox.Show($"Имя хозина - какой-то набор символов, а не пустая строка или пробелы", "У вас ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                            else if (CurrentAnimal is Dolphin && pointConv.ConvertBack(TextBoxTreasureCoordinates.Text, typeof(Point), null, CultureInfo.InvariantCulture) == DependencyProperty.UnsetValue)
                                MessageBox.Show("Координаты - это два целых числа, записанных через запятую (например, '100,-100')", "У вас ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                            else
                            {
                                this.DialogResult = true;
                                this.Close();
                            }
                            break;
                        }
                    case FriendlyAnimal _:
                        {
                            if (byteConv.ConvertBack(TextBoxHappiness.Text, typeof(byte), null, CultureInfo.InvariantCulture) == DependencyProperty.UnsetValue)
                                MessageBox.Show($"Счастье - это целое положительное число до 255", "У вас ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                            else if (CurrentAnimal is Cow && byteConv.ConvertBack(TextBoxMilk.Text, typeof(byte), null, CultureInfo.InvariantCulture) == DependencyProperty.UnsetValue)
                                MessageBox.Show($"Молоко - это целое положительное число до {Cow.MAX_MILK_LITERS}", "У вас ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
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
