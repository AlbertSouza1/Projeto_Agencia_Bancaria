using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaBancaria.Dominio
{
    public abstract class Lancamento
    {
        public Lancamento(decimal valor, DateTime data, ContaBancaria conta)
        {
            Data = data;
            Conta = conta ?? throw new Exception("Conta não pode ser nula");
            Valor = (valor > 0) ? valor : throw new Exception("Valor deve ser maior que zero!");
        }

        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public ContaBancaria Conta { get; set; }
    }
}
