using System;
using System.Collections.Generic;
using System.Text;

namespace PoointWebApi.Model
{
    public class ComentarioAvi
    {

        public int id_ComentarioA { get; set; }
        public int id_user { get; set; }
        public int id_Avisos { get; set; }
        public string comentario { get; set; }
        public DateTime fecha { get; set; }

    }
}
