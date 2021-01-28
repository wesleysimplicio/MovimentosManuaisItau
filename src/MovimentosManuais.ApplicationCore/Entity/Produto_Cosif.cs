using System;
using System.Collections.Generic;
using System.Text;

namespace MovimentosManuais.ApplicationCore.Entity
{
    public class Produto_Cosif
    {
        public Produto_Cosif()
        {

        }

        public string COD_PRODUTO { get; set; }
        public string COD_COSIF { get; set; }
        public string COD_CLASSIFICACAO { get; set; }
        public string STA_STATUS { get; set; }
        public Produto PRODUTO { get; set; }
        public ICollection<Movimento_Manual> MOVIMENTOS_MANUAIS { get; set; }
    }
}
