using Business.Interfaces;
using Domain.Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.BO
{
    public class LocacaoBO : ILocacaoBO
    {
        private readonly ILocacaoRepository _repository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IFilmeRepository _filmeRepository;
        public LocacaoBO(ILocacaoRepository repository
            , IClienteRepository clienteRepository
            , IFilmeRepository filmeRepository)
        {
            _repository = repository;
            _clienteRepository = clienteRepository;
            _filmeRepository = filmeRepository;
        }

        public async Task<Locacao> Alterar(Locacao entity)
        {
            return await _repository.Alterar(entity);
        }

        public async Task<Locacao> Buscar(int Id)
        {
            return await _repository.Buscar(Id);
        }

        public async Task<List<Locacao>> BuscarTodos()
        {
            var Locacaos = await _repository.BuscarTodos();
            return await _repository.BuscarTodos();
        }

        public async Task<Locacao> Cadastrar(Locacao entity)
        {
            var cliente = await _clienteRepository.Buscar(entity.ClienteId);
            var filme = await _filmeRepository.Buscar(entity.FilmeId);
            if(cliente == null)
            {
                throw new Exception("Cliente Não Encontrado!");
            }
            if (filme == null)
            {
                throw new Exception("Filme Não Encontrado!");
            }
            if (filme.Alugado)
            {
                throw new Exception("Filme Já Alugado!!!");
            }
            entity.Cliente = cliente;
            entity.Filme = filme;

            return await _repository.Cadastrar(entity);
        }

        public async Task<string> Devolver(int idLocacao)
        {
            var locacao = await _repository.Buscar(idLocacao);
            if(locacao == null)
            {
                throw new Exception("Locação não Encontrada para devolução!");
            }
            locacao.Devolvido = true;
            await _repository.Alterar(locacao);
            if (DateTime.Now.Date > locacao.DataDevolucao.Date)
            {
                return $"Atenção!!! Devolução com Atraso de {DiferencaDaDevolucao(locacao.DataDevolucao.Date)} Dia(s)";
            }
                return "Devolução Realizada"; 
        }
        private int DiferencaDaDevolucao(DateTime data)
        {
            return DateTime.Now.Date.Subtract(data).Days;
        }
    }
}
