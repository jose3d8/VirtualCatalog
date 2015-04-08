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
    public class Configuraciones
    {
        public string Config { set; get; }
        public int Valor { set; get; }
    }
}
