using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;

namespace BLL
{
    public class RutasDetalle
    {
        public int IdCliente { set; get; }
        public int OrdenVisita { set; get; }
    }
}
