using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSnakeGame.Objects
{
    public class Schema : PictureBox
    {
        public Schema()
        {
            this.Size = new Size(40, 40);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.BackColor = Color.Transparent;
        }
    }
}
