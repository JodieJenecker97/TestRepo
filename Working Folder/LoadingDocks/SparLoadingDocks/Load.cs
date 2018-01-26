using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparLoadingDocks
{
    class Load
    {

        public double weight;
        public string Name;
        public string Bay;
        public bool Added;

        public Load(double w, string N)
        {
            weight = w;
            Name = N;
            Bay = "";
            Added = false;

        }

        public void displayLoad()
        {
            Console.WriteLine("{0} weight is: {1} ", Name, weight);
        }

        public void DisplayAllocatedLoad()
        {

            Console.WriteLine("{0} is allocated to the following Bay/s : {1} ", Name, Bay);
        }
        public void SubTractLoad(double L)
        {
            this.weight = weight - L;
        }
    }
}

