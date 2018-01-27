using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SparLoadingDocks
{
    class Bay
    {
        public string Name;
        public double MaxCapacity;
        public double currentLoad;
        public double AvailableCapacity;
        public ArrayList loadsInBAy;



        //public string name2;

        public Bay(string N, double Cap)
        {
            Name = N;
            MaxCapacity = Cap;
            AvailableCapacity = MaxCapacity;
            currentLoad = 0;
            loadsInBAy = new ArrayList();
        }
        public void displayBay(Bay cur)
        {
            Console.WriteLine("{0}, MaxCapacity: {1}, AvailableCapacity: {2}", cur.Name, cur.MaxCapacity, AvailableCapacity);
        }
        public void subtractcapacity(double weight)
        {
            this.AvailableCapacity = AvailableCapacity - weight;
        }
        public void DisplayLoadsofABay()
        {
            Console.WriteLine("");
            Console.WriteLine("Bay {0} contains loads ",Name);
            ArrayList LIB = loadsInBAy;
            for (int i = 0; i < LIB.Count; i++)
            {
                String LoadName = (String)LIB[i];

                Console.WriteLine("{0} ", LoadName);
            }
        }      
    }
}

