using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaBancaria.Dominio
{
    public class ContaPoupanca : ContaBancaria //Conta poupança está herdando a conta bancária
    {
        public ContaPoupanca(Cliente cliente): base(cliente) //herdando a info do cliente
        {
            PercentualRendimento = 0.003M; //M significa que estou declarando um valor decimal
        }
        
        public decimal PercentualRendimento { get; private set; }
    }
}
