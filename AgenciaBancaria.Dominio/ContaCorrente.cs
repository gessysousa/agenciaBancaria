using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaBancaria.Dominio
{
    public class ContaCorrente : ContaBancaria
    {
        public ContaCorrente(Cliente cliente, decimal limite) : base(cliente)
        {
            ValorTaxaManutencao = 0.05M;
            Limite = limite;
        }

        public override void Sacar(decimal valor, string senha) //override, eu posso sobrescrever o método da classe mãe
        {                                                      //polimorfismo: eu tenho dois métodos com o mesmo nome(Sacar), mas fazem a mesma coisa de formas diferentes
            if (Senha != senha)
            {
                throw new Exception("Senha inválida.");
            }

            if ((Saldo + Limite) < valor)
            {
                throw new Exception("Saldo insuficiente.");
            }
            Saldo -= valor;
        }

        public decimal Limite { get; private set; }

        public decimal ValorTaxaManutencao { get; private set; }
    }
}
