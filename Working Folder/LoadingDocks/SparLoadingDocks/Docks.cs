using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom;
using System.Collections;
//testing repository
namespace SparLoadingDocks
{
    class Docks
    {
        BayList ListOfBays;
        LoadList ListOfLoads;

        public Docks()
        {

            ListOfBays = new BayList();

        }

        public void DisplayBays()
        {

            ListOfBays.displayBays();
        }

        public void LoadInformation()
        {

            ListOfLoads = new LoadList();
        }

        public void DisplayLoads()
        {

            ListOfLoads.displayLoads();
        }

        public void DisplaySorted()
        {

            ListOfBays.DisplaySorted();
        }

        public void AllocateLoads()
        {
            double sum = 0;
            int lastPoint = 0;
            if (60 > ListOfLoads.Count()) // theres more Bays than loads // Bays size is 60
            {
                int i = 0;
                int p = 0;
                Bay curBay = ListOfBays.CurrentBay(i);
                Load curLoad = ListOfLoads.CurrentLoad(p);
                while (curLoad.weight > 0) // This allows the weight of a single load to continuosly decrease until the whole load has been allocated to a bay
                {
                    while (curBay.AvailableCapacity > 0) // if there is  space in bay
                    {
                        while (curLoad.weight > 0)
                        {
                            sum += curLoad.weight;
                            if (curBay.AvailableCapacity >= curLoad.weight) // there is enough space in bay to accomadate a whole load
                            {
                                Console.WriteLine("Allocate {0} loads from {1} to Bay {2}", curLoad.weight, curLoad.Name, curBay.Name);

                                curBay.subtractcapacity(curLoad.weight);
                                curLoad.SubTractLoad(curLoad.weight);
                                curLoad.Bay = curLoad.Bay + " " + curBay.Name;
                                if (curLoad.weight == 0)
                                {
                                    i++;

                                }
                                if (i == ListOfLoads.Count())
                                {
                                    Console.WriteLine("total loads is: {0}", sum);
                                    Console.WriteLine("End of List Loads");
                                    lastPoint = i;

                                    break;
                                }
                                curLoad = ListOfLoads.CurrentLoad(i);

                            }
                            else // if there is not enough space in bay
                            {
                                double diff = curLoad.weight - curBay.AvailableCapacity;

                                Console.WriteLine("Allocate {0} loads from {1} to Bay {2}", curBay.AvailableCapacity, curLoad.Name, curBay.Name);
                                //sum += curLoad.weight;
                                curLoad.SubTractLoad(curBay.AvailableCapacity);
                                curBay.subtractcapacity(curBay.AvailableCapacity);
                                curLoad.Bay = curLoad.Bay + " " + curBay.Name;
                                if (curBay.AvailableCapacity == 0)
                                {
                                    p++;

                                }// availabe capacity of bay is 0
                                if (p == 60)
                                {
                                    Console.WriteLine("No more bays left, we need more spcae/bays");
                                    Console.WriteLine("the remaining loads is");
                                    //displayremainingLoads(LoadArrList, i);
                                    break;

                                }
                                curBay = ListOfBays.CurrentBay(p);
                            }
                        }
                        break;
                    }
                    break;
                }

            }
            else // There is more  (or just enough) Loads than Bays
            {
                int p = 0;
                for (int i = 0; i < 60; i++)
                {

                    Bay curBay = ListOfBays.CurrentBay(i);
                    Load curLoad = ListOfLoads.CurrentLoad(p);
                    p++;
                    //while (curLoad.weight > 0) // This allows the weight of a single load to continuosly decrease until the whole load has been allocated to a bay
                    //{
                    if (curBay.AvailableCapacity > 0) // if there is enough space in bay
                    {
                        if (curBay.AvailableCapacity >= curLoad.weight)
                        {
                            Console.WriteLine("Allocate {0} loads from {1} to {2}", curLoad.weight, curLoad.Name, curBay.Name);
                            curBay.subtractcapacity(curLoad.weight);
                            curLoad.Bay = curLoad.Bay + " " + curBay.Name;
                        }
                    }
                    else // if there is not enough space in bay
                    {
                        double diff = curLoad.weight - curBay.AvailableCapacity;
                        Console.WriteLine("Allocate {0} loads from {2} to {1}", diff, curBay.Name, curLoad.Name);
                        curLoad.SubTractLoad(diff);
                        curLoad.Bay = curLoad.Bay + " " + curBay.Name;
                    }
                    //}
                    if (i == 60)
                    {
                        Console.WriteLine("End of bays, now for repeat");
                        i = 0;
                        break;
                    }
                }
            }

        }



