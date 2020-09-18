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
    public class FilmeRepository : IFilmeRepository
    {
        private readonly LocacaoDbContext _context;
        public FilmeRepository(LocacaoDbContext context)
        {
            _context = context;
        }
        public async Task<List<Filme>> BuscarTodos()
        {
            return await _context.Filmes.ToListAsync();
        }

        public async Task<Filme> Buscar(int Id)
        {
            return await _context.Filmes.FindAsync(Id);
        }
        public async Task<Filme> Cadastrar(Filme entity)
        {
            await _context.Filmes.AddAsync(entity);
            _context.SaveChanges();
            return entity;
        }
        public async Task<Filme> Alterar(Filme entity)
        {
            _context.Filmes.Update(entity);
            await _context.SaveChangesAsync();
            return await entity;
        }
        public Filme BuscarPor(Expression<Func<Filme, bool>> filtro)
        {
            return _context.Filmes.Where(filtro).FirstOrDefault();
        }
    }
}
