using ByCoders.ParseCNAB.Dados.Transacoes;
using ByCoders.ParseCNAB.Dominio.Comandos.Entradas;
using ByCoders.ParseCNAB.Dominio.Comandos.Manipuladores;
using ByCoders.ParseCNAB.Dominio.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ByCoders.ParseCNAB.API.Controllers
{
    [Route("api")]
    public class MovimentacaoFinanceiraController : BaseController
    {
        private readonly IMovimentacaoFinanceiraRepositorio _repositorio;
        private readonly CriarMovimentacaoFinanceiraComandoManipulador _manipulador;
        private readonly ListarMovimentacaoFinanceiraComandoManipulador _manipuladorListagem;

        public MovimentacaoFinanceiraController(
            IMovimentacaoFinanceiraRepositorio repositorio,
            IUow uow,
            CriarMovimentacaoFinanceiraComandoManipulador manipulador,
             ListarMovimentacaoFinanceiraComandoManipulador manipuladorListagem)
            : base(uow)
        {
            _repositorio = repositorio;
            _manipulador = manipulador;
            _manipuladorListagem = manipuladorListagem;
        }


        [HttpPost, DisableRequestSizeLimit]
        [Route("v1/movimentacao-financeira/upload-arquivo")]
        public async Task<IActionResult> EntradaPorArquivo()
        {
            var resultado = _manipulador.ManipularArquivo(new CriarMovimentacaoFinanceiraArquivoComando { Arquivo = Request.Form.Files[0] });
            return await Resposta(resultado, _manipulador.Notifications);
        }

        // GET: MovimentacaoFinanceiraController/Details/5
        [HttpGet]
        [Route("v1/movimentacao-financeira")]
        public async Task<IActionResult> Listar()
        {
            var resultado = _manipuladorListagem.Manipular(null);
            return await Resposta(resultado, _manipulador.Notifications);
        }

        // GET: MovimentacaoFinanceiraController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        // POST: MovimentacaoFinanceiraController/v1/adicionar
        // TODO: VERIRICAR SE DEVE USAR MovimentacaoFinanceiraComando OU CRIAR UM RegistroMovimentacaoFinanceiraComando
        [HttpPost]
        [Route("v1/adicionar")]
        public async Task<IActionResult> Adicionar([FromBody] CriarMovimentacaoFinanceiraComando comando)
        {
            var resultado = _manipulador.Manipular(comando);
            return await Resposta(resultado, _manipulador.Notifications);
        }

        // POST: MovimentacaoFinanceiraController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: MovimentacaoFinanceiraController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
