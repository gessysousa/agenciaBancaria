using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AgenciaBancaria.Dominio
{
    public abstract class ContaBancaria //abstract classe não pode ser instanciada, mas pode ser herdada
    {
        public ContaBancaria(Cliente cliente)
        {
            Random random = new Random(); //cria um número aleatório
            NumeroConta = random.Next(50000, 100000); //gera um número entre 50000 e 100000
            DigitoVerificador = random.Next(0, 9);

            Situacao = SituacaoConta.Criada;

            Cliente = cliente ?? throw new Exception("Cliente deve ser informado.");
        }

        public void Abrir(string senha)
        {
            SetaSenha(senha);
            Situacao = SituacaoConta.Aberta;
            DataAbertura = DateTime.Now;
        }

        private void SetaSenha(string senha)
        {
            Senha = senha.ValidaStringVazia();

            if(!Regex.IsMatch(senha, @"^(?=.*?[a-z])(?=.*?[0-9]).{8,}$"))//validação da senha se tem pelo menos uma letra, pelo menos um númro e 8 digitos
            {
                throw new Exception("Senha inválida.");
            }

            Senha = senha;
        }

        public virtual void Sacar(decimal valor, string senha)//virtual, consigo sobrescrever o método na classee filha
        {
            if (Senha != senha)
            {
                throw new Exception("Senha inválida.");
            }

            if ( Saldo < valor)
            {
                throw new Exception("Saldo insuficiente.");
            }
            Saldo -= valor;
        }

        public int NumeroConta { get; init; } //init só posso setar os valores na inicialização da classe
        public int DigitoVerificador { get; init; }
        public decimal Saldo { get; protected set; }//classes filhas que herdaram de conta bancaria, elas podem setar o saldo
        public DateTime? DataAbertura { get; private set; } // digito ? serve para permitir nulo
        public DateTime? DataEncerramento { get; private set; } //não posso setar data de abertura fora da minha classe conta bancaria
        public SituacaoConta Situacao { get; private set; }
        public string Senha { get; protected set; }
        public Cliente Cliente { get; init; }

    }
}
