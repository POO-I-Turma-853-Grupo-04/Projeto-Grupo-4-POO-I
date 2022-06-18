namespace EmprestimoTopCoders
{
    public class Contrato
    {
        public int id;
        public Cliente cliente;
        public Funcionario funcionario;
        public DateTime dataContrato;
        // empréstimo
        // garantia

        public Contrato(int id, Cliente cliente, Funcionario funcionario, DateTime dataContrato)
        {
            this.id = id;
            this.cliente = cliente;
            this.funcionario = funcionario;
            this.dataContrato = dataContrato;
        }
    }
}
