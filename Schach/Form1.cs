using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schach
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //gespiegelt: lblZahl.Text= Convert.ToChar(49+y).ToString();

            int f = 8;

            int g = 80;



            this.BackColor = Color.WhiteSmoke;

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {   

                    if (x == 0|| x == f - 1)
                    {
                        Label lblZahl = new Label();
                        lblZahl.AutoSize = false;
                        lblZahl.Size = new Size(25, g);
                        lblZahl.Location = new Point((x == 0) ? 0 :(x+1)*g +25, y*g +25);
                        lblZahl.Text= Convert.ToChar(56-y).ToString();
                        lblZahl.TextAlign = ContentAlignment.MiddleCenter;
                        lblZahl.BackColor = Color.Transparent;
                        this.Controls.Add(lblZahl);
                    }

                    if (y == 0 || y == f - 1)
                    {
                        Label lblBuchstabe = new Label();
                        lblBuchstabe.AutoSize = false;
                        lblBuchstabe.Size = new Size(g, 25);
                        lblBuchstabe.Location = new Point(25 + x * g, (y==0)?0:(y+1) * g +25);
                        lblBuchstabe.Text = Convert.ToChar(65 + x).ToString();
                        lblBuchstabe.TextAlign = ContentAlignment.MiddleCenter;
                        lblBuchstabe.BackColor = Color.Transparent;
                        this.Controls.Add(lblBuchstabe);
                    }


                    Panel feld = new Panel();
                    feld.Size = new Size(g, g);
                    feld.Location = new Point(25 + x * g, 25 + y * g);
                    feld.BackColor = (y % 2 != 0)?((x % 2 == 0) ? Color.Black : Color.White): ((x % 2 == 0) ? Color.White : Color.Black);
                    feld.BackgroundImage = Schach.Properties.Resources.sbauer;
                    feld.BackgroundImageLayout = ImageLayout.Center;
                    this.Controls.Add(feld);
                }            
            }
            this.ClientSize = new Size(f*g+25*2, f*g+25*2);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Text = "Schack";
        }
    }
}
