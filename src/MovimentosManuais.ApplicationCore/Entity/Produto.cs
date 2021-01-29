using System;
using System.Collections.Generic;
using System.Text;

namespace MovimentosManuais.ApplicationCore.Entity
{
    public class Produto
    {
        public Produto()
        {

        }

        public string COD_PRODUTO { get; set; }
        public string DES_PRODUTO { get; set; }
        public string STA_STATUS { get; set; }
        //public ICollection<Produto_Cosif> PRODUTO_COSIFS { get; set; }
        //public ICollection<Movimento_Manual> MOVIMENTOS_MANUAIS { get; set; }

    }
}
