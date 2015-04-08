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
    public class VentasDetalle
    {
        public int IdProducto { set; get; }
        public int Cantidad { set; get; }
        public float Precio { set; get; }
        public int IdOferta { set; get; }
    }
}
