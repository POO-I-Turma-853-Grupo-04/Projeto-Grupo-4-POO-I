using static Grupo_04_Turma_853.Auxiliar;

namespace Grupo_04_Turma_853
{
    public class Contrato
    {
        public int id;
        public Cliente cliente;
        public Funcionario funcionario;
        public DateTime dataContrato;
        public Emprestimo emprestimo;
        public Garantia garantia;
        public Veiculo veiculo;
        public Imovel imovel;
        public bool contratoAssinado;

        public Contrato(int id, Cliente cliente, Funcionario funcionario, DateTime dataContrato, Emprestimo emprestimo, Garantia garantia, Veiculo veiculo, Imovel imovel)
        {
            this.id = id;
            this.cliente = cliente;
            this.funcionario = funcionario;
            this.dataContrato = dataContrato;
            this.emprestimo = emprestimo;
            this.garantia = garantia;
            this.veiculo = veiculo;
            this.imovel = imovel;
        }

        public void ImprimirContrato()
        {
            Console.WriteLine(String.Format("\n|{0,72}|", "------------------------------------------------------------------------"));
            Console.WriteLine(String.Format("|{0,72}|", "---------------------    CONTRATO DE EMPRÉSTIMO    ---------------------"));
            Console.WriteLine(String.Format("|{0,72}|", "------------------------------------------------------------------------"));
            Console.WriteLine(String.Format("|{0,72}|", "--------------------         DADOS PESSOAIS         --------------------"));
            Console.WriteLine(String.Format("|{0,72}|", "------------------------------------------------------------------------"));
            Console.WriteLine(String.Format("|{0,-72}|", " Nome"));
            Console.WriteLine(String.Format("|{0,-72}|", "  " + CapitalizaString(cliente.nome)));
            Console.WriteLine(String.Format("|{0,72}|", "------------------------------------------------------------------------"));
            Console.WriteLine(String.Format("|{0,-36}|{1,-35}|", " CPF", " Telefone"));
            Console.WriteLine(String.Format("|{0,-36}|{1,-35}|", "  " + TratarCPF(cliente.cpf), "  " + TratarTelefone(cliente.telefone)));
            Console.WriteLine(String.Format("|{0,72}|", "------------------------------------------------------------------------"));
            Console.WriteLine(String.Format("|{0,72}|", "------------------------   DADOS DA GARANTIA    ------------------------"));
            Console.WriteLine(String.Format("|{0,72}|", "------------------------------------------------------------------------"));
            Console.WriteLine(String.Format("|{0,-20}|{1,-51}|", " Tipo", " Valor"));
            Console.WriteLine(String.Format("|{0,-20}|{1,-51}|", "  " + garantia.Tipo[garantia.CodigoTipo - 1],"  " + garantia.Valor.ToString("C")));
            Console.WriteLine(String.Format("|{0,72}|", "------------------------------------------------------------------------"));

            if (garantia.CodigoTipo == 1)
            {
                Console.WriteLine(String.Format("|{0,-20}|{1,-51}|", " Placa", " Modelo"));
                Console.WriteLine(String.Format("|{0,-20}|{1,-51}|", "  " + veiculo.Placa, "  " + CapitalizaString(veiculo.Modelo)));
                Console.WriteLine(String.Format("|{0,72}|", "------------------------------------------------------------------------"));
            }
            else if (garantia.CodigoTipo == 2)
            {
                Console.WriteLine(String.Format("|{0,-72}|", " Endereço Completo"));
                Console.WriteLine(String.Format("|{0,-72}|", "  " + imovel.endereco + ", CEP: " + imovel.cep));
                Console.WriteLine(String.Format("|{0,72}|", "------------------------------------------------------------------------"));
            }

            Console.WriteLine(String.Format("|{0,72}|", "--------------------   INFORMAÇÕES DO EMPRÉSTIMO    --------------------"));
            Console.WriteLine(String.Format("|{0,72}|", "------------------------------------------------------------------------"));
            Console.WriteLine(String.Format("|{0,-25}|{1,-46}|", " Valor Contratado", " Condição de Pagamento"));
            Console.WriteLine(String.Format("|{0,-25}|{1,-46}|", "  " + emprestimo.valorEmprestado.ToString("C"), "  " + emprestimo.parcelaSelecionada + " parcelas de " + emprestimo.valorParcela.ToString("C")));
            Console.WriteLine(String.Format("|{0,72}|", "------------------------------------------------------------------------"));
            Console.WriteLine(String.Format("|{0,-25}|{1,-46}|", " Juros a pagar", " Valor Total da Dívida"));
            Console.WriteLine(String.Format("|{0,-25}|{1,-46}|", "  " + emprestimo.totalJuros.ToString("C"), "  " + emprestimo.valorTotalDivida.ToString("C")));
            Console.WriteLine(String.Format("|{0,72}|", "------------------------------------------------------------------------"));
            Console.WriteLine(String.Format("|{0,72}|", ""));
            Console.WriteLine(String.Format("|{0,-72}|", "  Eu estou ciente dos valores e condições do contrato."));
            Console.WriteLine(String.Format("|{0,72}|", ""));
            Console.WriteLine(String.Format("|{0,72}|", "------------------------------------------------------------------------"));
            Console.WriteLine(String.Format("|{0,72}|", "--------------   FUNCIONÁRIO RESPONSÁVEL PELO CONTRATO    --------------"));
            Console.WriteLine(String.Format("|{0,72}|", "------------------------------------------------------------------------"));
            Console.WriteLine(String.Format("|{0,-72}|", " Nome"));
            Console.WriteLine(String.Format("|{0,-72}|", "  " + CapitalizaString(funcionario.nome)));
            Console.WriteLine(String.Format("|{0,72}|", "------------------------------------------------------------------------"));
            Console.WriteLine(String.Format("|{0,-36}|{1,-35}|", " CPF", " Telefone"));
            Console.WriteLine(String.Format("|{0,-36}|{1,-35}|", "  " + TratarCPF(funcionario.cpf), "  " + TratarTelefone(funcionario.telefone)));
            Console.WriteLine(String.Format("|{0,72}|", "------------------------------------------------------------------------"));
            Console.WriteLine(String.Format("|{0,72}|", "------------------------------------------------------------------------"));
            Console.WriteLine(String.Format("|{0,72}|", "---------------------------   ASSINATURAS    ---------------------------"));
            Console.WriteLine(String.Format("|{0,72}|", "------------------------------------------------------------------------"));
            Console.WriteLine(String.Format("|{0,-36}|{1,-35}|", " Contratante", " Responsável da Let's Bank"));
            Console.WriteLine(String.Format("|{0,-36}|{1,-35}|", "  " + CapitalizaString(cliente.nome), "  " + CapitalizaString(funcionario.nome)));
            Console.WriteLine(String.Format("|{0,-36}|{1,-35}|", "  Ass.: " + (contratoAssinado == true ? "ASSINADO DIGITALMENTE" : ""), "  Ass.: " + (contratoAssinado == true ? funcionario.nome : "")));
            Console.WriteLine(String.Format("|{0,72}|", "------------------------------------------------------------------------"));
            Console.WriteLine(String.Format("|{0,-72}|", " Local e Data"));
            Console.WriteLine(String.Format("|{0,-72}|", "  São Paulo, " + dataContrato.ToString("dd 'de' MMMM 'de' yyyy") + "."));
            Console.WriteLine(String.Format("|{0,72}|", "------------------------------------------------------------------------"));
        }

        public void AssinarContrato()
        {
            funcionario.Bonificar((decimal)emprestimo.valorEmprestado);
            contratoAssinado = true;
            this.cliente.contrato = this;
            funcionario.contratos.Add(this);
        }
    }
}
