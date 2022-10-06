using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoReal.Capa_Negocio.Departamento
{
    public  class Departamento
    {



        public int _id_depa;
        public string _nombre;
        public string _direccion;
        public string _descripcion;
        public int _metros_cuadrados;
        public int _habitaciones;
        public int _banos;
        public string _region;
        public string _comuna;
        public string _valor_arriendo;
        public string _fecha;
        public string _habilitado;

        public Departamento()
        {
            this.Init();
        }

        public void Init()
        {
            _id_depa = 0;
            _nombre = string.Empty;
            _direccion = string.Empty;
            _descripcion = string.Empty;
            _metros_cuadrados = 0;
            _habitaciones = 0;
            _banos = 0;
            _region = string.Empty;
            _comuna = string.Empty;
            _valor_arriendo = string.Empty;
            _fecha = string.Empty;
            _habilitado = string.Empty;
        }


        public void CrearDepartamento()
        {

        }
    }
}
