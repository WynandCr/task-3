using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _19000562_GADE_Project
{
    class FactoryBuilding : Building//inherits from building class
    {
        public Map m = new Map();
        Unit[] unitAdd;
        private string unitType;//unit type to produce
        private int spawnX, spawnY, speed;//int for production speed and x and y varibles for spawn point

        public FactoryBuilding(int x, int y, int maxHP, int team, int symbol, int speed)
        {
            unitType = ("" + symbol);
            this.maxHP = maxHP;
            this.x = x;
            this.y = y;
            this.team = team;
            spawnX = x;
            hp = maxHP;

            if (y >= 19)
            {
                spawnY = y - 1;
            }
            else
            {
                spawnY = y + 1;
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

        public override void death()//override the death of base class
        {
            throw new DeathException(this.ToString() + " IS DEAD");//throws a message as a string using the ToString()
        }

        public void generateUnit()//method that spawns a unit
        {
            int tempAttack = 0;
            unitAdd = new Unit[m.units.Length + 1];
            Random r = new Random();
            Unit unit = null;

            switch (r.Next(0, 4))
            {
                case 0:
                    tempAttack = 40;
                    break;
                case 1:
                    tempAttack = 50;
                    break;
                case 2:
                    tempAttack = 60;
                    break;
                case 3:
                    tempAttack = 90;
                    break;
            }

            if(unitType == "0" && team == 1)
            {
                unit = new MeleeUnit(spawnX, spawnY, 100, 2, tempAttack, 30, team, ("" + symbol));//building type that belongs to team 1 will spawn in meleeunit
            }
            else if(unitType == "0" && team == 2)
            {
                unit = new MeleeUnit(spawnX, spawnY, 100, 2, tempAttack, 30, team, ("" + symbol));
            }

            if (unitType == "1" && team == 1)
            {
                unit = new RangeUnit(spawnX, spawnY, 100, 1, tempAttack, 90, team, ("" + symbol));
            }
            else if (unitType == "1" && team == 2)
            {
                unit = new RangeUnit(spawnX, spawnY, 100, 1, tempAttack, 90, team, ("" + symbol));//building type that belongs to team 2 will spawn at rangeunit
            }

            for(int loop = 0; loop < unitAdd.Length - 1; loop++)
            {
                unitAdd[loop] = m.units[loop];
            }

            unitAdd[unitAdd.Length - 1] = unit;//adds the unit at end
            m.units = unitAdd;

        }

        public override string toString()//override the tostring from base class
        {
            return "This factory belongs to this team: " + this.team + ", Position is at: " + this.x + ", " + this.y + ".\nIts health: " + this.hp + "\n" + 
                "Creates " + this.unitType + " unit every " + speed + " seconds at this locations: " + this.spawnX + ", " + this.spawnY;
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
            string saveBuilding = x + "," + y + "," + team + "," + symbol + "," + speed + "," + unitType + "," + spawnX + "," + spawnY + "\n";//saves information from each unit type
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "FactoryBuildings.txt")))
            {
                outputFile.WriteLine(saveBuilding);
            }
        }
    }
}
