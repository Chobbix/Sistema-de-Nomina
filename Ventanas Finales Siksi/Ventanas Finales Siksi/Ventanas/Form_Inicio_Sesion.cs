using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ventanas_Finales_Siksi
{
    public partial class Form_Inicio_Sesion : Form
    {
        public Form_Inicio_Sesion()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void Form1_Load(object sender, EventArgs e) //      CARGAR DIALOGO 
        {

        }

        private void button1_Click(object sender, EventArgs e) //   BOTON ACEPTAR 
        {
            AccionesForms.enlace = false;
            this.Hide();
            Form_Enlaces form = new Form_Enlaces();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e) //   BOTON CANCELAR 
        {
            AccionesForms.enlace = true;
            this.Hide();
            Form_Enlaces form = new Form_Enlaces();
            EnlaceCassandra.conectar();
            form.Show();
        }
    }
}
