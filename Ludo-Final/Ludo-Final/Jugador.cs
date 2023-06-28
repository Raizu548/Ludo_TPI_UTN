using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo_Final
{
    internal class Jugador
    {
        protected int id;
        protected Color colorJugador;
        protected List<Ficha> fichasEnCasa = new List<Ficha>();
        protected List<Ficha> fichaJuego = new List<Ficha>();
        protected List<Ficha> fichaRecorridoFinal = new List<Ficha>();
        protected List<Ficha> fichaMeta = new List<Ficha>();
        protected List<BotonPersonalizado> ruta = new List<BotonPersonalizado>();

        public Jugador(int id, List<Ficha> fichas, List<BotonPersonalizado> ruta)
        {
            this.id = id;
            fichasEnCasa = fichas;
            this.ruta = ruta;
            colorJugador = generarColor();
            actualizarColorFicha();
        }

        // Geters
        public Color getColor() { return colorJugador; }
        public bool getFichaJuego() { return fichaJuego.Count > 0; }

        public BotonPersonalizado posicionMover(BotonPersonalizado ubicacion, int desplazamiento)
        { // obtiene el boton al que se puede mover la ficha

            if (ubicacion == null) return ruta[0];
            else
            {
                int posBoton = ruta.IndexOf(ubicacion);
                int nuevaPosicion = posBoton + desplazamiento;

                if (nuevaPosicion <= ruta.Count) return ruta[nuevaPosicion];
                return null;
            }

        }

        public bool pasaFinal(int desplazamiento, BotonPersonalizado ubicacion)
        {
            int posBoton = ruta.IndexOf(ubicacion);
            int nuevaPosicion = posBoton + desplazamiento;
            return nuevaPosicion > ruta.Count;
        }

        public void ponerFichaJuego(Ficha f)
        {
            fichasEnCasa.Remove(f);
            fichaJuego.Add(f);
        }

        public void ponerFichaCasa(Ficha f)
        {
            fichaJuego.Remove(f);
            fichasEnCasa.Add(f);
        }

        public void ponerFichaMeta(Ficha f)
        {
            fichaRecorridoFinal.Remove(f);
            fichaMeta.Add(f);
            f.desactivarFicha();
        }

        public void ponerFichaRecorridoFinal(Ficha f)
        {
            fichaRecorridoFinal.Add(f);
            fichaJuego.Remove(f);
        }

        public void entroAlRecorrido(Ficha f)
        {
            int pos = ruta.IndexOf(f.GetUbicacion());
            if (pos >= ruta.Count - 6)
            {
                if (fichaJuego.Contains(f))
                {
                    ponerFichaRecorridoFinal(f);
                }

            }

            if (pos == ruta.Count)
            {
                ponerFichaMeta(f);
            }
        }

        public bool gano()
        {
            return fichaMeta.Count == 4;
        }

        private Color generarColor()
        {
            Color color;
            switch (id)
            {
                case 0: color = Color.Lime; break;
                case 1: color = Color.Blue; break;
                case 2: color = Color.Red; break;
                case 3: color = Color.Yellow; break;
                default: color = Color.White; break;
            }

            return color;
        }

        private void actualizarColorFicha()
        {
            foreach (Ficha f in fichasEnCasa)
            {
                f.setColor(this.colorJugador);
            }
        }
    }
}
