using PortalTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalTest.Interface
{
    public interface IGitRepositorieRepository
    {
        Task<List<GitRepositorie>> Listar();
        Task<GitRepositorie> ListarById(long id);
        Task Salvar(GitRepositorie model);
    }
}
