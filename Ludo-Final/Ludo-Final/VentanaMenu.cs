using Ludo_TPI;

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
            TableroLudo ventanaTableroLudo = new TableroLudo(1,true);
            ventanaTableroLudo.Show();
        }
    }
}