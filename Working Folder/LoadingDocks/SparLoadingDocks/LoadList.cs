using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparLoadingDocks
{
    class LoadList
    {
        ArrayList LList ;

        public LoadList()
        {
            LList = new ArrayList();

        }
        public ArrayList getListOfLoads()
        {
            ArrayList LoadList = new ArrayList();
            Console.WriteLine();
            Console.WriteLine("How many loads are there");
            int numOfLoads = int.Parse(Console.ReadLine());

            if (numOfLoads != 0)
            {

                CreatLoadnames(numOfLoads);
                StreamReader SR = new StreamReader("Loadnames.txt");
                Console.WriteLine("Enter loads");
                for (int i = 0; i < numOfLoads; i++)
                {
                    Console.Write("Load {0}: ", i + 1);
                    double w = double.Parse(Console.ReadLine());
                    string N = SR.ReadLine();
                    LoadList.Add(new Load(w, N));
                }
                SR.Close();
                return LoadList;
            }
            return null;
        }

         public void CreatLoadnames(int numOfLoads)
        {
            StreamWriter SW = new StreamWriter("Loadnames.txt");
            for (int i = 0; i < numOfLoads; i++)
            {
                SW.WriteLine("Load{0}", i + 1);
            }
            SW.Close();
        }

        public void totalWeightOfLoads(ArrayList L)
        {
            double S = 0;
            for (int i = 0; i < L.Count; i++)
            {
                Load curload = (Load)L[i];
                S += curload.weight;
            }
            Console.WriteLine("Total weight is {0}", S);
        }

        public void displayLoads()
        {
            Console.WriteLine();
            Console.Write("Displaying Loads");
            Console.WriteLine();
            if (LoadList == null)
            {
                Console.WriteLine("list is empty");
                return;
            }
            else
            {
                for (int i = 0; i < LoadList.Count; i++)
                {
                    Load curLoad = (Load)LoadList[i];
                    curLoad.displayLoad();
                }
            }

        }
    }
}
