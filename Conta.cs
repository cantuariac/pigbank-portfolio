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

        public Conta(string nome, TipoConta tipo) 
        {
            this.Nome = nome;
            this.Tipo = tipo;
            this.Saldo = 0;
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
            return "Conta de " + this.Nome;
        }

    }
}