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

        private List<BotonPersonalizado> listaBotones = new List<BotonPersonalizado>();
        private List<Ficha> listaFichas = new List<Ficha>();
        // Con estos 2 atributos podemos saber cuantos jugadores hay y si hay IA.
        private bool iaActiva;
        private int cantJugadores;

        public TableroLudo(int canJugador, bool iaActiva)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            cargarBotones();

            this.cantJugadores = canJugador;
            this.iaActiva = iaActiva;
        }

        private void cargarBotones()
        {
            // Se realiza la carga de los Botones y Fichas
            listaBotones.Add(new BotonPersonalizado(button1, 0, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button2, 1, Tipo.Seguro));
            listaBotones.Add(new BotonPersonalizado(button3, 2, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button4, 3, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button5, 4, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button6, 5, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button7, 6, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button8, 7, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button9, 8, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button10, 9, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button11, 10, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button12, 11, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button13, 12, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button14, 13, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button15, 14, Tipo.Seguro));
            listaBotones.Add(new BotonPersonalizado(button16, 15, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button17, 16, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button18, 17, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button19, 18, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button20, 19, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button21, 20, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button22, 21, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button23, 22, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button24, 23, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button25, 24, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button26, 25, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button27, 26, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button28, 27, Tipo.Seguro));
            listaBotones.Add(new BotonPersonalizado(button29, 28, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button30, 29, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button31, 30, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button32, 31, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button33, 32, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button34, 33, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button35, 34, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button36, 35, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button37, 36, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button38, 37, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button39, 38, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button40, 39, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button41, 40, Tipo.Seguro));
            listaBotones.Add(new BotonPersonalizado(button42, 41, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button43, 42, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button44, 43, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button45, 44, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button46, 45, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button47, 46, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button48, 47, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button49, 48, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button50, 49, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button51, 50, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button52, 51, Tipo.NoSeguro));
            listaBotones.Add(new BotonPersonalizado(button53, 52, Tipo.Seguro));
            listaBotones.Add(new BotonPersonalizado(button54, 53, Tipo.Seguro));
            listaBotones.Add(new BotonPersonalizado(button55, 54, Tipo.Seguro));
            listaBotones.Add(new BotonPersonalizado(button56, 55, Tipo.Seguro));
            listaBotones.Add(new BotonPersonalizado(button57, 56, Tipo.Seguro));
            listaBotones.Add(new BotonPersonalizado(button58, 57, Tipo.Final));
            listaBotones.Add(new BotonPersonalizado(button59, 58, Tipo.Seguro));
            listaBotones.Add(new BotonPersonalizado(button60, 59, Tipo.Seguro));
            listaBotones.Add(new BotonPersonalizado(button61, 60, Tipo.Seguro));
            listaBotones.Add(new BotonPersonalizado(button62, 61, Tipo.Seguro));
            listaBotones.Add(new BotonPersonalizado(button63, 62, Tipo.Seguro));
            listaBotones.Add(new BotonPersonalizado(button64, 63, Tipo.Final));
            listaBotones.Add(new BotonPersonalizado(button65, 64, Tipo.Seguro));
            listaBotones.Add(new BotonPersonalizado(button66, 65, Tipo.Seguro));
            listaBotones.Add(new BotonPersonalizado(button67, 66, Tipo.Seguro));
            listaBotones.Add(new BotonPersonalizado(button68, 67, Tipo.Seguro));
            listaBotones.Add(new BotonPersonalizado(button69, 68, Tipo.Seguro));
            listaBotones.Add(new BotonPersonalizado(button70, 69, Tipo.Final));
            listaBotones.Add(new BotonPersonalizado(button71, 70, Tipo.Seguro));
            listaBotones.Add(new BotonPersonalizado(button72, 71, Tipo.Seguro));
            listaBotones.Add(new BotonPersonalizado(button73, 72, Tipo.Seguro));
            listaBotones.Add(new BotonPersonalizado(button74, 73, Tipo.Seguro));
            listaBotones.Add(new BotonPersonalizado(button75, 74, Tipo.Seguro));
            listaBotones.Add(new BotonPersonalizado(button76, 75, Tipo.Final));

            listaFichas.Add(new Ficha(0, b_fichaVerde1, l_pos_verde1));
            listaFichas.Add(new Ficha(1, b_fichaVerde2, l_pos_verde2));
            listaFichas.Add(new Ficha(2, b_fichaVerde3, l_pos_verde3));
            listaFichas.Add(new Ficha(3, b_fichaVerde4, l_pos_verde4));
            listaFichas.Add(new Ficha(4, b_fichaRojo1, l_pos_rojo1));
            listaFichas.Add(new Ficha(5, b_fichaRojo2, l_pos_rojo2));
            listaFichas.Add(new Ficha(6, b_fichaRojo3, l_pos_rojo3));
            listaFichas.Add(new Ficha(7, b_fichaRojo4, l_pos_rojo4));
            listaFichas.Add(new Ficha(8, b_fichaAzul1, l_pos_azul1));
            listaFichas.Add(new Ficha(9, b_fichaAzul2, l_pos_azul2));
            listaFichas.Add(new Ficha(10, b_fichaAzul3, l_pos_azul3));
            listaFichas.Add(new Ficha(11, b_fichaAzul4, l_pos_azul4));
            listaFichas.Add(new Ficha(12, b_fichaAma1, l_pos_amarillo1));
            listaFichas.Add(new Ficha(13, b_fichaAma2, l_pos_amarillo2));
            listaFichas.Add(new Ficha(14, b_fichaAma3, l_pos_amarillo3));
            listaFichas.Add(new Ficha(15, b_fichaAma4, l_pos_amarillo4));
        }

        private List<BotonPersonalizado> cargarRuta(int inicio, int final, int extras)
        {
            //Este metodo permite asignar una ruta de camino segur el color del jugador
            //Le pasas el donde comienza hasta donde llega, y despues los 6 pasos finales
            List<BotonPersonalizado> ruta = new List<BotonPersonalizado>();

            //Carga desde donde comienza la ficha
            //Hasta donde la ficha va a entrar
            do
            {
                if (inicio > 51) inicio = 0;
                ruta.Add(listaBotones[inicio]);
                inicio++;

            } while (inicio != final);

            // Carga las 6 baldosas finales antes de llegar a la meta, incluido la meta
            for (int i = 0; i < 6; i++)
            {
                ruta.Add(listaBotones[extras]);
                extras++;
            }

            return ruta;

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
