using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo_04_Turma_853
{
    public class TestaEmprestimo
    {
        static void Main(string[] args)
        {
            Sistema sis = new Sistema();
            sis.InicializaFuncionarios(5);

            while (true)
            {
                Console.WriteLine("-- Ambiente de Empréstimo Virtual --");
                Console.WriteLine("O que deseja fazer?");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("1 - Consultar Taxas");
                Console.WriteLine("2 - Iniciar Processo de Empréstimo");

                string escolha = Console.ReadLine();
                Console.Clear();

                if (escolha == "0") break;
            
                if (escolha == sis.senha)
                    sis.ModoDesenvolvedor();
                else if (escolha == "1")
                {
                    Console.WriteLine("Incompleto.");
                }
                else if (escolha == "2")
                {
                    Funcionario funcionario = sis.AtribuiFuncionario();
                    Cliente cliente = new Cliente();
                    Console.WriteLine("-- Empréstimo Top Coders --");
                    Console.WriteLine($"Olá, meu nome é {funcionario.nome}, com quem eu falo?");

                    while (true)
                    {
                        string nome = Console.ReadLine();

                        if (!cliente.ValidaNome(nome))
                            Console.WriteLine($"Me desculpe, {nome} não é um nome válido, por favor, digite novamente nome e sobrenome.");
                        else
                        {
                            Console.WriteLine($"Prazer te conhecer {nome}, você pode digitar agora seu CPF?");
                            break;
                        }
                    }
                    
                    while (true)
                    {
                        string cpf = Console.ReadLine();

                        if (!cliente.ValidaCPF(cpf))
                            Console.WriteLine($"Me desculpe, {cpf} não é um CPF válido, por favor, tente novamente.");
                        else
                        {
                            Console.WriteLine($"Perfeito! Pode digitar agora seu telefone com DDD para contato?");
                            break;
                        }
                    }

                    while (true)
                    {
                        string telefone = Console.ReadLine();

                        if (!cliente.ValidaTelefone(telefone))
                            Console.WriteLine($"Me desculpe, {telefone} não é um telefone válido, por favor, tente novamente.");
                        else
                            break;
                    }

                    Console.WriteLine();
                    cliente.ImprimirDados();
                    Console.WriteLine("\nVocê confirma esses dados? (Sim/Não)");

                    string confirma = Console.ReadLine();

                    if (confirma.ToLower() != "sim") continue;

                    Console.WriteLine("Você digitou Sim!");
                    // PROCEDE PARA AS INFORMAÇÕES DO EMPRÉSTIMO
                }
            }
        }
    }
}
