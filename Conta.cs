using System;

namespace Portfolio.PigBank
{
    public enum TipoConta
    {
        PessoaFisica = 1,
        PessoaJuridica = 2
    }
    public class Conta
    {
        private string Nome { get; set; }
        private TipoConta Tipo { get; set; }
        private double Saldo { get; set; }

        public Conta(string nome, TipoConta tipo, double saldo = 0.0)
        {
            this.Nome = nome;
            this.Tipo = tipo;
            this.Saldo = saldo;
        }
        public string DetalharConta()
        {
            string retorno = "TipoConta: " + this.Tipo + "\n" +
                             "Nome: " + this.Nome + "\n" +
                             "Saldo: " + this.Saldo + "\n";
            return retorno;
        }

        public override string ToString()
        {
            return this.Nome;
        }

        public void Depositar(double valor)
        {
            this.Saldo += valor;
        }

        public bool Sacar(double valor)
        {
            if (valor <= this.Saldo && valor>0.0)
            {
                this.Saldo -= valor;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Transferir(double valor, Conta destino)
        {
            if(this.Sacar(valor)){
                destino.Depositar(valor);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}