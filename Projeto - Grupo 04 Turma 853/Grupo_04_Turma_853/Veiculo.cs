using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static Grupo_04_Turma_853.Auxiliar;

namespace Grupo_04_Turma_853
{
    public class Veiculo : Garantia
    {
        public string? Placa { get; set; }
        public string? Modelo { get; set; }
        public int[] numParcelaAuto = new int[] { 18, 24, 30, 36 };

        public bool ValidaPlaca(string placaDigitada)
        {
            // Validando tanto as placas antigas quanto as novas
            // Antiga: FDS-1515
            // Nova: BRA4G45

            string placa = placaDigitada.Replace("-", "").Trim().ToUpper();

            bool placaAntiga = true;
            bool placaNova = true;

            if (placa.Length != 7)
                return false;

            if (placa.Substring(0, 3).Any(c => !char.IsLetter(c)) || placa.Substring(3, 4).Any(c => !char.IsDigit(c)))
                placaAntiga = false;

            if (placa.Substring(0, 3).Any(c => !char.IsLetter(c)) || placa.Substring(5, 2).Any(c => !char.IsDigit(c)) || !char.IsDigit(placa[3]) || !char.IsLetter(placa[4]))
                placaNova = false;

            if (!placaNova && !placaAntiga)
                return false;

            if (!char.IsLetter(placa[4]))
            {
                Placa = placa.Substring(0, 3) + "-" + placa.Substring(3, 4);
            }
            else
            {
                Placa = placa;
            }
            return true;
        }
        public override void ImprimirDados()
        {
            Console.WriteLine(String.Format("|{0,-10}|{1,-42}|", " Modelo", " " + CapitalizaString(this.Modelo)));
            Console.WriteLine(String.Format("|{0,-10}|{1,-42}|", " Placa", " " + this.Placa));
            Console.WriteLine(String.Format("|{0,52}|", "-----------------------------------------------------"));
        }
    }
}
