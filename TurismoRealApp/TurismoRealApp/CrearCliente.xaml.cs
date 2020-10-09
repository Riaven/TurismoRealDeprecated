using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;
using ControladorBD;
using Modelo;

namespace TurismoRealApp
{
    /// <summary>
    /// Lógica de interacción para CrearCliente.xaml
    /// </summary>
    public partial class CrearCliente : Window
    {
        public CrearCliente()
        {
            InitializeComponent();
            cbx_nacionalidad.DataContext = null;
            CargarCbxNacionalidad();
            CargarCbxRegion();
            CargarCbxComuna();
            CargarCbxFrecuente();
        }

        

        //MÉTODOS PARA CARGAR COMBOBOX
        void CargarCbxNacionalidad()
        {
            //cbx_nacionalidad.
            foreach (Nacionalidad nac in NacionalidadController.ListarNacionalidad())
            {
                cbx_nacionalidad.Items.Add(nac.Descripcion);
                cbx_nacionalidad.SelectedIndex = 0;
                Console.WriteLine($"id {nac.Id_nacionalidad}  nombre {nac.Descripcion}");
            }
        }

        void CargarCbxRegion()
        {
            //cbx_nacionalidad.
            foreach (Region region in RegionController.ListarRegion())
            {
                cbx_region.Items.Add(region.Nombre);
                cbx_region.SelectedIndex = 0;
                Console.WriteLine($"id {region.Id_region}  nombre {region.Nombre}");
            }
        }

        void CargarCbxComuna()
        {
            //cbx_nacionalidad.
            foreach (Comuna comuna in ComunaController.ListarComuna())
            {
                cbx_comuna.Items.Add(comuna.Nombre);
                cbx_comuna.SelectedIndex = 0;
                Console.WriteLine($"id {comuna.Id_comuna}  nombre {comuna.Nombre}");
            }
        }

        void CargarCbxFrecuente()
        {
            cbx_frecuente.Items.Add("Si");
            cbx_frecuente.Items.Add("No");
            cbx_frecuente.SelectedIndex = 0;
        }

        private void btn_crear_Click(object sender, RoutedEventArgs e)
        {
            int estado;
            //tomamos los datos de la ventana
            if (!tbx_id.Text.Equals(string.Empty) && !tbx_rut.Text.Equals(string.Empty) && !tbx_nombre.Text.Equals(string.Empty) && !tbx_primer_ape.Text.Equals(string.Empty) && !tbx_segundo_ape.Text.Equals(string.Empty) && !tbx_direccion.Text.Equals(string.Empty) && !tbx_rut.Text.Equals(string.Empty) && !tbx_telefono.Text.Equals(string.Empty) && !tbx_correo.Text.Equals(string.Empty))
            {
                int id_cliente = int.Parse(tbx_id.Text);
                string rut = tbx_rut.Text;
                string nombre = tbx_nombre.Text;
                string primer_ape = tbx_primer_ape.Text;
                string segundo_ape =  tbx_segundo_ape.Text;
                string direccion = tbx_direccion.Text;
                string telefono = tbx_telefono.Text;
                DateTime fecha_nac = dp_fecha_nac.SelectedDate.Value;
                string correo = tbx_correo.Text;
                int frecuente = cbx_frecuente.SelectedIndex;
                int comuna_id = cbx_comuna.SelectedIndex;
                int region_id = cbx_region.SelectedIndex;
                int nacionalidad_id = cbx_nacionalidad.SelectedIndex;

                estado = ClienteController.CrearCliente(id_cliente,rut, nombre, primer_ape, segundo_ape, direccion, telefono, fecha_nac,correo, frecuente, comuna_id, region_id, nacionalidad_id);

                if (estado == -1)
                {
                    MessageBox.Show("Error al crear registro, problemas con BD", "Error BD", MessageBoxButton.OK);
                }
                else if (estado > 0)
                {
                    MessageBox.Show("Registro ya existente", "Id duplicada", MessageBoxButton.OK);
                }
                else
                {
                    MessageBox.Show("Registro creado con éxito", "Registro creado", MessageBoxButton.OK);
                }
            }

            
            List<Cliente> clientes = ClienteController.ListarCliente();

            gv_lista_cliente.ItemsSource = clientes;
        }

    

