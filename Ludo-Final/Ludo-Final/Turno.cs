using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo_Final
{
    internal class Turno
    {

        private List<Jugador> ordenJugadores;

        public Turno(List<Jugador> jugadores)
        {

            ordenJugadores = jugadores;

        }

        public override bool Equals(object? obj)
        {
            return obj is Turno turno &&
                   EqualityComparer<List<Jugador>>.Default.Equals(ordenJugadores, turno.ordenJugadores);
        }

        public List<Jugador> ordenarTurnos()
        {
            //OrderByDescending ordena de manera descente de Mayor a menor la lista usando el atributo "nroDado" del Jugador 
            return ordenJugadores = ordenJugadores.OrderByDescending(Jugador => Jugador.getnroDado()).ToList();

        }

        

    }
}
