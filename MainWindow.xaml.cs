using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace di.prueba.parejas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<float> listaMovimientos = new List<float>() { 1234, 1500, -980, 1344, -670, -234, 1560, 1342, -675 };

        public MainWindow()
        {
            InitializeComponent();
        }

        private int CalcularCajasEnPallet(double largoPallet, double anchoPallet, double altoPallet,
                                          double largoCaja, double anchoCaja, double altoCaja)
        {
            int maxCajas = 0;

            int CalcularEnOrientacion(double largoCaja, double anchoCaja, double altoCaja)
            {
                int cajasEnBase = (int)(largoPallet / largoCaja) * (int)(anchoPallet / anchoCaja);
                int capasEnAltura = (int)(altoPallet / altoCaja);
                return cajasEnBase * capasEnAltura;
            }

            maxCajas = Math.Max(maxCajas, CalcularEnOrientacion(largoCaja, anchoCaja, altoCaja)); // Horizontal
            maxCajas = Math.Max(maxCajas, CalcularEnOrientacion(largoCaja, altoCaja, anchoCaja)); // 1ª Vertical
            maxCajas = Math.Max(maxCajas, CalcularEnOrientacion(anchoCaja, largoCaja, altoCaja)); // Rotación 90°
            maxCajas = Math.Max(maxCajas, CalcularEnOrientacion(anchoCaja, altoCaja, largoCaja)); // 2ª Vertical
            maxCajas = Math.Max(maxCajas, CalcularEnOrientacion(altoCaja, largoCaja, anchoCaja)); // Rotación 90° en Vertical
            maxCajas = Math.Max(maxCajas, CalcularEnOrientacion(altoCaja, anchoCaja, largoCaja)); // 3ª Vertical

            return maxCajas;
        }

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            double largoPallet = double.Parse(txtLargoPallet.Text);
            double anchoPallet = double.Parse(txtAnchoPallet.Text);
            double altoPallet = double.Parse(txtAltoPallet.Text);

            double largoCaja = double.Parse(txtLargoCaja.Text);
            double anchoCaja = double.Parse(txtAnchoCaja.Text);
            double altoCaja = double.Parse(txtAltoCaja.Text);

            int totalCajas = CalcularCajasEnPallet(largoPallet, anchoPallet, altoPallet, largoCaja, anchoCaja, altoCaja);

            // Muestra el resultado en el TextBlock txtResultado
            txtResultado.Text = $"Total de cajas que caben: {totalCajas}";
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
