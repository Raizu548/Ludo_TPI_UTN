using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo_Final
{
    internal class Ficha
    {
        private PictureBox b_ficha;
        private int id;
        private Color color;
        private BotonPersonalizado ubicacion;
        private Point posInicial;
        private System.Timers.Timer timer;
        private bool enMovimiento = false;
        private bool enCasa = true;

        public Ficha(int id, PictureBox ficha)
        {
            SetTimer();
            this.b_ficha = ficha;
            posInicial = ficha.Location;
            this.id = id;
        }

        public bool GetEnMovimiento() { return enMovimiento; }
        public BotonPersonalizado GetUbicacion() { return ubicacion; }
        public int GetId() { return id; }
        public PictureBox getFicha() { return b_ficha; }
        public bool getEnCasa() { return enCasa; }
        public Color GetColor() { return color; }
        public void setColor(Color color) { this.color = color; }
        
        public void volverACasa()
        {
            b_ficha.Location = posInicial;
            ubicacion = null;
            enCasa = true;
        }

        public void ponerFichaJuego(BotonPersonalizado boton)
        { //Pone a la ficha en el punto de inicio para poder moverse
            enCasa = false;
            ubicacion = boton;
        }

        public void activarFicha()
        {
            b_ficha.Enabled = true;
            b_ficha.BackColor = Color.Pink;
        }

        public void desactivarFicha()
        {
            b_ficha.Enabled = false;
            b_ficha.BackColor = Color.Transparent;
        }

        public void achicar()
        {
            b_ficha.Size = new Size(20, 20);
        }

        public void agrandar()
        {
            b_ficha.Size = new Size(30, 30);
        }

        public void MoverFicha(BotonPersonalizado boton)
        {
            ponerFichaJuego(boton);
            enMovimiento = true; // Se avisa que esta en movimiento
            timer.Start(); // Inicializa la animacion
        }

        private void SetTimer() // Crea el timer
        {
            // Create a timer with a two second interval.
            timer = new System.Timers.Timer(10);
            // Hook up the Elapsed event for the timer. 
            timer.Elapsed += OnTimerEvent; // enlaza el timer, con el metodo que esta mas abajo
            timer.AutoReset = true;
            timer.Enabled = false;
        }

        private void OnTimerEvent(object sender, EventArgs e) // Movimiento de la ficha
        {
            try
            {
                // Esta secuencia se ejecuta cada 20 milisegundos
                if (this.b_ficha.Location.X != ubicacion.getPointCentral().X)
                {
                    if (this.b_ficha.Location.X < ubicacion.getPointCentral().X)
                        this.b_ficha.Left++;
                    else
                        this.b_ficha.Left--;
                }

                if (b_ficha.Location.Y != ubicacion.getPointCentral().Y)
                {
                    if (this.b_ficha.Location.Y < ubicacion.getPointCentral().Y)
                        this.b_ficha.Top++;
                    else
                        this.b_ficha.Top--;
                }

                if (this.b_ficha.Location.X == ubicacion.getPointCentral().X && this.b_ficha.Location.Y == ubicacion.getPointCentral().Y)
                {
                    enMovimiento = false;
                    timer.Stop();
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción específica
                Console.WriteLine("Se produjo una excepción: " + ex.Message);
            }

        }

        public bool Equals(PictureBox obj)
        { // busca por posicion en la memoria si estan en la misma pos es el mismo objeto
            if (obj == null) return false;
            return obj == b_ficha;
        }
    }
}
