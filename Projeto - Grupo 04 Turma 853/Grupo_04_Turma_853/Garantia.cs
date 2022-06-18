using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo_04_Turma_853
{
    public class Garantia
    {
        // Os valores de Tipo podem vir direto da classe sistema, ex.: DATABASE_TIPO = {"Veículo", "Imóvel"}
        // Assim, na main, podemos colocar opções para o usuário escolher
        // Não precisaríamos fazer uma validação nesse caso :) (Só a validação da escolha)
        // Depois teríamos um if.. que escolheria quais informações pediríamos: Imovel ou Veiculo
        public string[] Tipo { get; private set; } = { "Veículo", "Imóvel" };
        public decimal Valor { get; private set; }

        public void ImprimeListaTipos()
        {
            for (int i = 0; i < Tipo.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] {Tipo[i]}");
            }
        }

        public bool ValidaTipo(string codigoDigitado)
        {
            int codigoGarantia;

            if(!int.TryParse(codigoDigitado, out codigoGarantia) || codigoGarantia < 1 || codigoGarantia > Tipo.Length)
            {
                return false;
            }
            return true;
        }

        public bool ValidaValor(string valorDigitado)
        {
            decimal valorGarantia;

            if (!decimal.TryParse(valorDigitado, out valorGarantia) || valorGarantia < 0)
            {
                return false;
            }

            this.Valor = valorGarantia;
            return true;
        }
    }
}
