using System;
using System.Collections.Generic;
using System.Text;

namespace Produto.Domain.Dtos
{
    public class ProdutoAllDto
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public decimal preco { get; set; }
        public int estoque { get; set; }       
        public string departamento { get; set; }
    }
}
