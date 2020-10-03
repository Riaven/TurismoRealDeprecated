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
            int id = int.Parse(tbx_id.Text);
            string nota = string.Empty;
            nota = ControladorBD.ServicioExtraController.BuscarServicioExtra(id);
            lbl_nota.Content = nota;
        }
    }
}
