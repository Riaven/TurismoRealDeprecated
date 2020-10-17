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
        //constantes
        const int ERROR_BASE_DATOS = -1;
        const int FILA_MODIFICADA = 1;
        const int NO_MODIFICADO = 0;


        //métodos de ventana
        private void LimpiarVentana()
        {
            tbx_descripcion.Text = string.Empty;
            tbx_id.Text = string.Empty;
        }
        //buscar un servicio extra
        
        private void btn_buscar_Click(object sender, RoutedEventArgs e)
        {
            List<ServicioExtra> servicios_extra = new List<ServicioExtra>();
            if (!tbx_buscar_pro.Equals(string.Empty))
            {
                if ((bool)id.IsChecked)
                {
                    servicios_extra = ServicioExtraController.BuscarServicioExtra(int.Parse(tbx_buscar_pro.Text), null);
                }
                else
                {
                    servicios_extra = ServicioExtraController.BuscarServicioExtra(null, tbx_buscar_pro.Text);
                }

                gv_lista_se.ItemsSource = null;
                gv_lista_se.ItemsSource = servicios_extra;
            }
            else
            {
                MessageBox.Show("El campo debe tener datos par buscar", "Campo vacío", MessageBoxButton.OK);
            }
        }
        //Crear un servicio extra
        private void btn_crear_Click(object sender, RoutedEventArgs e)
        {
            if (!tbx_id.Text.Equals(string.Empty) && !tbx_descripcion.Text.Equals(string.Empty))
            {
                //falta controlar que el dígito no es un número
                int id = int.Parse(tbx_id.Text);
                string descripcion = tbx_descripcion.Text;
                int estado = 0;

                estado = ServicioExtraController.CrearServicioExtra(id, descripcion);
                if(estado == ERROR_BASE_DATOS)
                {
                    MessageBox.Show("Error al crear registro, problemas con BD", "Error BD", MessageBoxButton.OK);
                }
                else if (estado == NO_MODIFICADO)
                {
                    MessageBox.Show("Registro ya existente", "Id duplicada", MessageBoxButton.OK);
                }
                else
                {
                    MessageBox.Show("Registro creado con éxito", "Registro creado", MessageBoxButton.OK);
                }
                
                LimpiarVentana();
                ActualizarGrilla();
            }
            else
            {
                MessageBox.Show("Ningún campo debe estar vacío al crear un nuevo registro", "Campos vacíos", MessageBoxButton.OK);
            }
        }

        

        private void btn_modificar_Click(object sender, RoutedEventArgs e)
        {
            if (!tbx_id.Text.Equals(string.Empty) && !tbx_descripcion.Text.Equals(string.Empty))
            {
                int id = int.Parse(tbx_id.Text);
                string descripcion = tbx_descripcion.Text;
                int estado = 0;

                try
                {
                    estado = ServicioExtraController.ModificarServicioExtra(id, descripcion);
                    if (estado == ERROR_BASE_DATOS)
                    {
                        MessageBox.Show("Error al modificar registro, problemas con BD", "Error BD", MessageBoxButton.OK);
                    }
                    else if (estado == NO_MODIFICADO)
                    {
                        MessageBox.Show("Registro no existe, no es posible modificar", "No encontrado", MessageBoxButton.OK);
                    }
                    else
                    {
                        MessageBox.Show("Registro modificado con éxito", "Registro modificado", MessageBoxButton.OK);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al modificar {ex}", "Error", MessageBoxButton.OK);
                }
                LimpiarVentana();
                ActualizarGrilla();
            }
            else
            {
                MessageBox.Show("Para modificar todos los campos deben contener datos", "Error al modificar", MessageBoxButton.OK);
            }
        }
        //eliminar
        private void btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            if (!tbx_id.Text.Equals(string.Empty))
            {
                int id = int.Parse(tbx_id.Text);
                int estado = 0;
                try
                {
                    estado = ServicioExtraController.EliminarServicioExtra(id);
                    if (estado == ERROR_BASE_DATOS)
                    {
                        MessageBox.Show("Error al eliminar registro, problemas con BD", "Error BD", MessageBoxButton.OK);
                    }
                    else if (estado == NO_MODIFICADO)
                    {
                        MessageBox.Show("Registro no existe, no es posible modificar", "No encontrado", MessageBoxButton.OK);
                    }
                    else
                    {
                        MessageBox.Show("Registro modificado con éxito", "Registro modificado", MessageBoxButton.OK);
                    }

                    LimpiarVentana();
                    ActualizarGrilla();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar {ex}", "Error", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBox.Show("Para eliminar el campo ID debe contener datos", "Error al eliminar", MessageBoxButton.OK);
            }
        }

        private void ActualizarGrilla()
        {
            gv_lista_se.ItemsSource = null;
            List<ServicioExtra> clientes = ServicioExtraController.ListarServicioExtra();

            gv_lista_se.ItemsSource = clientes;
        }

        private void gv_lista_se_Loaded(object sender, RoutedEventArgs e)
        {
            ActualizarGrilla();
        }

       
    }
}
