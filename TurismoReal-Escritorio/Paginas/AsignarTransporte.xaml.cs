using MaterialDesignThemes.Wpf;
using Oracle.ManagedDataAccess.Client;
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
using TurismoReal.Capa_Negocio.Departamento;
using TurismoReal.Capa_Negocio.Transporte;

namespace TurismoReal_Escritorio.Paginas
{
    /// <summary>
    /// Lógica de interacción para Actualizar_Transporte.xaml
    /// </summary>
    public partial class AsignarTransporte : Window
    {
        public AsignarTransporte(string id_reserva)
        {
            InitializeComponent();
            AsignarValorReserva(id_reserva);
        }

        string id_reserva_temp;

        OracleConnection cone = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1522)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id = C##TR; Password=123");


        public void AsignarValorReserva(string id_r)
        {

             id_reserva_temp = id_r;

        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {

            try
            {

             string CONDUCTOR = TxtCONDUCTOR.Text;
             string AUTO = TxtAUTO.Text;
             string PATENTE = TxtPATENTE.Text;


                Planificar_transporte trn = new Planificar_transporte();

                if (CONDUCTOR.Length > 1 || AUTO.Length > 1 || PATENTE.Length > 1)
                {
                    if (trn.BuscarTransporte(id_reserva_temp))
                    {
                        MessageBox.Show("La Reserva ya posee un vehiculo");

                    }
                    else
                    {
                        trn.AgregarTransporte(CONDUCTOR, AUTO, PATENTE, id_reserva_temp);

                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se agrego el transporte");
                cone.Close();

                MessageBox.Show(ex.Message);
            }

        }

    }
}
