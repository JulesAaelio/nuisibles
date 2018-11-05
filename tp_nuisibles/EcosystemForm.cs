using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace tp_nuisibles
{
    public class EcosystemForm: Form
    {
        private Ecosystem Ecosystem;
        public EcosystemForm(Ecosystem ecosystem)
        {
            this.Ecosystem = ecosystem;
            this.KeyPress += KeyPress1;
            this.Size = new Size(this.Ecosystem.DimX * 15, this.Ecosystem.DimY * 15);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            List<Nuisible> nuisibles = new List<Nuisible>(this.Ecosystem.Nuisibles);
            int size = 10;
            
            SolidBrush brushe = new SolidBrush(Color.Gray);

            Graphics formGraphics= this.CreateGraphics();
            
            foreach (Nuisible nuisible in nuisibles)
            {
                Rectangle rectangle = new Rectangle(new Point(nuisible.Position.X * size, nuisible.Position.Y * size), new Size(size,size));
                brushe.Color = nuisible.Color;
                formGraphics.FillRectangle(brushe, rectangle);
            }
            
            //Liberate resources            
            brushe.Dispose();
            formGraphics.Dispose();
        }

        protected void KeyPress1(Object sender, KeyPressEventArgs e)
        {
           this.Ecosystem.MoveAllRandomly();
//           this.Refresh();

        }
    }
}