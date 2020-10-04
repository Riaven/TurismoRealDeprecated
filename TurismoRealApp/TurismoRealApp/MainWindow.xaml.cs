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
using ControladorBD;
using Modelo;

namespace TurismoRealApp
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_buscar_Click(object sender, RoutedEventArgs e)
        {
            if (!tbx_id.Text.Equals(string.Empty))
            {
                //falta controlar excepcion si es que el digito no es un número
                int id = int.Parse(tbx_id.Text);
                ServicioExtra servicio_extra = null;
                servicio_extra = ServicioExtraController.BuscarServicioExtra(id);
               

                //pintando los tbx
                if (servicio_extra.Id_servicio_extra != 0)
                {
                    tbx_id.Text = servicio_extra.Id_servicio_extra.ToString();
                    tbx_descripcion.Text = servicio_extra.Descripcion.ToString();
                }
                else
                {
                    MessageBox.Show($"No se ha encontrado registro con id {id}", "No encontrado", MessageBoxButton.OK);
                }
                
            }
            else
            {
                MessageBox.Show("Debe ingresar un ID a buscar", "Campo vacío", MessageBoxButton.OK);
            }
        }

        private void btn_crear_Click(object sender, RoutedEventArgs e)
        {
            if (!tbx_id.Text.Equals(string.Empty) && !tbx_descripcion.Text.Equals(string.Empty))
            {
                //falta controlar que el dígito no es un número


            }
            else
            {
                MessageBox.Show("Ningun campo debe estar vacío al crear un nuevo registro", "Campos vacíos", MessageBoxButton.OK);
            }
        }
    }
}
