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

namespace Pandapark
{
    /// <summary>
    /// Interaction logic for AddAnimal.xaml
    /// </summary>
    public partial class AddMammal : Window
    {
        public AddMammal()
        {
            InitializeComponent();
        }

        private void AddMammal_Click(object sender, RoutedEventArgs e)
        {
            if (IsValidFields() && DatePickerBirth.SelectedDate != null)
            {
                // Maak zoogdier aan
                string dieet = ((ComboBoxItem)ComboBoxDiet.SelectedItem).Content.ToString();
                string geslacht = ((ComboBoxItem)ComboBoxGender.SelectedItem).Content.ToString();

                Mammal newMammal = new Mammal(TextBoxName.Text, TextBoxType.Text, 
                    CheckBoxDanger.IsChecked == true, dieet, geslacht, 
                    (DateTime)DatePickerBirth.SelectedDate, TextBoxCountry.Text);

                // Sla zoogdier op in csv
                SaveMammal(newMammal);

                // Maak de velden leeg
                ResetFields();
            }
        }

        private bool IsValidFields()
        {
            return
                !String.IsNullOrEmpty(TextBoxName.Text) &&
                !String.IsNullOrEmpty(TextBoxType.Text) &&
                ComboBoxDiet.SelectedIndex != -1 &&
                ComboBoxGender.SelectedIndex != -1 &&
                DatePickerBirth.SelectedDate != null &&
                !String.IsNullOrEmpty(TextBoxCountry.Text);
        }

        private void SaveMammal(Mammal mammal)
        {
            using (FileStream fs = new FileStream(Settings.AnimalCSV, FileMode.Append))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(mammal.ToCSV());
                }
            }
        }

        private void ResetFields()
        {
            TextBoxName.Text = "";
            TextBoxType.Text = "";
            CheckBoxDanger.IsChecked = false;
            ComboBoxDiet.SelectedIndex = -1;
            ComboBoxGender.SelectedIndex = -1;
            DatePickerBirth.SelectedDate = null;
            TextBoxCountry.Text = "";
        }
    }
}
