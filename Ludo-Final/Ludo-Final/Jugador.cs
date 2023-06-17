using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo_Final
{
    internal class Jugador
    {
        private Boolean poderMover;
        private int nroDado;
        private int id;
        private Color colorJugador;

        public Jugador() { }

        public Jugador(int id) 
        {
            poderMover = false;
            this.id = id;
            colorJugador = generarColor();
        }

        public int getnroDado() { return nroDado; }
        public int setnroDado(int nro) { return nroDado = nro; }

        public int getId() { return id; }

        public Color getColor() { return colorJugador; }

        //compruebo si el Color del BtnTurno del Tablero , coincida con el Color del Jugador
        public Boolean comprobarMover(Button btnTurno) 
        {
            return btnTurno.BackColor == colorJugador;
        }

        public Color generarColor()
        {
            Color color;
            switch (id)
            {
                case 1: color = Color.Lime; break;
                case 2: color = Color.Red; break;
                case 3: color = Color.Yellow; break;
                case 4: color = Color.Blue; break;
                default:color = Color.White; break;
            }

            return color;
        }

    }
}
