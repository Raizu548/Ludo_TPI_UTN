using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo_Final
{
    internal class JugadorIA : Jugador
    {
        public JugadorIA(int id, List<Ficha> fichas, List<BotonPersonalizado> ruta) : base(id, fichas, ruta) { }

        // comprobas si tengo fichas para mover
        //  - primera prioridad: ficha en casa
        //  - 2° ficha mas serca a la meta
        // selecionar ficha
        // mover ficha seleccionada

        public Ficha seleccionarFicha(int dado)
        {
            if (dado == 1 || dado == 6)
            {
                if (fichasEnCasa.Count > 0)
                {
                    BotonPersonalizado b = ruta.First(); // el inicio
                    if (b.tieneFicha())
                    {
                        Random r = new Random();
                        int result = r.Next(100);
                        if (result > 70) // muevo ficha en el inicio
                        {
                            Ficha f = fichaJuego.Find(x => x.GetUbicacion() == b);
                            return f;
                        }

                    }

                    return fichasEnCasa[0];
                }
                else
                {
                    return devolverFicha(dado);
                }
                
            }
            else if (fichaJuego.Count > 0 || fichaRecorridoFinal.Count > 0)
            {
                return devolverFicha(dado);
            }

            return null;
        }

        private Ficha devolverFicha(int dado)
        {
            if (fichaRecorridoFinal.Count > 0)
            { // si hay ficha serca de la meta
                Ficha fichaRetornar = fichaMasCercana(fichaRecorridoFinal, dado);
                if (fichaRetornar != null)
                {
                    return fichaRetornar;
                }
                else
                {
                    return fichaMasCercana(fichaJuego, dado);
                }
            }
            else
            { // ficha que esta en juego 

                foreach(Ficha f in fichaJuego)
                {
                    if (puedeComer(f, dado))
                    {
                        return f;
                    }
                }


                Random r = new Random();
                int resultado = r.Next(100);
                if (resultado > 80) 
                {
                    resultado = r.Next(fichaJuego.Count);
                    return fichaJuego[resultado];
                }

                return fichaMasCercana(fichaJuego, dado);
            }
        }

        private Ficha fichaMasCercana(List<Ficha> lista, int dado)
        { // devuelve la ficha que mas cerca este de la meta
            Ficha fichaSeleccionada = null;
            int posMayor = 0;

            foreach (Ficha ficha in lista)
            {
                int posFicha = ruta.IndexOf(ficha.GetUbicacion());
                if (posFicha >= posMayor && (posFicha + dado) < ruta.Count)
                {
                    posMayor = posFicha;
                    fichaSeleccionada = ficha;
                }
            }

            return fichaSeleccionada;
            
        }

        private bool puedeComer(Ficha ficha, int dado)
        {
            int posMover = ruta.IndexOf(ficha.GetUbicacion()) + dado;
            BotonPersonalizado nuevaPos = ruta[posMover];

            if (nuevaPos.getCantFichas() == 1)
            {
                Ficha f = fichaJuego.Find(x => x.GetUbicacion() == nuevaPos);

                if (f.GetColor() != ficha.GetColor())
                {
                    return true;
                }
            }
            return false;
        }

    }
}
