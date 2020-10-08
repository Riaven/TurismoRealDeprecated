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
    }
}
