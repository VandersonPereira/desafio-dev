using ByCoders.ParseCNAB.Dominio.Comandos.Entradas;
using ByCoders.ParseCNAB.Dominio.Comandos.Resultados;
using ByCoders.ParseCNAB.Dominio.Compartilhado.Comandos;
using ByCoders.ParseCNAB.Dominio.Entidades;
using ByCoders.ParseCNAB.Dominio.ObjetosDeValor;
using ByCoders.ParseCNAB.Dominio.Repositorios;
using Flunt.Notifications;
using System;
using System.Collections.Generic;

namespace ByCoders.ParseCNAB.Dominio.Comandos.Manipuladores
{
    public class ListarMovimentacaoFinanceiraComandoManipulador : Notifiable<Notification>, IComandoManipulador<ListarMovimentacaoFinanceiraComando>
    {
        private readonly IMovimentacaoFinanceiraRepositorio _repositorio;

        public ListarMovimentacaoFinanceiraComandoManipulador(IMovimentacaoFinanceiraRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IComandoResultado Manipular(ListarMovimentacaoFinanceiraComando comando)
        {
            try
            {
                var movimentacoesFinanceirasRetorno = new List<MovimentacaoFinanceiraResultado>();
                var movimentacoesFinanceiras = _repositorio.Listar();

                if (movimentacoesFinanceiras.Count > 0)
                {
                    foreach (var movimentacao in movimentacoesFinanceiras)
                    {
                        var movimentacaoFinanceiraResultado = new MovimentacaoFinanceiraResultado();
                        movimentacaoFinanceiraResultado.TipoTransacao = movimentacao.TipoTransacao.Descricao;
                        movimentacaoFinanceiraResultado.Natureza = movimentacao.TipoTransacao.Natureza;
                        movimentacaoFinanceiraResultado.DataOcorrencia = movimentacao.DataOcorrencia.Data;
                        movimentacaoFinanceiraResultado.Valor = movimentacao.Valor;
                        movimentacaoFinanceiraResultado.CPF = movimentacao.CPF;
                        movimentacaoFinanceiraResultado.Cartao = movimentacao.Cartao;
                        movimentacaoFinanceiraResultado.DonoLoja = movimentacao.DonoLoja;
                        movimentacaoFinanceiraResultado.NomeLoja = movimentacao.NomeLoja;

                        movimentacoesFinanceirasRetorno.Add(movimentacaoFinanceiraResultado);
                    }
                }
                var retorno = new ListarRegistroMovimentacaoFinanceiraComandoResultado
                {
                    Mensagem = "Sucesso ao consultar dados.",
                    Movimentacoes = movimentacoesFinanceirasRetorno
                };

                return retorno;
            }
            catch (Exception ex)
            {
                AddNotification(new Notification("Excessão", "Houve um erro interno."));
                return null;
            }
        }
    }
}
