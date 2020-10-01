using System;
using System.Collections.Generic;
using System.Threading;

namespace TjuvOchPolis
{
    class Program
    {
        static void Main(string[] args)
        {

            int xcounter = 1;
            int ycounter = 1;
            bool running = true;
            List<Person> peopleList = AmountOfPeople(10, 20, 30);
            int prisoneramount = 0;
            List<Person> Prison = new List<Person>();
            string print = "";
            int amountOfThefts = 0;
            int amountOfArrests = 0;
            bool pause = false;
            bool theft = false;
            bool arrest = false;
            int personOne = 0;
            while (running)
            {
                for (int y = 1; y <= 25; y++)
                {
                    for (int x = 1; x <= 100; x++)
                    {
                        for (int i = 0; i < peopleList.Count; i++)
                        {

                            if (xcounter == peopleList[i].XPostion && ycounter == peopleList[i].YPostion)
                            {
                                
                                if (print == "P" && peopleList[i].BokstavRepresentant == "T")
                                {
                                    

                                    print = "X";
                                    Inventory.Arrest(peopleList[personOne].Inventory, peopleList[i].Inventory);
                                    SendToPrison(peopleList, i, Prison);
                                    prisoneramount++;
                                    amountOfArrests++;
                                    pause = true;
                                    arrest = true;





                                }
                                else if (print == "T" && peopleList[i].BokstavRepresentant == "M")
                                {

                                    print = "X";

                                    Inventory.Steal(peopleList[personOne].Inventory, peopleList[i].Inventory);
                                    amountOfThefts++;
                                    theft = true;
                                    pause = true;
                                }
                                else if (print == "M" && peopleList[i].BokstavRepresentant == "T")
                                {

                                    print = "X";

                                    Inventory.Steal(peopleList[personOne].Inventory, peopleList[i].Inventory);
                                    amountOfThefts++;
                                    theft = true;
                                    pause = true;

                                }

                                else
                                {
                                    print = peopleList[i].BokstavRepresentant;


                                    personOne = i;


                                }


                            }




                        }
                        if (print == "")
                        {
                            Console.Write(" ");
                        }
                        Console.Write(print);
                        print = "";

                        xcounter++;
                        if (xcounter == 101)
                        {
                            xcounter = 1;
                        }
                    }
                    Console.WriteLine();
                    ycounter++;
                    if (ycounter == 26)
                    {
                        ycounter = 1;
                    }
                }
               
                if (theft == true)
                {
                    Console.WriteLine("Tjuv rånar medborgare");
                    theft = false;


                }
                if (arrest == true)
                {
                    Console.WriteLine("Polis tar tjuv");
                    arrest = false;
                }

                Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                Console.WriteLine($"Antal tjuvar i fängelse: {prisoneramount}");
                for (int j = 0; j < Prison.Count; j++)
                {
                    if (Prison[j].InPrison == true)
                    {
                        Prison[j].PrisonerTimer++;
                        Console.WriteLine($"Tjuv {j + 1}  har suttit i fängelse i {Prison[j].PrisonerTimer} sekunder.");

                        if (Prison[j].PrisonerTimer == 30)
                        {
                            pause = true;
                            Prison[j].InPrison = false;
                            Prison[j].PrisonerTimer = 0;
                            prisoneramount--;
                            peopleList.Add(Prison[j]);
                            Prison.RemoveAt(j);
                            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                            Console.WriteLine("En tjuv går fri från fängelset.");
                        }
                    }
                }
              

                Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                Console.WriteLine($"Antal rånade medborgare: {amountOfThefts}");
                Console.WriteLine($"Antal gripna tjuvar: {amountOfArrests}");

                if (pause == true)
                {
                    Thread.Sleep(2000);
                    pause = false;
                }
                Console.Clear();
                Move(peopleList);



            }


        }



        private static void Move(List<Person> listaAvFolk)
        {
            for (int i = 0; i < listaAvFolk.Count; i++)
            {
                listaAvFolk[i].XPostion += listaAvFolk[i].XTravel;
                listaAvFolk[i].YPostion += listaAvFolk[i].YTravel;
                if (listaAvFolk[i].XPostion > 100)
                {
                    listaAvFolk[i].XPostion = 1;
                }
                if (listaAvFolk[i].XPostion < 1)
                {
                    listaAvFolk[i].XPostion = 100;
                }
                if (listaAvFolk[i].YPostion > 25)
                {
                    listaAvFolk[i].YPostion = 1;
                }
                if (listaAvFolk[i].YPostion < 1)
                {
                    listaAvFolk[i].YPostion = 25;
                }
                if (listaAvFolk[i].XTravel == 0 && listaAvFolk[i].YTravel == 0)
                {
                    Random r = new Random();
                    listaAvFolk[i].YTravel = r.Next(-1, 1 + 1);
                    listaAvFolk[i].XTravel = r.Next(-1, 1 + 1);
                }
            }
        }

        public static List<Person> AmountOfPeople(int mängdAvPoliser, int mängdAvTjuvar, int mängdAvMedborgare)
        {
            Random random = new Random();
            List<Person> listOfPeople = new List<Person>();
            for (int i = 0; i < mängdAvPoliser; i++)
            {


                Polis polis = new Polis(random.Next(1, 100 + 1), random.Next(1, 25 + 1), random.Next(-1, 1 + 1), random.Next(-1, 1 + 1), "P", Beslagtaget.SkapaBeslagtaget());
                listOfPeople.Add(polis);
            }
            for (int i = 0; i < mängdAvTjuvar; i++)
            {
                Tjuv tjuv = new Tjuv(random.Next(1, 100 + 1), random.Next(1, 25 + 1), random.Next(-1, 1 + 1), random.Next(-1, 1 + 1), "T", Stöldgods.SkapaStöldgods(), false, 0);
                listOfPeople.Add(tjuv);
            }
            for (int i = 0; i < mängdAvMedborgare; i++)
            {
                Medborgare medborgare = new Medborgare(random.Next(1, 100 + 1), random.Next(1, 25 + 1), random.Next(-1, 1 + 1), random.Next(-1, 1 + 1), "M", Tillhörigheter.SkapaTillhörigheter());
                listOfPeople.Add(medborgare);
            }
            return listOfPeople;

        }
        public static void SendToPrison(List<Person> peopleList, int i, List<Person> prisonList)
        {
            peopleList[i].InPrison = true;
            peopleList[i].PrisonerTimer = 0;
            prisonList.Add(peopleList[i]);
            peopleList.RemoveAt(i);



        }








    }
}
