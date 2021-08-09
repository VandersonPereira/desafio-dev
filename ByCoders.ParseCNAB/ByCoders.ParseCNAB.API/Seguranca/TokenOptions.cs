using Microsoft.IdentityModel.Tokens;
using System;
using System.Threading.Tasks;

namespace ByCoders.ParseCNAB.API.Seguranca
{
    public class TokenOptions
    {
        public string Solicitante { get; set; }

        public string Assunto { get; set; }

        public string Recebedor { get; set; }

        public DateTime NaoAntesQue { get; set; } = DateTime.UtcNow;

        public DateTime DataSolicitacao { get; set; } = DateTime.UtcNow;

        public TimeSpan ValidoAte { get; set; } = TimeSpan.FromDays(2);

        public DateTime Expiracao => DataSolicitacao.Add(ValidoAte);

        public Func<Task<string>> GeradorJti =>
          () => Task.FromResult(Guid.NewGuid().ToString());

        public SigningCredentials AssinarCredenciais { get; set; }
    }
}
