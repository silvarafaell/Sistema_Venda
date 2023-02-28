using SistemaVenda.Application.Extensions;
using SistemaVenda.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenda.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<OperationResult> Create(Produto produto);

        Task<OperationResult> FindAll();

        Task<OperationResult> FindById(int id);

        Task<OperationResult> Delete(int id);

        Task<OperationResult> Update(int id);
    }

}
