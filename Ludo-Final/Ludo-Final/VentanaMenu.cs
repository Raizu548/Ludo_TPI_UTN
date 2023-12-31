using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ludo_Final
{
    public partial class VentanaMenu : Form
    {

        public VentanaMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TableroLudo ventanaTableroLudo = new TableroLudo(1, true);
            ventanaTableroLudo.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TableroLudo ventanaTableroLudo = new TableroLudo(2, false);
            ventanaTableroLudo.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TableroLudo ventanaTableroLudo = new TableroLudo(4, false);
            ventanaTableroLudo.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TableroLudo ventanaTableroLudo = new TableroLudo(3, false);
            ventanaTableroLudo.Show();
        }
    }
}