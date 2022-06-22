using static Grupo_04_Turma_853.Auxiliar;

namespace Grupo_04_Turma_853
{
    class Sistema
    {
        public List<Cliente> clientes = new List<Cliente>();
        public List<Funcionario> funcionarios = new List<Funcionario>();
        public List<Contrato> contratos = new List<Contrato>();
        public string senha = "123456";

        public void InicializaFuncionarios(int quantidadeFuncionarios)
        {
            for (int i = 0; i < quantidadeFuncionarios; i++)
            {
                Funcionario funcionario = CriaFuncionario();

                bool nomeRepetido = false;
                foreach (Funcionario f in funcionarios)
                {
                    if (funcionario.nome == f.nome)
                    {
                        nomeRepetido = true;
                        i--;
                    }
                }

                if (!nomeRepetido)
                    funcionarios.Add(funcionario);
            }
        }

        public void ListaFuncionarios()
        {
            Console.WriteLine("Lista de Funcionários: ");
            foreach (Funcionario f in funcionarios)
            {
                Console.WriteLine($"Nome: {f.nome}          CPF: {f.cpf}");
            }
        }

        public void ConsultaFuncionario(string cpf)
        {
            foreach (Funcionario f in funcionarios)
            {
                if (f.cpf == cpf)
                    f.ImprimirDados(true);
            }
        }

        public Funcionario AtribuiFuncionario()
        {
            Random rnd = new Random();
            return funcionarios[rnd.Next(0, funcionarios.Count)];
        }

        public bool AdicionaCliente(Cliente cliente)
        {
            foreach (Cliente c in clientes)
            {
                if (cliente.cpf == c.cpf)
                    return false;
            }

            cliente.score = CriaScore();
            clientes.Add(cliente);
            return true;
        }

        public void ListaCliente()
        {
            Console.WriteLine("Lista de Clientes: ");
            foreach (Cliente c in clientes)
            {
                Console.WriteLine($"Nome: {c.nome}          CPF: {c.cpf}");
            }
        }
        public void ConsultaCliente(string cpf)
        {
            foreach (Cliente c in clientes)
            {
                if (c.cpf == cpf)
                    c.ImprimirDados(true);
            }
        }

        public Contrato CriaContrato(Cliente cliente, Funcionario funcionario, DateTime dataContrato, Emprestimo emprestimo, Garantia garantia, Veiculo veiculo, Imovel imovel) // Recebe também Empréstimo e Garantia
        {
            int id = contratos.Count + 1;
            Contrato contrato = new Contrato(id, cliente, funcionario, DateTime.Now, emprestimo, garantia, veiculo, imovel);
            contratos.Add(contrato);

            contrato.ImprimirContrato();

            return contrato;
        }

        public void ListaContratos()
        {
            foreach (Contrato c in contratos)
            {
                Console.WriteLine($"Contrato {c.id}. Funcionário Responsável: {c.funcionario.nome}. Cliente {c.cliente.nome}.");
            }
        }

        public void ConsultaContrato(string id)
        {
            foreach (Contrato c in contratos)
            {
                if (Convert.ToString(c.id) == id)
                    c.ImprimirContrato();
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        public void ModoDesenvolvedor()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Olá, dev. O que temos pra hoje?");
                Console.WriteLine("1 - Cadastrar Funcionários");
                Console.WriteLine("2 - Consultar Funcionários");
                Console.WriteLine("3 - Consultar Clientes");
                Console.WriteLine("4 - Consultar Contratos");
                Console.WriteLine("5 - Criar Clientes");
                Console.WriteLine("6 - Sair");

                string escolhaDev = Console.ReadLine();
                Console.Clear();

                if (escolhaDev == "1")
                {
                    Console.WriteLine("-- Adicionar Funcionários --");
                    Console.WriteLine("Quantos funcionários deseja adicionar?");
                    Int32.TryParse(Console.ReadLine(), out int qtFuncionarios);

                    InicializaFuncionarios(qtFuncionarios);
                }
                else if (escolhaDev == "2")
                {
                    Console.WriteLine("-- Consultar Funcionários --");
                    ListaFuncionarios();
                    Console.Write("\nDigite o CPF do funcionário que deseja mais informações: ");
                    string cpf = Console.ReadLine();
                    Console.WriteLine();
                    ConsultaFuncionario(cpf);
                    Console.ReadKey();
                }
                else if (escolhaDev == "3")
                {
                    Console.WriteLine("-- Consultar Clientes --");
                    ListaCliente();
                    Console.WriteLine("\nDigite o CPF do cliente que deseja mais informações: ");
                    string cpf = Console.ReadLine();
                    Console.WriteLine();
                    ConsultaCliente(cpf);
                    Console.ReadKey();
                }
                else if (escolhaDev == "4")
                {
                    Console.WriteLine("-- Consultar Contrato --");
                    ListaContratos();

                    Console.WriteLine("Digite o ID do contrato que deseja visualizar.");
                    string id = Console.ReadLine();
                    ConsultaContrato(id);
                }
                else if (escolhaDev == "5")
                {
                    Console.WriteLine("-- Criar Clientes --");
                    Console.WriteLine("Quantos clientes deseja adicionar?");

                    Int32.TryParse(Console.ReadLine(), out int qtClientes);

                    for (int i = 0; i < qtClientes; i++)
                    {
                        AdicionaCliente(CriaCliente());
                    }
                }
                else if (escolhaDev == "6") break;
            }
        }
    }
}