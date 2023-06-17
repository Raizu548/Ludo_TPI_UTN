using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo_Final
{
    internal class Ficha
    {
        private Button b_ficha;
        private int id;
        private BotonPersonalizado ubicacion;
        private Label inicio;
        private System.Timers.Timer timer;
        private bool enMovimiento = false;

        public Ficha(int id, Button ficha, Label b_inicio)
        {
            SetTimer();
            this.b_ficha = ficha;
            this.id = id;
            this.inicio = b_inicio;
            PosicionarFicha();
        }

        public bool GetEnMovimiento() { return enMovimiento; }
        public BotonPersonalizado GetUbicacion() { return ubicacion; }
        public int GetId() { return id; }
        
        private void PosicionarFicha()
        {
            b_ficha.Location = inicio.Location;
        }

        public void MoverFicha(BotonPersonalizado boton)
        {
            ubicacion = boton; // se le pasa a donde se va a mover
            enMovimiento = true; // Se avisa que esta en movimiento
            timer.Start(); // Inicializa la animacion
        }

        public void comerFicha(Ficha f)
        {
            f.PosicionarFicha();
        }

        public void ponerFichaJuego()
        { //Pone a la ficha en el punto de inicio para poder moverse
            int[] posiciones = ubicacion.GetPosCentral();
            b_ficha.Location = new Point(posiciones[0], posiciones[1]);
        }

        public bool Equals(Button obj)
        { // busca por posicion en la memoria si estan en la misma pos es el mismo objeto
            if (obj == null) return false;
            return obj == b_ficha;
        }

        private void SetTimer()
        {
            // Create a timer with a two second interval.
            timer = new System.Timers.Timer(20);
            // Hook up the Elapsed event for the timer. 
            timer.Elapsed += OnTimerEvent; // enlaza el timer, con el metodo que esta mas abajo
            timer.AutoReset = true;
            timer.Enabled = false;
        }

        private void OnTimerEvent(object sender, EventArgs e)
        {
            // Esta secuencia se ejecuta cada 20 milisegundo
            if (b_ficha.Location.X != ubicacion.GetPosCentralX())
            {
                if (b_ficha.Location.X < ubicacion.GetPosCentralX()) b_ficha.Left++;
                else b_ficha.Left--;
            }

            if (b_ficha.Location.Y != ubicacion.GetPosCentralY())
            {
                if (b_ficha.Location.Y < ubicacion.GetPosCentralY()) b_ficha.Top++;
                else b_ficha.Top--;
            }

            if (b_ficha.Location.X == ubicacion.GetPosCentralX() && b_ficha.Location.Y == ubicacion.GetPosCentralY())
            {
                timer.Stop();
                enMovimiento = false;
            }
        }
    }
}
