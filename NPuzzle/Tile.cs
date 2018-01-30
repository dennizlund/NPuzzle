using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPuzzle
{
    class Tile
    {
        private int data;

        public int Data
        {
            get { return data; }
            set { data = value; }
        }
        
        
        
        public Tile(int tileValue)
        {
            data = tileValue;
        }

        public int IsEmpty()
        {
            if (data == 0)
            {
                return 1;
            }
            else
                return 0;
        }

        

    }
}
