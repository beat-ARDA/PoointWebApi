using System;
using System.Collections.Generic;
using System.Text;

namespace PoointWebApi.Model
{
    public class Tareas
    {
        public int id_Tareas { get; set; }
        public int id_user { get; set; }
        public int id_Tarea { get; set; }
        public int id_SubGrupo { get; set; }
        public int id_Actividad { get; set; }
        public DateTime fecha { get; set; }
        public string Titulo { get; set; }
        public string puntos { get; set; }
        public string username { get; set; }

    }
}
