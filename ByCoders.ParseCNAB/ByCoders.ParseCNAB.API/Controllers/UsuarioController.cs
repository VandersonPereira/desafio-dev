using ByCoders.ParseCNAB.Dados.Transacoes;
using ByCoders.ParseCNAB.Dominio.Comandos.Entradas;
using ByCoders.ParseCNAB.Dominio.Comandos.Manipuladores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ByCoders.ParseCNAB.API.Controllers
{
    [Route("api")]
    [Authorize]
    public class UsuarioController : BaseController
    {
        private readonly LoginMovimentacaoFinanceiraComandoManipulador _manipuladorLogin;

        public UsuarioController(IUow uow, LoginMovimentacaoFinanceiraComandoManipulador manipuladorLogin) 
            : base(uow)
        {
            _manipuladorLogin = manipuladorLogin;
        }

        // POST: v1/usuario/login
        [HttpPost]
        [Route("v1/usuario/login")]
        [AllowAnonymous]
        public async Task<IActionResult> Adicionar([FromBody] LoginMovimentacaoFinanceiraComando comando)
        {
            var resultado = _manipuladorLogin.Manipular(comando);
            return await Resposta(resultado, _manipuladorLogin.Notifications);
        }
    }
}
