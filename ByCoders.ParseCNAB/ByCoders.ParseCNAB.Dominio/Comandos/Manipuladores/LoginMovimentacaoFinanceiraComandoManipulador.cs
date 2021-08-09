using ByCoders.ParseCNAB.Dominio.Comandos.Entradas;
using ByCoders.ParseCNAB.Dominio.Comandos.Resultados;
using ByCoders.ParseCNAB.Dominio.Compartilhado.Comandos;
using ByCoders.ParseCNAB.Dominio.Repositorios;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace ByCoders.ParseCNAB.Dominio.Comandos.Manipuladores
{
    public class LoginMovimentacaoFinanceiraComandoManipulador : Notifiable<Notification>, IComandoManipulador<LoginMovimentacaoFinanceiraComando>
    {
        private readonly IUsuarioRepositorio _repositorio;

        public LoginMovimentacaoFinanceiraComandoManipulador(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IComandoResultado Manipular(LoginMovimentacaoFinanceiraComando comando)
        {
            if (string.IsNullOrEmpty(comando.Email))
            {
                AddNotification(new Notification("Email", "O E-mail é obrigatório!"));
                return null;
            }

            if (string.IsNullOrEmpty(comando.Senha))
            {
                AddNotification(new Notification("Senha", "A senha é obrigatória!"));
                return null;
            }

            var usuario = _repositorio.RetornarPorEmail(comando.Email);
            if (usuario == null)
            {
                AddNotification(new Notification("Usuário", "Usuário não encontrado!"));
                return null;
            }

            var autenticado = usuario.Autenticar(comando.Email, comando.Senha);
            if (!autenticado)
            {
                AddNotification(new Notification("Usuário", "Usuário ou senha incorretos!"));
                return null;
            }

            var token = usuario.GerarToken();

            return new LoginMovimentacaoFinanceiraComandoResultado (usuario.Nome, token, "Login realizado com sucesso!");
        }
    }
}
