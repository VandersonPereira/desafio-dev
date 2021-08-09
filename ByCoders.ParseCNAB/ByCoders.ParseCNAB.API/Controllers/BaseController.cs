using ByCoders.ParseCNAB.Dados.Transacoes;
using Flunt.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ByCoders.ParseCNAB.API.Controllers
{
    public class BaseController : Controller
    {
        private readonly IUow _uow;

        public BaseController(IUow uow)
        {
            _uow = uow;
        }

        [NonAction]
        public async Task<IActionResult> Resposta(object resultado, IEnumerable<Notification> notificaoes)
        {
            if (!notificaoes.Any() && (resultado == null || resultado != null))
            {
                try
                {
                    _uow.Commit();

                    return await Task.Run(() => Ok(new
                    {
                        sucesso = true,
                        dados = resultado
                    }));
                }
                catch (Exception)
                {
                    return await Task.Run(() => StatusCode(StatusCodes.Status500InternalServerError, new
                    {
                        sucesso = false,
                        erros = new[] { "Ocorreu um erro no servidor!" }
                    }));
                }
            }
            else
            {
                return await Task.Run(() => BadRequest(new
                {
                    sucesso = false,
                    erros = notificaoes
                }));
            }
        }
    }
}