        public void AllocateTry()
        {

            int i = ListOfLoads.Count();
            int p = 0;

            Bay curBay;
            while (p < i)
            {

                int k = 0;

                Load curLoad = ListOfLoads.CurrentLoad(p);
                bool empty = false;

                for (int j = 0; j < 60; j++)
                {
                    curBay = ListOfBays.CurrentBay(j);             //This goes through the entire Bay List and checks if there is a Bay with the same capacity as the Load//

                    if (curBay.AvailableCapacity >= curLoad.weight && (empty == false))
                    {
                        Console.WriteLine("Allocate {0} loads from {1} to Bay {2}", curLoad.weight, curLoad.Name, curBay.Name);
                        //I added this code () 1 line below
                        curBay.loadsInBAy.Add(curLoad.Name);

                        curBay.subtractcapacity(curLoad.weight);
                        curBay.currentLoad += curLoad.weight;
                        curLoad.SubTractLoad(curLoad.weight);
                        curLoad.Bay += " " + curBay.Name;
                        empty = true;
                        break;
                    }
                }


                if (!empty)                                         //If the Load is not empty then allocate the Load until it's empty (Split)
                {

                    while (curLoad.weight > 0)
                    {
                        curBay = ListOfBays.CurrentBay(k);
                        if ((curBay.AvailableCapacity > 0) && (curBay.AvailableCapacity < curLoad.weight))              //// If there is space in the Bay and the available capacity is less than weight (Not really split up yet)           
                        {
                            Console.WriteLine("Allocate {0} loads from {1} to Bay {2}", curBay.AvailableCapacity, curLoad.Name, curBay.Name);
                            //I added this code () 1 line below
                            curBay.loadsInBAy.Add(curLoad.Name);


                            curLoad.SubTractLoad(curBay.AvailableCapacity);
                            curBay.subtractcapacity(curBay.AvailableCapacity);
                            curLoad.Bay += " " + curBay.Name;
                            //curBay.currentLoad += curLoad.weight;
                        }
                        else if (curBay.AvailableCapacity > curLoad.weight)                                             ///Checks if Load is less than Bay (For smaller splits)
                        {
                            Console.WriteLine("Allocate {0} loads from {1} to Bay {2}", curLoad.weight, curLoad.Name, curBay.Name);                     
                            //I added this code () 1 line below
                            curBay.loadsInBAy.Add(curLoad.Name);



                            curBay.subtractcapacity(curLoad.weight);
                            curLoad.SubTractLoad(curLoad.weight);
                            //curBay.currentLoad += curLoad.weight;
                            curLoad.Bay += " " + curBay.Name;
                        }

                        k++;
                    }
                }

                p++;
            }
            ListOfLoads.displayAllocatedLoads();

        }


        public void displayremainingLoads(ArrayList LoadList, int StartPoint)
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
                for (int i = StartPoint; i < LoadList.Count; i++)
                {
                    Load curLoad = (Load)LoadList[i];
                    curLoad.displayLoad();
                }
            }

        }


        public Bay[] Test()
        {
            ArrayList LList = ListOfLoads.getLL();
            Bay[] BL = ListOfBays.getBL(); 
            if (LList == null)
            {
                Console.WriteLine("List is empty");
            }
            for (int i = 1; i < LList.Count; i++)
            {
                Load prevLoad = (Load)LList[0];
                String prevLoadBayName = prevLoad.Bay; ;
                for (int g = i; g < LList.Count; g++)
                {
                    Load curLoad = ((Load)LList[g]);
                    if (!(prevLoadBayName).Equals((curLoad).Bay) && (curLoad.Added = false))
                    {
                        int h = 0;
                        while (!(BL[h].Name).Equals(prevLoadBayName))
                        {
                            h++;
                        }
                        Bay curBay = (Bay)BL[h];
                        curBay.loadsInBAy.Add(curLoad);
                        curLoad.Added = true;
                    }
                }
            }
            return BL;
        }
    }
}
