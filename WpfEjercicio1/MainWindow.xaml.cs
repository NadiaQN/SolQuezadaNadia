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

namespace WpfEjercicio1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.cbxServicios.Items.Add("Divorcio");
            this.cbxServicios.Items.Add("Herencias");
            this.cbxServicios.Items.Add("Comerciales");
            this.cbxServicios.SelectedItem = "Divorcio";

        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            this.txtNombreCliente.Text = string.Empty;
            this.txtHorasEstimadas.Text = string.Empty;
            this.lblTotal.Content = string.Empty;
            this.lblAdelanto.Content = string.Empty;
            this.lblMensaje.Content = string.Empty;
            this.cbxServicios.SelectedItem = "Divorcio";
            this.lblMensaje.Background = Brushes.Transparent;
        }

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            // Variables
            string nombreCliente, tipoServicio, strHorasEstimadas;
            double valorHora, horasEstimadas, totalServicio, adelantoServicio;

            nombreCliente = this.txtNombreCliente.Text;
            tipoServicio = this.cbxServicios.Text;
            strHorasEstimadas = this.txtHorasEstimadas.Text;
            valorHora = 0;

            double.TryParse(strHorasEstimadas, out horasEstimadas);

            // Se asigna el valor hora según cada servicio
            switch (tipoServicio)
            {
                case "Divorcio":
                    valorHora = 10000;
                    break;

                case "Herencias":
                    valorHora = 15000;
                    break;

                case "Comerciales":
                    valorHora = 25000;
                    break;
            }

            // Calcular valor total del servicio
            totalServicio = valorHora * horasEstimadas;

            // Calcular adelanto a pagar
            adelantoServicio = totalServicio * 0.4;


            // Validar que el minimo sea de $100.000
            if (totalServicio < 100000)
            {
                this.lblTotal.Content = "$" + totalServicio;
                this.lblMensaje.Content = "El minimo para cotizar es $100.000";
                this.lblMensaje.Background = Brushes.OrangeRed;

            }
            else
            {
                this.lblTotal.Content = "$" + totalServicio;
                this.lblAdelanto.Content = "$" + adelantoServicio;
            }
        }
    }
}
