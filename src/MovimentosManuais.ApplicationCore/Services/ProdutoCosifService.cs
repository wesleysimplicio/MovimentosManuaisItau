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
    public class ProdutoCosifService: IProdutoCosifService
    {
        private readonly IRepository<Produto_Cosif> _repository;

        public ProdutoCosifService(IRepository<Produto_Cosif> repository)
        {
            _repository = repository;
        }
        public Produto_Cosif Adicionar(Produto_Cosif entity)
        {
            return _repository.Adicionar(entity);
        }
        public void Atualizar(Produto_Cosif entity)
        {
            _repository.Atualizar(entity);
        }
        public IEnumerable<Produto_Cosif> ObterTodos()
        {
            return _repository.ObterTodos();
        }
        public Produto_Cosif ObterId(int Id)
        {
            return _repository.ObterId(Id);
        }
        public Produto_Cosif ObterCod(string Cod)
        {
            return _repository.ObterCod(Cod);
        }
        public IEnumerable<Produto_Cosif> Buscar(Expression<Func<Produto_Cosif, bool>> predicado)
        {
            return _repository.Buscar(predicado);
        }
        public void Remover(Produto_Cosif entity)
        {
            _repository.Remover(entity);
        }
    }
}
