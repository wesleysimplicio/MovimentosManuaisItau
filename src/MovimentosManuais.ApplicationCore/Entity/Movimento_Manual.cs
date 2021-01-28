﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MovimentosManuais.ApplicationCore.Entity
{
    public class Movimento_Manual
    {
        public Movimento_Manual()
        {

        }
        public int DAT_MES { get; set; }
        public int DAT_ANO { get; set; }
        public int NUM_LANCAMENTO { get; set; }
        public string COD_PRODUTO { get; set; }
        public string COD_COSIF { get; set; }
        public string DES_DESCRICAO { get; set; }
        public DateTime DAT_MOVIMENTO { get; set; }
        public string COD_USUARIO { get; set; }
        public decimal VAL_VALOR { get; set; }
        public Produto PRODUTO { get; set; }
        public Produto_Cosif PRODUTO_COSIF { get; set; }
    }
}
