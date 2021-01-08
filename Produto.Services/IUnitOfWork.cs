using System;
using System.Collections.Generic;
using System.Text;



namespace Produto.Services
{
    public interface IUnitOfWork : IDisposable
    {
        SqlConnetion GetContextDomainModel(string connectionString);
    }
}
