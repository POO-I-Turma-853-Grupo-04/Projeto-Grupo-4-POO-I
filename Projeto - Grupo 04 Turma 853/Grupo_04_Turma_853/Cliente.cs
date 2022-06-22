using static Grupo_04_Turma_853.Auxiliar;

namespace Grupo_04_Turma_853
{
    public class Cliente : Pessoa
    {
        public int score;
                
        public void ImprimirDados()
        {
            string cpfTratado = cpf.Insert(3, ".").Insert(7, ".").Insert(11, "-");
            string telefoneTratado = telefone.Insert(0, "(").Insert(3, ")").Insert(4, " ").Insert(10, "-");
            //Console.WriteLine($"Nome: {nome}, CPF: {cpfTratado}, Telefone: {telefoneTratado}");

           // Console.Clear();
            Console.WriteLine(String.Format("|{0,50}|", "----------------------------------------------------"));
            Console.WriteLine(String.Format("|{0,50}|", "------------------- DADOS PESSOAIS -----------------"));
            Console.WriteLine(String.Format("|{0,50}|", "----------------------------------------------------"));
            Console.WriteLine(String.Format("|{0,-10}|{1,-41}|", " Nome", " " + CapitalizaString(nome)));
            Console.WriteLine(String.Format("|{0,-10}|{1,-41}|", " CPF", " " + cpfTratado));
            Console.WriteLine(String.Format("|{0,-10}|{1,-41}|", " Telefone", " " + telefone));
            Console.WriteLine(String.Format("|{0,50}|", "----------------------------------------------------"));
        }
    }
}
