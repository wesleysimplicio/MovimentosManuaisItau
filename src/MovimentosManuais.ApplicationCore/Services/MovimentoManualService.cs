using MovimentosManuais.ApplicationCore.Entity;
using MovimentosManuais.ApplicationCore.Interfaces.Repository;
using MovimentosManuais.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovimentosManuais.ApplicationCore.Services
{
    public class MovimentoManualService : IMovimentoManualService
    {
        private readonly IRepository<Movimento_Manual> _repository;
        private readonly IProdutoService _produtoService;


        public MovimentoManualService(IProdutoService produtoService,
            IRepository<Movimento_Manual> repository)
        {
            _repository = repository;
            _produtoService = produtoService;
        }

        public Movimento_Manual Adicionar(Movimento_Manual entity)
        {
            entity.DAT_MOVIMENTO = DateTime.Now;
            entity.COD_USUARIO = "TESTE";

            var buscaUltimoLanc = _repository.Buscar(q => q.DAT_MES == entity.DAT_MES && q.DAT_ANO == entity.DAT_ANO).OrderByDescending(e=>e.DAT_MOVIMENTO).FirstOrDefault();

            entity.NUM_LANCAMENTO = (buscaUltimoLanc.NUM_LANCAMENTO > 0) ? buscaUltimoLanc.NUM_LANCAMENTO + 1 : 1;
            return _repository.Adicionar(entity);
        }
        public void Atualizar(Movimento_Manual entity)
        {
            _repository.Atualizar(entity);
        }
        public IEnumerable<Movimento_Manual> ObterTodos()
        {
            return _repository.Buscar(e => e.COD_PRODUTO != null).OrderByDescending(e => e.DAT_MOVIMENTO);
        }
        public Movimento_Manual ObterId(int Id)
        {
            return _repository.ObterId(Id);
        }
        public Movimento_Manual ObterCod(string Cod)
        {
            return _repository.ObterCod(Cod);
        }
        public IEnumerable<Movimento_Manual> Buscar(Expression<Func<Movimento_Manual, bool>> predicado)
        {
            return _repository.Buscar(predicado);
        }
        public void Remover(Movimento_Manual entity)
        {
            var produto = _produtoService.ObterCod(entity.COD_PRODUTO);
            if (produto != null)
            {
                _produtoService.Remover(produto);
                _repository.Remover(entity);
            }
        }
    }
}
