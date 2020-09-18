using Business.Interfaces;
using Domain.Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.BO
{
    public class FilmeBO : IFilmeBO
    {
        private readonly IFilmeRepository _repository;
        public FilmeBO(IFilmeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Filme> Alterar(Filme entity)
        {
            return await _repository.Alterar(entity);
        }

        public async Task<Filme> Buscar(int Id)
        {
            return await _repository.Buscar(Id);
        }

        public async Task<List<Filme>> BuscarTodos()
        {
            return await _repository.BuscarTodos();
        }

        public async Task<Filme> Cadastrar(Filme entity)
        {
            return await _repository.Cadastrar(entity);
        }
        public async Task<Filme> Inativar(int Id)
        {
            var Filme = await _repository.Buscar(Id);
            Filme.Inativo = true;
            return await _repository.Alterar(Filme);
        }
        public async Task<Filme> Reativar(int Id)
        {
            var Filme = await _repository.Buscar(Id);
            Filme.Inativo = false;
            return await _repository.Alterar(Filme);
        }
    }
}
