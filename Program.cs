using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGameTogether
{
    class Program
    {
        static void Main(string[] args)
        {
            MeetTheWitch m = new MeetTheWitch();
            m.Intro();
            m.setUpGame();
            m.look();
        }
    }
}
