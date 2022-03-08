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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pandapark
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Animal> animals = new List<Animal>();

        public MainWindow()
        {
            InitializeComponent();

            animals = ReadCSV();
        }

        #region Click_Handlers
        private void AllAnimals_Click(object sender, RoutedEventArgs e)
        {
            AllAnimals allAnimalsWindow = new AllAnimals(animals);
            allAnimalsWindow.ShowDialog();
        }

        private void AddMammal_Click(object sender, RoutedEventArgs e)
        {
            AddMammal addMammalWindow = new AddMammal();
            addMammalWindow.ShowDialog();
            animals = ReadCSV();
        }

        private void AddBird_Click(object sender, RoutedEventArgs e)
        {
            AddBird addBirdWindow = new AddBird();
            addBirdWindow.ShowDialog();
            animals = ReadCSV();
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            Help helpWindow = new Help();
            helpWindow.Show();
        }

        private void Zoek_Click(object sender, RoutedEventArgs e)
        {
            var animalsWithName = from animal in animals
                                  where animal.Name.ToLower().Contains(TextBoxZoek.Text.ToLower())
                                  select animal;
            if (animalsWithName.Count() > 0)
            {
                TextBlockBeschrijving.Text = DescribeAnimal(animalsWithName.First());
            }
        }
        #endregion

        private List<Animal> ReadCSV()
        {
            List<Animal> animalsFromCSV = new List<Animal>();

            using (StreamReader sr = new StreamReader(Settings.AnimalCSV))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (line.Split(';')[0].Equals("M"))
                    {
                        Animal animal = new Mammal(line);
                        animalsFromCSV.Add(animal);
                    }
                    else if (line.Split(';')[0].Equals("B"))
                    {
                        Animal animal = new Bird(line);
                        animalsFromCSV.Add(animal);
                    }

                }
            }

            return animalsFromCSV;
        }

        #region Animal_Description
        private string DescribeAnimal(Animal animal)
        {
            // Indien het een vogel is, dan moet de vleugelgrootte van de vogel vergeleken worden.
            if (animal is Bird)
            {
                Bird bird = (Bird)animal;

                string wingSpanDescription = DescribeBirdWingSpan(bird);
                
                return bird.Describe() + $" {wingSpanDescription}";
            }
            return animal.Describe();
        }

        private string DescribeBirdWingSpan(Bird bird)
        {
            var wingSpans = from a in animals 
                            where a is Bird 
                            select ((Bird)a).WingSpan;

            // Als de vleugels niet bijzonder zijn, dan worden ze niet extra beschreven.
            if (bird.WingSpan != wingSpans.Max() && bird.WingSpan != wingSpans.Min())
            {
                return "";
            }

            StringBuilder wingSpanDescription = new StringBuilder();
            wingSpanDescription.Append($" De vleugelspanwijdte van {bird.WingSpan} cm is de ");

            if (bird.WingSpan == wingSpans.Max())
            {
                wingSpanDescription.Append("grootste");
            }
            else if (bird.WingSpan == wingSpans.Min())
            {
                wingSpanDescription.Append("kleinste");
            }
            wingSpanDescription.Append(" spanwijdte in het park.");

            return wingSpanDescription.ToString();
        }
        #endregion
    }
}
