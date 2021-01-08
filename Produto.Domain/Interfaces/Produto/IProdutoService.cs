using System;
using System.Collections.Generic;
using System.Text;
using Produto.Domain.Model;

namespace Produto.Domain.Interfaces
{
    public interface IProdutoService : IRepository<Model.Produto>
    {
    }
}
