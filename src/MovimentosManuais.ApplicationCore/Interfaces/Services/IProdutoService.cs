using MovimentosManuais.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MovimentosManuais.ApplicationCore.Interfaces.Services
{
    public interface IProdutoService
    {
        Produto Adicionar(Produto entity);
        void Atualizar(Produto entity);
        IEnumerable<Produto> ObterTodos();
        Produto ObterId(int Id);
        Produto ObterCod(string Cod);
        IEnumerable<Produto> Buscar(Expression<Func<Produto, bool>> predicado);
        void Remover(Produto entity);
    }
}
