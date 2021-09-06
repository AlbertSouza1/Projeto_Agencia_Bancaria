using AgenciaBancaria.Dominio;
using System;

namespace AgenciaBancaria
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                //cadastro do cliente
                Endereco endereco = new Endereco("Rua 10, n 10", "15710000", "São Francisco", "SP");
                Cliente cliente = new Cliente("José", "151231231", "543444123", endereco);

                Console.WriteLine(cliente.Nome + " se cadastrou.");

                //criando conta pro cliente
                ContaBancaria conta = new ContaCorrente(cliente, 5000);

                Console.WriteLine("Conta "+conta.GetType().Name+" "+conta.Situacao + ": "+conta.NumeroConta+conta.DigitoVerificador);

                //abrindo conta
                string senha = "az!C245asEE";
                conta.Abrir(senha);

                //utilizando a conta

                var valorDeposito = 2000;
                conta.Depositar(valorDeposito);
                Console.WriteLine(Environment.NewLine+"Depositados R$" + valorDeposito);
                Console.WriteLine(conta.VerSaldo());

                var valorSaque = 300;
                conta.Sacar(valorSaque, senha);
                Console.WriteLine(Environment.NewLine + "Sacados R$" + valorSaque);
                Console.WriteLine(conta.VerSaldo());

                Console.WriteLine(Environment.NewLine+conta.VerExtrato());

            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
