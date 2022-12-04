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
using TurismoReal.Capa_Negocio.Servicios;
using System.Runtime.Intrinsics.Arm;


using OracleCommand = Oracle.ManagedDataAccess.Client.OracleCommand;
using OracleConnection = Oracle.ManagedDataAccess.Client.OracleConnection;
using OracleDataReader = Oracle.ManagedDataAccess.Client.OracleDataReader;
using OracleParameter = Oracle.ManagedDataAccess.Client.OracleParameter;
using System.Collections.ObjectModel;
using MaterialDesignThemes.Wpf;

namespace TurismoReal_Escritorio.Paginas
{

    public partial class Transporte : Page
    {
        OracleConnection cone = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id = C##TR; Password=123");
        TurismoReal.Capa_Negocio.Transporte.Planificar_transporte trn = new TurismoReal.Capa_Negocio.Transporte.Planificar_transporte();
        public Transporte()
        {
            /*InitializeComponent();
            ObservableCollection<TurismoReal.Capa_Negocio.Transporte.Planificar_transporte> Lista1 = new ObservableCollection<TurismoReal.Capa_Negocio.Transporte.Planificar_transporte>();
            ObservableCollection<TurismoReal.Capa_Negocio.Transporte.Planificar_transporte> Lista2 = new ObservableCollection<TurismoReal.Capa_Negocio.Trasnporte.Planificar_transporte>();

            Lista1 = trn.(Lista2);
            Lista.ItemsSource = Lista1;
            .Text = "TRASNPORTE: " + Lista1.Count.ToString();

            */

            /*  public void btnAgregarServicio_click(object sender, RoutedEventArgs e)
              {
                  VentanaAgregarServicioextra.IsOpen = true;


              }

              public void btnGuardarServicio_Click(object sender, RoutedEventArgs e)
              {
                  try
                  {
                      /* string CONDUCTOR = TxtNOMBRE_SRV.Text;
                      string AUTO = TxtPRECIO.Text;
                      string PATENTE = TxtPATENTE.Text;


                        srv.AgregarServicioExtra(NOMBRESRV, PRECIO);

                      */
        }

        /*

                catch (Exception ex)
                {
                    MessageBox.Show("No se agrego el Departamento a la base de datos");
                    cone.Close();

                    MessageBox.Show(ex.Message);
                }
            }


        }
        */



    }
}
