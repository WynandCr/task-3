using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _19000562_GADE_Project
{
    class ResourceBuilding : Building//inherits from building class
    {
        private int resourceGen, resourceType, resourceRem, resourceGenRound;//new fields for resources

        public ResourceBuilding( int x, int y, int maxHP, int team, int symbol, int resourceRem, string resourceType)
        {
            this.resourceType = resourceType;
            this.team = team;
            this.x = x;
            this.y = y;
            this.resourceRem = resourceRem;
            this.symbol = symbol;
            hp = maxHP;
            this.maxHP = maxHP;
        }

        public void generateResource()//method that generates resources and removes them
        {
            if(resourceRem > 0 && hp > 0)
            {
                resourceGen += resourceGenRound;
                resourceRem -= resourceGenRound;
                symbol = resourceGen;
            }
        }

        public override int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public override int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        public override int MaxHP
        {
            get
            {
                return maxHP;
            }
            set
            {
                maxHP = value;
            }
        }

        public override int Team
        {
            get
            {
                return team;
            }
            set
            {
                team = value;
            }
        }

        public override int Symbol
        {
            get
            {
                return symbol;
            }
            set
            {
                symbol = value;
            }
        }

        public int ResourceType
        {
            get
            {
                return resourceType;
            }
            set
            {
                resourceType = value;
            }
        }

        public int ResourceRem
        {
            get
            {
                return resourceRem;
            }
            set
            {
                resourceRem = value;
            }
        }

        public override string ToString()//overrides the tostring method from building class
        {
            return "The building has " + resourceRem + " resources remaining and has generated " + resourceGenRound + " resources per round";
        }

        public override void death()//overrides the death method from building class
        {
            throw new DeathException(this.ToString() + " IS DEAD");//throws a message as a string using the ToString()
        }

        public class DeathException : System.Exception
        {
            public DeathException() : base()//new instrance for exception class
            {

            }

            public DeathException(string message) : base(message)//using a string message for base
            {

            }

            public DeathException(string message, System.Exception inner) : base(message, inner)//inner property calls original exception that caused problem
            {

            }

            //using contructor for serialization
            //using serialization to store the objects in memory
            protected DeathException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)//streaming context = source and destination
            {

            }
        }

        public override void save(string docPath)//override from save method in building and unit class
        {
            string saveBuilding = x + "," + y + "," + maxHP + "," + team + "," + symbol + "," + resourceRem + "," + resourceType + "," + resourceGen + "\n";//saves information from each unit type
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "ResourceBuilding.txt")))
            {
                outputFile.WriteLine(saveBuilding);//outputs the file with the saved information
            }
        }
    }
}
