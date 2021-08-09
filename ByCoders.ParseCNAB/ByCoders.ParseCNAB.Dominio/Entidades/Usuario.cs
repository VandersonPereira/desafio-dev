using ByCoders.ParseCNAB.Dominio.Compartilhado;
using ByCoders.ParseCNAB.Dominio.Compartilhado.Entidades;
using Flunt.Notifications;
using Flunt.Validations;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;

namespace ByCoders.ParseCNAB.Dominio.Entidades
{
    public class Usuario : EntidadeGenerica
    {
        protected Usuario() { }

        public Usuario(int id, string nome, string email, string senha) : base(id)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
        }

        public Usuario(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;

            AddNotifications(new Contract<Usuario>()
                .Requires()
                .IsGreaterThan(20, Nome.Length, "Nome", "O nome não pode ter mais do que 50 caracteres!")
                .IsGreaterThan(50, Email.Length, "Email", "O e-mail não pode ter mais do que 100 caracteres!")
                .IsEmail(Email, "Email")
                .IsGreaterThan(50, Senha.Length, "Senha", "A senha não pode ter mais do que 100 caracteres!"));
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }

        public bool Autenticar (string email, string senha)
        {
            if (Email == email && Senha == EncriptarSenha(senha))
                return true;

            AddNotification(new Notification("Usuário","Usuário ou senha inválidos"));

            return false;
        }

        private string EncriptarSenha(string senha)
        {
            if (string.IsNullOrEmpty(senha)) return "";

            senha = (senha += "|2d331cca-f6c0-40c0-bb43-6e32989c2881");

            var md5 = MD5.Create();
            var dados = md5.ComputeHash(Encoding.Default.GetBytes(senha));
            var sbString = new StringBuilder();

            foreach (var t in dados)
                sbString.Append(t.ToString("x2"));

            return sbString.ToString();
        }

        public string GerarToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuracoes.ChaveSecreta);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, Nome),
                    new Claim(ClaimTypes.Email, Email),
                    new Claim(ClaimTypes.NameIdentifier, Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public static string RecuperarValorClaim(IIdentity identity, string field)
        {
            var claims = identity as ClaimsIdentity;

            return claims.FindFirst(field).Value;
        }
    }
}
