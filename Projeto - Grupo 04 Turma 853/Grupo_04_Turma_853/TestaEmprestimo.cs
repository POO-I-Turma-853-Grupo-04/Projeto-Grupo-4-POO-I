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

                if (escolha == "0")
                    break;

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
                            Console.WriteLine(
                                $"Me desculpe, {nome} não é um nome válido, por favor, digite novamente nome e sobrenome."
                            );
                        else
                        {
                            Console.WriteLine(
                                $"Prazer te conhecer {nome}, você pode digitar agora seu CPF?"
                            );
                            break;
                        }
                    }

                    while (true)
                    {
                        string cpf = Console.ReadLine();

                        if (!cliente.ValidaCPF(cpf))
                            Console.WriteLine(
                                $"Me desculpe, {cpf} não é um CPF válido, por favor, tente novamente."
                            );
                        else
                        {
                            Console.WriteLine(
                                $"Perfeito! Pode digitar agora seu telefone com DDD para contato?"
                            );
                            break;
                        }
                    }
                    
                    while (true)
                    {
                        string telefone = Console.ReadLine();

                        if (!cliente.ValidaTelefone(telefone))
                            Console.WriteLine(
                                $"Me desculpe, {telefone} não é um telefone válido, por favor, tente novamente."
                            );
                        else
                            break;
                    }

                    Console.WriteLine();
                    sis.AdicionaCliente(cliente);
                    cliente.ImprimirDados();
                    Console.WriteLine("\nVocê confirma esses dados? (Sim/Não)");

                    string confirma = Console.ReadLine();

                    if (confirma.ToLower() != "sim")
                        continue;

                    Console.WriteLine("Você digitou Sim!");

                    AnaliseRisco analise = new AnaliseRisco(cliente);
                    if (analise.score <= 300)
                    {
                        Console.WriteLine("Poxa, não podemos continuar com o empréstimo.");
                        Console.WriteLine("Score abaixo do permitido.");
                        return;
                    }

                    // PROCEDE PARA AS INFORMAÇÕES DO EMPRÉSTIMO



                    // DEPOIS DE VALIDADO O SCORE, ARMAZENAR INFORMAÇÕES DE GARANTIA
                    #region "GARANTIA"
                    Console.Clear();
                    Console.WriteLine(
                        $"\nCerto, {cliente.nome}! Muito obrigado pelas informações."
                    );
                    Console.WriteLine("\nAgora precisamos saber qual é o tipo da sua garantia.");

                    Garantia garantia = new Garantia();
                    Veiculo veiculo = new Veiculo();
                    Imovel imovel = new Imovel();

                    while (true)
                    {
                        #region "Escolha do tipo da Garantia"
                        while (true)
                        {
                            Console.WriteLine("\n-- Garantias disponíveis --");
                            garantia.ImprimeListaTipos();
                            Console.Write("\nDigite uma das opções acima: ");

                            string garantiaEscolhida = Console.ReadLine();

                            if (!garantia.ValidaTipo(garantiaEscolhida))
                            {
                                Console.Clear();
                                Console.WriteLine($"Por favor, escolha uma opção válida!");
                            }
                            else
                                break;
                        }
                        #endregion

                        #region "Escolha do valor da Garantia"
                        Console.Clear();
                        Console.WriteLine(
                            $"\nÓtimo! Agora, precisamos saber o valor do seu {garantia.Tipo[garantia.CodigoTipo - 1].ToLower()}."
                        );

                        while (true)
                        {
                            Console.Write(
                                $"\nValor do {garantia.Tipo[garantia.CodigoTipo - 1]}: R$ "
                            );
                            string valorDigitadoGarantia = Console.ReadLine();

                            if (!garantia.ValidaValor(valorDigitadoGarantia))
                            {
                                Console.Clear();
                                Console.WriteLine("Por favor, digite um valor válido!");
                            }
                            else
                                break;
                        }
                        #endregion

                        #region "Armazenando as informações do Veículo"
                        if (garantia.CodigoTipo == 1)
                        {
                            Console.WriteLine("\nDigite o modelo:");
                            string modeloDigitado = Console.ReadLine();
                            veiculo.Modelo = modeloDigitado; // depois adicionar um método para armazenar no objeto

                            while (true)
                            {
                                Console.WriteLine("\nDigite a placa");
                                string placaDigitada = Console.ReadLine();

                                if (!veiculo.ValidaPlaca(placaDigitada))
                                {
                                    Console.Clear();
                                    Console.WriteLine(
                                        $"{placaDigitada} não é uma placa válida! Por favor, tente de novo."
                                    );
                                }
                                else
                                    break;
                            }
                            Console.Clear();
                            garantia.ImprimirDados();
                            veiculo.ImprimirDados();
                        }
                        #endregion

                        #region "Armazenando as informações do Imóvel"
                        else if (garantia.CodigoTipo == 2)
                        {
                            Console.WriteLine("\nDigite o endereço:");
                            string enderecoDigitado = Console.ReadLine();
                            imovel.endereco = enderecoDigitado; // depois adicionar um método para armazenar no objeto

                            while (true)
                            {
                                Console.WriteLine("\nDigite o CEP:");
                                string cepDigitado = Console.ReadLine();

                                if (!imovel.ValidaCEP(cepDigitado))
                                {
                                    Console.Clear();
                                    Console.WriteLine(
                                        $"{cepDigitado} não é um CEP válido! Por favor, tente de novo."
                                    );
                                }
                                else
                                    break;
                            }
                            Console.Clear();
                            garantia.ImprimirDados();
                            imovel.ImprimirDados();
                        }
                        #endregion

                        #region "Confirmando dados da Garantia"
                        Console.WriteLine("\nVocê confirma esses dados? (Sim/Não)");

                        string confirmaGarantia = Console.ReadLine();
                        Console.Clear();

                        if (confirmaGarantia.ToLower() == "sim")
                            break;
                        #endregion
                    }
                    #endregion

                    analise.CalculaValorEmprestimo(garantia);
                    bool validaValor;
                    do
                    {
                        Console.WriteLine($"\nVerifiquei aqui no sistema o valor máximo que posso te disponibilizar para empréstimo é {analise.valorMaximoEmprestimo.ToString("C")}");
                        Console.WriteLine("\nQual valor você gostaria de emprestar? ");

                        validaValor = decimal.TryParse(Console.ReadLine(), out analise.valorEmprestado);
                        
                        if (analise.valorEmprestado > analise.valorMaximoEmprestimo)
                        {
                            Console.WriteLine("Valor maior que o permitido!");
                            validaValor = false;
                        }
                        if(analise.valorEmprestado < analise.valorMinimoEmprestimo){
                            Console.WriteLine("Valor menor que o permitido!");
                            Console.WriteLine($"O alor mínimo permitido é {analise.valorMinimoEmprestimo.ToString("C")}");
                            validaValor = false;
                        }
                    } while (validaValor == false);

                    //Emprestimo emprestimo = new Emprestimo();

                }
            }
        }
    }
}
