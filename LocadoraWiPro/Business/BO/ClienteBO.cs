using Business.Interface;
using Domain.Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business
{
    public class ClienteBO : IClienteBO
    {
        private readonly IClienteRepository _repository;
        public ClienteBO(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<Cliente> Alterar(Cliente entity)
        {
            return await _repository.Alterar(entity);
        }

        public async Task<Cliente> Buscar(int Id)
        {
            return await _repository.Buscar(Id);
        }

        public async Task<List<Cliente>> BuscarTodos()
        {
            var clientes = await _repository.BuscarTodos();
            return await _repository.BuscarTodos();
        }

        public async Task<Cliente> Cadastrar(Cliente entity)
        {
           if(_repository.BuscarPor(x => x.CPF == entity.CPF) != null)
            {
                throw new ArgumentException("CPF Já Cadastrado!");
            }
            return await _repository.Cadastrar(entity);
        }
        public async Task<Cliente> Inativar(int Id)
        {
            var cliente = await _repository.Buscar(Id);
            cliente.Inativo = true;
            return await _repository.Alterar(cliente);
        }
        public async Task<Cliente> Reativar(int Id)
        {
            var cliente = await _repository.Buscar(Id);
            cliente.Inativo = false;
            return await _repository.Alterar(cliente);
        }
    }
}
