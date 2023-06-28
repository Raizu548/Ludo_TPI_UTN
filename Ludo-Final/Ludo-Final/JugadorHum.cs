using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo_Final
{
    internal class JugadorHum : Jugador
    {

        public JugadorHum(int id, List<Ficha> fichas, List<BotonPersonalizado> ruta) : base (id, fichas, ruta) { }

        public void activarFichaJuego() // Activa las fichas en juego
        {
            if (fichaJuego != null)
            {
                foreach (Ficha f in fichaJuego)
                {
                    f.activarFicha();
                }
                // Activa fichas al final de recorrido
            }
        }

        public void activarFichaRecorridoFinal(int dado)
        {
            foreach (Ficha f in fichaRecorridoFinal)
            {
                int pos = ruta.IndexOf(f.GetUbicacion());
                if (pos + dado <= ruta.Count)
                {
                    f.activarFicha();
                }
            }
        }

        public void activarFichas() // Activa todas las fichas
        {
            activarFichaJuego();
            if (fichasEnCasa != null)
            {
                foreach (Ficha f in fichasEnCasa)
                {
                    f.activarFicha();
                }
            }
        }

        public void desactivarFichas() // Desactiva las fichas
        {
            if (fichasEnCasa != null)
            {
                foreach (Ficha f in fichasEnCasa)
                {
                    f.desactivarFicha(); 
                }
            }

            if (fichaJuego != null)
            {
                foreach (Ficha f in fichaJuego)
                {
                    f.desactivarFicha();
                }
            }
        }

    }
}
