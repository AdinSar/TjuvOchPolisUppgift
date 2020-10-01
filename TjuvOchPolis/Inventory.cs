using System;
using System.Collections.Generic;
using System.Text;

namespace TjuvOchPolis
{
    class Inventory
    {


        
        public static void Steal(List<string> stöldgods, List<string> tillhörigheter)
        {
            if (tillhörigheter.Count == 0)
            {
                

            }
            else if (tillhörigheter.Count ==1)
            {
                stöldgods.Add(tillhörigheter[0]);
                tillhörigheter.RemoveAt(0);
            }
            else
            {
                
                Random random = new Random();
                int randomnumber = random.Next(1, tillhörigheter.Count);


                stöldgods.Add(tillhörigheter[randomnumber]);
                tillhörigheter.RemoveAt(randomnumber);
            }
        }

        internal static void Arrest(List<string> beslagtaget, List<string> stöldgods)
        {
            if (stöldgods.Count == 0)
            {

            }
            else
            {
                for (int i = 0; i < stöldgods.Count; i++)
                {
                    beslagtaget.Add(stöldgods[i]);
                }
                stöldgods.Clear();
            }
            
        }
    }
    class Stöldgods : Inventory
    {
        public static List<string> SkapaStöldgods()
        {
            List<String> stöldgods = new List<string>();
            return stöldgods;
        }
    }
    class Beslagtaget : Inventory
    {
        public static List<string> SkapaBeslagtaget()
        {
            List<String> beslagtaget = new List<string>();
            return beslagtaget;
        }
    }
    class Tillhörigheter : Inventory
    {
        public static List<string> SkapaTillhörigheter()
        {
            List<String> tillhörigheter = new List<string>();
            tillhörigheter.Add("Nycklar");
            tillhörigheter.Add("Mobiltelefon");
            tillhörigheter.Add("Pengar");
            tillhörigheter.Add("Klocka");
            return tillhörigheter;

        }


    }

}
