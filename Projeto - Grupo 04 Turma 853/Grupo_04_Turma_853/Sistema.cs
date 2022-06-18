using static EmprestimoTopCoders.Auxiliar;

namespace EmprestimoTopCoders
{
    class Sistema
    {
        public List<Cliente> clientes = new List<Cliente>();
        public List<Funcionario> funcionarios = new List<Funcionario>();
        public List<Contrato> contratos = new List<Contrato>();

        public void InicializaFuncionarios(int quantidadeFuncionarios)
        {
            while (funcionarios.Count < quantidadeFuncionarios)
            {
                Funcionario funcionario = CriaFuncionario();

                bool nomeRepetido = false;
                foreach (Funcionario f in funcionarios)
                {
                    if (funcionario.nome == f.nome)
                        nomeRepetido = true;
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
                    f.ImprimirDados();
            }
        }

        public Funcionario AtribuiFuncionario()
        {
            Random rnd = new Random();
            return funcionarios[rnd.Next(0, funcionarios.Count)];
        }

        public void AdicionaCliente(Cliente cliente)
        {
            cliente.score = CriaScore();
            clientes.Add(cliente);
        }

        public void ConsultaCliente(string cpf)
        {
            foreach (Cliente c in clientes)
            {
                if (c.cpf == cpf)
                    c.ImprimirDados();
            }
        }

        public void CriaContrato(Cliente cliente, Funcionario funcionario) // Recebe também Empréstimo e Garantia
        {
            int id = contratos.Count + 1;
            Contrato contrato = new Contrato(id, cliente, funcionario, DateTime.Now);
            contratos.Add(contrato);
        }

        public void ListaContratos()
        {
            foreach (Contrato c in contratos)
            {
                Console.WriteLine($"Contrato {c.id}. Funcionário Responsável: {c.funcionario.nome}. Cliente {c.cliente.nome}.");
            }
        }

        public void ConsultaContrato(int id)
        {
            foreach (Contrato c in contratos)
            {
                // if (c.id == id)
                    // c.ImprimirContrato();
            }
        }
    }
}