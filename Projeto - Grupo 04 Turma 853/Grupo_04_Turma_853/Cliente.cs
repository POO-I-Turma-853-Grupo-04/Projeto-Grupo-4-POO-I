using static Grupo_04_Turma_853.Auxiliar;

namespace Grupo_04_Turma_853
{
    public class Cliente : Pessoa
    {
        public int score;
        public Contrato contrato;

        public void ImprimirDados()
        {
            Console.Clear();
            Console.WriteLine(String.Format("|{0,50}|", "----------------------------------------------------"));
            Console.WriteLine(String.Format("|{0,50}|", "------------------- DADOS PESSOAIS -----------------"));
            Console.WriteLine(String.Format("|{0,50}|", "----------------------------------------------------"));
            Console.WriteLine(String.Format("|{0,-10}|{1,-41}|", " Nome", " " + CapitalizaString(nome)));
            Console.WriteLine(String.Format("|{0,-10}|{1,-41}|", " CPF", " " + TratarCPF(cpf)));
            Console.WriteLine(String.Format("|{0,-10}|{1,-41}|", " Telefone", " " + TratarTelefone(telefone)));
            Console.WriteLine(String.Format("|{0,50}|", "----------------------------------------------------"));
        }

        public void ImprimirDados(bool _)
        {
            this.ImprimirDados();
            Console.WriteLine($"[DEV] Este cliente tem score de {score} [/DEV]");

            if (contrato != null)
            {
                Console.WriteLine($"Contrato de ID {contrato.id} feito por {contrato.funcionario.nome} no valor de {contrato.emprestimo.valorEmprestado.ToString("C")}");
            }
        }
    }
}
