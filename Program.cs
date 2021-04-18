using System;
using System.Collections.Generic;

namespace Portfolio.PigBank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            testFunction();
            string operacao = "";
            while (true)//operacao.ToUpper() != "X")
            {
                Console.Clear();
                operacao = MenuInicio();

                switch (operacao)
                {
                    case "1":
                        if (listContas.Count == 0)
                        {
                            MensagemEspera("Não há nenhuma conta cadastrada");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("PigBank 🐷");
                            Conta conta = MenuListaContas();
                            if (conta != null)
                            {
                                AcessarConta(conta);
                            }
                            else
                            {
                                MensagemEspera();
                            }
                        }
                        break;
                    case "2":
                        Conta novaConta = CriarConta();
                        if (novaConta != null)
                        {
                            MensagemEspera(String.Format("Conta de {0} criada com sucesso", novaConta));
                        }
                        break;
                    case "X":
                        Console.WriteLine("Obrigado por usar o PigBank 🐷");
                        return;
                    default:
                        MensagemEspera("Opção invalida");
                        break;
                }

            }
        }

        static void testFunction()
        {
            listContas.Add(new Conta("Joao", TipoConta.PessoaFisica, 100.0));
            listContas.Add(new Conta("Maria", TipoConta.PessoaFisica, 200.0));
            listContas.Add(new Conta("Pedro", TipoConta.PessoaJuridica, 50.0));
        }

        static void MensagemEspera(string message = null)
        {
            if (message != null)
            {
                Console.WriteLine(message);

            }
            Console.WriteLine("Pressione qualquer tecla para retornar");
            Console.ReadKey();
        }
        static string MenuInicio()
        {
            Console.WriteLine("PigBank 🐷");
            Console.WriteLine("Escolha a operação desejada:");
            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Criar nova conta");
            Console.WriteLine("x - Sair");

            string operacao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return operacao;
        }

        static Conta MenuListaContas()
        {
            Console.WriteLine("Contas cadastradas:");
            for (var i = 0; i < listContas.Count; i++)
            {
                Console.Write("{0} - ", i + 1);
                Console.WriteLine(listContas[i]);
            }
            Console.WriteLine("Entre o número de uma conta para seleciona-la");
            Console.WriteLine("ou qualquer tecla para retornar");
            int indiceConta;
            if (int.TryParse(Console.ReadLine(), out indiceConta))
            {
                if (indiceConta > 0 && indiceConta <= listContas.Count)
                {
                    return listContas[indiceConta - 1];
                }
            }
            return null;
        }

        static Conta CriarConta()
        {
            string nome, tipo;
            Console.Clear();
            Console.WriteLine("PigBank 🐷");

            while (true)
            {
                Console.WriteLine("Selecione o tipo de conta:");
                Console.WriteLine("1 - Pessoa fisica");
                Console.WriteLine("2 - Pessoa jurídica");
                Console.WriteLine("x - Cancelar");
                tipo = Console.ReadLine().ToUpper();
                if (tipo == "X")
                {
                    return null;
                }
                else if (tipo == "1" || tipo == "2")
                {
                    break;
                }
            } //while (tipo != "1" || tipo != "2");

            Console.WriteLine("Insira o nome do titular da conta");
            Console.WriteLine("x - Cancelar");
            nome = Console.ReadLine();
            if (nome == "X")
            {
                return null;
            }

            Conta conta = new Conta(nome, (TipoConta)int.Parse(tipo));
            listContas.Add(conta);
            return conta;

        }
        static string MenuConta()
        {
            Console.WriteLine("Escolha a operação desejada:");
            Console.WriteLine("1 - Deposito");
            Console.WriteLine("2 - Saque");
            Console.WriteLine("3 - Transferência");
            Console.WriteLine("x - Retornar");

            string operacao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return operacao;
        }
        static void AcessarConta(Conta conta)
        {
            string operacao;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("PigBank 🐷");
                Console.WriteLine(conta.DetalharConta());

                operacao = MenuConta();

                switch (operacao)
                {
                    case "1":
                        Deposito(conta);
                        break;
                    case "2":
                        Saque(conta);
                        break;
                    case "3":
                        Transferencia(conta);
                        break;
                    case "X":
                        return;
                }
            }


        }
        static void Deposito(Conta conta)
        {
            double valor;
            Console.WriteLine("Insira o valor a ser depositado");
            if (double.TryParse(Console.ReadLine(), out valor))
            {
                if (valor > 0.0)
                {
                    conta.Depositar(valor);
                }
                else
                {
                    MensagemEspera("O valor deve ser maior que zero");
                }
            }
            else
            {
                MensagemEspera("O valor inserido não é válido");
            }
        }
        static void Saque(Conta conta)
        {
            double valor;
            Console.WriteLine("Insira o valor a ser sacado");
            if (double.TryParse(Console.ReadLine(), out valor))
            {
                if (valor > 0.0)
                {
                    if (conta.Sacar(valor))
                    {
                        MensagemEspera("Saque realizado com sucesso");
                    }
                    else
                    {
                        MensagemEspera("Saldo insuficiente");
                    }
                }
                else
                {
                    MensagemEspera("O valor deve ser maior que zero");
                }
            }
            else
            {
                MensagemEspera("O valor inserido não é válido");
            }
        }
        static void Transferencia(Conta conta)
        {
            Conta destino;
            Console.WriteLine("Selecione a conta de destino");
            destino = MenuListaContas();
            if (destino == null)
            {
                return;
            }
            double valor;
            Console.WriteLine("Insira o valor a ser transferido");
            if (double.TryParse(Console.ReadLine(), out valor))
            {
                if (valor > 0.0)
                {
                    if (conta.Transferir(valor, destino))
                    {
                        MensagemEspera("Transferência realizada com sucesso");
                    }
                    else
                    {
                        MensagemEspera("Saldo insuficiente");
                    }
                }
                else
                {
                    MensagemEspera("O valor deve ser maior que zero");
                }
            }
            else
            {
                MensagemEspera("O valor inserido não é válido");
            }
        }
    }
}
