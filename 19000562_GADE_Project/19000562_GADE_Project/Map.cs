using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _19000562_GADE_Project
{
    class Map
    {
        public Unit[] units = new Unit[10];//new array with 10 elements
        public ResourceBuilding[] rBuildings;
        public FactoryBuilding[] fBuildings;
        int fCount = 0;
        int rCount = 0;
        Random r = new Random();//creating new random number

        public Map()
        {

            for (int i = 0; i < 10; i++)//looping through each element
            {
                int newX = r.Next(0, 20);//randomise x and y position 
                int newY = r.Next(0, 20);
                int team = i % 2;
                int tempAttack = 0;
                switch (r.Next(0, 4))//getting random number betweeen 0 and 3 included
                {
                    case 0://if 0 then attack equal to 5
                        tempAttack = 5;
                        break;
                    case 1:
                        tempAttack = 10;
                        break;
                    case 2:
                        tempAttack = 15;
                        break;
                    case 3:
                        tempAttack = 20;
                        break;
                }

                switch (r.Next(0, 2))//getting random number between 0 and 1 included
                {
                    case 0://if its 0 then do meleeunit
                        units[i] = new MeleeUnit(newX, newY, 100, 1, tempAttack, 1, team, i.ToString());//updates the unit based on its changing x and y cord
                        break;
                    case 1://if its 1 then do rangeunit
                        units[i] = new RangeUnit(newX, newY, 100, 1, tempAttack, 4, team, i.ToString());
                        break;
                }

                switch (r.Next(0, 2))//depending on the team, it will be randomized 
                {
                    case 0:
                        int typeOfFactory = r.Next(0. 2);
                        fBuildings[fCount] = new FactoryBuilding(newX, newY, 150, team, typeOfFactory, 2);//randomly chooses a building type and team and places it on the x an y pos
                        fCount++;
                        break;

                    case 1:
                        int typeOfResource = r.Next(0, 2);
                        rBuildings[rCount] = new ResourceBuilding(newX, newY, 150, team, 0, 50, typeOfResource);
                        rCount++;
                        break;

                    default:
                        break;
                }
            }
        }
        public void read(string docPath)//read method that reads the save files
        {
            string line;
            int countFBuildings = 0;
            int countRBuildings = 0;
            int countUnits = 0;

            try
            {
                StreamReader sr = new StreamReader("c:\\RangeUnit.txt");//passes the txt file and file path to the streamreader constructor

                line = sr.ReadLine();//reads the first line
                int[] stats = line.Split(',').Select(p => int.Parse(p)).ToArray();
                units[countUnits] = new RangeUnit(stats[0], stats[2], stats[3], stats[4], stats[5], stats[6], countUnits.ToString());
                countUnits++;


                while (line != null)//continues reading 
                {
                    line = sr.ReadLine();
                    stats = line.Split(',').Select(p => int.Parse(p)).ToArray();
                    units[countUnits] = new RangeUnit(stats[0], stats[2], stats[3], stats[4], stats[5], stats[6], countUnits.ToString());
                    countUnits++;


                }

                sr.Close();//closes the file
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing block");
            }

            //Factory buildings
            try
            {
                StreamReader sr = new StreamReader("c:\\FactoryBuilding.txt");//reads the txt file

                line = sr.ReadLine();
                int[] stats = line.Split(',').Select(p => int.Parse(p)).ToArray();
                units[countFBuildings] = new FactoryBuilding(stats[0], stats[1], stats[2], stats[3], stats[4], stats[5], stats[6], countUnits.ToString());
                countFBuildings++;


                while (line != null)
                {
                    line = sr.ReadLine();
                    stats = line.Split(',').Select(p => int.Parse(p)).ToArray();
                    fBuildings[countFBuildings] = new FactoryBuilding(stats[0], stats[2], stats[3], stats[4], stats[5], stats[6], countUnits.ToString());
                    countFBuildings++;
                }

                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing block");
            }

            //Resource Building
            try
            {
                StreamReader sr = new StreamReader("c:\\FactoryBuilding.txt");//reads the txt file

                line = sr.ReadLine();
                int[] stats = line.Split(',').Select(p => int.Parse(p)).ToArray();
                rBuildings[countRBuildings] = new ResourceBuilding(stats[0], stats[2], stats[3], stats[4], stats[5], stats[6], countUnits.ToString());
                countRBuildings++;


                while (line != null)
                {
                    line = sr.ReadLine();
                    stats = line.Split(',').Select(p => int.Parse(p)).ToArray();
                    rBuildings[countRBuildings] = new ResourceBuilding(stats[0], stats[2], stats[3], stats[4], stats[5], stats[6], countUnits.ToString());
                    countRBuildings++;
                }

                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing block");
            }
        }
    }
}
        
        
    

