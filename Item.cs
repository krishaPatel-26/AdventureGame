using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGameTogether
{
    class Item : Thing
    {
        private int value; //use or not use it... up to you
        private int loc;

        public void setLoc(int r) { loc = r; } //change the items room num
        public int getLoc() { return loc; } //tell me which room the item is in

        public void setValue(int v) { this.value = v; }
        public int getValue() { return this.value; }
    }
}
