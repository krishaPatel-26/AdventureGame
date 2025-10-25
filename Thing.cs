using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGameTogether
{
    class Thing
    {
        //variables should be private
        protected string name;
        protected string desc;

        //we need a setter to set the PRIVATE name from another class
        public void setName(string name)
        {
            this.name = name;
        }

        public void setDesc(string d)
        {
            this.desc = d;
        }

        //we need a getter to GET this name from another class
        public string getName()
        {
            return this.name;
        }

        public string getDesc()
        {
            return this.desc;
        }
    }
}
