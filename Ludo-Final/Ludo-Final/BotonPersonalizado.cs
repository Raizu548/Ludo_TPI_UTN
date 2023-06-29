using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo_Final
{
    enum Tipo { Seguro, NoSeguro, Final}
    internal class BotonPersonalizado
    {
        private Button boton;
        private int id;
        private Tipo tipo;
        private Point pointCentral = new Point();
        private Color cActivado;
        private Color cDesactivado;
        private List<Ficha> listaFichas = new List<Ficha>();
        private List<Point> listUbicacion = new List<Point>();

        public BotonPersonalizado(Button boton, int id, Tipo tipo, Color cActivado)
        {
            this.boton = boton;
            this.id = id;
            this.tipo = tipo;
            this.cDesactivado = boton.BackColor;
            this.cActivado = cActivado;
            this.pointCentral = ObtenerPosCentral(boton);
            cargarPuntos();
        }

        public Button GetBoton() { return boton; }
        public int GetId() { return id; }
        public Point getPointCentral() { return pointCentral; }
        public bool esSeguro() { return tipo == Tipo.Seguro; }
        public int getCantFichas() { return listaFichas.Count; }
        public bool tieneFicha() { return listaFichas.Count > 0; }

        public void activarBoton()
        {
            this.boton.BackColor = cActivado;
            boton.Enabled = true;
        }

        public void desactivarBoton()
        {
            this.boton.BackColor = cDesactivado;
            boton.Enabled = false;
        }

        private Point ObtenerPosCentral(Button boton)
        {
            pointCentral = new Point(boton.Location.X + 8, boton.Location.Y + 8);
            return pointCentral;
        }

        private void cargarPuntos()
        {
            // Carga los 4 puntos donde se puede posicionar la fichas
            Point punto = new Point(boton.Location.X, boton.Location.Y);
            listUbicacion.Add(punto);
            punto = new Point(boton.Location.X + 26, boton.Location.Y);
            listUbicacion.Add(punto);
            punto = new Point(boton.Location.X , boton.Location.Y +26);
            listUbicacion.Add(punto);
            punto = new Point(boton.Location.X + 26, boton.Location.Y +26);
            listUbicacion.Add(punto);
        }

        public void agregarFicha(Ficha f) // Agrega una ficha al boton
        { 
            if (listaFichas.Count == 0)
            {
                listaFichas.Add(f);
            }
            else
            {
                if (listaFichas.Count < 5)
                {
                    listaFichas.Add(f);
                    cambiarPosicion();
                }
            }
        }

        public void sacarFicha(Ficha f) // Saca la ficha del boton
        {
            if (listaFichas.Count > 1) f.agrandar(); // al sacar la ficha lo vuevlo a su tamaño normal

            listaFichas.Remove(f);
            if (listaFichas.Count == 1)
            {// si queda una sola ficha lo pongo en tamaño normal y en la pocision central
                Ficha aux = listaFichas[0];
                aux.getFicha().Location = new Point(pointCentral.X, pointCentral.Y);
                aux.agrandar();
            }
            else
            {
                cambiarPosicion();
            }
        }

        public void logicaComer(Ficha f, Jugador jugador, List<Jugador> jugadores) 
        {
            // Logica de comprobar si hay una ficha extra sino comer
            if (!esSeguro())
            {
                if (tieneFicha())
                {
                    if (getCantFichas() == 1)
                    { // si ya hay una ficha comprueba si puede comer
                        comprobarCome(f, jugador, jugadores);
                    }
                    else
                    { // si no hay una ficha o hay mas de 2 agrega la ficha nueva
                        agregarFicha(f);
                    }
                }
                else
                { // si no hay ficha solo agrega
                    agregarFicha(f);
                }
            }
            else
            {
                agregarFicha(f);
            }

        }

        public void comprobarCome(Ficha f, Jugador jugador, List<Jugador> jugadores) // comprueba si se puede comer otra ficha
        {
            if (f.GetColor() != listaFichas[0].GetColor())
            {
                Ficha fsale = listaFichas[0];
                listaFichas.Remove(fsale);
                fsale.volverACasa();

                Jugador jugadorEnemigo = jugadores.Find(x => x.getColor() == fsale.GetColor());
                jugadorEnemigo.ponerFichaCasa(fsale);

                listaFichas.Add(f);
            }
            else
            {
                listaFichas.Add(f);
                cambiarPosicion();
            }
        }

        private void cambiarPosicion() // ordena las fichas
        {
            int i = 0;
            foreach (Ficha f in listaFichas)
            {
                f.achicar();
                f.getFicha().Location = new Point(listUbicacion[i].X, listUbicacion[i].Y);
                i++;
            }
        }

    }
}
