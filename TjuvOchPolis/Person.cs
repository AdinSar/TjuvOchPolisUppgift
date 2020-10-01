using System;
using System.Collections.Generic;
using System.Text;

namespace TjuvOchPolis
{
    class Person
    {
        public int XPostion { get; set; }
        public int YPostion { get; set; }
        public int XTravel { get; set; }
        public int YTravel { get; set; }

        public string BokstavRepresentant { get; set; }

        public List<string> Inventory { get; set; }
        public bool InPrison { get; set; }

        public int PrisonerTimer { get; set; }



    }
    class Polis : Person
    {


        

        public Polis(int xpostion, int ypostion,int xtravel,int ytravel,string bokstavsrepresentant, List<string> beslagtaget)
        {
            XPostion = xpostion;
            YPostion = ypostion;
            XTravel = xtravel;
            YTravel = ytravel;
            BokstavRepresentant = "P";
            Inventory = beslagtaget;





        }

        internal static void Arrest()
        {
            
        }
    }
    class Tjuv : Person
    {
        

        public Tjuv(int xpostion, int ypostion, int xtravel, int ytravel, string bokstavsrepresentant, List<String> stöldgods, bool status, int prisonTimet)
        {
            XPostion = xpostion;
            YPostion = ypostion;
            XTravel = xtravel;
            YTravel = ytravel;
            BokstavRepresentant = "T";
            Inventory = stöldgods;
            InPrison = status;
            PrisonerTimer = prisonTimet;

        }
    }
    class Medborgare : Person
    {
        

        public Medborgare(int xpostion, int ypostion, int xtravel, int ytravel, string bokstavsrepresentant, List<String> tillhörigheter)
        {
            XPostion = xpostion;
            YPostion = ypostion;
            XTravel = xtravel;
            YTravel = ytravel;
            BokstavRepresentant = "M";
            Inventory = tillhörigheter;
            


        }
        


           



        

    }

   

    



}
