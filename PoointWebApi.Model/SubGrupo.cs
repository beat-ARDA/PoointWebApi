using System;
using System.Collections.Generic;
using System.Text;

namespace PoointWebApi.Model
{
    public class SubGrupo
    {
        public int id_SubGrupo { get; set; }
       
        public string nombre { get; set; }
        
        public DateTime fecha { get; set; }
  
        public int id_Grupo { get; set; }
    }
}
