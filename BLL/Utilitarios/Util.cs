using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Utilitarios
{
    public class Util
    {
        public static int ObtenerEntero(object ObjetoValor)
        {
            int Valor = 0;

            if (ObjetoValor != null)
            {
                int.TryParse(ObjetoValor.ToString(), out  Valor);
            }

            return Valor;
        }
    }
}
