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
        private int[] posCentral = new int[2];

        public BotonPersonalizado(Button boton, int id, Tipo tipo)
        {
            this.boton = boton;
            this.id = id;
            this.tipo = tipo;
            this.posCentral = ObtenerPosCentral(boton);
        }

        public Button GetBoton() { return boton; }
        public int GetId() { return id; }
        public int[] GetPosCentral() { return posCentral; }
        public int GetPosCentralX() { return posCentral[0]; }
        public int GetPosCentralY() { return posCentral[1]; }
        public Tipo GetTipo() { return tipo; }

        private int[] ObtenerPosCentral(Button boton)
        {
            int[] posCentral = new int[2];

            // Lo divido por 4 ya que es la mitad de la mitad (Esto se puede hacer mejor de otra forma)
            posCentral[0] = boton.Location.X + (boton.Size.Width / 4);
            posCentral[1] = boton.Location.Y + (boton.Size.Height / 4);

            return posCentral;
        }
    }
}
