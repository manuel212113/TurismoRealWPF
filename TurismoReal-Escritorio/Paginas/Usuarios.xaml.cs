using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data.OracleClient;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TurismoReal_Escritorio.Paginas
{
    /// <summary>
    /// Lógica de interacción para Inicio.xaml
    /// </summary>
    public partial class Usuarios : Page
    {
        public Usuarios()
        {
            InitializeComponent();
        }

        private void btnAgregarUsuario_Click(object sender, RoutedEventArgs e)
        {
            VentanaAgregarusario.IsOpen = true;

        }

 //       OracleConnection cone = new OracleConnection("DATA SOURCE = xe ; PASSWORD = 123 ; USER ID = TURISMOREALWPF");

        private void btnGuardarUsuario_Click(object sender, RoutedEventArgs e)
        {
            try 
            { 
            cone.Open();
            OracleCommand comando3 = new OracleCommand("insertar", cone);
            comando3.CommandType = System.Data.CommandType.StoredProcedure;
            comando3.Parameters.Add("rut", OracleType.VarChar).Value = TxtRUT.Text;
            comando3.Parameters.Add("nom", OracleType.VarChar).Value = TxtNombre.Text;
            comando3.Parameters.Add("apell", OracleType.VarChar).Value = TxtApellido.Text;
            comando3.Parameters.Add("gene", OracleType.VarChar).Value = TxtGenero.Text;
            comando3.Parameters.Add("eda", OracleType.VarChar).Value = TxtEdad.Text;
            comando3.Parameters.Add("est", OracleType.VarChar).Value = TxtEstado_civil.Text;
            comando3.Parameters.Add("mail", OracleType.VarChar).Value = TxtCorreo.Text;
            comando3.Parameters.Add("comu", OracleType.VarChar).Value = TxtComuna.Text;
            comando3.Parameters.Add("contra", OracleType.VarChar).Value = TxtContrasena.Text;
            comando3.ExecuteNonQuery();
            MessageBox.Show("Persona agregada a la base de datos");
                cone.Close();
            }
            catch
            {
                MessageBox.Show("No se agrego la persona a la base de datos");
                cone.Close();

            }
            

        }
    }
}
