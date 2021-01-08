using System;
using System.Collections.Generic;
using System.Text;

namespace Produto.Domain.Dtos
{
    public class ProdutoDto
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public string departamento { get; set; }
    }
}
