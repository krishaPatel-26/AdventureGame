using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGameTogether
{
    class Room : Thing
    {
        private int[] exits = new int[4];
        //create an empty array of integers of lenght 4

        public void setExits(int n, int s, int e, int w)
        {
            exits[0] = n;
            exits[1] = s;
            exits[2] = e;
            exits[3] = w;
        }

        //need to add getters
        public int getN() { return exits[0]; }
        public int getS() { return exits[1]; }
        public int getE() { return exits[2]; }
        public int getW() { return exits[3]; }

    }
}
