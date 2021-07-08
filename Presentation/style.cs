using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORUS.Presentation
{
    public class style
    {
        public static  void button(ref Button  button) {
            button.BackColor = Color.FromArgb(0,76,139);
            button.FlatStyle = FlatStyle.Flat;
        }
    }
}
