using System;
using System.Collections.Generic;
using System.Text;

namespace Produto.Domain.Model
{
    public class Produto
    {
        public int? id { get; set; }
        public string descricao { get; set; }
        public decimal preco { get; set; }
        public int estoque { get; set; }
        public int departamento_Id { get; set; }
        public virtual Departamento Departamento { get; set; }
    }
}
