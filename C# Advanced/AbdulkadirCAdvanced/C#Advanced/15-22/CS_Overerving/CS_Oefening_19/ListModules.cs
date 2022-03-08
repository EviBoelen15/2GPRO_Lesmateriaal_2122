using System;
using System.Linq;
using System.Collections.Generic; // Om aan List<T> te geraken

using System.Windows.Controls; // Om aan ListBox te kunnen geraken

namespace CS_Oefening_19
{
    class ListModules : Modules<string> // Hier werken we niet meer met T, maar concreet met string
    {
        private List<string> lijst;
        private ListBox listBox;

        // Geef de ListBox gebruikt in WPF door aan deze class
        // via de constructor
        public ListModules(ListBox listBox)
        {
            this.listBox = listBox;
            // ListBox omzetten naar List<string>
            // Dit is een korte manier via LINQ (using System.Linq).
            // We casten eerst elk item van de ListBox naar een ListBoxItem.
            // Daarna selecteren we elk item en zetten we de content daarvan om naar een string.
            // Het gehele resultaat zetten we dan om naar een List via ToList().
            lijst = listBox.Items.Cast<ListBoxItem>().Select(i => i.Content.ToString()).ToList();

            // De langere manier via gewone C#:
            /*
            lijst = new List<string>(listBox.Items.Count); // pre-alloceer List met dezelfde grootte als ListBox
            for (int i = 0; i < listBox.Items.Count; i++)
            {
                lijst.Add(((ListBoxItem)listBox.Items[i]).Content.ToString());
            }
            */
        }

        public List<string> Inhoud => lijst;

        public void Add(string item)
        {
            lijst.Add(item);
            listBox.Items.Add(item);
        }

        public int IndexOf(string item) => lijst.IndexOf(item);

        public bool Remove(string item)
        {
            int index = IndexOf(item);
            if (index == -1)
                return false;
            
            RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            lijst.RemoveAt(index);
            listBox.Items.RemoveAt(index);
        }
    }
}
