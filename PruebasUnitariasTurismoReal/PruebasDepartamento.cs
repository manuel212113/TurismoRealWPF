using TurismoReal.Capa_Negocio.Departamento;

namespace PruebasUnitariasTurismoReal
{
    public class PruebasDepartamento
    {
        [Fact]
        public void CrearDepartamento()
        {
            Departamento dep = new Departamento();

            string nombre = "El TiTo";
            string direccion = "las torres";
            string descripcion = "El mejor departamento";
            string metros_cuadrados = "200";
            string habitaciones = "23445555";
            string banos = "5";
            string region = "Metropolitana";
            string comuna = "Melipilla";
            string valor_arriendo = "10000";
            string fecha = "23-10-2022";
            string habilitado = "si";
            string imagen = "";


            string resultado = dep.AgregarDepartamento(nombre, direccion, descripcion, metros_cuadrados, habitaciones, banos, region, comuna, valor_arriendo, fecha, habilitado, imagen);

            Assert.Equal("Exito", resultado);
        }

        [Fact]
        public void EliminarDepartamento()
        {
            Departamento dep = new Departamento();

            string iddepa = "10";

            string resultado = dep.EliminarDepartamento(iddepa);

            Assert.Equal("Exito", resultado);

        }


        [Fact]
        public void CargarImagen()
        {
            Departamento dep = new Departamento();

            string resultado=dep.SubirImagenPrueba("C:\\Users\\Usuario\\Desktop\\prueba22.jpg");

            Assert.Equal("Exito", resultado);

        }


    }
}