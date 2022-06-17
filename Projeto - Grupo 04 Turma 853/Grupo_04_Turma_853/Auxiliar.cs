﻿using static EmprestimoTopCoders.Auxiliar;

namespace EmprestimoTopCoders
{
    public static class Auxiliar
    {
        public static string[] DATABASE_NOMES = { "Miguel", "Arthur", "Gael", "Heitor", "Helena", "Alice", "Theo", "Laura", "Davi", "Gabriel" };
        public static string[] DATABASE_SOBRENOMES = { "Silva", "Santos", "Oliveira", "Souza", "Rodrigues", "Ferreira", "Alves", "Pereira", "Lima", "Gomes" };

        public static Funcionario CriaFuncionario()
        {
            Random rnd = new Random();
            string nome = DATABASE_NOMES[rnd.Next(0, DATABASE_NOMES.Length)];
            string sobrenome = DATABASE_SOBRENOMES[rnd.Next(0, DATABASE_SOBRENOMES.Length)];
            string cpf = CriaNumerosAleatorios(11);
            string telefone = "1199" + CriaNumerosAleatorios(7);
            decimal salario = rnd.Next(0, 1000) + 1000M;
            Funcionario func = new Funcionario($"{nome} {sobrenome}", cpf, telefone, salario);

            return func;
        }
        public static int CriaScore()
        {
            Random rnd = new Random();
            return rnd.Next(0, 1001);
        }

        public static string CriaNumerosAleatorios(int quantidade)
        {
            string numeros = "";

            for (int i = 0; i < quantidade; i++)
            {
                Random rnd = new Random();
                int numeroAleatorio = rnd.Next(0, 10);

                numeros += numeroAleatorio;
            }

            return numeros;
        }

        public static string CapitalizaString(string palavras)
        {
            if (string.IsNullOrEmpty(palavras))
            {
                return string.Empty;
            }

            string[] palavraTratada = palavras.Trim().ToLower().Split(' ');

            List<string> listPalavras = new List<string>(palavraTratada);
            for (int i = 0; i < listPalavras.Count; i++)
            {
                if (string.IsNullOrEmpty(listPalavras[i]))
                {
                    listPalavras.RemoveAt(listPalavras.IndexOf(""));
                    i--;
                }
            }
            palavraTratada = listPalavras.ToArray();

            for (int i = 0; i < palavraTratada.Length; i++)
            {
                char[] letras = palavraTratada[i].ToCharArray();
                letras[0] = char.ToUpper(letras[0]);
                palavraTratada[i] = string.Join("", letras);
            }

            return string.Join(" ", palavraTratada);
        }
    }
}




