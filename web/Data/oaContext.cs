using web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace web.Data
{
public class oaContext : IdentityDbContext<ApplicationUser>
    {
    public oaContext(DbContextOptions<oaContext> options) : base(options)
    {
    }
    public DbSet<UporabniskiRacun> UporabniskiRacuni { get; set; }
    public DbSet<ObjavaIscemOa> ObjaveIscemOa { get; set; }
    public DbSet<ObjavaNudimOa> ObjaveNudimOa { get; set; }
    public DbSet<NudimNadomescanje> NudimNadomescanje { get; set; }
    public DbSet<IscemNadomescanje> IscemNadomescanje { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<UporabniskiRacun>().ToTable("UporabniskiRacun");
        modelBuilder.Entity<ObjavaIscemOa>().ToTable("ObjavaIscemOa");
        modelBuilder.Entity<ObjavaNudimOa>().ToTable("ObjavaNudimOa");
        modelBuilder.Entity<NudimNadomescanje>().ToTable("NudimNadomescanje");
        modelBuilder.Entity<IscemNadomescanje>().ToTable("IscemNadomescanje");
    }

    
}
}