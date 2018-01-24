using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparLoadingDocks
{
    class BayList
    {
        Bay[] ListOfBays;
        public BayList()
        {

             ListOfBays = new Bay[60];
        } 

        public void PopulateBays()
        {
            StreamReader Text = new StreamReader("BayArea.txt");
            int i = 0;
            while (!Text.EndOfStream)
            {
                string Item = Text.ReadLine();
                string[] data = Item.Split(',');
                string Name = data[0];
                double Capacity = double.Parse(data[1]);
                ListOfBays[i] = new Bay(Name, Capacity);
                i++;
            }
            Text.Close();

        }

        public void BubbleSortForBays(Bay[] List)
        {
            Console.WriteLine();
            Bay First, Second;

            for (int x = 1; x <= List.Count() - 1; x++)
            {
                for (int y = 1; y <= (List.Count() - x); y++)
                {
                    First = (Bay)List[y - 1];
                    Second = (Bay)List[y];
                    if (First.AvailableCapacity.CompareTo(Second.AvailableCapacity) > 0)
                    {
                        Swap(y, y - 1, List);
                    }
                }
            }
        }

        public void Swap(int a, int b, Bay[] List1)
        {
            Bay temp = List1[a];
            List1[a] = List1[b];
            List1[b] = temp;
        }

         public void displayBays()
        {
            if (ListOfBays == null)
            {
                Console.WriteLine("list of bays is empty");
                return;
            }
            for (int i = 0; i < ListOfBays.Length; i++)
            {
                Bay curbay = ListOfBays[i];
                curbay.displayBay(curbay);
            }
        }
    }

}
