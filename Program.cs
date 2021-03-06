using System;
using System.Collections.Generic;
using trsBancaria.Enum;

namespace trsBancaria
{
    class Program
    {
        static List<Contas> ListasContas = new List<Contas>();
        static void Main(string[] args)
        {
            string opcaoUsuario = obterOperacaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new AccessViolationException();

                }

                opcaoUsuario = obterOperacaoUsuario();
            }

            Console.WriteLine("Obrigado por ultilizar nossos serviços");
            Console.ReadLine();
        }

        private static void ListarContas()
        {
            if (ListasContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for (int i = 0; i < ListasContas.Count; i++)
            {
                Contas conta = ListasContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir uma nova conta");

            Console.WriteLine("Digite 1 para conta fisica ou 2 para juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Credito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Contas novaConta = new Contas(id: 1, tipoConta: (tipoConta)entradaTipoConta, saldo: entradaSaldo, credito: entradaCredito, nome: entradaNome);

            ListasContas.Add(novaConta);

        }

        private static void Transferir()
        {
            Console.WriteLine("Didigite o numero da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite numero da conta destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            ListasContas[indiceContaOrigem].Transferir(valorTransferencia, ListasContas[indiceContaDestino]);
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            ListasContas[indiceConta].Sacar(valorSaque);
        }

        private static void Depositar()
        {
            Console.WriteLine("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser depositado");
            double valorDeposito = double.Parse(Console.ReadLine());

            ListasContas[indiceConta].Depositar(valorDeposito);
        }

        private static string obterOperacaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Banco DIO ao seu dispor");
            Console.WriteLine("Selecione a opção desejada");

            Console.WriteLine("1 - Lista de conta");
            Console.WriteLine("2 - Inserir uma nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
