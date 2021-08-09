using ByCoders.ParseCNAB.Dominio.Entidades;
using System.Collections.Generic;

namespace ByCoders.ParseCNAB.Dominio.Repositorios
{
    public interface IUsuarioRepositorio
    {
        Usuario RetornarPorEmail(string email);
    }
}
