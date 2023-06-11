using Ludo_Final;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ludo_TPI
{
    public partial class TableroLudo : Form
    {
        Dado dado = new Dado();
        int contadorDado = 0;
        int dadoSeleccionado;

        public TableroLudo()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void timerDado_Tick(object sender, EventArgs e)
        {
            int x = dado.tirarDado();

            if (contadorDado != 10)
            {

                pictureBoxDado.Load(dado.animacion(x));

            }
            else
            {
                dadoSeleccionado = x;

                pictureBoxDado.Load(dado.animacion(dadoSeleccionado));

                contadorDado = 0;
                b_lanzar_dado.Enabled = true;

                timerDado.Stop();

            }

            contadorDado++;

        }

        private void b_lanzar_dado_Click(object sender, EventArgs e)
        {
            timerDado.Start();
            b_lanzar_dado.Enabled = false;
            

        }
    }
}
