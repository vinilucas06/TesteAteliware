using Microsoft.EntityFrameworkCore;
using PortalTest.Data;
using PortalTest.Interface;
using PortalTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalTest.Infrastructure
{
    public class GitRepositorieRepository : IGitRepositorieRepository
    {
        private readonly TesteContext _context;

        public GitRepositorieRepository(TesteContext context)
        {
            _context = context;
        }

        public async Task<List<GitRepositorie>> Listar()
        {
            return await _context.GitRepositorie.ToListAsync();
        }

        public async Task<GitRepositorie> ListarById(long id)
        {
            return await _context.GitRepositorie
               .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Salvar(GitRepositorie model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();
        }
    }
}
