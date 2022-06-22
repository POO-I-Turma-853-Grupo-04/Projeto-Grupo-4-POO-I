using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Grupo_04_Turma_853.Auxiliar;

namespace Grupo_04_Turma_853
{
    #region "Tela de Console"
    public class TelasConsole
    {
        public void ImprimeCabecalho()
        {
            Console.Clear();
            Console.WriteLine("|-------------------------------------|");
            Console.WriteLine("|------- Empréstimo Top Coders -------|");
            Console.WriteLine("|-------------------------------------|");
        }

        public void ImprimeTabelaTaxasEmprestimo()
        {
            Console.WriteLine(String.Format("\n|{0,16}|", "---------------------------"));
            Console.WriteLine(String.Format("|{0,16}|", "--- Taxas de Empréstimo ---"));
            Console.WriteLine(String.Format("|{0,16}|", "---------------------------"));
            Console.WriteLine(String.Format("|{0,-10}|{1,-16}|", " Veículo", " 1,49% a.m."));
            Console.WriteLine(String.Format("|{0,-10}|{1,-16}|", " Imóvel", " 0,99% a.m."));
            Console.WriteLine(String.Format("|{0,16}|", "---------------------------"));
        }
    }
    #endregion
    public class TestaEmprestimo
    {
        static void Main(string[] args)
        {
            TelasConsole telasConsole = new TelasConsole();
            Sistema sis = new Sistema();
            sis.InicializaFuncionarios(5);

            while (true)
            {
                Console.Clear();
                Console.WriteLine(" |--------------------------------------|");
                Console.WriteLine(" |--- Ambiente de Empréstimo Virtual ---|");
                Console.WriteLine(" |--------------------------------------|");
                Console.WriteLine(" | O que deseja fazer?                  |");
                Console.WriteLine(" |                                      |");
                Console.WriteLine(" | [1] Consultar Taxas                  |");
                Console.WriteLine(" | [2] Iniciar Processo de Empréstimo   |");
                Console.WriteLine(" |                                      |");
                Console.WriteLine(" | [0] Sair                             |");
                Console.WriteLine(" |                                      |");
                Console.WriteLine(" |                                      |");
                Console.WriteLine(" |--------------------------------------|");
                Console.WriteLine(" |---- Exclusivo para Desenvolvedor ----|");
                Console.WriteLine(" |--------------------------------------|");
                Console.WriteLine(" | [123456] Modo Desenvolvedor          |");
                Console.WriteLine(" |--------------------------------------|");

                Console.Write("\n  Digite um opção: ");
                string escolha = Console.ReadLine();
                Console.Clear();

                if (escolha == "0")
                    break;

                if (escolha == sis.senha)
                    sis.ModoDesenvolvedor();
                else if (escolha == "1")
                {
                    telasConsole.ImprimeCabecalho();
                    telasConsole.ImprimeTabelaTaxasEmprestimo();

                    Console.Write("\n\nAperte qualquer tecla para voltar.");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (escolha == "2")
                {
                    Funcionario funcionario = sis.AtribuiFuncionario();
                    Cliente cliente = new Cliente();

                    telasConsole.ImprimeCabecalho();
                    Console.WriteLine($"\nOlá, meu nome é {funcionario.nome}, com quem eu falo?");

                    while (true)
                    {
                        Console.Write("Nome Completo: ");
                        string nome = Console.ReadLine();

                        if (!cliente.ValidaNome(nome))
                        {
                            telasConsole.ImprimeCabecalho();
                            Console.WriteLine(
                                $"\nMe desculpe, {nome} não é um nome válido, por favor, digite novamente nome e sobrenome."
                            );
                        }
                        else
                        {
                            telasConsole.ImprimeCabecalho();
                            Console.WriteLine(
                                $"\nPrazer te conhecer {CapitalizaString(cliente.nome.Split()[0])}! Você pode digitar agora seu CPF?"
                            );
                            break;
                        }
                    }

                    while (true)
                    {
                        Console.Write("CPF: ");
                        string cpf = Console.ReadLine();

                        if (!cliente.ValidaCPF(cpf))
                        {
                            telasConsole.ImprimeCabecalho();
                            Console.WriteLine(
                                $"\nMe desculpe, {cpf} não é um CPF válido, por favor, tente novamente."
                            );
                        }
                        else
                        {
                            telasConsole.ImprimeCabecalho();
                            Console.WriteLine(
                                $"\nPerfeito! Pode digitar agora seu telefone com DDD para contato?"
                            );
                            break;
                        }
                    }
                    while (true)
                    {
                        Console.Write("Telefone: ");
                        string telefone = Console.ReadLine();

                        if (!cliente.ValidaTelefone(telefone))
                        {
                            telasConsole.ImprimeCabecalho();
                            Console.WriteLine(
                                $"\nMe desculpe, {telefone} não é um telefone válido, por favor, tente novamente."
                            );
                        }
                        else
                            break;
                    }

                    Console.WriteLine();
                    cliente.ImprimirDados();
                    Console.Write("\nVocê confirma esses dados? (Sim/Não): ");

                    string confirma = Console.ReadLine();

                    if (confirma.ToLower() != "sim")
                        continue;

                    if (!sis.AdicionaCliente(cliente))
                    {
                        Console.WriteLine(
                            $"{cliente.nome.Split(' ')[0]}, consta aqui que seu CPF já está cadastrado no sistema, vou te retornar para o início!"
                        );
                        Console.ReadKey();
                        continue;
                    }

                    AnaliseRisco analise = new AnaliseRisco(cliente);
                    if (analise.score <= 300)
                    {
                        Console.Clear();

                        Console.WriteLine("|-------------------------------------|");
                        Console.WriteLine("|-------------- ATENÇÃO --------------|");
                        Console.WriteLine("|-------------------------------------|");
                        Console.WriteLine("\nPoxa, não podemos continuar com o empréstimo.");
                        Console.WriteLine("Score abaixo do permitido.");

                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }

                    #region "GARANTIA"
                    telasConsole.ImprimeCabecalho();
                    Console.WriteLine(
                        $"\nCerto, {CapitalizaString(cliente.nome.Split()[0])}! Muito obrigado pelas informações."
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
                            garantia.ImprimeListaTipos();
                            Console.Write("\nDigite uma das opções acima: ");

                            string garantiaEscolhida = Console.ReadLine();

                            if (!garantia.ValidaTipo(garantiaEscolhida))
                            {
                                telasConsole.ImprimeCabecalho();
                                Console.WriteLine($"Por favor, escolha uma opção válida!");
                            }
                            else
                                break;
                        }
                        #endregion

                        #region "Escolha do valor da Garantia"
                        telasConsole.ImprimeCabecalho();
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
                            telasConsole.ImprimeCabecalho();
                            Console.WriteLine(
                                "\nCerto! Precisamos saber algumas informações do seu Veículo."
                            );
                            Console.Write("\nDigite o modelo: ");
                            string modeloDigitado = Console.ReadLine();
                            veiculo.Modelo = modeloDigitado; // depois adicionar um método para armazenar no objeto

                            while (true)
                            {
                                Console.Write("\nDigite a placa: ");
                                string placaDigitada = Console.ReadLine();

                                if (!veiculo.ValidaPlaca(placaDigitada))
                                {
                                    Console.Clear();
                                    telasConsole.ImprimeCabecalho();
                                    Console.WriteLine(
                                        $"\n{placaDigitada} não é uma placa válida! Por favor, tente de novo."
                                    );
                                    Console.WriteLine($"\nModelo: {veiculo.Modelo}");
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
                            telasConsole.ImprimeCabecalho();
                            Console.WriteLine(
                                "\nCerto! Precisamos saber algumas informações do seu endereço."
                            );

                            while (true)
                            {
                                Console.Write("\nDigite o seu CEP: ");
                                string cepDigitado = Console.ReadLine();

                                if (!imovel.ValidaCEP(cepDigitado))
                                {
                                    telasConsole.ImprimeCabecalho();
                                    Console.WriteLine(
                                        $"\n{cepDigitado} não é um CEP válido! Por favor, tente de novo."
                                    );
                                }
                                else
                                    break;
                            }

                            Console.Clear();
                            telasConsole.ImprimeCabecalho();
                            Console.Write("\nDigite o seu endereço completo: ");
                            string enderecoDigitado = Console.ReadLine();
                            imovel.endereco = enderecoDigitado; // depois adicionar um método para armazenar no objeto

                            Console.Clear();

                            garantia.ImprimirDados();
                            imovel.ImprimirDados();
                        }
                        #endregion

                        #region "Confirmando dados da Garantia"
                        Console.Write("\nVocê confirma esses dados? (Sim/Não): ");

                        string confirmaGarantia = Console.ReadLine();
                        Console.Clear();

                        if (confirmaGarantia.ToLower() == "sim")
                            break;

                        telasConsole.ImprimeCabecalho();
                        #endregion
                    }
                    #endregion

                    #region "CÁLCULOS DO EMPRÉSTIMO"
                    telasConsole.ImprimeCabecalho();
                    analise.CalculaValorEmprestimo(garantia);
                    bool validaValor;
                    do
                    {
                        Console.WriteLine(String.Format("\n|{0,48}|", "-------------------------------------------------"));
                        Console.WriteLine(String.Format("|{0,48}|","-------- VALORES DISPONÍVEIS DE EMPRÉSTIMO ------"));
                        Console.WriteLine(String.Format("|{0,48}|","-------------------------------------------------"));
                        Console.WriteLine(String.Format("|{0,-16}|{1,-32}|"," Valor Mínimo"," R$ " + analise.valorMinimoEmprestimo.ToString("N2")));
                        Console.WriteLine(String.Format("|{0,-16}|{1,-32}|"," Valor Máximo"," R$ " + analise.valorMaximoEmprestimo.ToString("N2")));
                        Console.WriteLine(String.Format("|{0,48}|","-------------------------------------------------"));

                        Console.WriteLine($"\nVerifiquei aqui no sistema o valor máximo que posso te disponibilizar para empréstimo é {analise.valorMaximoEmprestimo.ToString("C")}.");
                        Console.WriteLine("\nQual valor você gostaria de emprestar? ");
                        Console.Write("R$ ");

                        validaValor = decimal.TryParse(
                            Console.ReadLine(),
                            out analise.valorEmprestado
                        );

                        if (analise.valorEmprestado > analise.valorMaximoEmprestimo)
                        {
                            telasConsole.ImprimeCabecalho();
                            Console.WriteLine("\nValor maior que o permitido!");
                            validaValor = false;
                        }
                        if (analise.valorEmprestado < analise.valorMinimoEmprestimo)
                        {
                            telasConsole.ImprimeCabecalho();
                            Console.WriteLine("\nValor menor que o permitido!");
                            Console.WriteLine(
                                $"O valor mínimo permitido é {analise.valorMinimoEmprestimo.ToString("C")}"
                            );
                            validaValor = false;
                        }
                    } while (validaValor == false);

                    Emprestimo emprestimo = new Emprestimo(analise, garantia);
                    #endregion

                    #region "ESCOLHENDO AS CONDIÇÕES DO EMPRÉSTIMO"
                    double parcelaEscolhida = 0;
                    validaValor = true;

                    telasConsole.ImprimeCabecalho();

                    do
                    {
                        Console.WriteLine("\nEncontramos quatro ofertas para você! ");

                        Console.WriteLine(String.Format("\n|{0,37}|", "-------------------------------------"));
                        Console.WriteLine(String.Format("|{0,37}|", "------- VEJA AS NOSSAS OFERTAS ------"));
                        Console.WriteLine(String.Format("|{0,37}|", "-------------------------------------"));
                        Console.WriteLine(String.Format("|{0,-37}|", " Empréstimo: R$ " + emprestimo.valorEmprestado.ToString("N2")));
                        Console.WriteLine(String.Format("|{0,37}|", "-------------------------------------"));
                        emprestimo.ImprimeParcelas();
                        Console.WriteLine(String.Format("|{0,37}|", "-------------------------------------"));

                        Console.Write("\nEm quantas parcelas você prefere? ");
                        validaValor = double.TryParse(Console.ReadLine(), out parcelaEscolhida);

                        if (!Array.Exists(emprestimo.numParcela, element => element == parcelaEscolhida) || parcelaEscolhida == 0)
                        {
                            telasConsole.ImprimeCabecalho();
                            Console.WriteLine($"\nNúmero de parcelas inválido! Não é possível escolher {parcelaEscolhida} parcelas.");
                            validaValor = false;
                        }
                        else
                        {
                            validaValor = true;
                            emprestimo.CalculaValorParcela(parcelaEscolhida);
                            emprestimo.CalculaTotalDivida();
                            emprestimo.CalculaTotalJuros();
                        }
                    } while (validaValor == false);
                    #endregion

                    #region "Contrato"
                    for (int i = 0; i < 4; i++)
                    {
                        Console.Clear();
                        Console.Write("Gerando Contrato");
                        Console.Write(" ");
                        Console.Write("...");
                        Thread.Sleep(millisecondsTimeout: 600);
                    }

                    Console.Clear();

                    Contrato contrato = sis.CriaContrato(cliente, funcionario, DateTime.Today, emprestimo, garantia, veiculo, imovel);

                    Console.WriteLine("\n [1] Assinar Contrato      [2] Cancelar Contrato");
                    while (true)
                    {
                        Console.Write("\n Digite a sua opção: ");
                        string? opcaoEscolhida = Console.ReadLine();

                        if (string.IsNullOrEmpty(opcaoEscolhida))
                        {
                            opcaoEscolhida = "0";
                        }

                        if (opcaoEscolhida == "1")
                        {
                            contrato.AssinarContrato();
                            Console.WriteLine("\n |-------------------------------------|");
                            Console.WriteLine(" |--------- CONTRATO ASSINADO ---------|");
                            Console.WriteLine(" |-------------------------------------|");
                            Console.WriteLine("\n Muito obrigado por confiar em nós!");
                            break;
                        }
                        else if (opcaoEscolhida == "2")
                        {
                            Console.WriteLine("\n |------------------------------------|");
                            Console.WriteLine(" |-------- CONTRATO CANCELADO --------|");
                            Console.WriteLine(" |------------------------------------|");
                            break;
                        }

                        Console.WriteLine("\n Por favor, digite uma opção válida!");
                    }

                    Console.Write("\n\n Aperte qualquer tecla para voltar para o menu inicial.");
                    Console.ReadKey();
                    #endregion
                }
            }
        }
    }
}
