using Business.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IBOAtivaInativa<T> : IBOBase<T>
    {
        Task<T> Inativar(int Id);
        Task<T> Reativar(int Id);
    }
}
