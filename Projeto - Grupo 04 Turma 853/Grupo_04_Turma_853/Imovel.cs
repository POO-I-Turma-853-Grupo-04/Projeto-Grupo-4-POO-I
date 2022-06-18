using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo_04_Turma_853
{
    public class Imovel : Garantia
    {
        public string? endereco;
        public string? cep;

        public bool ValidaCEP(string cep)
        {
            if (cep.Length != 8 || !long.TryParse(cep, out _))
                return false;

            this.cep = cep;
            return true;
        }
        public void ImprimirDados()
        {
            Console.WriteLine("Dados do Endereço:");
            Console.WriteLine($"{endereco}, CEP: {this.cep?.Substring(0,5)}-{this.cep?.Substring(5,3)}");
        }    
    }
}
