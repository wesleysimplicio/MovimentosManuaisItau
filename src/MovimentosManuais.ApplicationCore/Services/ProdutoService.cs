using MovimentosManuais.ApplicationCore.Entity;
using MovimentosManuais.ApplicationCore.Interfaces.Repository;
using MovimentosManuais.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MovimentosManuais.ApplicationCore.Services
{
    public class ProdutoService: IProdutoService
    {
        private readonly IRepository<Produto> _repository;

        public ProdutoService(IRepository<Produto> repository)
        {
            _repository = repository;
        }

        public Produto Adicionar(Produto entity)
        {
            return _repository.Adicionar(entity);
        }
        public void Atualizar(Produto entity)
        {
            _repository.Atualizar(entity);
        }
        public IEnumerable<Produto> ObterTodos()
        {
            return _repository.ObterTodos();
        }
        public Produto ObterId(int Id)
        {
            return _repository.ObterId(Id);
        }
        public IEnumerable<Produto> Buscar(Expression<Func<Produto, bool>> predicado)
        {
            return _repository.Buscar(predicado);
        }
        public void Remover(Produto entity)
        {
            _repository.Remover(entity);
        }
    }
}
