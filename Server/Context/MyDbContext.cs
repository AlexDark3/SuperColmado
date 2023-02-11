using Microsoft.EntityFrameworkCore;
using SUPERCOLMADO.Server.Models;

namespace SUPERCOLMADO.Server.Context;

internal interface IMyDbContext
{
    DbSet<Usuario> Usuarios { get; set; }
    DbSet<UsuarioRol> UsuarioRoles { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
*
internal class MyDbContext : DbContext, IMyDbContext
{
    protected readonly IConfiguration _configuration;
    public MyDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(_configuration.GetConnectionString("SqlServerDB"));
    }
    #region     Tablas de la DB.
    public DbSet<Usuario> Usuarios { get; set; } = null!;
    public DbSet<UsuarioRol> UsuarioRoles { get; set; } = null!;
    #endregion

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}