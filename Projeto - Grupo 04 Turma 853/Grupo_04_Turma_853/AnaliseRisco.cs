using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo_04_Turma_853
{
    public class AnaliseRisco
    {
        public Cliente cliente;
        public Garantia garantia;
        public decimal valorMaximoEmprestimo;
        public decimal valorMinimoEmprestimo;
        public decimal porcentagemScore;
        public int score;
        public decimal valorGarantia;

        public AnaliseRisco(Cliente cliente, Garantia garantia)
        {
            this.score = cliente.score;
            this.valorGarantia = garantia.Valor;

            if (score <= 300)
            {
                Console.WriteLine("Emprestimo não concedido. Score abaixo do ideal");
            }
            else if (score >= 301 && score <= 500)
            {
                this.porcentagemScore = 0.5M;
            }
            else if (score >= 501 & score <= 700)
            {
                this.porcentagemScore = 0.7M;
            }
            else
            {
                this.porcentagemScore = 1M;
            }

            this.CalculaValorEmprestimo();
        }

        private void CalculaValorEmprestimo()
        {
            this.valorMaximoEmprestimo = (this.valorGarantia / 2) * this.porcentagemScore;
            this.valorMinimoEmprestimo = this.valorMaximoEmprestimo * 0.3M;
        }
    }
}
