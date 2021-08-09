using ByCoders.ParseCNAB.Dados.Contextos;
using ByCoders.ParseCNAB.Dominio.Entidades;
using ByCoders.ParseCNAB.Dominio.Repositorios;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ByCoders.ParseCNAB.Dados.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly MovimentacaoFinanceiraContexto _contexto;

        public UsuarioRepositorio(MovimentacaoFinanceiraContexto contexto)
        {
            _contexto = contexto;
        }

        public Usuario RetornarPorEmail(string email)
        {
            return _contexto.Usuarios
                .AsNoTracking()
                .Where(x => x.Email.ToUpper() == email.ToUpper())
                .FirstOrDefault();
        }
    }
}
