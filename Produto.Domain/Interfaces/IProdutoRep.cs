﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Produto.Domain.Interfaces
{
    public interface IProdutoRep : IRepository<Model.Produto>
    {
        Task<ICollection<Model.Produto>> GetByDepartamentoId(int departamentoId);
    }
}