        private void gv_lista_cliente_Loaded(object sender, RoutedEventArgs e)
        {
            List<Cliente> clientes = ClienteController.ListarCliente();

            gv_lista_cliente.ItemsSource = clientes; //mejorar
        }

        private void btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            if (!tbx_id.Equals(string.Empty))
            {
                //!tbx_id.Equals(string.Empty) ? tbx_id.Text : 
                int id = int.Parse(tbx_id.Text);
                int estado = 0;
                try
                {
                    estado = ClienteController.EliminarCliente(id);
                    if (estado == -1)
                    {
                        MessageBox.Show("Error al eliminar registro, problemas con BD", "Error BD", MessageBoxButton.OK);
                    }
                    else if (estado == 0)
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
                    MessageBox.Show($"Error al eliminar {ex}", "Error", MessageBoxButton.OK);
                }

            }
            else
            {
                MessageBox.Show("Debes seleccionar un registro o digitar un id", "Eliminar", MessageBoxButton.OK);
            }
            gv_lista_cliente.ItemsSource = null;
            List<Cliente> clientes = ClienteController.ListarCliente();

            gv_lista_cliente.ItemsSource = clientes;
        }

        private void btn_buscar_Click(object sender, RoutedEventArgs e)
        {
            if (!tbx_id.Text.Equals(string.Empty))
            {
                Cliente cliente = ClienteController.BuscarCliente(int.Parse(tbx_id.Text));

                tbx_id.Text = cliente.Id_cliente.ToString();
                tbx_rut.Text = cliente.Rut;
                tbx_nombre.Text = cliente.Nombre;
                tbx_primer_ape.Text = cliente.Primer_ape;
                tbx_segundo_ape.Text = cliente.Segundo_ape;
                tbx_direccion.Text = cliente.Direccion;
                tbx_telefono.Text = cliente.Telefono;
                dp_fecha_nac.SelectedDate = cliente.Fecha_nac;
                tbx_correo.Text = cliente.Correo;
                cbx_frecuente.SelectedIndex = cliente.Frecuente;
                cbx_comuna.SelectedIndex = cliente.Comuna.Id_comuna;
                cbx_region.SelectedIndex = cliente.Region.Id_region;
                cbx_nacionalidad.SelectedIndex = cliente.Nacionalidad.Id_nacionalidad;

            }
        }

        private void btn_modificar_Click(object sender, RoutedEventArgs e)
        {
            int id_cliente = int.Parse(tbx_id.Text);
            string rut = tbx_rut.Text;
            string nombre = tbx_nombre.Text;
            string primer_ape = tbx_primer_ape.Text;
            string segundo_ape = tbx_segundo_ape.Text;
            string direccion = tbx_direccion.Text;
            string telefono = tbx_telefono.Text;
            DateTime fecha_nac = dp_fecha_nac.SelectedDate.Value;
            string correo = tbx_correo.Text;
            int frecuente = cbx_frecuente.SelectedIndex;
            int comuna_id = cbx_comuna.SelectedIndex;
            int region_id = cbx_region.SelectedIndex;
            int nacionalidad_id = cbx_nacionalidad.SelectedIndex;

            int estado = 0;

            try
            {
                estado = ClienteController.ModificarCliente(id_cliente, rut, nombre, primer_ape, segundo_ape, direccion, telefono, fecha_nac, correo, frecuente, comuna_id, region_id, nacionalidad_id);
                if (estado == -1)
                {
                    MessageBox.Show("Error al modificar registro, problemas con BD", "Error BD", MessageBoxButton.OK);
                }
                else if (estado == 0)
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

            gv_lista_cliente.ItemsSource = null;
            List<Cliente> clientes = ClienteController.ListarCliente();

            gv_lista_cliente.ItemsSource = clientes;

        }
    }
}
