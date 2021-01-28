using MovimentosManuais.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MovimentosManuais.ApplicationCore.Interfaces.Services
{
    public interface IProdutoCosifService
    {
        Produto_Cosif Adicionar(Produto_Cosif entity);
        void Atualizar(Produto_Cosif entity);
        IEnumerable<Produto_Cosif> ObterTodos();
        Produto_Cosif ObterId(int Id);
        Produto_Cosif ObterCod(string Cod);
        IEnumerable<Produto_Cosif> Buscar(Expression<Func<Produto_Cosif, bool>> predicado);
        void Remover(Produto_Cosif entity);
    }
}
