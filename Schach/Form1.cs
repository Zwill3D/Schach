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
        char figur = ' ';
        Point start = new Point(-1, -1);
        Point ziel = new Point(-1, -1);


        private char[,] spielfeld = {
            {'t','s','l','d','k','l','s','t'},
            {'b','b','b','b','b','b','b','b'},
            {' ',' ',' ',' ',' ',' ',' ',' '},
            {' ',' ',' ',' ',' ',' ',' ',' '},
            {' ',' ',' ',' ',' ',' ',' ',' '},
            {' ',' ',' ',' ',' ',' ',' ',' '},
            {'B','B','B','B','B','B','B','B'},
            {'T','S','L','D','K','L','S','T'},
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
                    feld.BackgroundImage = this.getFigur(this.spielfeld[y, x]);
                    feld.Click += Feld_Click;
                    feld.BackgroundImageLayout = ImageLayout.Center;
                    feld.Tag = new Point(x, y);
                    this.Controls.Add(feld);
                }            
            }
            this.ClientSize = new Size(f*g+25*2, f*g+25*2);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Text = "Schack Maat";
        }

        private void Feld_Click(object sender, EventArgs e)
        {
            
            Panel p = (Panel) sender;
            Point pt = (Point)p.Tag;
            if(figur == ' ')
            {
                if(spielfeld[pt.Y, pt.X] != ' ')
                {
                    start = pt;
                    figur = spielfeld[pt.Y, pt.X];
                    spielfeld[pt.Y, pt.X] = ' ';
                    this.updateFeld(pt.X, pt.Y);
                }
                
            }
            else
            {
                spielfeld[pt.Y, pt.X] = figur;
                figur = ' ';
                this.updateFeld(pt.X, pt.Y);
            }
            
            //Console.WriteLine(spielfeld[pt.Y, pt.X]);
        }

        private void updateFeld(int x, int y)
        {
            foreach (Control ctrl in this.Controls) 
            {
                if(ctrl.GetType() == typeof(Panel))
                {
                    Panel p = (Panel)ctrl;
                    Point pt = (Point)p.Tag;
                    if (pt.X == x && pt.Y == y)
                    {
                        p.BackColor = (x % 2 == 0 ^ y % 2 == 0) ? Color.Black : Color.White;
                        p.BackgroundImage = this.getFigur(this.spielfeld[y, x]);
                        return;
                    }
                }
            }
        }

        private bool checkZug()
        {
            int quellex = 
        }

        private Image getFigur(char feldinhalt)
        {
            Image bild = null;
            switch (feldinhalt)
            {
                case 't':
                    bild = Schach.Properties.Resources.sturm;
                    break;
                case 'T':
                    bild = Schach.Properties.Resources.wturm;
                    break;
                case 's':
                    bild = Schach.Properties.Resources.sspringer;
                    break;
                case 'S':
                    bild = Schach.Properties.Resources.wspringer;
                    break;
                case 'l':
                    bild = Schach.Properties.Resources.slaeufer;
                    break;
                case 'L':
                    bild = Schach.Properties.Resources.wlaeufer;
                    break;
                case 'b':
                    bild = Schach.Properties.Resources.sbauer;
                    break;
                case 'B':
                    bild = Schach.Properties.Resources.wbauer;
                    break;
                case 'k':
                    bild = Schach.Properties.Resources.skoenig;
                    break;
                case 'K':
                    bild = Schach.Properties.Resources.wkoenig;
                    break;
                case 'd':
                    bild = Schach.Properties.Resources.sdame;
                    break;
                case 'D':
                    bild = Schach.Properties.Resources.wdame;
                    break;
            }

            return bild;
        }
    }
}
