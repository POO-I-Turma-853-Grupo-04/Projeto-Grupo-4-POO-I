namespace Grupo_04_Turma_853
{
    public class Cliente : Pessoa
    {
        public int score;
                
        public void ImprimirDados()
        {
            string cpfTratado = cpf.Insert(3, ".").Insert(7, ".").Insert(11, "-");
            string telefoneTratado = telefone.Insert(0, "(").Insert(3, ")").Insert(4, " ").Insert(10, "-");
            Console.WriteLine($"Nome: {nome}, CPF: {cpfTratado}, Telefone: {telefoneTratado}, Score: {score}");
        }
    }
}
