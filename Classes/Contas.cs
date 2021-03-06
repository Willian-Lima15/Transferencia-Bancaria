using System;
using trsBancaria.Enum;

namespace trsBancaria
{
    public class Contas
    {
        private tipoConta pessoaFisica;
        private int v1;
        private int v2;
        private string v3;

        public Contas(int id, tipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.Id = id;
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;

        }

        public Contas(tipoConta pessoaFisica, int v1, int v2, string v3)
        {
            this.pessoaFisica = pessoaFisica;
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
        }

        public bool Sacar(double valorSaque)
        {
            if (this.Saldo - valorSaque < this.Credito * -1)
            {
                Console.WriteLine("Saldo Insuficiente");
                return false;
            }

            this.Saldo -= valorSaque;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
        }

        public void Transferir(double valorTransferencia, Contas contaDetino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDetino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = " ";
            retorno += "tipoConta: " + this.TipoConta + " | ";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Saldo: " + this.Saldo + " | ";
            retorno += "Credito: " + this.Credito + " | ";
            return retorno;
        }
        private int Id { get; set; }

        private tipoConta TipoConta { get; set; }
        private double Saldo { get; set; }

        private double Credito { get; set; }
        private string Nome { get; set; }

    }
}