using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IRepositoryBase<T>
    {
        Task<List<T>> BuscarTodos();
        Task<T> Buscar(int Id);
        Task<T> Cadastrar(T entity);
        Task<T> Alterar(T entity);
        T BuscarPor(Expression<Func<T, bool>> filtro);
    }
}
