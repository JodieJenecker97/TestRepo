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
        Bay[] BayList;          
        ArrayList LoadArrList = new ArrayList();
         
        public Docks()
        {
           
           
        }

        public void AllocateLoads(ref Bay[] BayList, ref ArrayList LoadArrList)
        {
            double sum = 0;
            int lastPoint = 0;
            if (BayList.Count() > LoadArrList.Count) // theres more Bays than loads
            {
                int i = 0;
                int p = 0;
                Bay curBay = (Bay)BayList[i];
                Load curLoad = (Load)LoadArrList[p];
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
                                if (i == LoadArrList.Count)
                                {
                                    Console.WriteLine("total loads is: {0}", sum);
                                    Console.WriteLine("End of List Loads");
                                    lastPoint = i;

                                    break;
                                }
                                curLoad = (Load)LoadArrList[i];
                            
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
                            if (p == BayList.Count() )
                            {
                                Console.WriteLine("No more bays left, we need more spcae/bays");
                                Console.WriteLine("the remaining loads is");
                                displayremainingLoads(LoadArrList, i);
                                break;

                            }
                            curBay = (Bay)BayList[p];
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
                for (int i = 0; i < BayList.Count(); i++)
                {

                    Bay curBay = (Bay)BayList[i];
                    Load curLoad = (Load)LoadArrList[p];
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
                    if (i == BayList.Count())
                    {
                        Console.WriteLine("End of bays, now for repeat");
                        i = 0;
                        break;
                    }
                }
            }

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


        static public void displayAllocatedLoads(ArrayList LoadList)
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
                    curLoad.DisplayAllocatedLoad();
                }
            }

        }


    }
}
