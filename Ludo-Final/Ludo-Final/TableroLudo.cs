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
        int contadorTurno = 0;
        int dadoSeleccionado;
        int indiceJugador = 0;
        bool timerSeDetuvo = false;
        bool seOrdeno = false;
        Jugador jugador1 = new Jugador(1);
        Jugador jugador2 = new Jugador(2);
        Jugador jugador3 = new Jugador(3);
        Jugador jugador4 = new Jugador(4);
        List<Jugador> ordenTurno = new List<Jugador>();


        public TableroLudo()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            llenarLista();
            btn_turnos.BackColor = Color.White;
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
                timerSeDetuvo = true;
            }

            contadorDado++;

        }


        private void b_lanzar_dado_Click(object sender, EventArgs e)
        {
            //verifico si se ordeno
            if (seOrdeno != true)
            {
                if (contadorTurno < ordenTurno.Count)
                {
                    timerDado.Start();
                    b_lanzar_dado.Enabled = false;
                    ordenTurno[contadorTurno].setnroDado(dadoSeleccionado);
                    contadorTurno++;

                }

                if (contadorTurno == ordenTurno.Count)
                {
                    ordenarTurnos();
                }

            }

            //cambio de color dependiendo del turno del juagador
            if (timerSeDetuvo)
            {
                if (indiceJugador > ordenTurno.Count - 1)
                {
                    indiceJugador = 0;
                }
                cambiarColorBtnTurno(indiceJugador);
                indiceJugador++;
                timerSeDetuvo = false;
            }
            timerDado.Start();
            b_lanzar_dado.Enabled = false;

        }

        private void llenarLista()
        {
            ordenTurno.Add(jugador1);
            ordenTurno.Add(jugador2);
            ordenTurno.Add(jugador3);
            ordenTurno.Add(jugador4);

        }

        private void ordenarTurnos()
        {

            ordenTurno = ordenTurno.OrderByDescending(jugador => jugador.getnroDado()).ToList();

        }

        private void cambiarColorBtnTurno(int indiceJugador)
        {

            btn_turnos.BackColor = ordenTurno[indiceJugador].getColor();

        }


    }
}
