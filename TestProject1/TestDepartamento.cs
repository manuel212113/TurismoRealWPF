namespace TestProject1


{
    [TestClass]
    public class TestDepartamento
    {
        [TestMethod]
        public void AgregarTest()
        {
            TurismoReal.Capa_Negocio.Departamento.Departamento dep = new Departamento();

            string nombre = "El TiTo";
            string direccion = "las torres";
            string descripcion = "El mejor departamento";
            string metros_cuadrados = "200";
            string habitaciones = "23445555";
            string banos = "1";
            string region = "Metropolitana";
            string comuna = "Melipilla";
            string valor_arriendo = "10000";
            string fecha = "23-10-2022";
            string habilitado = "si";
            string imagen = "";


            string resultado=dep.AgregarDepartamento(nombre, direccion, descripcion, metros_cuadrados, habitaciones, banos, region, comuna, valor_arriendo, fecha, habilitado, imagen);

            Assert.AreEqual("Exito",resultado);
        }
    }
}