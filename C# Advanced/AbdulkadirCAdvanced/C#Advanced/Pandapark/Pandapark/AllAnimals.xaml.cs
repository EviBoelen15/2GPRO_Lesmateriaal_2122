using System;
using System.Collections.Generic;
using System.IO;
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
using System.Linq;

namespace Pandapark
{
    /// <summary>
    /// Interaction logic for AllAnimals.xaml
    /// </summary>
    public partial class AllAnimals : Window
    {
        private List<Animal> animals;

        public AllAnimals(List<Animal> animals)
        {
            InitializeComponent();

            this.animals = animals;

            AnimalGrid.ItemsSource = animals;
        }

        private void TextBoxFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(TextBoxFilter.Text))
            {
                AnimalGrid.ItemsSource = animals;
            }
            else
            {
                string filter = TextBoxFilter.Text;
                List<Animal> filteredAnimals = (from animal in animals
                                                where
                                                    animal.Name.ToLower().Contains(filter.ToLower()) ||
                                                    animal.Type.ToLower().Contains(filter.ToLower()) ||
                                                    animal.Country.ToLower().Contains(filter.ToLower())
                                                select animal).ToList();
                AnimalGrid.ItemsSource = filteredAnimals;

            }
        }
    }
}
