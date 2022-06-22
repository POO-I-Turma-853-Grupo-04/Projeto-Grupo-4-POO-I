using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo_04_Turma_853
{
    public class Emprestimo
    {
        public AnaliseRisco analiseRisco;
        public Garantia garantia;

        public decimal valorMaximo;
        public decimal valorMinimo;
        public int[] numParcela;

        //CALCULA EMPRESTIMO
        public double parcelaSelecionada; //numero de parcelas que o cliente escolheu
        public double valorParcela;
        public double valorTotalDivida;
        public double valorEmprestado;
        public double jurosMensal;
        public double totalJuros;
        public double aux1;

        public Emprestimo(AnaliseRisco analiseRisco, Garantia garantia)
        {
            this.valorMaximo = analiseRisco.valorMaximoEmprestimo;
            this.valorMinimo = analiseRisco.valorMinimoEmprestimo;

            // Adicionei para a classe Emprestimo conseguir puxar o valor da AnaliseRisco na hora do construtor
            this.valorEmprestado = (double)analiseRisco.valorEmprestado; 

            if (garantia.CodigoTipo == 1)
            {
                this.numParcela = new int[] { 18, 24, 30, 36 };
                this.jurosMensal = 0.0149;
            }
            else
            {
                this.numParcela = new int[] { 60, 90, 120, 150 };
                this.jurosMensal = 0.0099;
            }
        }

        public void ImprimeParcelas()
        {
            foreach (double num in numParcela)
            {
                CalculaValorParcela(num); //passar aqui parametro NUMERO DE PARCELAS
                //Console.WriteLine($"{num} vezes de {this.valorParcela.ToString("C")}");
                Console.WriteLine(String.Format("|{0,-37}|", " - " + num + " vezes de " + this.valorParcela.ToString("C")));
            }
        }

        public void CalculaValorParcela(double numParcela)
        {
            this.parcelaSelecionada = numParcela;
            this.aux1 = Math.Pow((1 + this.jurosMensal), numParcela);

            this.valorParcela = this.valorEmprestado * ((aux1 * this.jurosMensal) / (aux1 - 1));
            //Console.WriteLine("valor parcela: " + this.valorParcela.ToString("C"));
        }

        public void CalculaTotalDivida()
        {
            this.valorTotalDivida = this.valorParcela * this.parcelaSelecionada;
            //Console.WriteLine("Total divida: " + this.valorTotalDivida.ToString("C"));
        }

        public void CalculaTotalJuros()
        {
            this.totalJuros = this.valorTotalDivida - this.valorEmprestado;
            //Console.WriteLine("total juros: " + this.totalJuros.ToString("C"));
        }

        public void ImprimeEmprestimo()
        {
            this.CalculaValorParcela(this.parcelaSelecionada);
            //Console.WriteLine($"Valor da parcela: {this.valorParcela}");
            Console.WriteLine(String.Format("|{0,-40}|", " Valor da parcela: R$ " + this.valorParcela.ToString("N2")));

            this.CalculaTotalDivida();
            //Console.WriteLine($"Valor total da divida: {this.valorTotalDivida}");
            Console.WriteLine(String.Format("|{0,-40}|", " Valor total da dívida: R$ " + this.valorTotalDivida.ToString("N2")));

            this.CalculaTotalJuros();
            //Console.WriteLine($"Valor total dos juros: {this.totalJuros}");
            Console.WriteLine(String.Format("|{0,-40}|", " Valor total dos juros: R$ " + this.totalJuros.ToString("N2")));

        }
    }
}
