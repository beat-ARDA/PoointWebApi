using System;
using System.Collections.Generic;
using System.Text;

namespace PoointWebApi.Model
{
    public class Tarea
    {
        public int id_Tarea { get; set; }
        public string Descripcion { get; set; }
        public int puntos { get; set; } 
        public int puntos_max { get; set; }
        public DateTime fecha { get; set; }
        public DateTime fecha_venc { get; set; }
        public string estado { get; set; }
        public int id_SubGrupo { get; set; }

        public string Titulo { get; set; }
    }
}
