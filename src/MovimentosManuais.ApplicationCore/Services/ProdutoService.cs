using MovimentosManuais.ApplicationCore.Entity;
using MovimentosManuais.ApplicationCore.Interfaces.Repository;
using MovimentosManuais.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovimentosManuais.ApplicationCore.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IRepository<Produto> _repository;
        private readonly IProdutoCosifService _produtoCosifService;


        public ProdutoService(IProdutoCosifService produtoCosifService,
            IRepository<Produto> repository)
        {
            _repository = repository;
            _produtoCosifService = produtoCosifService;
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
        public Produto ObterCod(string Cod)
        {
            return _repository.ObterCod(Cod);
        }
        public IEnumerable<Produto> Buscar(Expression<Func<Produto, bool>> predicado)
        {
            return _repository.Buscar(predicado);
        }
        public void Remover(Produto entity)
        {
            var produto_cosif = _produtoCosifService.ObterCod(entity.COD_PRODUTO);
            if (produto_cosif != null) {
                _produtoCosifService.Remover(produto_cosif);
                _repository.Remover(entity);
            }
        }
    }
}
