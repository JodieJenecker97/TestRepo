using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparLoadingDocks
{
    class Bay
    {
        public string Name;
        public double MaxCapacity;
        public double currentLoad;
        public double AvailableCapacity;
        //public string name2;

        public Bay(string N, double Cap)
        {
            Name = N;
            MaxCapacity = Cap;
            AvailableCapacity = MaxCapacity;
            currentLoad = 0;
        }
        public void displayBay(Bay cur)
        {
            Console.WriteLine("{0}, MaxCapacity: {1}, AvailableCapacity: {2}", cur.Name, cur.MaxCapacity, AvailableCapacity);
        }
        public void subtractcapacity(double weight)
        {
            this.AvailableCapacity = AvailableCapacity - weight;
        }
    }
}

