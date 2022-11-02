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
using TurismoReal.Capa_Negocio;

namespace TurismoReal_Escritorio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Estas seguro que deseas cerrar la aplicación?", "Informacion", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                Close();
            }
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void rdHome_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void rdDepartamento_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Paginas/Departamento.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdUsuario_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Paginas/Usuarios.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdInventario_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Paginas/Inventario.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnTema_Click(object sender, RoutedEventArgs e)
        {
            if (btnTema.IsChecked==true)
            {
                ControladorTema.EstablecerTema(ControladorTema.TiposTema.Oscuro);
                Uri UrlTemaFinal = ControladorTema.UrlTema;
                ResourceDictionary TemaDiccionario = new ResourceDictionary() { Source = UrlTemaFinal };
                Application.Current.Resources.MergedDictionaries[5].Clear();
                Application.Current.Resources.MergedDictionaries[5] =TemaDiccionario;
            }
            else
            {
                ControladorTema.EstablecerTema(ControladorTema.TiposTema.Claro);
                Uri UrlTemaFinal = ControladorTema.UrlTema;
                ResourceDictionary TemaDiccionario = new ResourceDictionary() { Source = UrlTemaFinal };
                Application.Current.Resources.MergedDictionaries[5].Clear();
                Application.Current.Resources.MergedDictionaries[5] = TemaDiccionario;

            }
        }

        private void rdEstadisticas_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Paginas/Reportes.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdServicios_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Paginas/Servicios.xaml", UriKind.RelativeOrAbsolute));
        }


    }
}

