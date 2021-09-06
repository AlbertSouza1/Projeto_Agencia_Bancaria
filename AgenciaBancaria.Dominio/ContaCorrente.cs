using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaBancaria.Dominio
{
    public class ContaCorrente : ContaBancaria
    {
        public ContaCorrente(Cliente cliente, decimal limite) : base(cliente)
        {
            ValorTaxaManutencao = 0.05M;
            Limite = limite;
        }

        public override void Sacar(decimal valor, string senha)
        {          
            if(Senha != senha)
            {
                throw new Exception("Senha inválida!");
            }

            var saque = new Saque(valor, DateTime.Now, this);

            decimal valorMaxixoSaque = Saldo + Limite;

            if (valorMaxixoSaque < saque.Valor)
            {
                throw new Exception("Saldo + limite não são suficientes para realizar este saque");
            }
        
            Saldo -= saque.Valor;
            Lancamentos.Add(saque);
        }

        public decimal Limite { get; private set; }
        public decimal ValorTaxaManutencao { get; private set; }
    }
}
