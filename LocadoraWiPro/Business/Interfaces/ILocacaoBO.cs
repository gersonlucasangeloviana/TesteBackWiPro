using Business.Interface;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ILocacaoBO : IBOBase<Locacao>
    {
        Task<string> Devolver(int idLocacao);
    }
}
