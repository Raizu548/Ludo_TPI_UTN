using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo_Final
{
    internal class Dado
    {
        public String[] carasDado;

        public Dado()
        {
            String cara1 = Path.Combine(Application.StartupPath, "..", "..", "..", "..", "..", "recursos", "img", "cara1.png");
            String cara2 = Path.Combine(Application.StartupPath, "..", "..", "..", "..", "..", "recursos", "img", "cara2.png");
            String cara3 = Path.Combine(Application.StartupPath, "..", "..", "..", "..", "..", "recursos", "img", "cara3.png");
            String cara4 = Path.Combine(Application.StartupPath, "..", "..", "..", "..", "..", "recursos", "img", "cara4.png");
            String cara5 = Path.Combine(Application.StartupPath, "..", "..", "..", "..", "..", "recursos", "img", "cara5.png");
            String cara6 = Path.Combine(Application.StartupPath, "..", "..", "..", "..", "..", "recursos", "img", "cara6.png");

            carasDado = new String[] { cara1, cara2, cara3, cara4, cara5, cara6 };

        }

        //metodo que devuelve un nro al azar del 1 al 6
        public int tirarDado()

        {
            int nro = new Random().Next(1, 7);

            return nro;

        }

        //Metodo en el cual retorna la direccion de una imagen
        public String animacion(int nro)
        {
          
            String direccionImagen = "";

            switch(nro)
            {
                case 1: direccionImagen = carasDado[0];break;

                case 2: direccionImagen = carasDado[1];break;

                case 3: direccionImagen = carasDado[2];break;

                case 4: direccionImagen = carasDado[3];break;

                case 5: direccionImagen = carasDado[4];break;

                case 6: direccionImagen = carasDado[5];break;

                default:break;

            }

            return direccionImagen;
        }

    }
}
