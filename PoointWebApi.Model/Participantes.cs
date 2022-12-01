using System;
using System.Collections.Generic;
using System.Text;

namespace PoointWebApi.Model
{
    public class Participantes
    {
        public int id_Participantes { get; set; }
  
        public int id_user { get; set; }
  
        public int id_SubGrupo { get; set; }
        public string nombre { get; set; }
  
        public DateTime fecha { get; set; }

    }
}
