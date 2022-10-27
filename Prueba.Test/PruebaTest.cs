using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TurismoReal.Capa_Negocio.Departamento;



namespace Prueba.Test
{
    [TestClass]
    public class PruebaTest
    {

        [TestMethod]
        public void AgregarTest()
        {


           string nombre = "El TiTo",
           string  direccion = "las torres",
           string descripcion = "El mejor departamento",
           string metros_cuadrados = "200",
           string habitaciones = "23445555",
           string banos = "1",
           string region = "Metropolitana",
          string comuna = "Melipilla",
           string valor_arriendo = "10000",
          string fecha = "23-10-2022",
          string habilitado = "si",
           string imagen = ""


            dep.AgregarDepartamento(nombre, direccion, descripcion, metroscuadrados, habitaciones, banos, region, comuna, valorarriendo, fecha, habilitado, imagen);


        }


    }
}
    

