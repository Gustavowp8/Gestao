using Gestao.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gestao.Data
{
    public class GestaoContext : IdentityDbContext
    {
        public GestaoContext(DbContextOptions<GestaoContext> options) : base(options) { }

        public DbSet<SalasModel> Salas { get; set; }
    }
}
