using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neural
{
    public class Util
    {
        private static Util instance;
        private Random rand;

        public Random Rand
        {
            get { return rand; }
        }

        public static Util Instance
        {
            get {
                if (instance == null)
                    instance = new Util();
                return instance;
            }
        }


        public Util()
        {
            rand = new Random();
        }

    }
}
