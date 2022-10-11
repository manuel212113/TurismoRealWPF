using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
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
using TurismoReal.Capa_Negocio.Departamento;
using TurismoReal.Capa_Negocio.Usuario;

namespace TurismoReal_Escritorio.Paginas
{
    /// <summary>
    /// Lógica de interacción para Inicio.xaml
    /// </summary>
    
    public partial class Inicio : Page
    {

        OracleConnection cone = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id = C##TR; Password=123");

        public Inicio()

        {
            InitializeComponent();

            Departamento dep = new Departamento();

            ObservableCollection<Departamento> depa_l= new ObservableCollection<Departamento>();

            dep.LISTAR_DEPARTAMENTOS(depa_l, departamento_data_grid);
            Departamento_depa.Text = "DEPARTAMENTO: " + depa_l.Count.ToString();
        }


        

        private void btnAgregarDepa_Click(object sender, RoutedEventArgs e)
        {
            VentanaAgregarusuario.IsOpen = true;
            
        }

     
        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void textBoxFilter_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBoxFilter_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
