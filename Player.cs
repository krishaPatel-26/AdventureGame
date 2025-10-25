using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGameTogether
{
    class Player : Thing
    {
        private int loc;

        public void setLoc(int loc)
        {
            this.loc = loc;
        }

        public int getLoc()
        {
            return loc;
        }
    }
}
