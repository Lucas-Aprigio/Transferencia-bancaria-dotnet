using System;
using System.Collections.Generic;
namespace Bank.DIO
{
    public class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        
        {
            Console.WriteLine("Seja bem-vindo(a) ao banco MoneyTree!");
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                    ListarUsuarios();
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

                    case "6":
                    Consultar();
                    break;

                    case "C":
                    Console.Clear();
                    break;


                    default:
                    throw new ArgumentOutOfRangeException();
                }

            opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Volte Sempre!");
            Console.ReadLine();
        }

        static void ListarUsuarios()
        {
            if (listaContas.Count ==0)
            {
                Console.WriteLine("Você ainda não adicionou uma conta");
                return;
            }
            for (int i = 0 ; i< listaContas.Count; i++)
            {
                Conta conta =listaContas[i];
                Console.Write("#{0} -",i);
                Console.WriteLine(conta);
            } 

        }

        public static void InserirConta()
        {
            Console.WriteLine("Digite a opção desejada: 1- Pessoa física | 2- Pessoa Jurídica");
            int entradaTipo= int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome completo");
            string entradaNome= Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial:");
            double entradaSaldo= double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o crédito inicial:");
            double entradaCredito= double.Parse(Console.ReadLine());

            Conta novaConta = new Conta((TipoConta)entradaTipo, entradaSaldo, 
                                        entradaCredito, entradaNome);        

            listaContas.Add(novaConta);
        }
        

        public static void Transferir()
        {
            Console.Write("Digite o indice da conta de origem: ");
            int contaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o indice da conta de destino: ");
            int contaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor:");
            double valor= double.Parse(Console.ReadLine());


            listaContas[contaOrigem].Sacar(valor);
            listaContas[contaDestino].Depositar(valor);

        }

        public static void Sacar()
        {
            Console.Write("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            
            Console.Write("Digite o Valor a ser sacado:");
            double valorSaque= double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);
        }

        public static void Depositar ()
        {
            Console.Write("Digite o índice da conta: ");
            int indiceConta= int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor:");
            double valorDeposito= double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valorDeposito);
            
        }

        public static void Consultar ()
        {
            Console.Write("Digite o índice da conta: ");
            int indiceConta= int.Parse(Console.ReadLine());

            Console.WriteLine(listaContas[indiceConta].ToString());
        }



        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("");
            
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("6 - Consultar Saldo");
            Console.WriteLine("C - Limpar a tela");
            Console.WriteLine("X - Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine("");
            return opcaoUsuario;

        }
        
    }
}