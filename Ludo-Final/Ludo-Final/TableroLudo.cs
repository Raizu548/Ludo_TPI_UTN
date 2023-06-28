using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ludo_Final
{
    public partial class TableroLudo : Form
    {
        // Contienen los objetos para mantener las referencias
        private List<BotonPersonalizado> listaBotones = new List<BotonPersonalizado>();
        private List<Ficha> listaFichas = new List<Ficha>();
        private List<Jugador> listaJugadores = new List<Jugador>();
        // Con este atributo podemos saber cuantos jugadores hay y si hay IA.
        private bool iaActiva;

        // Secuencia de juego
        Ficha fichaSeleccionada;
        Jugador jugadorActual;
        BotonPersonalizado botonActivado;
        int cantMovimiento;

        // Dado
        Dado dado = new Dado();
        int contadorDado = 0;
        int dadoSeleccionado;


        public TableroLudo(int canJugador, bool iaActiva)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            cargarBotones();
            this.iaActiva = iaActiva;
            cargarJugadores(canJugador);
            jugadorActual = listaJugadores[0]; // asigno el turno al primer jugador
        }


        // -------------------------- METODOS DE CARGA --------------------------

        private void cargarBotones() // <- Carga Botones
        {
            // Se realiza la carga de los Botones y Fichas
            listaBotones.Add(new BotonPersonalizado(button1, 0, Tipo.Seguro, Color.Green));
            listaBotones.Add(new BotonPersonalizado(button2, 1, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button3, 2, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button4, 3, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button5, 4, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button6, 5, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button7, 6, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button8, 7, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button9, 8, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button10, 9, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button11, 10, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button12, 11, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button13, 12, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button14, 13, Tipo.Seguro, Color.DarkRed));
            listaBotones.Add(new BotonPersonalizado(button15, 14, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button16, 15, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button17, 16, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button18, 17, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button19, 18, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button20, 19, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button21, 20, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button22, 21, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button23, 22, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button24, 23, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button25, 24, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button26, 25, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button27, 26, Tipo.Seguro, Color.DarkBlue));
            listaBotones.Add(new BotonPersonalizado(button28, 27, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button29, 28, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button30, 29, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button31, 30, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button32, 31, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button33, 32, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button34, 33, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button35, 34, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button36, 35, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button37, 36, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button38, 37, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button39, 38, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button40, 39, Tipo.Seguro, Color.Olive));
            listaBotones.Add(new BotonPersonalizado(button41, 40, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button42, 41, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button43, 42, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button44, 43, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button45, 44, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button46, 45, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button47, 46, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button48, 47, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button49, 48, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button50, 49, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button51, 50, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button52, 51, Tipo.NoSeguro, Color.White));
            listaBotones.Add(new BotonPersonalizado(button53, 52, Tipo.Seguro, Color.Green));
            listaBotones.Add(new BotonPersonalizado(button54, 53, Tipo.Seguro, Color.Green));
            listaBotones.Add(new BotonPersonalizado(button55, 54, Tipo.Seguro, Color.Green));
            listaBotones.Add(new BotonPersonalizado(button56, 55, Tipo.Seguro, Color.Green));
            listaBotones.Add(new BotonPersonalizado(button57, 56, Tipo.Seguro, Color.Green));
            listaBotones.Add(new BotonPersonalizado(button58, 57, Tipo.Final, Color.Green));
            listaBotones.Add(new BotonPersonalizado(button59, 58, Tipo.Seguro, Color.DarkRed));
            listaBotones.Add(new BotonPersonalizado(button60, 59, Tipo.Seguro, Color.DarkRed));
            listaBotones.Add(new BotonPersonalizado(button61, 60, Tipo.Seguro, Color.DarkRed));
            listaBotones.Add(new BotonPersonalizado(button62, 61, Tipo.Seguro, Color.DarkRed));
            listaBotones.Add(new BotonPersonalizado(button63, 62, Tipo.Seguro, Color.DarkRed));
            listaBotones.Add(new BotonPersonalizado(button64, 63, Tipo.Final, Color.DarkRed));
            listaBotones.Add(new BotonPersonalizado(button65, 64, Tipo.Seguro, Color.DarkBlue));
            listaBotones.Add(new BotonPersonalizado(button66, 65, Tipo.Seguro, Color.DarkBlue));
            listaBotones.Add(new BotonPersonalizado(button67, 66, Tipo.Seguro, Color.DarkBlue));
            listaBotones.Add(new BotonPersonalizado(button68, 67, Tipo.Seguro, Color.DarkBlue));
            listaBotones.Add(new BotonPersonalizado(button69, 68, Tipo.Seguro, Color.DarkBlue));
            listaBotones.Add(new BotonPersonalizado(button70, 69, Tipo.Final, Color.DarkBlue));
            listaBotones.Add(new BotonPersonalizado(button71, 70, Tipo.Seguro, Color.Olive));
            listaBotones.Add(new BotonPersonalizado(button72, 71, Tipo.Seguro, Color.Olive));
            listaBotones.Add(new BotonPersonalizado(button73, 72, Tipo.Seguro, Color.Olive));
            listaBotones.Add(new BotonPersonalizado(button74, 73, Tipo.Seguro, Color.Olive));
            listaBotones.Add(new BotonPersonalizado(button75, 74, Tipo.Seguro, Color.Olive));
            listaBotones.Add(new BotonPersonalizado(button76, 75, Tipo.Final, Color.Olive));

            foreach (var item in listaBotones)
            {
                item.GetBoton().Click += Btn_Click;
            }

            listaFichas.Add(new Ficha(0, pb_fichaV1));
            listaFichas.Add(new Ficha(1, pb_fichaV2));
            listaFichas.Add(new Ficha(2, pb_fichaV3));
            listaFichas.Add(new Ficha(4, pb_fichaV4));
            listaFichas.Add(new Ficha(5, pb_fichaAz1));
            listaFichas.Add(new Ficha(6, pb_fichaAz2));
            listaFichas.Add(new Ficha(7, pb_fichaAz3));
            listaFichas.Add(new Ficha(8, pb_fichaAz4));
            listaFichas.Add(new Ficha(9, pb_fichaR1));
            listaFichas.Add(new Ficha(10, pb_fichaR2));
            listaFichas.Add(new Ficha(11, pb_fichaR3));
            listaFichas.Add(new Ficha(12, pb_fichaR4));
            listaFichas.Add(new Ficha(13, pb_fichaAm1));
            listaFichas.Add(new Ficha(14, pb_fichaAm2));
            listaFichas.Add(new Ficha(15, pb_fichaAm3));
            listaFichas.Add(new Ficha(16, pb_fichaAm4));

            foreach (var item in listaFichas)
            {
                item.getFicha().Click += Pbox_Click;
            }

        }

        private List<BotonPersonalizado> cargarRuta(int inicio, int final, int extras) // <- Carga la ruta a seguir
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

            } while (inicio != final + 1);

            // Carga las 6 baldosas finales antes de llegar a la meta, incluido la meta
            for (int i = 0; i < 6; i++)
            {
                ruta.Add(listaBotones[extras]);
                extras++;
            }

            return ruta;
        }

        private void cargarJugadores(int cant) // <- Carga los jugadores
        {
            // Carga los jugadores 
            if (cant >= 1) { cargarHumano(0, 4, 0, 50, 52, 0); } // Verde 50, 52, 0
            if (cant >= 2) { cargarHumano(4, 8, 26, 24, 64, 1); } // Azul 24, 64, 1
            if (cant >= 3) { cargarHumano(8, 12, 13, 11, 58, 2); } // Rojo 11, 58, 2
            if (cant >= 4) { cargarHumano(12, 16, 39, 37, 70, 3); } // Amarillo 37, 70, 3

            if (iaActiva) cargarIA(4, 8, 26, 24, 64, 1);
        }

        private void cargarIA(int inFicha, int finFicha, int inRuta, int finRuta, int extRuta, int id) // <- Carga la IA 
        {
            listaJugadores.Add(new JugadorIA(id, cargarFicha(inFicha, finFicha), cargarRuta(inRuta, finRuta, extRuta)));
        }

        private void cargarHumano(int inFicha, int finFicha, int inRuta, int finRuta, int extRuta, int id) // <- Carga los jugadores
        {
            listaJugadores.Add(new JugadorHum(id, cargarFicha(inFicha, finFicha), cargarRuta(inRuta, finRuta, extRuta)));
        }

        private List<Ficha> cargarFicha(int inFicha, int finFicha) // <- Asigna las fichas a los jugadores
        {
            List<Ficha> fichas = new List<Ficha>();
            for (int i = inFicha; i < finFicha; i++)
            {
                fichas.Add(listaFichas[i]);
                listaFichas[i].getFicha().Visible = true;
            }

            return fichas;
        }

        // -------------------------- METODOS DE COMPONENTES --------------------------

        private void b_lanzar_dado_Click(object sender, EventArgs e) // <- lanza los dados
        {
            jugar();
        }

        private void Btn_Click(object sender, EventArgs e) // <- Boton seleccionado
        {
            // Todas las casillas pueden realizar este evento
            Button clickedButton = (Button)sender;
            // seleciono la casilla y se mueve la ficha
            moverFicha();

        }

        private void Pbox_Click(object sender, EventArgs e) // <- Ficha seleccionada
        { // Todos los Picture box pueden realizar este evento

            PictureBox clickedPictureBox = (PictureBox)sender;
            if (botonActivado != null) botonActivado.desactivarBoton();
            // Se guarda la ficha que fue seleccionada
            fichaSeleccionada = listaFichas.Find(boton => boton.getFicha() == clickedPictureBox);

            if (fichaSeleccionada != null)
            { // Activa la casilla a la que se puede mover
                if (!jugadorActual.pasaFinal(dadoSeleccionado, fichaSeleccionada.GetUbicacion()))
                {
                    botonActivado = jugadorActual.posicionMover(fichaSeleccionada.GetUbicacion(), dadoSeleccionado);
                    botonActivado.activarBoton();
                }

            }

        }

        private void timerDado_Tick(object sender, EventArgs e) // <- Animacion de dado
        {
            int x = dado.tirarDado();

            if (contadorDado != 10)
            {
                // ejecuta animacion de Dado
                pictureBoxDado.Load(dado.animacion(x));
            }
            else
            {
                timerDado.Stop();
                dadoSeleccionado = x;
                pictureBoxDado.Load(dado.animacion(dadoSeleccionado));

                contadorDado = 0;

                // Activa las fichas que se pueden mover del jugador actual
                activarFichasJugadorActual();

            }

            contadorDado++;
        }

        private void timerMovimiento_Tick(object sender, EventArgs e) // <- Mueve la ficha
        { // Mueve la ficha
            if (!fichaSeleccionada.GetEnMovimiento() && cantMovimiento > 0)
            {
                fichaSeleccionada.MoverFicha(jugadorActual.posicionMover(fichaSeleccionada.GetUbicacion(), 1));
                cantMovimiento--;
            }
            else if (cantMovimiento == 0 && !fichaSeleccionada.GetEnMovimiento())
            {
                // Comprueba si puede comer
                botonActivado.logicaComer(fichaSeleccionada, jugadorActual);
                timerMovimiento.Stop();

                jugadorActual.entroAlRecorrido(fichaSeleccionada);

                if (jugadorActual.gano())
                {
                    MessageBox.Show("Gano el jugador " + jugadorActual.getColor(), "Fin del juego");
                    this.Close();
                }

                terminarTurno();
            }
        }

        // -------------------------- METODOS AUXILIARES --------------------------

        private void jugar() // Accion jugar
        {
            b_lanzar_dado.Enabled = false;
            timerDado.Start();
        }

        private void moverFicha() // <- Verifica si puede mover la ficha
        {
            // seleciono la casilla y se mueve la ficha
            if (!jugadorActual.pasaFinal(dadoSeleccionado, fichaSeleccionada.GetUbicacion()))
            {

                if (fichaSeleccionada.getEnCasa())
                { // Si la ficha no esta en juego

                    BotonPersonalizado ubicacion = jugadorActual.posicionMover(fichaSeleccionada.GetUbicacion(), 1);
                    fichaSeleccionada.MoverFicha(ubicacion);
                    jugadorActual.ponerFichaJuego(fichaSeleccionada);
                    timerMovimiento.Start();

                }
                else
                { // Si la ficha ya esta en juego
                  // Saco ficha de la posicion actual para moverla
                    fichaSeleccionada.GetUbicacion().sacarFicha(fichaSeleccionada);
                    cantMovimiento = dadoSeleccionado;
                    timerMovimiento.Start();
                }

            }
        }

        private void activarFichasJugadorActual()
        {
            // Activa las fichas que se pueden mover del jugador actual
            if (jugadorActual is JugadorHum)
            {
                activarFichas();
            }
            else
            { // juega la IA
                JugadorIA jugadorIA = (JugadorIA)jugadorActual;
                fichaSeleccionada = jugadorIA.seleccionarFicha(dadoSeleccionado);

                if (fichaSeleccionada != null)
                {
                    botonActivado = jugadorActual.posicionMover(fichaSeleccionada.GetUbicacion(), dadoSeleccionado);

                    moverFicha();
                }
                else
                {
                    terminarTurno();
                }
            }
        }

        private void activarFichas() // <- Activa las fichas para su seleccion
        {
            JugadorHum jugadorHumano = (JugadorHum)jugadorActual;
            // Activa las fichas que se pueden mover
            if (dadoSeleccionado == 1 || dadoSeleccionado == 6)
            {
                jugadorHumano.activarFichas();
                Debug.WriteLine("1 o 6");
            }
            else if (jugadorActual.getFichaJuego())
            {
                jugadorHumano.activarFichaJuego();
            }
            else
            {
                terminarTurno();
            }
        }

        private void terminarTurno() // <- Procedimiento al terminar el turno
        {
            // Procedimientos que se lleva a cabo al finalizar el turno

            if (jugadorActual is JugadorHum)
            {
                JugadorHum jugadorHumano = (JugadorHum)jugadorActual;
                jugadorHumano.desactivarFichas();
            }

            pasarTurno();
            MessageBox.Show("Sigue jugador " + jugadorActual.getColor(), "Fin del turno");
            btn_turnos.BackColor = jugadorActual.getColor();

            if (botonActivado != null) botonActivado.desactivarBoton(); // desactiva el boton de posicion

            if (jugadorActual is JugadorIA)
            {
                b_lanzar_dado.Enabled = false;
                jugar();
            }
            else
            {
                b_lanzar_dado.Enabled = true; // activa el boton
            }
        }

        private void pasarTurno() // <- Pasa el turno
        {
            int turno = listaJugadores.IndexOf(jugadorActual);
            turno++;

            if (turno < listaJugadores.Count)
            {
                jugadorActual = listaJugadores[turno];
            }
            else
            {
                jugadorActual = listaJugadores[0];
            }
        }
  
    }
}
