using ByCoders.ParseCNAB.Dominio.Compartilhado.Comandos;
using Microsoft.AspNetCore.Http;

namespace ByCoders.ParseCNAB.Dominio.Comandos.Entradas
{
    public class CriarMovimentacaoFinanceiraArquivoComando : IComando
    {
        // INFORMAÇÕES QUE CHEGARAM PELA CONTROLLER E SERÃO ENCAMINHADAS PARA O MANIPULADOR
        public IFormFile Arquivo { get; set; }
    }
}
