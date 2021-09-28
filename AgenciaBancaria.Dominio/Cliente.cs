using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaBancaria.Dominio
{
    public class Cliente
    {
        public Cliente (string nome, string cpf, string rg, Endereco endereco) //construtor
        {
            //if (string.IsNullOrWhiteSpace(nome))//testar se o nome foi preenchido
            //{
            //    throw new Exception("A propriedade deve estar preenchida.");//caso o nome esteja em branco, a aplicação é encerrada
            //}
            Nome = nome.ValidaStringVazia();
            CPF = cpf.ValidaStringVazia();
            RG = rg.ValidaStringVazia();
            Endereco = endereco ?? throw new Exception("Endereço deve ser informado"); // operador ?? atribui ou o que está ao lado direito dele ou o que está ao lado esquerdo dele
        }

        
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string RG { get; private set; }
        public Endereco Endereco { get; private set; }

    }
}
