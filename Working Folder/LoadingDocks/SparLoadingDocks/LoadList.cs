using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparLoadingDocks
{
    class LoadList
    {
        ArrayList LList;

        public LoadList()
        {
            LList = new ArrayList();
            getListOfLoads();
            totalWeightOfLoads();

        }

        private void getListOfLoads()
        {

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
                    LList.Add(new Load(w, N));
                }
                SR.Close();

            }

        }

        private void CreatLoadnames(int numOfLoads)
        {
            StreamWriter SW = new StreamWriter("Loadnames.txt");
            for (int i = 0; i < numOfLoads; i++)
            {
                SW.WriteLine("Load{0}", i + 1);
            }
            SW.Close();
        }

        private void totalWeightOfLoads()
        {
            double S = 0;
            for (int i = 0; i < LList.Count; i++)
            {
                Load curload = (Load)LList[i];
                S += curload.weight;
            }
            Console.WriteLine("Total weight is {0}", S);
        }

        public Load CurrentLoad(int p)
        {

            if (p > LList.Count)
            {
                return null;
            }
            else
            {
                return (Load)LList[p];
            }
        }

        public int Count()
        {

            return LList.Count;
        }

        public void displayLoads()
        {
            Console.WriteLine();
            Console.Write("Displaying Loads");
            Console.WriteLine();
            if (LList == null)
            {
                Console.WriteLine("list is empty");
                return;
            }
            else
            {
                for (int i = 0; i < LList.Count; i++)
                {
                    Load curLoad = (Load)LList[i];
                    curLoad.DisplayAllocatedLoad();
                }
            }

        }

        public void displayAllocatedLoads()
        {
            Console.WriteLine();
            Console.Write("Displaying Loads");
            Console.WriteLine();
            if (LList == null)
            {
                Console.WriteLine("list is empty");
                return;
            }
            else
            {
                for (int i = 0; i < LList.Count; i++)
                {
                    Load curLoad = (Load)LList[i];
                    curLoad.DisplayAllocatedLoad();
                }
            }

        }
        public ArrayList getLL()
        {
            return LList;
        }

       
    }
}
