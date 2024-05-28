using System.Collections.ObjectModel;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using KPO;
using System.Numerics;
using System.Runtime.Serialization;
using Lab4.EntitiesCreation;
using Lab4.FactoriesCreation;

namespace Lab3
{
    /// <summary>
    /// Главное окно приложения
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Коллекция для хранения всех созданных животных
        /// </summary>
        public ObservableCollection<Animal> Animals { get; set; }

        public ObservableCollection<IAnimalFactory> Factories { get; set; }

        public WolfAndHorseFactoryMethod WolfAndHorseFactoryMethod { get; set; }

        public DolphinAndCowFactoryMethod DolphinAndCowFactoryMethod { get; set; }

        public PrototypeAnimalFactoryMethod PrototypeAnimalFactoryMethod { get; set; }



        /// <summary>
        /// Конструктор формы
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Animals = new ObservableCollection<Animal>();
            InitializeFactories();
            DataContext = this;
        }

        private void InitializeFactories()
        {
            Factories = new ObservableCollection<IAnimalFactory>();
            WolfAndHorseFactoryMethod = new WolfAndHorseFactoryMethod();
            DolphinAndCowFactoryMethod = new DolphinAndCowFactoryMethod();

            NeutralAnimal neutralAnimalPrototype = new NeutralAnimal();
            FriendlyAnimal friendlyAnimalPrototype = new FriendlyAnimal();

            new AnimalForm(neutralAnimalPrototype, AnimalFormRegime.PrototypeCreating).ShowDialog();
            new AnimalForm(friendlyAnimalPrototype, AnimalFormRegime.PrototypeCreating).ShowDialog();
            PrototypeAnimalFactoryMethod = new PrototypeAnimalFactoryMethod(neutralAnimalPrototype, friendlyAnimalPrototype);
       
            Factories.Add(WolfAndHorseFactoryMethod.CreateAnimalFactory());
            Factories.Add(DolphinAndCowFactoryMethod.CreateAnimalFactory());
            Factories.Add(PrototypeAnimalFactoryMethod.CreateAnimalFactory());

        }
        private void ButtonAddFriendlyAnimal_Click(object sender, RoutedEventArgs e)
        {
            FriendlyAnimal friendlyAnimal = ((IAnimalFactory)ComboBoxFactories.SelectedItem).CreateFriendlyAnimal();
            if (new AnimalForm(friendlyAnimal, AnimalFormRegime.Add).ShowDialog() == true)
                Animals.Add(friendlyAnimal);
        }

        private void ButtonAddNeutralAnimal_Click(object sender, RoutedEventArgs e)
        {
            NeutralAnimal neutralAnimal = ((IAnimalFactory)ComboBoxFactories.SelectedItem).CreateNeutralAnimal();
            if (new AnimalForm(neutralAnimal, AnimalFormRegime.Add).ShowDialog() == true)
                Animals.Add(neutralAnimal);
        }

        /// <summary>
        /// Создать дельфина
        /// </summary>
        /// <param name="sender">Объект, инициировавший событие</param>
        /// <param name="e">Данные события, связанные с кликом</param>
        private void ButtonAddDolphin_Click(object sender, RoutedEventArgs e)
        {
            Dolphin dolphin = new Dolphin();
            if (new AnimalForm(dolphin, AnimalFormRegime.Add).ShowDialog() == true)
                Animals.Add(dolphin);
        }

        /// <summary>
        /// Создать корову
        /// </summary>
        /// <param name="sender">Объект, инициировавший событие</param>
        /// <param name="e">Данные события, связанные с кликом</param>
        private void ButtonAddCow_Click(object sender, RoutedEventArgs e)
        {
            Cow cow = new Cow();
            if (new AnimalForm(cow, AnimalFormRegime.Add).ShowDialog() == true)
                Animals.Add(cow);
        }

        /// <summary>
        /// Создать лошадь
        /// </summary>
        /// <param name="sender">Объект, инициировавший событие</param>
        /// <param name="e">Данные события, связанные с кликом</param>
        private void ButtonAddHourse_Click(object sender, RoutedEventArgs e)
        {
            Horse horse = new Horse();
            if (new AnimalForm(horse, AnimalFormRegime.Add).ShowDialog() == true)
                Animals.Add(horse);
        }

        /// <summary>
        /// Создать волка
        /// </summary>
        /// <param name="sender">Объект, инициировавший событие</param>
        /// <param name="e">Данные события, связанные с кликом</param>
        private void ButtonAddWolf_Click(object sender, RoutedEventArgs e)
        {
            Wolf wolf = new Wolf();
            if (new AnimalForm(wolf, AnimalFormRegime.Add).ShowDialog() == true)
                Animals.Add(wolf);
        }

        /// <summary>
        /// Удалить животное
        /// </summary>
        /// <param name="sender">Объект, инициировавший событие</param>
        /// <param name="e">Данные события, связанные с кликом</param>
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            Animal selectedAnimal = (Animal)GridAnimals.SelectedItem;
            if (selectedAnimal != null)
            {
                if (new AnimalForm(selectedAnimal, AnimalFormRegime.Delete).ShowDialog() == true)
                    Animals.Remove(selectedAnimal);
            }
        }

        /// <summary>
        /// Изменить животное
        /// </summary>
        /// <param name="sender">Объект, инициировавший событие</param>
        /// <param name="e">Данные события, связанные с кликом</param>
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            Animal selectedAnimal = (Animal)GridAnimals.SelectedItem;
            if (selectedAnimal != null)
            {
                Animal copiedAnimal;
                switch (selectedAnimal.GetType())
                {
                    case Type t when t == typeof(Cow): copiedAnimal = new Cow((Cow)selectedAnimal); break;
                    case Type t when t == typeof(Horse): copiedAnimal = new Horse((Horse)selectedAnimal); break;
                    case Type t when t == typeof(Wolf): copiedAnimal = new Wolf((Wolf)selectedAnimal); break;
                    case Type t when t == typeof(Dolphin): copiedAnimal = new Dolphin((Dolphin)selectedAnimal); break;
                    case Type t when t == typeof(NeutralAnimal): copiedAnimal = new NeutralAnimal((NeutralAnimal)selectedAnimal); break;
                    case Type t when t == typeof(FriendlyAnimal): copiedAnimal = new FriendlyAnimal((FriendlyAnimal)selectedAnimal); break;
                    default: copiedAnimal = null; break;
                }
                if (new AnimalForm(copiedAnimal, AnimalFormRegime.Edit).ShowDialog() == true)
                    selectedAnimal.Copy(copiedAnimal);
                    GridAnimals.Items.Refresh();
            }
        }

        /// <summary>
        /// Создание и добавление случайной коровы, лошади, волка и дельфина
        /// </summary>
        /// <param name="sender">Объект, инициировавший событие</param>
        /// <param name="e">Данные события, связанные с кликом</param>
        private void ButtonGenerateAnimals_Click(object sender, RoutedEventArgs e)
        {
            Animals.Add(AnimalGenerator.GenerateCow());
            Animals.Add(AnimalGenerator.GenerateHorse());
            Animals.Add(AnimalGenerator.GenerateWolf());
            Animals.Add(AnimalGenerator.GenerateDolphin());
            
        }

        /// <summary>
        /// Изменение выбора в animalsGrid. При невыбранном элементе в таблице кнопки "удалить" и "изменить" блокируются.
        /// </summary>
        /// <param name="sender">Объект, инициировавший событие</param>
        /// <param name="e">Данные события, связанные с изменением выделения</param>
        private void animalsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool itemSelected = GridAnimals.SelectedItem != null;
            ButtonEdit.IsEnabled = itemSelected;
            ContextButtonEdit.IsEnabled = itemSelected;
            ButtonDelete.IsEnabled = itemSelected;
            ContextButtonDelete.IsEnabled = itemSelected;
        }

    }
}