﻿namespace Grupo_04_Turma_853
{
    public class Funcionario : Pessoa
    {
        public decimal salario;
        public decimal bonus;

        public Funcionario(string nome, string cpf, string telefone, decimal salario)
        {
            this.nome = nome;
            this.cpf = cpf;
            this.telefone = telefone;
            this.salario = salario;
        }
        public void ImprimirDados()
        {
            string cpfTratado = cpf.Insert(3, ".").Insert(7, ".").Insert(11, "-");
            string telefoneTratado = telefone.Insert(0, "(").Insert(3, ")").Insert(4, " ").Insert(10, "-");
            Console.WriteLine($"Consultando funcionário... \nNome: {nome}, CPF: {cpfTratado}, Telefone: {telefoneTratado}.");
            Console.WriteLine($"Seu salário é de {salario} e sua bonificação está atualmente em {bonus}");
        }

        public void Bonificar(decimal valor)
        {
            bonus += valor * 0.01M;
        }
    }
}
