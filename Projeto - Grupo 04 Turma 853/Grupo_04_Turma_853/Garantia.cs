using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo_04_Turma_853
{
    public class Garantia
    {
        public string[] Tipo { get; set; } = { "Veículo", "Imóvel" };
        public decimal Valor { get; set; }
        public int CodigoTipo { get; set; }

        public void ImprimeListaTipos()
        {
            Console.WriteLine(String.Format("\n|{0,28}|", "-----------------------------"));
            Console.WriteLine(String.Format("|{0,28}|", "--- Garantias disponíveis ---"));
            Console.WriteLine(String.Format("|{0,28}|", "-----------------------------"));

            for (int i = 0; i < Tipo.Length; i++)
            {
                Console.WriteLine(String.Format("|{0,-29}|", " [" + (i + 1) + "] " + Tipo[i]));
            }
            Console.WriteLine(String.Format("|{0,28}|", "-----------------------------"));
        }

        public bool ValidaTipo(string codigoDigitado)
        {
            int codigoGarantia;

            if (!int.TryParse(codigoDigitado, out codigoGarantia) || codigoGarantia < 1 || codigoGarantia > Tipo.Length)
            {
                return false;
            }
            CodigoTipo = codigoGarantia;
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

        public virtual void ImprimirDados()
        {
            Console.Clear();
            Console.WriteLine(String.Format("|{0,52}|", "-----------------------------------------------------"));
            Console.WriteLine(String.Format("|{0,52}|", "------------------ DADOS DA GARANTIA ----------------"));
            Console.WriteLine(String.Format("|{0,52}|", "-----------------------------------------------------"));
            Console.WriteLine(String.Format("|{0,-10}|{1,-42}|", " Tipo", " " + Tipo[CodigoTipo - 1]));
            Console.WriteLine(String.Format("|{0,-10}|{1,-42}|", " Valor", " R$ " + Valor.ToString("N2")));
        }
    }
}
