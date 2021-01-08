using System;
using System.Collections.Generic;
using System.Text;

namespace Produto.Domain.Model
{
    public class Departamento
    {
        public int? id { get; set; }
        public string descricao { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
