using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gomuko
{
    class Cell:Button
    {
        public bool occupy=false;
        public Cell(int W,int H)
        {
            this.Width = W;
            this.Height = H;
        }
    }
}
