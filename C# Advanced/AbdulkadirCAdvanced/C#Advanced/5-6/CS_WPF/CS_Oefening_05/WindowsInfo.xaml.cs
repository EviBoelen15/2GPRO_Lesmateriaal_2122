using System;
using System.Collections.Generic;
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

using System.Reflection;
using System.Diagnostics;

using System.IO;

namespace CS_Oefening_05
{
    /// <summary>
    /// Interaction logic for WindowsInfo.xaml
    /// </summary>
    public partial class WindowsInfo : Window
    {
        public WindowsInfo()
        {
            InitializeComponent();
            
            // doe eerst using System.Reflection; bovenaan (info over de code van het programma)
            // en using System.Diagnostics; om aan de FileVersionInfo te geraken
            
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            
            TextBlockVersion.Text += $" {fvi.ProductVersion}";
            TextBlockProductname.Text += $" {fvi.ProductName}";
            TextBlockCompanyname.Text += $" {fvi.CompanyName}";
            TextBlockCopyright.Text += $" {fvi.LegalCopyright}";
            TextBlockDescription.Text += $" {fvi.Comments}";
            
            // Je kan ook AssemblyInfo.cs inlezen via StreamReader en dan zelf gaan parsen...
            // Maar eigenlijk kan info over het eigen programma gemakkelijker via reflection.
            // https://nl.wikipedia.org/wiki/Reflectie_(informatica)
            // Dit is echter geen leerstof.

            //
            // Veel complexer is zelf gaan parsen...
            //
            /*
            FileInfo fi = new FileInfo(@"..\..\Properties\AssemblyInfo.cs");
            string startStuk = "[assembly: Assembly";
            int lengteStartStuk = startStuk.Length;


            if (fi.Exists)
            {
                using (StreamReader sr = fi.OpenText())
                {
                    while (!sr.EndOfStream)
                    {
                        string lijn = sr.ReadLine();
                        if (lijn.StartsWith(startStuk))
                        {
                            string str = lijn.Substring(lengteStartStuk);
                            string[] velden = str.Split('(');
                            string prop = velden[0];
                            string propWaarde = velden[1];
                            propWaarde = propWaarde.Remove(0, 1);
                            propWaarde = propWaarde.Remove(propWaarde.Length - 3, 3);

                            switch (prop)
                            {
                                case "Description":
                                    TextBlockDescription.Text += $" {propWaarde}";
                                    break;
                                case "Company":
                                    TextBlockCompanyname.Text += $" {propWaarde}";
                                    break;
                                case "Product":
                                    TextBlockProductname.Text += $" {propWaarde}";
                                    break;
                                case "Copyright":
                                    TextBlockCopyright.Text += $" {propWaarde}";
                                    break;
                                case "Version":
                                    TextBlockVersion.Text += $" {propWaarde}";
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
            */
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
