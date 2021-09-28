using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaBancaria.Dominio
{
    public static class Validacoes
    {
        public static string ValidaStringVazia(this string texto) //metodo de extensão
        {
            return string.IsNullOrWhiteSpace(texto) ? throw new Exception("A propriedade deve estar preenchida.") : texto;
        }

    }
}
