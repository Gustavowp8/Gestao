using Gestao.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestao.Data
{
    public class GestaoContext : DbContext
    {
        public GestaoContext(DbContextOptions<GestaoContext> options) : base(options) { }

        public DbSet<SalasModel> Salas { get; set; }
    }
}
