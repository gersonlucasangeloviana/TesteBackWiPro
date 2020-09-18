using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Repository.Database;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
   public class LocacaoRepository : ILocacaoRepository
    {
        private readonly LocacaoDbContext _context;
        public LocacaoRepository(LocacaoDbContext context)
        {
            _context = context;
        }
        public async Task<List<Locacao>> BuscarTodos()
        {
            return await _context.Locacacoes.ToListAsync();
        }

        public async Task<Locacao> Buscar(int Id)
        {
            return await _context.Locacacoes.FindAsync(Id);
        }
        public async Task<Locacao> Cadastrar(Locacao entity)
        {
            await _context.Locacacoes.AddAsync(entity);
            _context.SaveChanges();
            return entity;
        }
        public async Task<Locacao> Alterar(Locacao entity)
        {
            _context.Locacacoes.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public Locacao BuscarPor(Expression<Func<Locacao, bool>> filtro)
        {
            return _context.Locacacoes.Where(filtro).FirstOrDefault();
        }

    }
}
