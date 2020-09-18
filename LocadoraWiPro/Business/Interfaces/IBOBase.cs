using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IBOBase<T>
    {
        Task<T> Buscar(int Id);
        Task<List<T>> BuscarTodos();
        Task<T> Cadastrar(T entity);
        Task<T> Alterar(T entity);
    }
}
