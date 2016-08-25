using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nodeControl
{
    public partial class UserControl1: UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //e.Graphics.DrawImage(Image image, Point point);
            e.Graphics.DrawArc(Pens.Black, new Rectangle(currentCoordinates, new Size(5, 5)), 0, 360);
        }

        protected override void OnClick(EventArgs e)
        {
            if (e.GetType() == typeof(MouseEventArgs))
            {
                MouseEventArgs me = e as MouseEventArgs;
                currentCoordinates = me.Location;
                Refresh();
            }
            base.OnClick(e);
        }

        private Point currentCoordinates = new Point(0, 0);
    }
}
