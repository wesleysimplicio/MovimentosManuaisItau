﻿using MovimentosManuais.ApplicationCore.Entity;
using MovimentosManuais.ApplicationCore.Interfaces.Repository;
using MovimentosManuais.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

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
            return _repository.Adicionar(entity);
        }
        public void Atualizar(Movimento_Manual entity)
        {
            _repository.Atualizar(entity);
        }
        public IEnumerable<Movimento_Manual> ObterTodos()
        {
            return _repository.ObterTodos();
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
            if (produto != null) {
                _produtoService.Remover(produto);
                _repository.Remover(entity);
            }
        }
    }
}