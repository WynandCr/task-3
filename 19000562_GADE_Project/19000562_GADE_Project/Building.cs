using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19000562_GADE_Project
{
    abstract class Building
    {
        protected int x, y, hp, maxHP, team, symbol;//new class with protected fields

        public abstract int X
        {
            get;
            set;
        }

        public abstract int Y
        {
            get;
            set;
        }

        public abstract int MaxHP
        {
            get;
            set;
        }

        public abstract int Team
        {
            get;
            set;
        }

        public abstract int Symbol 
        {
            get;
            set;
        }

        public abstract string toString();//method to return a formated string

        public abstract void death();//method to handle the death of the unit

        public abstract void save(string docPath);//save method to save the files

    }
}
