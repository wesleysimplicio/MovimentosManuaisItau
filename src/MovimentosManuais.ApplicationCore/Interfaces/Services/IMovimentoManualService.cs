using MovimentosManuais.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MovimentosManuais.ApplicationCore.Interfaces.Services
{
    public interface IMovimentoManualService
    {
        Movimento_Manual Adicionar(Movimento_Manual entity);
        void Atualizar(Movimento_Manual entity);
        IEnumerable<Movimento_Manual> ObterTodos();
        Movimento_Manual ObterId(int Id);
        Movimento_Manual ObterCod(string Cod);
        IEnumerable<Movimento_Manual> Buscar(Expression<Func<Movimento_Manual, bool>> predicado);
        void Remover(Movimento_Manual entity);
    }
}
