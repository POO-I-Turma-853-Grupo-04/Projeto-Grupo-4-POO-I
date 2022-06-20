using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teste
{
    public class Emprestimo
    {
        private decimal valorMaximo; // PEGA ANALISE DE RISCO
        private decimal valorMinimo; // PEGA ANALISE DE RISCO
        private double numParcelaAuto = 18; // PEGA GARANTIA SUB CLASSE

        //private List<int> numParcelaImovel = new List<int>(60, 90, 120, 150);
        private double valorParcela; 
        private double valorTotalDivida;
        private double valorEmprestado = 100000;
        private double jurosMensal = 0.015;
        private double totalJuros;
        private double aux1;

        public Emprestimo(){
            this.CalculaValorParcela();
            this.CalculaTotalDivida();
            this.CalculaTotalJuros();
        }
        public void CalculaValorParcela()
        {
            this.aux1 = Math.Pow((1 + this.jurosMensal), this.numParcelaAuto);

            this.valorParcela = this.valorEmprestado * ((aux1 * this.jurosMensal)/(aux1 - 1));
            //Console.WriteLine("valor parcela: " + this.valorParcela.ToString("C"));
        }

        public void CalculaTotalDivida(){
            this.valorTotalDivida = this.valorParcela * this.numParcelaAuto;
            //Console.WriteLine("Total divida: " + this.valorTotalDivida.ToString("C"));
        }

        public void CalculaTotalJuros(){
            this.totalJuros = this.valorTotalDivida - this.valorEmprestado;
            //Console.WriteLine("total juros: " + this.totalJuros.ToString("C"));
        }
    }
}
