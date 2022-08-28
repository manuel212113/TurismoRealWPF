using System;
using System.Windows;
using TurismoReal.Capa_Negocio;


namespace TurismoReal.Capa_Negocio
{
    public static class ControladorTema
    {
        public static TiposTema temaActual { get; set; }
        public static Uri UrlTema { get; set; }


        public enum TiposTema
        {
            Oscuro, Claro,
            
        }

        public static ResourceDictionary DiccionarioTema
        {
            get { return Application.Current.Resources.MergedDictionaries[0]; }
            set { Application.Current.Resources.MergedDictionaries[0] = value; }
        }

        private static  Uri DevolverUrlTema(Uri uri)
        {

            return (uri);
        
        }
        public static void EstablecerTema(TiposTema tema)
        {
            string nombreTema = "";
            temaActual = tema;

            switch (tema)
            {
                case TiposTema.Oscuro: nombreTema = "TemaOscuro"; break;
                case TiposTema.Claro: nombreTema = "TemaClaro"; break;

            }
            try
            {
                if (!string.IsNullOrEmpty(nombreTema))
                    UrlTema = new Uri("Temas/" + nombreTema + ".xaml", UriKind.RelativeOrAbsolute);
                DevolverUrlTema(UrlTema);
            }
            catch
            {

            }
        }

    }

}
