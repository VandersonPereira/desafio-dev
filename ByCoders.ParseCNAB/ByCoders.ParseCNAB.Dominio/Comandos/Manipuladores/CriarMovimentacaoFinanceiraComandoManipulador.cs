using ByCoders.ParseCNAB.Dominio.Comandos.Entradas;
using ByCoders.ParseCNAB.Dominio.Comandos.Resultados;
using ByCoders.ParseCNAB.Dominio.Compartilhado.Comandos;
using ByCoders.ParseCNAB.Dominio.Entidades;
using ByCoders.ParseCNAB.Dominio.ObjetosDeValor;
using ByCoders.ParseCNAB.Dominio.Repositorios;
using Flunt.Notifications;
using System;
using System.IO;
using System.Net.Http.Headers;

namespace ByCoders.ParseCNAB.Dominio.Comandos.Manipuladores
{
    public class CriarMovimentacaoFinanceiraComandoManipulador : Notifiable<Notification>, IComandoManipulador<CriarMovimentacaoFinanceiraComando>
    {
        private readonly IMovimentacaoFinanceiraRepositorio _repositorio;

        public CriarMovimentacaoFinanceiraComandoManipulador(IMovimentacaoFinanceiraRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IComandoResultado Manipular(CriarMovimentacaoFinanceiraComando comando)
        {
            try
            {
                var tipoTransacao = comando.TipoTransacaoId;
                var dataOcorrencia = new DataOcorrencia(DateTime.Now);
                var cpf = new CPF(comando.CPF);

                var movimentacaoFinanceira = new MovimentacaoFinanaceira(tipoTransacao, dataOcorrencia, comando.Valor, cpf, comando.Cartao, comando.DonoLoja, comando.NomeLoja);

                AddNotifications(movimentacaoFinanceira.Notifications);

                if (!IsValid)
                    return null;

                _repositorio.Salvar(movimentacaoFinanceira);

                return new CriarRegistroMovimentacaoFinanceiraComandoResultado("Dados salvos com sucesso!");
            }
            catch (Exception ex)
            {
                AddNotification(new Notification("Excessão", "Houve um erro interno."));
                return null;
            }
        }

        public IComandoResultado ManipularArquivo(CriarMovimentacaoFinanceiraArquivoComando comando)
        {
            try
            {
                #region Salvando arquivo no servidor
                var arquivo = comando.Arquivo;

                if (Path.GetExtension(comando.Arquivo.FileName) != ".txt")
                {
                    AddNotification(new Notification("Arquivo", "Extensão errada. Utlizar .txt"));
                    return null;
                }

                if (arquivo.Length <= 0)
                {
                    AddNotification(new Notification("Arquivo", "Houve um erro interno."));
                    return null;
                }

                var nomePasta = Path.Combine("Arquivos", "Movimentação Financeira");
                var nomePastaParaSalvar = Path.Combine(Directory.GetCurrentDirectory(), nomePasta);
                var nomeArquivo = ContentDispositionHeaderValue.Parse(arquivo.ContentDisposition).FileName.Trim('"');
                var caminhoCompleto = Path.Combine(nomePastaParaSalvar, nomeArquivo);
                var dbPath = Path.Combine(nomePasta, nomeArquivo);

                if (!Directory.Exists(nomePastaParaSalvar))
                    Directory.CreateDirectory(nomePastaParaSalvar);

                using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    arquivo.CopyTo(stream);
                }
                #endregion

                #region Processando o arquivo
                var linhasArquivo = File.ReadAllLines(caminhoCompleto);

                foreach (string linhaArquivo in linhasArquivo)
                {
                    var segundo = Convert.ToInt32(linhaArquivo.Substring(46, 2));
                    var minuto = Convert.ToInt32(linhaArquivo.Substring(44, 2));
                    var hora = Convert.ToInt32(linhaArquivo.Substring(42, 2));
                    var dia = Convert.ToInt32(linhaArquivo.Substring(7, 2));
                    var mes = Convert.ToInt32(linhaArquivo.Substring(5, 2));
                    var ano = Convert.ToInt32(linhaArquivo.Substring(1, 4));

                    var tipoTransacaoId = Convert.ToInt32(linhaArquivo.Substring(0, 1));
                    var dataOcorrencia = new DataOcorrencia(segundo, minuto, hora, dia, mes, ano);
                    var valor = Convert.ToDecimal(linhaArquivo.Substring(9, 9)) / 100;
                    var cpf = new CPF (linhaArquivo.Substring(19, 11));
                    var cartao = linhaArquivo.Substring(30, 12);
                    var donoLoja = linhaArquivo.Substring(48, 14).Trim();
                    var nomeLoja = linhaArquivo.Substring(62).Trim();

                    var movimentacaoFinanceira = new MovimentacaoFinanaceira(tipoTransacaoId, dataOcorrencia, valor, cpf, cartao, donoLoja, nomeLoja);

                    AddNotifications(dataOcorrencia.Notifications);

                    if (!IsValid)
                        return null;

                    _repositorio.Salvar(movimentacaoFinanceira);
                }

                return new CriarRegistroMovimentacaoFinanceiraComandoResultado("Dados salvos com sucesso!");
                #endregion
            }
            catch (Exception ex)
            {
                AddNotification(new Notification("Excessão", "Houve um erro interno."));
                return null;
            }
        }
    }
}
