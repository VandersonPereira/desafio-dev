using ByCoders.ParseCNAB.Dados.Transacoes;
using ByCoders.ParseCNAB.Dominio.Comandos.Entradas;
using ByCoders.ParseCNAB.Dominio.Comandos.Manipuladores;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ByCoders.ParseCNAB.API.Controllers
{
    [Route("api")]
    public class MovimentacaoFinanceiraController : BaseController
    {
        private readonly CriarMovimentacaoFinanceiraComandoManipulador _manipulador;
        private readonly ListarMovimentacaoFinanceiraComandoManipulador _manipuladorListagem;

        public MovimentacaoFinanceiraController(
            IUow uow,
            CriarMovimentacaoFinanceiraComandoManipulador manipulador,
             ListarMovimentacaoFinanceiraComandoManipulador manipuladorListagem)
            : base(uow)
        {
            _manipulador = manipulador;
            _manipuladorListagem = manipuladorListagem;
        }

        // POST: v1/movimentacao-financeira/upload-arquivo
        [HttpPost, DisableRequestSizeLimit]
        [Route("v1/movimentacao-financeira/upload-arquivo")]
        public async Task<IActionResult> EntradaPorArquivo()
        {
            var resultado = _manipulador.ManipularArquivo(new CriarMovimentacaoFinanceiraArquivoComando { Arquivo = Request.Form.Files[0] });
            return await Resposta(resultado, _manipulador.Notifications);
        }

        // GET: v1/movimentacao-financeira
        [HttpGet]
        [Route("v1/movimentacao-financeira")]
        public async Task<IActionResult> Listar()
        {
            var resultado = _manipuladorListagem.Manipular(null);
            return await Resposta(resultado, _manipulador.Notifications);
        }

        // POST: v1/movimentacao-financeira/adicionar
        [HttpPost]
        [Route("v1/movimentacao-financeira/adicionar")]
        public async Task<IActionResult> Adicionar([FromBody] CriarMovimentacaoFinanceiraComando comando)
        {
            var resultado = _manipulador.Manipular(comando);
            return await Resposta(resultado, _manipulador.Notifications);
        }
    }
}
