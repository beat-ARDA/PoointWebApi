using System;
using System.Collections.Generic;
using System.Text;

namespace PoointWebApi.Model
{
    public class Avisos
    {
        public int id_Avisos { get; set; }
        public int id_user { get; set; }
        public int id_SubGrupo { get; set; }
        public string texto { get; set; }
        public DateTime fecha { get; set; }

        public string username { get; set; }

    }
}
