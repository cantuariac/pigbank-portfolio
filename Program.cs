using System;
using System.Collections.Generic;

namespace Portfolio.PigBank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                string operacao = MenuInicio();

                switch (operacao)
                {
                    case "1":
                        int indiceConta = MenuListaContas();
                        if (indiceConta > 0 && indiceConta <= listContas.Count)
                        {
                            AcessarConta(indiceConta);
                        }
                        break;
                    case "2":
                        CriarConta();
                        break;
                    case "3":
                        Deposito();
                        break;
                    case "4":
                        Saque();
                        break;
                    case "5":
                        Transferencia();
                        break;
                    case "x":
                        return;
                    default:
                        Console.WriteLine("Opção invalida");
                        Console.WriteLine("Pressione Enter para contimuar");
                        Console.ReadLine();
                        break;
                }

            }
        }

        static string MenuInicio()
        {
            Console.WriteLine("PigBank");
            Console.WriteLine("Escolha a operação desejada:");
            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Criar nova conta");
            Console.WriteLine("x - Retornar");

            string operacao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return operacao;
        }

        static int MenuListaContas()
        {
            if (listContas.Count == 0)
            {
                Console.WriteLine("Não há nenhuma conta cadastrada");
                return 0;
            }
            Console.WriteLine("Contas cadastradas:");
            for (var i = 0; i < listContas.Count; i++)
            {
                Console.Write("{0} - ", i + 1);
                Console.WriteLine(listContas[i]);
            }
            Console.WriteLine("Entre o número de uma conta para acessar-la");
            Console.WriteLine("ou qualquer tecla para retornar");
            int conta;
            if (int.TryParse(Console.ReadLine(), out conta))
            {
                return conta;
            }
            else
            {
                return 0;
            }
        }

        static void AcessarConta(int indiceConta)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("PigBank");
                listContas[indiceConta].DetalharConta();
                Console.WriteLine("Escolha a operação desejada:");
                Console.WriteLine("1 - Deposito");
                Console.WriteLine("2 - Saque");
                Console.WriteLine("3 - Transferência");
                Console.WriteLine("x - Retornar");

                switch (operacao)
                {
                    case "1":

                        break;
                    case "x":
                    case "X":
                        return;
                }
            }


        }
        static void CriarConta()
        {

        }
        static void Deposito()
        {

        }
        static void Saque()
        {

        }
        static void Transferencia()
        {

        }
    }
}
