using Microsoft.Graph;
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

namespace TurismoReal_Escritorio.Paginas
{

  public partial class Informe : Window
  {
    public Informe(string ganancias, string cant_rese )
    {
      InitializeComponent();
      txtCantReservas.Text = cant_rese;
      txtGanancias.Text = ganancias;
      txtTotal.Text = ganancias;
      txtFecha.Text = DateTime.Now.ToString("dddd , MMM dd yyyy,hh:mm:ss"); ;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        this.IsEnabled = false;
        PrintDialog printDialog = new PrintDialog();
        if (printDialog.ShowDialog() == true)
        {
          printDialog.PrintVisual(print, "invoice");
        }
      }
      finally
      {
        this.IsEnabled = true;
      }
    }
  }
}
