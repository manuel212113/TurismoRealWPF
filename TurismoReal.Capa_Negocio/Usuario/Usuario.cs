using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoReal.Capa_Negocio.Usuario
{
    public class usuario
    {
        public string rut { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public string genero { get; set; }
        public string contrasena { get; set; }
        public string apellido { get; set; }
        public string celular { get; set; }
        public int tipo_usuario_id_tipo_usuario { get; set; }

        public usuario(string rut_, string nombre_, string email_, string genero_, string contrasena_, string apellido_, string celular_, int tipo_usuario_id_tipo_usuario_)
        {
            this.rut = rut_;
            this.nombre = nombre_;
            this.email = email_;
            this.genero = genero_;
            this.contrasena = contrasena_;
            this.apellido = apellido_;
            this.celular = celular_;
            this.tipo_usuario_id_tipo_usuario = tipo_usuario_id_tipo_usuario_;
        }
    }
}