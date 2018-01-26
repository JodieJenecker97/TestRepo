using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace SparLoadingDocks
{/// <summary>
 /// ////////////
 /// </summary>
 /// 

    class Program
    {//Pre-condition: Have a list of loads, sorted in ascedind order of time; ie Ie the first load leaves the earliest. && Have a list of bays in my case stored as an array.
     //Psot Condition: display a how the loads have been allocated to the bays, in the most effecient manner. 
     [STAThread]
        static void Main(string[] args)
        { 
            Docks Dock = new Docks();
            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("INDICATE WHICH FUNCTIONALITY YOU WISH TO TEST");
                Console.WriteLine("1. Display list of Bays");
                Console.WriteLine("2. Enter Load Information");
                Console.WriteLine("3. Display Load Information");
                Console.WriteLine("4. Display sorted List of Bays");
                Console.WriteLine("5. Allocate and Display the Loads");
                Console.WriteLine("6. Remove A Load from a bay");
                Console.WriteLine("9. TERMINATE PROCESSING");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Dock.DisplayBays();
                        Console.WriteLine("Press enter to continue................");
                        Console.ReadLine();
                        break;
                    case 2:
                        // At this point we have a list of loads stored in an arraylist. Now its time to allocate the loads
                        Dock.LoadInformation();
                        Console.WriteLine("Press enter to continue................");
                        Console.ReadLine();
                        break;
                    case 3:
                        //Displays Loads
                        Dock.DisplayLoads();
                        Console.WriteLine("Press enter to continue................");
                        Console.ReadLine();
                        break;
                    case 4:
                        // At this point the List of bays is sorted in ascending order
                        Console.WriteLine("Sorted List of Bays");
                        Dock.DisplaySorted();
                        Console.WriteLine("Press enter to continue................");
                        Console.ReadLine();
                        break;
                    case 5:                   
                        //Display with Allocated Bays
                        Dock.AllocateTry();
                        Console.WriteLine("Sorted List of Loads");
                        Console.WriteLine("Press enter to continue................");
                        Console.ReadLine();
                        break;
                    case 6:
                        //Removes loads from a bay
                        Bay[] BL = Dock.Test();
                        for (int i = 0; i < BL.Count(); i++)
                        {
                            Bay curbay = (Bay)BL[i];
                            if (curbay.loadsInBAy.Count > 0)
                            {
                                curbay.DisplayLoadsofABay();
                            }
                           
                        }
                        Console.ReadLine();
                        break;
                    case 9: break;
                    default:
                        Console.WriteLine("Incorrect selection - press enter to continue");
                        Console.ReadLine();
                        break;
                }
            } while (choice != 9);
            Console.WriteLine("Processing terminated - press enter to continue");
            Console.ReadLine();
        }






        //static public void BubbleSortForLoads(ArrayList List)
        //{
        //    Load First, Second;

        //    for (int x = 1; x <= List.Count - 1; x++)
        //    {
        //        for (int y = 1; y <= (List.Count - x); y++)
        //        {
        //            First = (Load)List[y - 1];
        //            Second = (Load)List[y];


        //            if (First.weight - Second.weight > 0)
        //            {
        //                Swap(y, y - 1, List);
        //            }
        //        }
        //    }
        //}
        //static public void Swap(int a, int b, ArrayList List)
        //{
        //    Load temp = (Load)List[a];
        //    List[a] = List[b];
        //    List[b] = temp;
        //}
    }
}
