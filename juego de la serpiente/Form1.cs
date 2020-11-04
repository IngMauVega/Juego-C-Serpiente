using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace juego_de_la_serpiente
{
    public partial class Form1 : Form
    {
        List<PictureBox> Lista = new List<PictureBox>();
        int tamanoPiezaPrincipal = 80, tiempo = 10;
        PictureBox comida = new PictureBox();
        string direccion = "right";
       
        public Form1()
        {
            InitializeComponent();
            IniciarJuego();
            
        }
        public void IniciarJuego()
        {
            tiempo = 10;
            direccion = "right";
            timer1.Interval = 200;
            Lista = new List<PictureBox>();
            lblpuntos.Text = "0";
            //piezas iniciales
            for(int i=2;0<=i;i=i-1)
            {
                Crearchuek(Lista, this, (i * tamanoPiezaPrincipal) + 70, 80);
            }
            CrearDinero();

        }
        public void Crearchuek(List<PictureBox> Listapelota, Form formulario, int posicionX, int posicionY)
        {
            PictureBox pb = new PictureBox();
            pb.Location = new Point(posicionX, posicionY);
           // pb.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("Shrek");
            pb.Image = Image.FromFile(Application.StartupPath + (@"\img\Shrek.png"));
            pb.BackColor = Color.Transparent;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            Listapelota.Add(pb);
            formulario.Controls.Add(pb);
        }
        public void  CrearDinero()
        {
            Random rdn = new Random();
            int enterox = rdn.Next(1, this.Width - tamanoPiezaPrincipal - 10);
            int enteroy = rdn.Next(1, this.Height - tamanoPiezaPrincipal - 40);

            PictureBox pb = new PictureBox();
            pb.Location = new  Point (enterox,enteroy);
            pb.Image=Image.FromFile(Application.StartupPath + (@"\img\dinero.jpg"));
            //  pb.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("dinero2");
            pb.BackColor = Color.Transparent;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            comida = pb;
            this.Controls.Add(pb);


        }

        private void MoverPieza(object sender, KeyEventArgs e)
        {
            //depende que toque es pa donde va ir
            direccion = ((e.KeyCode & Keys.Up)==Keys.Up) ? "up" : direccion;
            direccion = ((e.KeyCode & Keys.Down)==Keys.Down) ? "down" : direccion;
            direccion = ((e.KeyCode & Keys.Up)==Keys.Left) ? "left" : direccion;
            direccion = ((e.KeyCode & Keys.Up)==Keys.Right) ? "right" : direccion;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int nx = Lista[0].Location.X;
            int ny = Lista[0].Location.Y;
            //colocar a tomas
            Lista[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("tomas" + direccion);
            for(int i=Lista.Count-1;i>=0; i=i-1)
            {
                if(i==0)
                {
                    if (direccion == "right") nx = nx + tamanoPiezaPrincipal;
                    else if (direccion == "left") nx = nx - tamanoPiezaPrincipal;
                    else if (direccion == "up") nx = nx - tamanoPiezaPrincipal;
                    else if (direccion == "down") nx = nx + tamanoPiezaPrincipal;
                 //   Lista[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("tomas"+direccion) ;
                    Lista[0].Location = new Point(nx, ny);
                }
                else
                {
                    //intercambio de seguimiento
                    Lista[i].Location = new Point((Lista[i - 1].Location.X), (Lista[i].Location.Y));
                    Lista[i].Location = new Point((Lista[i].Location.X), (Lista[i-1].Location.Y));

                }
                //for (int contarpiezas = 1; contarpiezas < Lista.Count; contarpiezas = i + 1)
                //{
                //    if (Lista[contarpiezas].Bounds.IntersectsWith(comida.Bounds))
                //    {
                //        this.Controls.Remove((comida));//desaparecer el dinero
                //        tiempo = Convert.ToInt32(timer1.Interval);//mas tiempo
                //        if (tiempo > 10)
                //        {
                //            timer1.Interval = tiempo - 10;
                //        }
                //        lblpuntos.Text = (Convert.ToInt32(lblpuntos.Text) + 1).ToString();
                //       // CrearDinero();
                //      //  Crearchuek(Lista, this, Lista[Lista.Count - 1].Location.X * tamanoPiezaPrincipal, 0);//nuevo chuek
                //    }
                //}
            }
        }
    }
}
