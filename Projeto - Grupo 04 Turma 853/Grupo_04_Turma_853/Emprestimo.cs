using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo_04_Turma_853
{
    public class Emprestimo
    {
        public decimal? valorTotal;
        public decimal? valorParcela;
        public int? numeroParcelas; //nome alterado no uml
        public double? taxa; //tipo alterado no uml
        public Garantia garantia;

        public void CalculaValorMaximo(int score){
        

        }
    }
}