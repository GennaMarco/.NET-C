using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Campo_Minato
{
    public class Cella : Button
    {
        public Cella(string name, string text, int width, int height, Color backcolor, Color forecolor)
        {
            this.Name = name;
            this.Text = text;
            this.Width = width;
            this.Height = height;
            this.BackColor = backcolor;
            this.ForeColor = forecolor;
            this.Font = new Font(Font.FontFamily, 8);
        }
    }
}
