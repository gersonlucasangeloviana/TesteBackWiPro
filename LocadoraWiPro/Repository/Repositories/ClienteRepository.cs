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
    public class ClienteRepository : IClienteRepository
    {
        private readonly LocacaoDbContext _context;
        public ClienteRepository(LocacaoDbContext context)
        {
            _context = context;
        }
        public async Task<List<Cliente>> BuscarTodos()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> Buscar(int Id)
        {
            return await _context.Clientes.FindAsync(Id);
        }
        public async Task<Cliente> Cadastrar(Cliente entity)
        {
            await _context.Clientes.AddAsync(entity);
            _context.SaveChanges();

            return entity;
        }
        public async Task<Cliente> Alterar(Cliente entity)
        {
            _context.Clientes.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public Cliente BuscarPor(Expression<Func<Cliente, bool>> filtro)
        {
            return _context.Clientes.Where(filtro).FirstOrDefault();
        }
    }
}
