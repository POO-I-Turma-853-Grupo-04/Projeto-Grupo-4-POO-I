using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static EmprestimoTopCoders.Auxiliar;

namespace Grupo_04_Turma_853
{
    public class Veiculo : Garantia
    {
        public string? Placa { get; set; }
        public string? Modelo { get; set; }

        public bool ValidaPlaca(string placaDigitada)
        {
            // Validando tanto as placas antigas quanto as novas
            // Antiga: FDS-1515
            // Nova: BRA4G45

            Regex rgxNotLetraNumero = new Regex("[^A-Z0-9]");
            Regex rgxNotLetra = new Regex("[^A-Z]");
            Regex rgxNotNumero = new Regex("[^0-9]");

            string placa = placaDigitada.Trim().Replace("-", "").ToUpper();

            if (placa.Length != 7)
                return false;

            bool primeiraParteValida = !rgxNotLetra.IsMatch(placa.Substring(0, 3));
            bool segundaParteValidaPlacaAntiga = !rgxNotNumero.IsMatch(placa.Substring(3, 4));
            bool segundaParteValidaPlacaNova = !rgxNotNumero.IsMatch(placa.Substring(3, 1)) && !rgxNotLetra.IsMatch(placa.Substring(4, 1)) && !rgxNotNumero.IsMatch(placa.Substring(5, 2));

            if (primeiraParteValida && (segundaParteValidaPlacaAntiga || segundaParteValidaPlacaNova))
            {
                if (!rgxNotNumero.IsMatch(placa.Substring(4, 1)))
                {
                    Placa = placa.Substring(0, 3) + "-" + placa.Substring(3, 4);
                }
                else
                {
                    Placa = placa;
                }
                return true;
            }

            return false;
        }
        public void ImprimirDados()
        {
            Console.WriteLine("Dados do veículo: ");
            Console.WriteLine($"Placa: {this.Placa}");
            Console.WriteLine($"Modelo: {CapitalizaString(this.Modelo)}");
        }
    }
}
