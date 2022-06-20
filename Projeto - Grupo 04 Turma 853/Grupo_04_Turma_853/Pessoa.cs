using System.Text.RegularExpressions;

namespace Grupo_04_Turma_853
{
    public class Pessoa
    {
        public string nome;
        public string cpf;
        public string telefone;

        public bool ValidaNome(string nome)
        {
            nome = nome.Trim();

            Regex rgx = new Regex("[^A-Za-z ]");
            if (rgx.IsMatch(nome) || nome.Split(' ').Length == 1)
                return false;

            this.nome = nome;
            return true;
        }

        public bool ValidaCPF(string cpf)
        {
            cpf = cpf.Replace("-", "").Replace(".", "").Trim();

            if (!Double.TryParse(cpf, out _) || cpf.Length != 11)
                return false;

            this.cpf = cpf;
            return true;
        }

        public bool ValidaTelefone(string telefone)
        {
            telefone = telefone.Replace("-", "").Replace("(", "").Replace(")", "").Replace(" ", "").Replace(",", "");

            if (!Double.TryParse(telefone, out _) || telefone.Length != 11) // FIX: Todos os estados tem 11 dígitos?
                return false;

            this.telefone = telefone;
            return true;
        }
    }
}
