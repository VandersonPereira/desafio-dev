using ByCoders.ParseCNAB.Dominio.Compartilhado.Comandos;
using Microsoft.AspNetCore.Http;

namespace ByCoders.ParseCNAB.Dominio.Comandos.Entradas
{
    public class CriarMovimentacaoFinanceiraArquivoComando : IComando
    {
        public IFormFile Arquivo { get; set; }
    }
}
